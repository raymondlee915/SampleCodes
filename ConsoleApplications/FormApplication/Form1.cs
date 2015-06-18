using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace FormApplication
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        protected override void OnLoad(System.EventArgs e)
        {
            base.OnLoad(e);
            this.RightToLeftLayout = true;
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;

            this.textBox1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;

        }
    }
}
