using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace ServiceVPT
{
    class Schedule
    {
        public static List<Lesson> lessons = new List<Lesson>();

        /// <summary>
        /// Парсит документ со списком звонков
        /// </summary>
        public static void ParceLesson()
        {
            //XDocument xdoc = XDocument.Load(GlobalSetting.Path + @"\shedule\" + "DefaulTest");
            XDocument xdoc = XDocument.Load(@"C:\Users\Frosty\source\repos\ServiceVPT\ServiceVPT\bin\Debug\schedule\DefaultTest");
            foreach (XElement LessonElement in xdoc.Element("Schedule").Elements("pair"))
            {
                Lesson lesson = new Lesson();

                XElement startHour      = LessonElement.Element("StartHour");
                XElement startMinutes   = LessonElement.Element("StartMinutes");
                XElement endHour        = LessonElement.Element("EndHour");
                XElement endMinutes     = LessonElement.Element("EndMinutes");

                lesson.startLesson = new DateTime
                    (DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 
                    int.Parse(startHour.Value), int.Parse(startMinutes.Value), 0);
                lesson.endLesson = new DateTime
                    (DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day,
                    int.Parse(endHour.Value), int.Parse(endMinutes.Value), 0);

                lessons.Add(lesson);
            }
            Logs.CreateLog("Размер проинициализированного листа " + lessons.Count());

            for(int i = 0; i < lessons.Count; i++)
            {
                Logs.CreateLog(i + " - пара " + lessons[i].startLesson + " - " + lessons[i].endLesson);
            }
        }
    }
}
