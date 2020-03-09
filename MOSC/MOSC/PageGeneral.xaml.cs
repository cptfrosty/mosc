using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace VPT_CALL_TO_CLASS
{
    /// <summary>
    /// Логика взаимодействия для PageGeneral.xaml
    /// </summary>
    public partial class PageGeneral : Page
    {
        System.ServiceProcess.ServiceController service = new System.ServiceProcess.ServiceController("ServiceVPT");



        public PageGeneral()
        {
            InitializeComponent();
            LoadPageInfo();
            LoadAndSetTime();
        }

        /// <summary>
        /// Смотрит время на компе и устанавливает его
        /// </summary>
        void LoadAndSetTime()
        {
            var timer = new System.Windows.Threading.DispatcherTimer();
            timer.Interval = new TimeSpan(0, 0, 1);
            timer.IsEnabled = true;
            timer.Tick += (o, e) => { timeNow.Text = "Время сейчас: " + DateTime.Now.ToString(); };
            timer.Start();
        }

        /// <summary>
        /// Остановить службу
        /// </summary>
        void ServiceStop()
        {
            service.Stop();
            infoService.Foreground = Brushes.Red;
            infoService.Text = "Служба не работает";
            btnRunService.IsEnabled = true;

        }

        void ServiceStart()
        {
            service.Start();
            infoService.Foreground = Brushes.Green;
            infoService.Text = "Служба работает";
            btnOffService.IsEnabled = true;
        }

        /// <summary>
        /// Загружает информацию о странице и службе
        /// </summary>
        public void LoadPageInfo()
        {
            System.ServiceProcess.ServiceController servCheck = System.ServiceProcess.ServiceController.GetServices().FirstOrDefault(s => s.ServiceName == "ServiceVPT");
            if (servCheck != null)
            {

                //Если служба остановлена, то передаём глобальное значение
                if (service.Status == System.ServiceProcess.ServiceControllerStatus.Stopped)
                {
                    GlobalSetting.isService = false;
                }
                else if (service.Status == System.ServiceProcess.ServiceControllerStatus.Running)
                {
                    GlobalSetting.isService = true;
                }

                //Если служба существует, то отобразить о ней информацию
                SetPageInfo();
            }
            else
            {
                infoService.Foreground = Brushes.Red;
                infoService.Text = "Служба отсутствует";
                btnOffService.IsEnabled = false;
                btnRunService.IsEnabled = false;
                typeSchedule.Visibility = Visibility.Hidden;
            }

            
        }

        /// <summary>
        /// Устанавливает значение на главное странице
        /// </summary>
        public void SetPageInfo()
        {
            //Если служба работает
            if (service.Status == System.ServiceProcess.ServiceControllerStatus.Running)
            {
                infoService.Foreground = Brushes.Green;
                infoService.Text = "Служба работает";

                btnOffService.IsEnabled = true;
                btnRunService.IsEnabled = false;
            }
            //Если служба не работает
            else
            {
                infoService.Foreground = Brushes.Red;
                infoService.Text = "Служба не работает";
                btnOffService.IsEnabled = false;
                btnRunService.IsEnabled = true;
            }
        }

        /// <summary>
        /// Остановка службы
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnOffService_Click(object sender, RoutedEventArgs e)
        {
            btnOffService.IsEnabled = false;
            btnRunService.IsEnabled = false;
            ServiceStop(); 
        }

        /// <summary>
        /// Запуск службы
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnRunService_Click(object sender, RoutedEventArgs e)
        {
            btnOffService.IsEnabled = false;
            btnRunService.IsEnabled = false;
            ServiceStart();
        }
    }
}
