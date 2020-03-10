using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MOSC
{
    class ServiceController
    {
        static System.ServiceProcess.ServiceController service = new System.ServiceProcess.ServiceController("ServiceVPT");

        public static bool GetStatus()
        {
            if(service.Status == System.ServiceProcess.ServiceControllerStatus.Running)
            {
                return true;
            }
            else
            {
                return false;
            }
            
        }

        /// <summary>
        /// Остановить службу
        /// </summary>
        public static void ServiceStop()
        {
            service.Stop();
        }


        /// <summary>
        /// Запустить службу
        /// </summary>
        public static void ServiceStart()
        {
            service.Start();
        }

        /// <summary>
        /// Проверить наличие службы
        /// </summary>
        /// <returns></returns>
        public static bool CheckAvailability()
        {
            System.ServiceProcess.ServiceController servCheck = System.ServiceProcess.ServiceController.GetServices().FirstOrDefault(s => s.ServiceName == "ServiceVPT");
            if (servCheck != null) return true;
            else return false;
        }
    }
}
