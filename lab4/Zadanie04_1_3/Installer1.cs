using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration.Install;
using System.Linq;
using System.ServiceProcess;
using System.Threading.Tasks;

namespace Zadanie04_1_3
{
    [RunInstaller(true)]
    public partial class Installer1 : System.Configuration.Install.Installer
    {
        public Installer1()
        {
            var processInstaller = new ServiceProcessInstaller();
            var serviceInstaller = new ServiceInstaller();

            processInstaller.Account = ServiceAccount.LocalSystem;

            // Parametry widoczne w services.msc
            serviceInstaller.ServiceName = "Zadanie04_1_3";
            serviceInstaller.DisplayName = "Udostępnianie Zadanie04_1_3";
            serviceInstaller.Description = "Dodawanie liczb.";
            serviceInstaller.StartType = ServiceStartMode.Automatic;

            Installers.Add(processInstaller);
            Installers.Add(serviceInstaller);
        }
    }
}
