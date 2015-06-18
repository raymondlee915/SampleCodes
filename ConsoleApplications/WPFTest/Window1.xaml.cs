using System;
using System.Collections.Generic;
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
using System.Windows.Shapes;

namespace WPFTest
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class Window1 : Window
    {
        public Window1()
        {
            InitializeComponent();
            this.Title = "ברוכים הבאים dell החדשות שלך";

            //tbLabel.FlowDirection = System.Windows.FlowDirection.RightToLeft;
           // tbLabel.TextAlignment = TextAlignment.Right;
            //this.FlowDirection = System.Windows.FlowDirection.RightToLeft;
           // tbHebrew.FlowDirection = System.Windows.FlowDirection.RightToLeft;
            string message =string.Join(", ", System.Windows.SystemFonts.MessageFontFamily.FamilyNames.Select(p => string.Format("{0}:{1}", p.Key, p.Value)));
            MessageBox.Show(message);
            //MessageBox.Show(System.Windows.SystemFonts.MessageFontFamily.FamilyNames)
        }
    }
}
