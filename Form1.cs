using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            int i = 0;
            foreach (var color in typeof(SystemColors).GetProperties())
            {
                var c = (Color)color.GetValue(null);
                var name = color.Name;
                var p = new Panel() { Width = 60, Height = 30,
                    BackColor = c,
                    BorderStyle = BorderStyle.Fixed3D,
                    Top = i * 40,
                    Left = 180,
                };
                var t = new Label() { Text = name, Top = i*40, Width = 160, Height = 30 };
                panel1.Controls.Add(t);
                panel1.Controls.Add(p);
                i++;
            }
        }

    }
}
