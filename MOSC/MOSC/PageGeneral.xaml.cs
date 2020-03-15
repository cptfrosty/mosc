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

namespace MOSC
{
    /// <summary>
    /// Логика взаимодействия для PageGeneral.xaml
    /// </summary>
    public partial class PageGeneral : Page
    {
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
            timer.Tick += (o, e) => {
                timeNow.Text = "Время сейчас: " + DateTime.Now.ToString();
                //sheduleNext.Text = Schedule.NextCall.Hour + " : " + Schedule.NextCall.Minute;
            };
            timer.Start();
        }

        /// <summary>
        /// Загружает информацию о странице и службе
        /// </summary>
        public void LoadPageInfo()
        {

            if (ServiceController.CheckAvailability())
            {
                MessageBox.Show(ServiceController.GetStatus().ToString());
                //Если служба остановлена, то передаём глобальное значение
                if (!ServiceController.GetStatus())
                {
                    GlobalSetting.isService = false;
                }
                else if (ServiceController.GetStatus())
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
            if (GlobalSetting.isService)
            {
                infoService.Foreground = Brushes.Green;
                infoService.Text = "Служба работает";

                btnOffService.IsEnabled = true;
                btnRunService.IsEnabled = false;

                SettingService.mainPage.btnSchedule.IsEnabled = false;
                SettingService.mainPage.btnTask.IsEnabled = false;
                SettingService.mainPage.btnResources.IsEnabled = false;

            }
            //Если служба не работает
            else
            {
                infoService.Foreground = Brushes.Red;
                infoService.Text = "Служба не работает";
                btnOffService.IsEnabled = false;
                btnRunService.IsEnabled = true;

                SettingService.mainPage.btnSchedule.IsEnabled = true;
                SettingService.mainPage.btnTask.IsEnabled = true;
                SettingService.mainPage.btnResources.IsEnabled = true;
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

            infoService.Foreground = Brushes.Red;
            infoService.Text = "Служба не работает";
            btnRunService.IsEnabled = true;

            SettingService.mainPage.btnSchedule.IsEnabled = true;
            SettingService.mainPage.btnTask.IsEnabled = true;
            SettingService.mainPage.btnResources.IsEnabled = true;

            ServiceController.ServiceStop();
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

            infoService.Foreground = Brushes.Green;
            infoService.Text = "Служба работает";
            btnOffService.IsEnabled = true;

            SettingService.mainPage.btnSchedule.IsEnabled = false;
            SettingService.mainPage.btnTask.IsEnabled = false;
            SettingService.mainPage.btnResources.IsEnabled = false;

            ServiceController.ServiceStart();
        }
    }
}
