using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Memory;

namespace brotato
{
    public partial class Form1 : Form
    {

        Mem m = new Mem();
        
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            m.OpenProcess("Brotato.exe");
            panel1.Visible = true;
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                timer1.Start();  // CheckBox işaretliyse timer başlasın
            }
            else
            {
                timer1.Stop();   // İşaret kaldırılırsa timer dursun
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            timer1.Interval = 100;  // Her 100 ms'de bir kontrol et
            timer1.Tick += new EventHandler(timer1_Tick);

        }

        // Örnek adresler : 1AB85BA9FA0 - 7FF6EA3FB5A5... // Pointer'ı bulmalısınız!
        private void timer1_Tick(object sender, EventArgs e)
        {
            if (checkBox1.Checked == true)
            {
                m.WriteMemory("289C56725E0", "byte", "FF");  // 255 ekle // Find memory pointer.
            }
            else
            {
                m.WriteMemory("289C56725E0", "byte", "30");  // 1 ekle

            }
        }

    }
}
