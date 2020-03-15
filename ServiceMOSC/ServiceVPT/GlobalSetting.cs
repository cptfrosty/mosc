using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace ServiceVPT
{
    class GlobalSetting
    {
        public static string Path { get; private set; }
        public static bool IsStartLesson { get; set; } //Флаг начала пары

        //Максимальное кол-во пар, после того как счетчик законченных уроков доходит до данного значения, то он обнуляется (счётчик законченных уроков).
        public static int CountLessonMax = 7;
        public static int LessonCounter = 0; //Счётчик законченных уроков

        public static string ProfileNow = ""; //Профиль звонков, который используется сейчас

        public static string PathTypeSheduleNow;
        public static string PathMusicForFiveMinutesStartPair;
        public static string PathMusicStartPair;
        public static string PathMusicEndPair;
        public static string PathMusicForFiveMinutesEndPair;


        //Загрузить настройки службы
        public static void LoadSetting()
        {
            string path = AppDomain.CurrentDomain.BaseDirectory + @"\setting\setting_s";
            XDocument xdoc = XDocument.Load(path);
            PathTypeSheduleNow = xdoc.Element("Setting").Element("TypeSheduleNow").Value;

            PathMusicStartPair = xdoc.Element("Setting").Element("PathMusicStartPair").Value;
            PathMusicForFiveMinutesStartPair = xdoc.Element("Setting").Element("PathMusicForFiveMinutesStartPair").Value;
            PathMusicEndPair = xdoc.Element("Setting").Element("PathMusicEndPair").Value;
            PathMusicForFiveMinutesEndPair = xdoc.Element("Setting").Element("PathMusicForFiveMinutesEndPair").Value;
        }

        /// <summary>
        /// Если пара завершилась, то увеличивает счётчик на 1 законченную пару
        /// </summary>
        public static void LessonCompleted()
        {
            LessonCounter++;
            if(LessonCounter > CountLessonMax)
            {
                LessonCounter = 0;
            }
        }
    }
}
