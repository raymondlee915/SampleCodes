﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
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

namespace JSONFileValidator
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private string selectedPath = null;

        public MainWindow()
        {
            InitializeComponent();
            this.Loaded += MainWindow_Loaded;

        }

        void MainWindow_Loaded(object sender, RoutedEventArgs e)
        {
            selectedPath = Settings.Default.RecentFolder;
            ShowSelectedFolder(selectedPath);
        }

        private async void btnFolderOpener_Click(object sender, RoutedEventArgs e)
        {
            using (FolderBrowserDialog dialog = new FolderBrowserDialog())
            {
                dialog.SelectedPath = selectedPath;
                dialog.RootFolder = Environment.SpecialFolder.MyComputer;
               
                var result = dialog.ShowDialog();
                if (result == System.Windows.Forms.DialogResult.OK)
                {
                    selectedPath = dialog.SelectedPath;

                    await ShowSelectedFolder(selectedPath);

                    Settings.Default.RecentFolder = selectedPath;
                    // btnGo_Click(null, null);
                }
            }
        }

        private async void btnGo_Click(object sender, RoutedEventArgs e)
        {
            ClearMessage();

            AddMessage("Start validation....");

            string[] filePaths = Directory.GetFiles(selectedPath, "*.json", SearchOption.AllDirectories);
            foreach (string file in filePaths)
            {
                using (StreamReader fileReader = new StreamReader(file, true))
                {
                    object obj = null;
                    var fileName = System.IO.Path.GetFileName(file);

                    try
                    {
                        var contentJson = await fileReader.ReadToEndAsync();
                        obj =await Newtonsoft.Json.JsonConvert.DeserializeObjectAsync(contentJson);
                        //Thread.Sleep(500);
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("file: {0}, error: {1}", fileName, ex.Message);
                    }


                    if (obj == null)
                    {
                        AddErrorMessage(fileName);
                    }
                    else
                    {
                        AddSuccessMessage(fileName);
                    }
                }
            }

            AddMessage("End validation....");
        }

        private void AddErrorMessage(string fileName)
        {
            string format = "{0}: error.";
            format = string.Format(format, fileName);
            AddMessage(format, Brushes.Red);
        }

        private void AddSuccessMessage(string fileName)
        {
            string format = "{0}: succed.";
            format = string.Format(format, fileName);
            AddMessage(format, Brushes.Green);
        }

        private void AddMessage(string message)
        {
            AddMessage(message, Brushes.Black);
        }

        private void AddMessage(string message, Brush foreground)
        {
            System.Windows.Controls.Label label = new System.Windows.Controls.Label();
            label.Content = message;
            label.Foreground = foreground;
            this.ErrorPanel.Children.Add(label);
        }

        private async Task ClearMessage()
        {
            await Task.Run(() =>
            {
                this.ErrorPanel.Dispatcher.Invoke(() =>
                    {
                        this.ErrorPanel.Children.Clear();
                    });
            });
        }

        private async Task ShowSelectedFolder(string folderPath)
        {
            await Task.Run(() =>
            {
                this.tbFilePath.Dispatcher.Invoke(() =>
                {
                    this.tbFilePath.Text = folderPath;
                });
            });
        }
    }
}
