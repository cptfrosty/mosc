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
            LoadSound();
            GlobalSetting.IsStartLesson = false;
            GlobalSetting.LoadPath();
            Schedule.ParceLesson();
            TimerUpdate();
        }

        protected override void OnStop()
        {

        }

        public void LoadSound()
        {
            sound.SoundLocation = @"D:\sound\Sound2.wav";
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
                if (Schedule.lessons[GlobalSetting.LessonCounter].startLesson.Hour == DateTime.Now.Hour && 
                    Schedule.lessons[GlobalSetting.LessonCounter].startLesson.Minute == DateTime.Now.Minute)
                {
                    PlaySound();
                    GlobalSetting.IsStartLesson = true;
                }
            }
            else
            {
                if (Schedule.lessons[GlobalSetting.LessonCounter].endLesson.Hour == DateTime.Now.Hour &&
                    Schedule.lessons[GlobalSetting.LessonCounter].endLesson.Minute == DateTime.Now.Minute)
                {
                    PlaySound();
                    GlobalSetting.LessonCompleted();
                    GlobalSetting.IsStartLesson = false;
                }
            }

            /*if(DateTime.Now.Second == 10)
            {
                PlaySound();
            }*/
        }
    }
}
