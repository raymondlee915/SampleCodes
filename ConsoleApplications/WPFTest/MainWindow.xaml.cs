using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using WPFTest.LearningCenterService;
using WPFTest.TestService;

namespace WPFTest
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
           //Thread.CurrentThread.CurrentUICulture = new CultureInfo("zh-tw");

            InitializeComponent();
            testText.Text = WPFTest.Properties.Resources.Test;
        }

        private void Grid_Initialized(object sender, EventArgs e)
        {
            //IService1 service = new Service1Client();
            //var task = await service.GetDataAsync(23);
            //this.Title = task;


        }

        private async void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Title = "loading....";
            Button btn = sender as Button;
            btn.IsEnabled = false;

            this.Title = await HandleClickAsync();
            btn.IsEnabled = true;
        }

        private async Task<string> HandleClickAsync()
        {
            await Task.Delay(5000).ConfigureAwait(false);
            return "4";
        }
    }
}
