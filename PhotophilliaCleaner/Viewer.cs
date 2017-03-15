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
using Edge.Enviroment;
using WhetStone.Looping;

namespace PhotophilliaCleaner
{
    public partial class Viewer : Form
    {
        private readonly string _rawdir;
        private readonly string[] _dests;
        public Viewer(string rawdir, string[] dests)
        {
            _rawdir = rawdir;
            _dests = dests;
            InitializeComponent();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            foreach (var t in new [] {textBox1, textBox2})
            {
                if (!t.Text.EndsWith(".png"))
                    t.Text += ".png";
            }
            string path1 = Path.Combine(_rawdir, textBox1.Text);
            string path2 = Path.Combine(_rawdir, textBox2.Text);
            if (!File.Exists(path1) || !File.Exists(path2))
                return;
            pictureBox1.Image = Image.FromFile(path1);
            pictureBox2.Image = Image.FromFile(path2);
        }
        private void Delete(string name)
        {
            foreach (var dir in _dests.Concat(_rawdir.Enumerate()))
            {
                string path = Path.Combine(dir, name);
                if (File.Exists(path))
                    File.Delete(path);
            }
        }
        private void button2_Click(object sender, EventArgs e)
        {
            pictureBox2.Image.Dispose();
            pictureBox2.Image = null;
            var todel = textBox2.Text;
            textBox2.Text = "";
            Delete(todel);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            pictureBox1.Image.Dispose();
            pictureBox1.Image = null;
            var todel = textBox1.Text;
            textBox1.Text = "";
            Delete(todel);
        }

        private void Viewer_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '\r')
                button1.PerformClick();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            textBox1.Text = textBox2.Text = "";
            textBox1.Focus();
        }
    }
}
