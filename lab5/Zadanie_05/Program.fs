module TaskQueue

open System
open System.Threading

type Priority = Low | Normal | High

type TaskMsg =
    | Submit  of Task                          
    | Cancel  of Guid                         
    | Status  of AsyncReplyChannel<AgentStatus> 
    | Pause                                   
    | Resume                                  
    | Shutdown of AsyncReplyChannel<unit>      

and Task = {
    Id       : Guid
    Name     : string
    Priority : Priority
    Work     : unit -> Result<string, string>  
}

and AgentStatus = {
    Queued    : int
    Completed : int
    Failed    : int
    Cancelled : int
    Paused    : bool
    Current   : string option                  
}

type private AgentState = {
    Queue     : Task list          
    Completed : int
    Failed    : int
    Cancelled : int
    Paused    : bool
    Current   : string option
    Cancelled_ids : Set<Guid>
}

let private empty = {
    Queue        = []
    Completed    = 0
    Failed       = 0
    Cancelled    = 0
    Paused       = false
    Current      = None
    Cancelled_ids= Set.empty
}

let private priorityWeight = function High -> 0 | Normal -> 1 | Low -> 2

let private insertByPriority task queue =
    queue @ [task]
    |> List.sortBy (fun t -> priorityWeight t.Priority)

let private timestamp () =
    DateTime.Now.ToString("HH:mm:ss.fff")

let private log (color: ConsoleColor) (prefix: string) (msg: string) =
    let prev = Console.ForegroundColor
    Console.ForegroundColor <- color
    printfn "[%s] [%s] %s" (timestamp()) prefix msg
    Console.ForegroundColor <- prev

let logInfo  = log ConsoleColor.Cyan    "INFO   "
let logOk    = log ConsoleColor.Green   "OK     "
let logWarn  = log ConsoleColor.Yellow  "WARN   "
let logError = log ConsoleColor.Red     "ERROR  "
let logAgent = log ConsoleColor.Magenta "AGENT  "

let createAgent () =

    MailboxProcessor<TaskMsg>.Start(fun inbox ->

        let rec loop (state: AgentState) = async {
            let state =
                if state.Paused || state.Queue.IsEmpty then state
                else
                    let task = state.Queue.Head
                    let rest = state.Queue.Tail

                    if state.Cancelled_ids.Contains task.Id then
                        logWarn (sprintf "Zadanie '%s' pominięte (anulowane)" task.Name)
                        { state with Queue = rest
                                     Cancelled_ids = state.Cancelled_ids.Remove task.Id }
                    else
                        logAgent (sprintf "▶ Rozpoczynam: '%s' [%A]" task.Name task.Priority)
                        let state' = { state with Queue = rest; Current = Some task.Name }

                        let result = try task.Work() with ex -> Error ex.Message

                        match result with
                        | Ok msg ->
                            logOk (sprintf "✔ '%s' zakończone: %s" task.Name msg)
                            { state' with Completed = state'.Completed + 1; Current = None }
                        | Error err ->
                            logError (sprintf "✘ '%s' błąd: %s" task.Name err)
                            { state' with Failed = state'.Failed + 1; Current = None }

            let! msg = inbox.Receive()

            match msg with
            | Submit task ->
                logInfo (sprintf "➕ Zgłoszono: '%s' [%A]" task.Name task.Priority)
                let queue' = insertByPriority task state.Queue
                return! loop { state with Queue = queue' }

            | Cancel id ->
                if state.Queue |> List.exists (fun t -> t.Id = id) then
                    logWarn (sprintf "⊘ Anulowanie zadania %s" (id.ToString("N")))
                    return! loop { state with
                                    Queue         = state.Queue |> List.filter (fun t -> t.Id <> id)
                                    Cancelled     = state.Cancelled + 1 }
                else
                    logWarn (sprintf "⊘ Zadanie %s nieznane lub w trakcie – oznaczam" (id.ToString("N")))
                    return! loop { state with
                                    Cancelled_ids = state.Cancelled_ids.Add id
                                    Cancelled     = state.Cancelled + 1 }

            | Status reply ->
                reply.Reply {
                    Queued    = state.Queue.Length
                    Completed = state.Completed
                    Failed    = state.Failed
                    Cancelled = state.Cancelled
                    Paused    = state.Paused
                    Current   = state.Current
                }
                return! loop state

            | Pause ->
                logWarn "⏸ Agent wstrzymany"
                return! loop { state with Paused = true }

            | Resume ->
                logInfo "▶ Agent wznowiony"
                return! loop { state with Paused = false }

            | Shutdown reply ->
                logAgent (sprintf "🛑 Shutdown. Zrealizowane: %d  Błędy: %d  Anulowane: %d"
                            state.Completed state.Failed state.Cancelled)
                reply.Reply ()
        }

        loop empty
    )

let makeTask name priority (work: unit -> Result<string,string>) =
    { Id = Guid.NewGuid(); Name = name; Priority = priority; Work = work }

[<EntryPoint>]
let main _ =
    logInfo "=== System kolejkowania zadań (MailboxProcessor) ==="

    let agent = createAgent ()

    agent.Post(Submit (makeTask "Raport miesięczny" Normal (fun () ->
        Thread.Sleep 300
        Ok "Raport wygenerowany (42 strony)")))

    agent.Post(Submit (makeTask "Backup bazy danych" High (fun () ->
        Thread.Sleep 500
        Ok "Backup zapisany: backup_2026.tar.gz")))

    agent.Post(Submit (makeTask "Wysyłka e-maili" Low (fun () ->
        Thread.Sleep 200
        Ok "Wysłano 1 337 wiadomości")))

    agent.Post(Submit (makeTask "Optymalizacja indeksów" Normal (fun () ->
        Thread.Sleep 400
        Ok "Zoptymalizowano 7 indeksów")))

    agent.Post(Submit (makeTask "Import danych (błędny plik)" Low (fun () ->
        Thread.Sleep 100
        Error "Nieprawidłowy format CSV w wierszu 17")))

    let urgentId = Guid.NewGuid()
    agent.Post(Submit {
        Id       = urgentId
        Name     = "Pilne: certyfikat SSL"
        Priority = High
        Work     = fun () ->
            Thread.Sleep 150
            Ok "Certyfikat odnowiony, ważny 365 dni" })

    let cancelId = Guid.NewGuid()
    agent.Post(Submit { Id = cancelId; Name = "Zadanie do anulowania"; Priority = Low
                        Work = fun () -> Ok "Tego nie zobaczymy" })
    agent.Post(Cancel cancelId)

    Thread.Sleep 800
    agent.Post Pause
    logWarn "  (agent wstrzymany – czekamy 400 ms)"
    Thread.Sleep 400
    agent.Post Resume

    Thread.Sleep 200
    let status = agent.PostAndReply Status
    printfn ""
    logInfo (sprintf "📊 Status: w kolejce=%d  zrealizowane=%d  błędy=%d  anulowane=%d  pauza=%b"
                status.Queued status.Completed status.Failed status.Cancelled status.Paused)
    match status.Current with
    | Some name -> logInfo (sprintf "   Aktualnie: '%s'" name)
    | None      -> ()
    printfn ""

    Thread.Sleep 1500
    agent.PostAndReply Shutdown

    logInfo "=== Koniec ==="
    0