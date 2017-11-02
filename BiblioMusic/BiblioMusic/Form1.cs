using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BiblioMusic
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnCargar_Click(object sender, EventArgs e)
        {
            String formatos="";
            foreach (var chk in chklstFormatos.CheckedItems) {
                formatos += "."+chk.ToString()+"|";
            }

            string[] extensions = formatos.Split('|');
            DirectoryInfo dinfo = new DirectoryInfo(txtRuta.Text);
            FileInfo[] files = dinfo.GetFiles().Where(f => extensions.Contains(f.Extension.ToLower())).ToArray();

            
            foreach (var fi in files)
            {
                TagLib.File Mp3file = TagLib.File.Create(fi.FullName);
                lstCanciones.Items.Add(Mp3file);
                lstCanciones.DisplayMember = "Mp3file.Tag.Title";
            }
        }

        private void lstCanciones_SelectedIndexChanged(object sender, EventArgs e)
        {
            var curItem = lstCanciones.SelectedItem;
        }
    }
}
