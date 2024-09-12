using System;
using System.Collections.Generic;
using System.ComponentModel;
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
using System.Windows.Shapes;

namespace SplashScreen.Views
{
    /// <summary>
    /// Interaction logic for SplashScreen_Window.xaml
    /// </summary>
    public partial class SplashScreen_Window : Window
    {

        private BackgroundWorker _BackgroundWorker;
        public SplashScreen_Window()
        {
            InitializeComponent();
            Application.Current.ShutdownMode = ShutdownMode.OnExplicitShutdown;
            _BackgroundWorker = new BackgroundWorker();
            _BackgroundWorker.DoWork += _BackgroundWorker_DoWork;
            _BackgroundWorker.RunWorkerCompleted += _BackgroundWorker_RunWorkerCompleted;
            _BackgroundWorker.RunWorkerAsync();
        }

        private void _BackgroundWorker_RunWorkerCompleted(object? sender, RunWorkerCompletedEventArgs e)
        {
            this.Close();
            // After waiting closing the splash screen and showing the main window
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
        }

        private void _BackgroundWorker_DoWork(object? sender, DoWorkEventArgs e)
        {
            Thread.Sleep(6000); // waiting for 6 seconds
        }

        private void Image_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                Application.Current.Shutdown();
            }
        }
    }
}
