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

namespace VPT_CALL_TO_CLASS
{
    /// <summary>
    /// Логика взаимодействия для PageSettingSchedule.xaml
    /// </summary>
    public partial class PageSettingSchedule : Page
    {
        /// <summary>
        /// mainSchedule - основное расписание
        /// reducedSchedule - сокращённое расписание
        /// </summary>
        public enum TypeSchedule {mainSchedule, reducedSchedule, profile1, profile2, profile3}
        public TypeSchedule typeSchedule = TypeSchedule.mainSchedule;

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
                new XElement("pair0start",
                    new XAttribute("name", "startPair"),
                    new XElement("hour", Pairs0Hours.Text),
                    new XElement("minutes", Pairs0Minutes.Text)),
                new XElement("pair0end",
                    new XAttribute("name", "endPair"),
                    new XElement("hour", EndPairs0Hours.Text),
                    new XElement("minutes", EndPairs0Minutes.Text)),

               new XElement("pair1start",
                    new XAttribute("name", "startPair"),
                    new XElement("hour", Pairs1Hours.Text),
                    new XElement("minutes", Pairs1Minutes.Text)),
                new XElement("pair1end",
                    new XAttribute("name", "endPair"),
                    new XElement("hour", EndPairs1Hours.Text),
                    new XElement("minutes", EndPairs1Minutes.Text)),

                new XElement("pair2start",
                    new XAttribute("name", "startPair"),
                    new XElement("hour", Pairs2Hours.Text),
                    new XElement("minutes", Pairs2Minutes.Text)),
                new XElement("pair2end",
                    new XAttribute("name", "endPair"),
                    new XElement("hour", EndPairs2Hours.Text),
                    new XElement("minutes", EndPairs2Minutes.Text)),

                new XElement("pair3start",
                    new XAttribute("name", "startPair"),
                    new XElement("hour", Pairs3Hours.Text),
                    new XElement("minutes", Pairs3Minutes.Text)),
                new XElement("pair3end",
                    new XAttribute("name", "endPair"),
                    new XElement("hour", EndPairs3Hours.Text),
                    new XElement("minutes", EndPairs3Minutes.Text)),

                new XElement("pair4start",
                    new XAttribute("name", "startPair"),
                    new XElement("hour", Pairs4Hours.Text),
                    new XElement("minutes", Pairs4Minutes.Text)),
                new XElement("pair4end",
                    new XAttribute("name", "endPair"),
                    new XElement("hour", EndPairs4Hours.Text),
                    new XElement("minutes", EndPairs4Minutes.Text)),

                new XElement("pair5start",
                    new XAttribute("name", "startPair"),
                    new XElement("hour", Pairs5Hours.Text),
                    new XElement("minutes", Pairs5Minutes.Text)),
                new XElement("pair5end",
                    new XAttribute("name", "endPair"),
                    new XElement("hour", EndPairs5Hours.Text),
                    new XElement("minutes", EndPairs5Minutes.Text)),

                new XElement("pair6start",
                    new XAttribute("name", "startPair"),
                    new XElement("hour", Pairs6Hours.Text),
                    new XElement("minutes", Pairs6Minutes.Text)),
                new XElement("pair6end",
                    new XAttribute("name", "endPair"),
                    new XElement("hour", EndPairs6Hours.Text),
                    new XElement("minutes", EndPairs6Minutes.Text)),

                new XElement("pair7start",
                    new XAttribute("name", "startPair"),
                    new XElement("hour", Pairs7Hours.Text),
                    new XElement("minutes", Pairs7Minutes.Text)),
                new XElement("pair7end",
                    new XAttribute("name", "endPair"),
                    new XElement("hour", EndPairs7Hours.Text),
                    new XElement("minutes", EndPairs7Minutes.Text))
                    )
                    );

            //Путь к сохранению
            string path = $@"{Environment.CurrentDirectory}\schedule";

            //Создать путь к директории
            DirectoryInfo dirInfo = new DirectoryInfo(path);

            //Если путь к директории отсутствует (не хватает папок), то создать их
            if (!dirInfo.Exists) dirInfo.Create();

            //Сохранить документ
            xdoc.Save($@"{path}\Default");

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
            string path = $@"{Environment.CurrentDirectory}\schedule";
            //Проверка пути
            switch (typeSchedule)
            {
                case TypeSchedule.mainSchedule:
                    path = $@"{path}\Default";
                    
                    break;
                case TypeSchedule.reducedSchedule:
                    path = $@"{path}\Reduced";
                    break;
                case TypeSchedule.profile1:
                    path = $@"{path}\Profile1";
                    break;
                case TypeSchedule.profile2:
                    path = $@"{path}\Profile2";
                    break;
                case TypeSchedule.profile3:
                    path = $@"{path}\Profile3";
                    break;
            }

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
            for (int i = 0; i < textBoxStart.Length; i++)
            {
                string textPair = "pair" + countPair + "start";
                textBoxStart[i].Text = xdoc.Element("Schedule").Element(textPair).Element("hour").Value;
                textBoxStart[++i].Text = xdoc.Element("Schedule").Element(textPair).Element("minutes").Value;
                countPair++;
            }

            countPair = 0; //Обнуление счётчика пар
            //Заполнение полей (Часы и минуты конца)
            for (int i = 0; i < textBoxEnd.Length; i++)
            {
                string textPair = "pair" + countPair + "end";
                textBoxEnd[i].Text = xdoc.Element("Schedule").Element(textPair).Element("hour").Value;
                textBoxEnd[++i].Text = xdoc.Element("Schedule").Element(textPair).Element("minutes").Value;
                countPair++;
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
                    typeSchedule = TypeSchedule.mainSchedule;
                    LoadToFileScheduleXML();
                    break;
                case "Сокр. расписание":
                    typeSchedule = TypeSchedule.reducedSchedule;
                    LoadToFileScheduleXML();
                    break;
                case "Profile1":
                    typeSchedule = TypeSchedule.profile1;
                    LoadToFileScheduleXML();
                    break;
                case "Profile2":
                    typeSchedule = TypeSchedule.profile2;
                    LoadToFileScheduleXML();
                    break;
                case "Profile3":
                    typeSchedule = TypeSchedule.profile3;
                    LoadToFileScheduleXML();
                    break;
            }
        }
    }
}
