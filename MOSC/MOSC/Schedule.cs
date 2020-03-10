using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace MOSC
{
    /// <summary>
    /// Расписание
    /// </summary>
    class Schedule
    {
        public static List<Lesson> lessons = new List<Lesson>();
        /// <summary>
        /// Время следующего звонка
        /// </summary>
        public static DateTime NextCall;
        public static bool startLesson = false;
        private static bool isChange = false; //Проверяет, изменено ли время на новое или нет.

        /// <summary>
        /// Проверяет изменение по времени и следующего звонка
        /// </summary>
        public static void CheckNextCall()
        {
            NextCall = lessons[0].startLesson;
            var timer = new System.Windows.Threading.DispatcherTimer();
            timer.Interval = new TimeSpan(0, 0, 1);
            timer.IsEnabled = true;
            timer.Tick += (o, e) => {
                if (NextCall.Hour <= DateTime.Now.Hour && NextCall.Minute < DateTime.Now.Minute)
                {
                    for (int i = lessons.Count-1; i >= 0; i--)
                    {
                        if(lessons[i].endLesson.Hour >= DateTime.Now.Hour && lessons[i].endLesson.Minute > DateTime.Now.Minute)
                        {
                            NextCall = lessons[i].endLesson;
                            startLesson = false;
                            isChange = true;
                        }

                        if (lessons[i].startLesson.Hour >= DateTime.Now.Hour && lessons[i].startLesson.Minute > DateTime.Now.Minute)
                        {
                            NextCall = lessons[i].startLesson;
                            startLesson = true;
                            isChange = true;
                        }
                    }
                    //Если изменение не произошло, значит все пары закончились
                    //И мы присваиваем ему самое первое значение
                    if (!isChange)
                    {
                        NextCall = lessons[0].startLesson;
                    }
                }
            };
            timer.Start();
        }

        /// <summary>
        /// Класс расписание начинает собирать информацию;
        /// </summary>
        public static void Start()
        {
            ParseXMLToList();
            CheckNextCall();
        }

        /// <summary>
        /// Заполнить расписание
        /// </summary>
        public static void ParseXMLToList()
        {
            XDocument xdoc = XDocument.Load(GlobalSetting.Path + @"\schedule\" + GlobalSetting.GetTypeScheduleActiveToFile());
            //XDocument xdoc = XDocument.Load(@"C:\Users\Frosty\source\repos\ServiceVPT\ServiceVPT\bin\Debug\schedule\DefaultTest");
            foreach (XElement LessonElement in xdoc.Element("Schedule").Elements("pair"))
            {
                Lesson lesson = new Lesson();

                XElement startHour = LessonElement.Element("StartHour");
                XElement startMinutes = LessonElement.Element("StartMinutes");
                XElement endHour = LessonElement.Element("EndHour");
                XElement endMinutes = LessonElement.Element("EndMinutes");

                lesson.startLesson = new DateTime
                    (DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day,
                    int.Parse(startHour.Value), int.Parse(startMinutes.Value), 0);
                lesson.endLesson = new DateTime
                    (DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day,
                    int.Parse(endHour.Value), int.Parse(endMinutes.Value), 0);
                lessons.Add(lesson);
            }
        }

        /// <summary>
        /// Определение времени следующей пары для графического отображения
        /// </summary>
        /*public void NextPair()
        {
            nextCall = DateTime.Now;
            //Счетчик пар
            //При парсинге определяет какая пара будет или какая пара сейчас
            int countPair = 0;

            for (int i = lessons.Count; i < lessons.Count; i--)
            {
                if (nextCall.Hour < lessons[i].startLesson.Hour)
                {
                    if (nextCall.Minute < lessons[i].startLesson.Minute)
                    {
                        nextCall = lessons[i].startLesson;
                        countPair = i;
                    }
                }
                else if (nextCall.Hour < lessons[i].endLesson.Hour)
                {
                    if (nextCall.Minute < lessons[i].endLesson.Minute)
                    {
                        nextCall = lessons[i].endLesson;
                        
                    }
                }
                else
                {
                    
                }
            }
        }*/
    }
}
