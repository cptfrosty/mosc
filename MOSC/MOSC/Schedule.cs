using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace VPT_CALL_TO_CLASS
{
    /// <summary>
    /// Расписание
    /// </summary>
    class Schedule
    {
        public enum TypePair { Start, end };

        public static List<Lesson> lessons = new List<Lesson>();
        public static TypePair typePair;
        /// <summary>
        /// Время следующего звонка
        /// </summary>
        public static DateTime nextCall;

        

        /// <summary>
        /// Заполнить расписание
        /// </summary>
        public static void ParseXML()
        {
            //XDocument xdoc = XDocument.Load(GlobalSetting.Path + @"\shedule\" + "DefaulTest");
            XDocument xdoc = XDocument.Load(@"C:\Users\Frosty\source\repos\ServiceVPT\ServiceVPT\bin\Debug\schedule\DefaultTest");
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
