using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Windows.Globalization.NumberFormatting;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using static RecRoomPainter.MainForm;


namespace RecRoomPainter
{
    public partial class RunningProgressBar : Form
    {
        public RunningProgressBar()
        {
            this.StartPosition = FormStartPosition.Manual;
            this.Location = new System.Drawing.Point(0, 0);
            this.FormBorderStyle = FormBorderStyle.FixedToolWindow;
            this.TopMost = true;
            InitializeComponent();
        }

        protected override bool ShowWithoutActivation => true;

        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams cp = base.CreateParams;
                cp.ExStyle |= 0x20; // WS_EX_TRANSPARENT makes the window click-through.
                return cp;
            }
        }

        public void UpdateProgress(int currentValue, int endValue, int time)
        {
            try
            {
                timeLabel.Text = ConvertMillisecondsToTimeFormat(time);
            }
            catch {
                timeLabel.Text = "D00:H00:M00:S00";
            }
            try
            {
                int percent = (int)((double)(endValue - currentValue) / endValue * 100);
                runningProgressBar1.Value = percent;
                runningLabel.Text = $"{percent}%\n{(endValue - currentValue)}/{endValue}";
            }
            catch
            {
                runningProgressBar1.Value = 0;
                runningLabel.Text = $"0%\n0/0";
            }
        }
    }
}

