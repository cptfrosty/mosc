using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace MOSC
{

    class GlobalSetting
    {
        /*
         * 0 - Основное расписание
         * 1 - Сокращённое расписание
         * 2 - Profile 1
         * 3 - Profile 2
         * 4 - Profile 3
         */
        //Профили расписания
        public enum TypeScheduleActive {MainSchedule, ReducedSchedule, Profile1, Profile2, Profile3 };
        public static TypeScheduleActive TypeScheduleNow = TypeScheduleActive.MainSchedule;

        /// <summary>
        /// Получить активный профиль
        /// </summary>
        /// <returns>Возвращает активный профиль</returns>
        public static TypeScheduleActive GetTypeScheduleActive()
        {
            return TypeScheduleNow;
        }

        /// <summary>
        /// Получить название файла взависимости от активного профиля
        /// </summary>
        /// <returns></returns>
        public static string GetTypeScheduleActiveToFile()
        {
            string nameFile = "";
            switch (TypeScheduleNow)
            {
                case TypeScheduleActive.MainSchedule: nameFile = "Default"; break;
                case TypeScheduleActive.ReducedSchedule: nameFile = "Reduced"; break;
                case TypeScheduleActive.Profile1: nameFile = "P1"; break;
                case TypeScheduleActive.Profile2: nameFile = "P2"; break;
                case TypeScheduleActive.Profile3: nameFile = "P3"; break;
            }
            return nameFile;
        }

        /// <summary>
        /// Директория пути
        /// </summary>
        public static string Path = AppDomain.CurrentDomain.BaseDirectory;



        //----------------------------------------------------------------------//
        
        public static List<Task> task = new List<Task>(); //Список всех звонков
        

        /// <summary>
        /// Статус работы службы
        /// </summary>
        public static bool isService = false;

        /// <summary>
        /// Добавление задачи
        /// </summary>
        /// <param name="indexTypeTask">Индекс задачи</param>
        /// <param name="indexTypeMelody">Индекс звука</param>
        /// <param name="day">День</param>
        /// <param name="mounth">Месяц</param>
        /// <param name="year">Год</param>
        /// <param name="hour">Часы</param>
        /// <param name="minutes">Минуты</param>
        public static void AddTask(string nameTask,int indexTypeTask, int indexTypeMelody, int day, int mounth, int year, int hour, int minutes)
        {
            Task _task = new Task();
            switch (indexTypeTask)
            {
                case 0: _task.typeTask = Task.TypeTask.TrainingAlert; break;
                default: break;
            }

            switch (indexTypeMelody)
            {
                case 0: _task.typeMelody = Task.TypeMelody.TrainingAlert; break;
                default: break;
            }

            _task.NameTask      = nameTask;
            _task.Day           = day;
            _task.Mounth        = mounth;
            _task.Year          = year;
            _task.TimeHour      = hour;
            _task.TimeMinutes   = minutes;

            task.Add(_task);
            SaveTaskXML();
        }

        public static void SaveTaskXML()
        {
            XDocument xdoc = new XDocument();
            XElement elem = new XElement("Task");
            for (int i = 0; i < task.Count; i++)
            {
                XElement element = new XElement("Task");
                XAttribute attr = new XAttribute("name" + i, "Task" + i);
                XElement nameTask = new XElement("nameTask", task[i].NameTask);
                XElement indexTypeTask = new XElement("indexTypeTask", task[i].typeTask.ToString());
                XElement indexTypeMelody = new XElement("indexTypeMelody",task[i].typeMelody.ToString());
                XElement day = new XElement("day",task[i].Day.ToString());
                XElement mounth = new XElement("mounth", task[i].Mounth.ToString());
                XElement year = new XElement("year",task[i].Year.ToString());
                XElement hour = new XElement("hour",task[i].TimeHour.ToString());
                XElement minutes = new XElement("minutes",task[i].TimeMinutes.ToString());

                
                element.Add(attr);
                element.Add(indexTypeTask);
                element.Add(indexTypeMelody);
                element.Add(day);
                element.Add(mounth);
                element.Add(year);
                element.Add(hour);
                element.Add(minutes);
                elem.Add(element);
            }


            xdoc.Add(elem);

            //Путь к сохранению
            string path = $@"{Environment.CurrentDirectory}\task";

            //Создать путь к директории
            DirectoryInfo dirInfo = new DirectoryInfo(path);

            //Если путь к директории отсутствует (не хватает папок), то создать их
            if (!dirInfo.Exists) dirInfo.Create();

            //Сохранить документ
            xdoc.Save($@"{path}\Task");
        }

    }

    //Расписание пар (структура)
    //Начало пары - часы
    //Начало пары - минуты
    //Конец пары - часы
    //Конец пары - минуты
    struct PairsSchedule
    {
        int startPairHour;
        int startPairMinutes;
        int endPairHour;
        int endPairMinutes;
    }
   
    class Task
    {
        public string NameTask;
        public enum TypeTask {TrainingAlert = 0}
        public TypeTask typeTask;
        public enum TypeMelody { TrainingAlert = 0 }
        public TypeMelody typeMelody;
        public int Day { get; set; }
        public int Mounth { get; set; }
        public int Year { get; set; }
        public int TimeHour { get; set; }
        public int TimeMinutes { get; set; }
        public bool isActiv = false;
    }
}
