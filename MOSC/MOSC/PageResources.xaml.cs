using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace MOSC
{
    /// <summary>
    /// Логика взаимодействия для PageResources.xaml
    /// </summary>
    public partial class PageResources : Page
    {
        public PageResources()
        {
            InitializeComponent();
        }

        public void ShowPath(System.Windows.Controls.TextBox tb)
        {
            OpenFileDialog OPF = new OpenFileDialog();
            OPF.Filter = "|*.wav";
            OPF.Multiselect = true;
            if (OPF.ShowDialog() == DialogResult.OK)
            {
                tb.Text = OPF.FileName;
            }
        }

        public void SavePathes()
        {
            GlobalSetting.pathMusicStartPair = tbPathStartSoundPair.Text;
            GlobalSetting.pathMusicForFiveMinutesStartPair = tbPathStartForFiveSoundPair.Text;
            GlobalSetting.pathMusicEndPair = tbPathEndSoundPair.Text;
            GlobalSetting.pathMusicForFiveMinutesEndPair = tbPathEndForFiveSoundPair.Text;

            bool status = GlobalSetting.SaveGlobalSettigsSound();
            if (status)
            {
                statusSave.Foreground = Brushes.Green;
                statusSave.Visibility = Visibility.Visible;
            }
        }

        private void btnPathStartSoundPair_Click(object sender, RoutedEventArgs e)
        {
            ShowPath(tbPathStartSoundPair);
        }

        private void btnPathStartForFiveSoundPair_Click(object sender, RoutedEventArgs e)
        {
            ShowPath(tbPathStartForFiveSoundPair);
        }

        private void btnPathEndSoundPair_Click(object sender, RoutedEventArgs e)
        {
            ShowPath(tbPathEndSoundPair);
        }

        private void btnPathEndForFiveSoundPair_Click(object sender, RoutedEventArgs e)
        {
            ShowPath(tbPathEndForFiveSoundPair);
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            SavePathes();
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            tbPathStartSoundPair.Text = GlobalSetting.pathMusicStartPair;
            tbPathStartForFiveSoundPair.Text = GlobalSetting.pathMusicForFiveMinutesStartPair;
            tbPathEndSoundPair.Text = GlobalSetting.pathMusicEndPair;
            tbPathEndForFiveSoundPair.Text = GlobalSetting.pathMusicForFiveMinutesEndPair;
        }
    }
}
