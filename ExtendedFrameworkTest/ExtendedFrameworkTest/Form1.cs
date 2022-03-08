using ExtendedFramework.Core;
using ExtendedFramework.Core.ExtendedFrameworkAttribute;
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

namespace ExtendedFrameworkTest
{
    public partial class Form1 : Form
    {
        DataChangeEntity dataChangeEntity;
        int i1 = 0;
        int i2 = 0;
        public Form1()
        {
            InitializeComponent();
            SignalSoltRegister.AddSolt("ExtendedFrameworkTest.DataChangeEntity", (key, item) =>
            {
            });
            SignalSoltRegister.AddSolt("DataChangeEntity", (key, item) =>
            {
                this.Invoke(new Action(() =>
                {
                    this.Text = "Form1 " + (++i1) + " " + i2;
                }));
            });
            SignalSoltRegister.AddSolt("DataChangeEntity_Type", (key, item) =>
            {
                this.Invoke(new Action(() =>
                {
                    this.Text = "Form1 " + i1 + " " + (++i2);
                }));
            });
        }

        private void button1_Click(object sender, EventArgs e)
        {
            dataChangeEntity = DataChangeEntity.New();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (dataChangeEntity == null)
            {
                MessageBox.Show("对象不能为空");
                return;
            }

            dataChangeEntity.Type = 1;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            dataChangeEntity = DataChangeEntity.New();
            dataChangeEntity.Type = 1;
        }
    }

    [SignalSolt("DataChangeEntity")]
    public class DataChangeEntity : FEntity<DataChangeEntity>
    {
        [SignalSolt("DataChangeEntity_Type")]
        public virtual int Type { get; set; } = 0;
        /// <summary>
        /// 新建.
        /// 固定格式.
        /// </summary>
        /// <returns></returns>
        public static DataChangeEntity New(string objectID = null)
        {
            return SignalSoltNewEntity.New<DataChangeEntity>(objectID);
        }

        /// <summary>
        /// 保存至本地.
        /// 固定格式.
        /// </summary>
        public virtual void Save()
        {
            //SignalSoltNewEntity.SaveEntity<CompanyEntity>(Guid.NewGuid().ToString(), this);
            //上传服务器
        }
    }
}
