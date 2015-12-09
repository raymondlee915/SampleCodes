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
        string rootPath = System.IO.Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData), @"Dell\Dell Product Registration");
        string lobFileName { get { return System.IO.Path.Combine(rootPath, "lob.txt"); } }
        string modelFileName  { get { return  System.IO.Path.Combine(rootPath, "systemmodel.txt"); } }
        string countryFileName  { get { return  System.IO.Path.Combine(rootPath, "country.txt"); } }
        string lanFileName { get { return System.IO.Path.Combine(rootPath, "language.txt"); } }

        string MacfeePath
        {
            get
            {
                return System.IO.Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ProgramFiles), @"McAfee.com\Agent\mcagent.exe");
            }
        }

        string DropboxPath
        {
            get
            {
                return System.IO.Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ProgramFiles), @"Dropbox\DropboxOEM\DropboxOEM.exe"); 
            }
        }

        public MainWindow()
        {
            InitializeComponent();
        }

        protected override void OnInitialized(EventArgs e)
        {
            base.OnInitialized(e);

            this.Title = "KS Simulator";

            ViewModel vm = new ViewModel();
            DataContext = vm;
            this.CbxModels.ItemsSource = vm.Models;
            this.LblResult.Content = "";
            int index = IndexOf(vm.Models, ReadFile(modelFileName));
            if (index != -1)
            {
                this.CbxModels.SelectedIndex = index;
            }

            this.CbxCountries.ItemsSource = vm.Countries;
            this.LblCountryResult.Content = "";
            index = IndexOf(vm.Countries, ReadFile(countryFileName));
            if (index != -1)
            {
                this.CbxCountries.SelectedIndex = index;
            }

            this.CbxLanguages.ItemsSource = vm.Languages;
            this.LblLanguageResult.Content = "";
            index = IndexOf(vm.Languages, ReadFile(lanFileName));
            if (index != -1)
            {
                this.CbxLanguages.SelectedIndex = index;
            }

            if (File.Exists(MacfeePath))
            {
                this.LiveSafeInstalled.IsChecked = true;
            }

            if (File.Exists(DropboxPath))
            {
                this.DropboxInstalled.IsChecked = true;
            }

        }

        private static int IndexOf(CollectionView collection, string value)
        {
            if(string.IsNullOrWhiteSpace(value))
            {
                return -1;
            }

            int index = 0;
            foreach (var item in collection)
            {
                Pair p = item as Pair;
                if (value.Equals(p.Value))
                {
                    return index;
                }

                if (value.Equals(p.Text))
                {
                    return index;
                }

                index++;
            }

            return -1;
        }

        private void Clear_Click(object sender, RoutedEventArgs e)
        {
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
            if (this.LiveSafeInstalled.IsChecked.HasValue && this.LiveSafeInstalled.IsChecked.Value)
            {
                ReleaseResourceFile(MacfeePath, KSModelSimulator.Properties.Resources.MockLifeSafe);
            }
            else
            {
                DeleteFile(MacfeePath);
            }


            if (this.DropboxInstalled.IsChecked.HasValue && this.DropboxInstalled.IsChecked.Value)
            {
                ReleaseResourceFile(DropboxPath, KSModelSimulator.Properties.Resources.MockDropbox);
            }
            else
            {
                DeleteFile(DropboxPath);
            }        
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

        private static string ReadFile(string fileName)
        {
            if (!File.Exists(fileName))
            {
                return null;
            }

            using(StreamReader reader = new StreamReader(fileName))
            {
                return reader.ReadLine();
            }
        }

        private static void MakeSureLocalDirectoryExist(string localFile)
        {
            var pathInfo = System.IO.Path.GetDirectoryName(localFile);

            if (!System.IO.Directory.Exists(pathInfo))
            {
                System.IO.Directory.CreateDirectory(pathInfo);
            }
        }

        private static void ReleaseResourceFile(string fileName, byte[] resourceFile)
        {
            if (File.Exists(fileName))
            {
                return;
            }

            MakeSureLocalDirectoryExist(fileName);

            using (FileStream writer = File.OpenWrite(fileName))
            {
                writer.Write(resourceFile, 0, resourceFile.Length);
            }
        }
    }


}
