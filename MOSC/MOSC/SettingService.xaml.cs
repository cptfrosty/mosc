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
using System.Windows.Shapes;

namespace VPT_CALL_TO_CLASS
{
    /// <summary>
    /// Логика взаимодействия для SettingService.xaml
    /// </summary>
    public partial class SettingService : Window
    {
        public SettingService()
        {
            InitializeComponent();
            Schedule.ParseXML();
        }

        private void btnGeneral_Click(object sender, RoutedEventArgs e)
        {
            pageContent.NavigationService.RemoveBackEntry();
            PageGeneral pageGeneral = new PageGeneral();
            pageContent.Content = pageGeneral;
        }

        private void btnSchedule_Click(object sender, RoutedEventArgs e)
        {
            pageContent.NavigationService.RemoveBackEntry();
            PageSettingSchedule pageSchedule = new PageSettingSchedule();
            pageContent.Content = pageSchedule;
        }

        private void btnTask_Click(object sender, RoutedEventArgs e)
        {
            pageContent.NavigationService.RemoveBackEntry();
            PageTask pageTask = new PageTask();
            pageContent.Content = pageTask;
        }
    }
}
