using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UI
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            foreach (Cypher c in Cyphers)
            {
                //PAN_Cyphers.Controls.Add();
            }
            
        }

        private void BTN_1_Click(object sender, EventArgs e)
        {
                        
        }
    }
}
