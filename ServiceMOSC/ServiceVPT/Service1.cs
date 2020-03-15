using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Media;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace ServiceVPT
{
    public partial class Service1 : ServiceBase
    {
        Timer timer = new Timer();
        SoundPlayer sound = new SoundPlayer();

        public Service1()
        {
            InitializeComponent();
            
        }

        protected override void OnStart(string[] args)
        {
            GlobalSetting.LoadSetting();
            LoadSound();
            GlobalSetting.IsStartLesson = false;
            Schedule.ParceLesson();
            TimerUpdate();
        }

        protected override void OnStop()
        {

        }

        public void LoadSound()
        {
            sound.SoundLocation = GlobalSetting.PathMusicStartPair;
            sound.Load();
        }

        public void PlaySound()
        {
            sound.Play();
        }

        void TimerUpdate()
        {
            timer.Interval = 1000;
            timer.Elapsed += Timer_Elapsed;
            timer.Start();
        }

        public void StopSound()
        {
            sound.Stop();
        }

        private void Timer_Elapsed(object sender, ElapsedEventArgs e)
        {
            if (!GlobalSetting.IsStartLesson) {
                for (int i = 0; i < Schedule.lessons.Count; i++)
                {
                    if (Schedule.lessons[i].startLesson.Hour == DateTime.Now.Hour &&
                        Schedule.lessons[i].startLesson.Minute == DateTime.Now.Minute)
                    {
                        PlaySound();
                        GlobalSetting.IsStartLesson = true;
                    }
                    //Logs.CreateLog(Schedule.lessons[i].startLesson.Hour.ToString());
                }
            }
            else
            {
                for (int i = 0; i < Schedule.lessons.Count; i++)
                {
                    if (Schedule.lessons[GlobalSetting.LessonCounter].endLesson.Hour == DateTime.Now.Hour &&
                    Schedule.lessons[GlobalSetting.LessonCounter].endLesson.Minute == DateTime.Now.Minute)
                    {
                        PlaySound();
                        GlobalSetting.LessonCompleted();
                        GlobalSetting.IsStartLesson = false;
                    }
                    //Logs.CreateLog("FALSE:" + Schedule.lessons[i].startLesson.Hour.ToString());
                }
            }

            /*if(DateTime.Now.Second == 10)
            {
                PlaySound();
            }*/
        }
    }
}
