using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace KSModelSimulator
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            this.Title = "KS Simulator";

            ViewModel vm = new ViewModel();
            DataContext = vm;
            this.CbxModels.ItemsSource = vm.Models;
            this.LblResult.Content = "";

            this.CbxCountries.ItemsSource = vm.Countries;
            this.LblCountryResult.Content = "";

            this.CbxLanguages.ItemsSource = vm.Languages;
            this.LblLanguageResult.Content = "";
        }

        private void Clear_Click(object sender, RoutedEventArgs e)
        {
            string rootPath = System.IO.Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData), @"Dell\Dell Product Registration");
            string lobFileName = System.IO.Path.Combine(rootPath, "lob.txt");
            string modelFileName = System.IO.Path.Combine(rootPath, "systemmodel.txt");
            string countryFileName = System.IO.Path.Combine(rootPath, "country.txt");
            string lanFileName = System.IO.Path.Combine(rootPath, "language.txt");

            DeleteFile(lobFileName);
            DeleteFile(modelFileName);
            DeleteFile(countryFileName);
            DeleteFile(lanFileName);

            this.LblResult.Content = "using computer setting";
            this.LblCountryResult.Content = "using computer setting";
            this.LblLanguageResult.Content = "using computer setting";
        }

        private static void DeleteFile(string lobFileName)
        {
            if (File.Exists(lobFileName))
                File.Delete(lobFileName);
        }



        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string text = this.CbxModels.Text;

            string lob = text.Substring(0, text.IndexOf(" "));

            if (text.Contains("3Dcamera"))
            {
                text = "3Dcamera";
            }

            if (lob == "Venue")
            {
                lob = "VenuePro";
            }

            string country = this.CbxCountries.SelectedValue.ToString();
            string language = this.CbxLanguages.Text;

            SetValues(text, lob, country, language);
        }

        private void SetValues(string model, string lob, string country, string language)
        {
            string rootPath = System.IO.Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData), @"Dell\Dell Product Registration");
            string lobFileName = System.IO.Path.Combine(rootPath, "lob.txt");
            string modelFileName = System.IO.Path.Combine(rootPath, "systemmodel.txt");
            string countryFileName = System.IO.Path.Combine(rootPath, "country.txt");
            string lanFileName = System.IO.Path.Combine(rootPath, "language.txt");

            ReWriteFile(lob, lobFileName);

            ReWriteFile(model, modelFileName);

            ReWriteFile(country, countryFileName);

            ReWriteFile(language, lanFileName);

            this.LblResult.Content = "Now it is " + model;
            this.LblCountryResult.Content = "Now it is " + country;
            this.LblLanguageResult.Content = "Now it is " + language;
        }

        private static void ReWriteFile(string lob, string lobFileName)
        {

            if (File.Exists(lobFileName))
            {
                File.Delete(lobFileName);
            }

            string dirPath = System.IO.Path.GetDirectoryName(lobFileName);
            if (!Directory.Exists(dirPath))
            {
                Directory.CreateDirectory(dirPath);
            }


            using (StreamWriter writter = new StreamWriter(File.Open(lobFileName, FileMode.OpenOrCreate)))
            {
                writter.Write(lob);
                writter.Flush();
            }
        }
    }


}
