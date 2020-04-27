using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ColonyLife.BLL;

namespace ColonyLife.PL
{
    public partial class Form1 : Form
    {
        ColonyLife.BLL.Envirenment envirenment;
        List<ColonyInfo> colonyInfo;
        //ListViewItem item;
        int tickCount = 0;
        public Form1()
        {
            InitializeComponent();
            envirenment = new ColonyLife.BLL.Envirenment();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            TimerSwitch();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            timer1.Stop();
            envirenment.Life();
            GetInfo();
            tickCount += 1;
            //timer1.Start();
            if (tickCount == 3)
            {
                //TimerSwitch();
                tickCount = 0;
            }
        }

        private void hScrollBar1_Scroll(object sender, ScrollEventArgs e)
        {
            label2.Text = hScrollBar1.Value.ToString();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            envirenment.setTemperature(hScrollBar1.Value);            
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            envirenment.AddColony(textBox1.Text, Convert.ToInt32(textBox2.Text), Convert.ToInt32(textBox3.Text),
                Convert.ToInt32(textBox4.Text), Convert.ToInt32(textBox5.Text), Convert.ToInt32(textBox6.Text));
            dataGridView1.Rows.Add();
            GetInfo();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
        private void TimerSwitch()
        {
            if (timer1.Enabled)
            {
                timer1.Stop();
                button1.Text = "Start";
            }
            else
            {
                timer1.Start();
                button1.Text = "Stop";
            }
        }
        private void GetInfo()
        {
            colonyInfo = envirenment.GetInfo();
            int count = colonyInfo.Count;
            for (int i = 0; i < count; i++)
            {
                dataGridView1.Rows[i].SetValues(new string[] { colonyInfo[i].KindName, colonyInfo[i].Count.ToString() });
            }
        }
    }
}
