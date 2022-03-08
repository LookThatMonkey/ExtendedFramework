using ExtendedFramework.Core.SignalSolt;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ExtendedFrameworkTest2
{
    public partial class Form0 : Form
    {
        int i1 = 0;
        int i2 = 0;
        public Form0()
        {
            InitializeComponent();
            SignalSoltRegister.AddSolt("Test1.DataChangeEntity", (key, item) =>
            {
            });
            SignalSoltRegister.AddSolt("DataChangeEntity", (key, item) =>
            {
                this.Invoke(new Action(() =>
                {
                    this.Text = "Form0 " + (++i1) + " " + i2;
                }));
            });
            SignalSoltRegister.AddSolt("DataChangeEntity_Type", (key, item) =>
            {
                this.Invoke(new Action(() =>
                {
                    this.Text = "Form0 " + i1 + " " + (++i2);
                }));
            });
        }
    }
}
