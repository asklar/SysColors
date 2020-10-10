using System.Collections.Generic;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public static class user32
    {
        [DllImport("user32.dll")]
        public static extern bool SetSysColors(int cElements, int[] lpaElements,
   uint[] lpaRgbValues);

        public const int
         COLOR_SCROLLBAR = 0,
         COLOR_BACKGROUND = 1,
         COLOR_DESKTOP = 1,
         COLOR_ACTIVECAPTION = 2,
         COLOR_INACTIVECAPTION = 3,
         COLOR_MENU = 4,
         COLOR_WINDOW = 5,
         COLOR_WINDOWFRAME = 6,
         COLOR_MENUTEXT = 7,
         COLOR_WINDOWTEXT = 8,
         COLOR_CAPTIONTEXT = 9,
         COLOR_ACTIVEBORDER = 10,
         COLOR_INACTIVEBORDER = 11,
         COLOR_APPWORKSPACE = 12,
         COLOR_HIGHLIGHT = 13,
         COLOR_HIGHLIGHTTEXT = 14,
         COLOR_BTNFACE = 15,
         COLOR_3DFACE = 15,
         COLOR_BTNSHADOW = 16,
         COLOR_3DSHADOW = 16,
         COLOR_GRAYTEXT = 17,
         COLOR_BTNTEXT = 18,
         COLOR_INACTIVECAPTIONTEXT = 19,
         COLOR_BTNHIGHLIGHT = 20,
         COLOR_3DHIGHLIGHT = 20,
         COLOR_3DHILIGHT = 20,
         COLOR_BTNHILIGHT = 20,
         COLOR_3DDKSHADOW = 21,
         COLOR_3DLIGHT = 22,
         COLOR_INFOTEXT = 23,
         COLOR_INFOBK = 24,
         COLOR_HOTLIGHT = 26,
         COLOR_GRADIENTACTIVECAPTION = 27,
            COLOR_GRADIENTINACTIVECAPTION = 28,
            COLOR_MENUHILIGHT = 29,
            COLOR_MENUBAR = 30;

        public static SortedDictionary<string, int> map = new SortedDictionary<string, int>()
        {
            {"ScrollBar",  COLOR_SCROLLBAR},
{"Desktop",  COLOR_DESKTOP},
{"ActiveCaption",  COLOR_ACTIVECAPTION},
{"InactiveCaption",  COLOR_INACTIVECAPTION},
{"Menu",  COLOR_MENU},
{"Window",  COLOR_WINDOW},
{"WindowFrame",  COLOR_WINDOWFRAME},
{"MenuText",  COLOR_MENUTEXT},
{"WindowText", COLOR_WINDOWTEXT},
{"ActiveCaptionText", COLOR_CAPTIONTEXT},
{"ActiveBorder", COLOR_ACTIVEBORDER},
{"InactiveBorder", COLOR_ACTIVEBORDER},
{"AppWorkspace", COLOR_APPWORKSPACE},
{"Highlight", COLOR_HIGHLIGHT},
{"HighlightText", COLOR_HIGHLIGHTTEXT},
{"ButtonFace",  COLOR_3DFACE},
{"ControlDark", COLOR_BTNSHADOW},
{"GrayText", COLOR_GRAYTEXT},
{"ControlText", COLOR_BTNTEXT},
{"InactiveCaptionText", COLOR_INACTIVECAPTIONTEXT},
{"ControlLightLight",  COLOR_BTNHILIGHT},
{"ControlDarkDark",  COLOR_3DDKSHADOW},
{"ControlLight", COLOR_3DLIGHT},
{"InfoText", COLOR_INFOTEXT},
{"Info", COLOR_INFOBK},
{"HotTrack", COLOR_HOTLIGHT},
{"GradientActiveCaption", COLOR_GRADIENTACTIVECAPTION},
{"GradientInactiveCaption", COLOR_GRADIENTINACTIVECAPTION},
{"MenuHighlight", COLOR_MENUHILIGHT},
{"MenuBar", COLOR_MENUBAR}
        };

        [DllImport("user32.dll")]
        public static extern uint GetSysColor(int nIndex);
    }

    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            int i = 0;
            
            foreach (var entry in user32.map)
            {
                var c = ColorTranslator.FromWin32((int)user32.GetSysColor(entry.Value));
                var name = entry.Key;
                var p = new Panel() { Width = 60, Height = 30,
                    BackColor = c,
                    BorderStyle = BorderStyle.Fixed3D,
                    Top = i * 40,
                    Left = 180,
                };
                p.Click += (_1, _2) => {
                    ColorDialog cd = new ColorDialog();
                    cd.Color = c;
                    cd.FullOpen = true;
                    if (cd.ShowDialog() == DialogResult.OK)
                    {
                        var res = cd.Color;
                        user32.SetSysColors(1, 
                            new int[] { entry.Value }, 
                            new uint[] { (uint)ColorTranslator.ToWin32(res) });
                        p.BackColor = res;
                    }
                };
                var t = new Label() { Text = name, Top = i*40, Width = 160, Height = 30 };
                panel1.Controls.Add(t);
                panel1.Controls.Add(p);
                i++;
            }
        }

    }
}
