using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

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

        //Определить где находится служба
        public static void LoadPath()
        {
            Path = Application.StartupPath;
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
