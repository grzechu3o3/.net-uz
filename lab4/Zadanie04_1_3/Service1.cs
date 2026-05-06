using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;

namespace Zadanie04_1_3
{
    public partial class Service1 : ServiceBase
    {
        private ZadanieManager _manager;
        public Service1()
        {
            InitializeComponent();
            this.ServiceName = "Zadanie04_1_3";
        }

        protected override void OnStart(string[] args)
        {
            _manager = new ZadanieManager();
            Task.Run(() => _manager.Start());
        }

        protected override void OnStop()
        {
            _manager?.Stop();
        }
    }
}
