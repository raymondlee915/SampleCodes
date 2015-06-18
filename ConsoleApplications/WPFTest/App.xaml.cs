using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;

namespace WPFTest
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public App()
        {
            this.LoadCompleted += App_LoadCompleted;
        }

        void App_LoadCompleted(object sender, System.Windows.Navigation.NavigationEventArgs e)
        {
            
        }

        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo("ar");

            var window = new Window1();
            window.Show();

            string systemDrive = Environment.GetFolderPath(Environment.SpecialFolder.System);
            MessageBox.Show(systemDrive);

        }
    }
}
