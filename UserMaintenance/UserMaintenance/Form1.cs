using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using UserMaintenance.Entities;

namespace UserMaintenance
{
    

    public partial class Form1 : Form
    {
        BindingList<User> users = new BindingList<User>();
        public Form1()
        {
            InitializeComponent();
            button2.Text = Resource1.File;
            label1.Text = Resource1.String1; // label1

            button3.Text = Resource1.Delete;
            button1.Text = Resource1.String3; // button1

            listBox1.DataSource = users;
            listBox1.ValueMember = "ID";
            listBox1.DisplayMember = "FullName";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var u = new User()
            {
                FullName = textBox1.Text,
                
            };
            users.Add(u);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog();
          
            sfd.DefaultExt = "txt";
            sfd.AddExtension = true;
            sfd.Filter = "TXT file (*.txt)|*.txt";
            if (sfd.ShowDialog() != DialogResult.OK) return;

            using (StreamWriter sw = new StreamWriter(sfd.FileName, true, Encoding.UTF8))
            {
                for (int i = 0; i < users.Count; i++)
                {
                    sw.WriteLine(users[i].FullName);
                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            users.RemoveAt(listBox1.SelectedIndex);
        }
    }
}
