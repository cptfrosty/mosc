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
using System.IO;
using System.Xml.Linq;

namespace MOSC
{
    /// <summary>
    /// Логика взаимодействия для PageSettingSchedule.xaml
    /// </summary>
    public partial class PageSettingSchedule : Page
    {
        public PageSettingSchedule()
        {
            InitializeComponent();
            LoadToFileScheduleXML();
        }


        //Проверка правильности заполнения. Проверяется каждый клик по клавише
        private void CheckForCorrectValues(object sender, TextCompositionEventArgs e)
        {
            //(sender as TextBox).Text.Length >= 2 ограничение на 2 символа в textbox
            if (!Char.IsDigit(e.Text, 0) || (sender as TextBox).Text.Length >= 2) e.Handled = true;
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

                EndPairs0Hours, EndPairs0Minutes,
                EndPairs1Hours, EndPairs1Minutes,
                EndPairs2Hours, EndPairs2Minutes,
                EndPairs3Hours, EndPairs3Minutes,
                EndPairs4Hours, EndPairs4Minutes,
                EndPairs5Hours, EndPairs5Minutes,
                EndPairs6Hours, EndPairs6Minutes,
                EndPairs7Hours, EndPairs7Minutes,
            };

            //Проверка часового формата
            bool isError = false;
            bool isEmpty = false;
            int hours = 0;
            int minutes = 0;
            for (int i = 0; i < textBox.Length; i = i + 2)
            {
                isEmpty = int.TryParse(textBox[i].Text, out hours);

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

            if (!isError)
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
                SaveToFileScheduleXML();
            }
        }

        /// <summary>
        /// Создание структуры файла XML
        /// </summary>
        void SaveToFileScheduleXML()
        {
            /*XDocument xdoc = new XDocument();
            //Создание первого элемента
            XElement pair = new XElement(namePair);

            //Создание атрибутов
            XAttribute startScheduleAttr = new XAttribute("name", "Начало пары");
            XElement startHourElem = new XElement("Часы", startHourPair);
            XElement startMinuteElem = new XElement("Часы", startHourPair);

            XAttribute endScheduleAttr = new XAttribute("name", "Конец пары");
            XElement endHourElem = new XElement("Часы", endHourPair);
            XElement endMinuteElem = new XElement("Часы", endHourPair);*/

            XDocument xdoc = new XDocument(new XElement("Schedule",
                new XElement("pair",
                    new XAttribute("name", "Pair0"),
                    new XElement("StartHour", Pairs0Hours.Text),
                    new XElement("StartMinutes", Pairs0Minutes.Text),
                    new XElement("EndHour", EndPairs0Hours.Text),
                    new XElement("EndMinutes", EndPairs0Minutes.Text)),

                new XElement("pair",
                    new XAttribute("name", "Pair1"),
                    new XElement("StartHour", Pairs1Hours.Text),
                    new XElement("StartMinutes", Pairs1Minutes.Text),
                    new XElement("EndHour", EndPairs1Hours.Text),
                    new XElement("EndMinutes", EndPairs1Minutes.Text)),

                new XElement("pair",
                    new XAttribute("name", "Pair2"),
                    new XElement("StartHour", Pairs2Hours.Text),
                    new XElement("StartMinutes", Pairs2Minutes.Text),
                    new XElement("EndHour", EndPairs2Hours.Text),
                    new XElement("EndMinutes", EndPairs2Minutes.Text)),

                new XElement("pair",
                    new XAttribute("name", "Pair3"),
                    new XElement("StartHour", Pairs3Hours.Text),
                    new XElement("StartMinutes", Pairs3Minutes.Text),
                    new XElement("EndHour", EndPairs3Hours.Text),
                    new XElement("EndMinutes", EndPairs3Minutes.Text)),

                new XElement("pair",
                    new XAttribute("name", "Pair4"),
                    new XElement("StartHour", Pairs4Hours.Text),
                    new XElement("StartMinutes", Pairs4Minutes.Text),
                    new XElement("EndHour", EndPairs4Hours.Text),
                    new XElement("EndMinutes", EndPairs4Minutes.Text)),

                new XElement("pair",
                    new XAttribute("name", "Pair5"),
                    new XElement("StartHour", Pairs5Hours.Text),
                    new XElement("StartMinutes", Pairs5Minutes.Text),
                    new XElement("EndHour", EndPairs5Hours.Text),
                    new XElement("EndMinutes", EndPairs5Minutes.Text)),

                new XElement("pair",
                    new XAttribute("name", "Pair6"),
                    new XElement("StartHour", Pairs6Hours.Text),
                    new XElement("StartMinutes", Pairs6Minutes.Text),
                    new XElement("EndHour", EndPairs6Hours.Text),
                    new XElement("EndMinutes", EndPairs6Minutes.Text)),

                new XElement("pair",
                    new XAttribute("name", "Pair7"),
                    new XElement("StartHour", Pairs7Hours.Text),
                    new XElement("StartMinutes", Pairs7Minutes.Text),
                    new XElement("EndHour", EndPairs7Hours.Text),
                    new XElement("EndMinutes", EndPairs7Minutes.Text))
                ));

            //Путь к сохранению
            string path = $@"{Environment.CurrentDirectory}\schedule";

            //Создать путь к директории
            DirectoryInfo dirInfo = new DirectoryInfo(path);

            //Если путь к директории отсутствует (не хватает папок), то создать их
            if (!dirInfo.Exists) dirInfo.Create();

            //Сохранить документ
            xdoc.Save($@"{path}\");

            //Информация пользователю об успешном сохранении
            ErrorShow.Foreground = Brushes.Green;
            ErrorShow.Text = "Сохранение прошло успешно";
        }

        //Очистка полей ввода, если файл не был найден в сохранениях
        void ClearTextForSchedule()
        {
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

                EndPairs0Hours, EndPairs0Minutes,
                EndPairs1Hours, EndPairs1Minutes,
                EndPairs2Hours, EndPairs2Minutes,
                EndPairs3Hours, EndPairs3Minutes,
                EndPairs4Hours, EndPairs4Minutes,
                EndPairs5Hours, EndPairs5Minutes,
                EndPairs6Hours, EndPairs6Minutes,
                EndPairs7Hours, EndPairs7Minutes,
            };

            for(int i = 0; i < textBox.Length; i++)
            {
                textBox[i].Text = "";
            }
        }

        void LoadToFileScheduleXML()
        {
            string path = $@"{Environment.CurrentDirectory}\schedule\{GlobalSetting.GetTypeScheduleActiveToFile()}";
            

            //Путь к загрузке
            
            //Создать путь к директории
            FileInfo fileInfo = new FileInfo(path);

            XDocument xdoc = null;

            //Если данный путь существует
            if (fileInfo.Exists)
            {
                xdoc = XDocument.Load($@"{path}");
            }
            else
            {
                ClearTextForSchedule();
                return;
            }

            TextBox[] textBoxStart = new TextBox[]
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

            TextBox[] textBoxEnd = new TextBox[]
            {
                EndPairs0Hours, EndPairs0Minutes,
                EndPairs1Hours, EndPairs1Minutes,
                EndPairs2Hours, EndPairs2Minutes,
                EndPairs3Hours, EndPairs3Minutes,
                EndPairs4Hours, EndPairs4Minutes,
                EndPairs5Hours, EndPairs5Minutes,
                EndPairs6Hours, EndPairs6Minutes,
                EndPairs7Hours, EndPairs7Minutes,
            };

            int countPair = 0;

            /*textBox[0].Text = xdoc.Element("Schedule").Element("pair0start").Element("hour").Value;
            textBox[1].Text = xdoc.Element("Schedule").Element("pair0start").Element("minutes").Value;

            textBox[2].Text = xdoc.Element("Schedule").Element("pair1start").Element("hour").Value;
            textBox[3].Text = xdoc.Element("Schedule").Element("pair1start").Element("minutes").Value;*/


            //Заполнение полей (Часы и минуты начала)
            /*for (int i = 0; i < textBoxStart.Length; i=i+2)
            {
                string textPair = "pair";
                textBoxStart[i].Text = xdoc.Element("Schedule").Elements(textPair).Element("StartHour").Value;
                textBoxStart[i+1].Text = xdoc.Element("Schedule").Element(textPair).Element("StartMinutes").Value;

                textBoxEnd[i].Text = xdoc.Element("Schedule").Element(textPair).Element("EndHour").Value;
                textBoxEnd[i+1].Text = xdoc.Element("Schedule").Element(textPair).Element("EndHour").Value;

                countPair++;
            }*/

            foreach(XElement element in xdoc.Element("Schedule").Elements("pair"))
            {
                XElement startHour = element.Element("StartHour");
                XElement startMinutes = element.Element("StartMinutes");
                XElement endHour = element.Element("EndHour");
                XElement endMinutes = element.Element("EndMinutes");

                textBoxStart[countPair].Text = int.Parse(startHour.Value).ToString();
                textBoxStart[countPair+1].Text = int.Parse(startMinutes.Value).ToString();

                textBoxEnd[countPair].Text = int.Parse(endHour.Value).ToString();
                textBoxEnd[countPair + 1].Text = int.Parse(endMinutes.Value).ToString();

                countPair= countPair + 2;
            }
        }

        /// <summary>
        /// Событие изменения check box
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void NowUsedType_DropDownClosed(object sender, EventArgs e)
        {
            switch (NowUsedType.Text)
            {
                case "Осн. расписание":
                    GlobalSetting.TypeScheduleNow = GlobalSetting.TypeScheduleActive.MainSchedule;
                    LoadToFileScheduleXML();
                    break;
                case "Сокр. расписание":
                    GlobalSetting.TypeScheduleNow = GlobalSetting.TypeScheduleActive.ReducedSchedule;
                    LoadToFileScheduleXML();
                    break;
                case "Profile1":
                    GlobalSetting.TypeScheduleNow = GlobalSetting.TypeScheduleActive.Profile1;
                    LoadToFileScheduleXML();
                    break;
                case "Profile2":
                    GlobalSetting.TypeScheduleNow = GlobalSetting.TypeScheduleActive.Profile2;
                    LoadToFileScheduleXML();
                    break;
                case "Profile3":
                    GlobalSetting.TypeScheduleNow = GlobalSetting.TypeScheduleActive.Profile3;
                    LoadToFileScheduleXML();
                    break;
            }
        }

        private void SetSheduleNow(object sender, RoutedEventArgs e)
        {
            SaveToFileScheduleXML();

        }
    }
}
