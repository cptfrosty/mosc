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
    /// Логика взаимодействия для PageTask.xaml
    /// </summary>
    public partial class PageTask : Page
    {
        public PageTask()
        {
            InitializeComponent();
        }

        private void btnAddTask_Click(object sender, RoutedEventArgs e)
        {
            GlobalSetting.AddTask(
                nameTask.Text, typeTask.SelectedIndex, 
                typeSound.SelectedIndex, int.Parse(tbDay.Text), 
                int.Parse(tbMounth.Text), int.Parse(tbYear.Text), 
                int.Parse(tbHour.Text), int.Parse(tbMinutes.Text));
        }
    }
}
