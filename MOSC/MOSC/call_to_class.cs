using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;

namespace MOSK
{
    partial class call_to_class : ServiceBase
    {
        public call_to_class()
        {
            InitializeComponent();
        }

        protected override void OnStart(string[] args)
        {
            // TODO: Добавьте код для запуска службы.
        }

        protected override void OnStop()
        {
            // TODO: Добавьте код, выполняющий подготовку к остановке службы.
        }
    }
}
