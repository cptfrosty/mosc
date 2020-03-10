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
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public static bool isPause = false;
        public MainWindow()
        {
            InitializeComponent();
        }

        //Проверка правильности заполнения. Проверяется каждый клик по клавише
        private void CheckForCorrectValues(object sender, TextCompositionEventArgs e)
        {
            //(sender as TextBox).Text.Length >= 2 ограничение на 2 символа в textbox
            if (!Char.IsDigit(e.Text, 0) || (sender as TextBox).Text.Length >= 2) e.Handled = true;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }

        private void SaveDefaultTime(object sender, RoutedEventArgs e)
        {
            ErrorShow.Foreground = Brushes.Red;

            TextBox[] textBox = new TextBox[]
            {
                Pairs0Hours, Pairs0Minutes,
                Pairs1Hours, Pairs1Minutes,
                Pairs2Hours, Pairs2Minutes,
                Pairs3Hours, Pairs3Minutes,
                Pairs4Hours, Pairs4Minutes,
                Pairs5Hours, Pairs5Minutes,
                Pairs6Hours, Pairs6Minutes,
                Pairs7Hours, Pairs7Minutes,
            };

            //Проверка часового формата
            bool isError = false;
            bool isEmpty = false;
            int hours = 0;
            int minutes = 0;
            for(int i = 0; i < textBox.Length; i=i+2)
            {
                isEmpty = int.TryParse(textBox[i].Text,out hours);

                //Проверка на заполнение часов
                if (!isEmpty)
                {
                    ErrorShow.Text = "Вы не указали часы";
                    isError = true;
                    break;
                }

                if (hours > 24)
                {
                    ErrorShow.Text = "Сохранение не удалось. Не верный часовой формат";
                    isError = true;
                    break;
                }
            }

            if(!isError)
            {
                ErrorShow.Text = "";
            }

            //Проверка минутного формата
            for (int i = 1; i < textBox.Length; i = i + 2)
            {
                isEmpty = int.TryParse(textBox[i].Text, out minutes);

                if (!isEmpty)
                {
                    ErrorShow.Text = "Вы не указали минуты";
                    isError = true;
                    break;
                }

                //Проверка на заполнение минут
                if (minutes > 60)
                {
                    if (isError) ErrorShow.Text = "Сохранение не удалось. Не верный часовой формат и минутный";
                    ErrorShow.Text = "Сохранение не удалось. Не верный минутный формат";
                    isError = true;
                    break;
                }
            }

            //ErrorShow.Text = "ErrorShow: " + isError;

            if (!isError)
            {
                ErrorShow.Foreground = Brushes.Green;
                ErrorShow.Text = "Сохранение прошло успешно";
            }
        }
    }
}
