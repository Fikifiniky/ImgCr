using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ImgCreator
{
    public partial class Form1 : Form
    {
        /*
         * strechtnout tak 50 šířka a 120 výška
         * udělat porovnání a uložení avg barvy obrázku
         */


        private ImageAnalyzer analyzer;
        private ImageBuilder builder;
        public Form1()
        {
            InitializeComponent();
            analyzer = new ImageAnalyzer();
            
        }

        private void btn_Analyze_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog fbd = new FolderBrowserDialog();
            fbd.ShowDialog(); // pak vyresit kontrolu, zda neco bylo zvoleno apod...
            analyzer.AnalyzeImages(fbd.SelectedPath);

            MessageBox.Show("Done! All images have been analyzed!");
        }

        private void btn_PickImage_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "Image files (*.jpg, *.jpeg, *.jpe, *.jfif, *.png) | *.jpg; *.jpeg; *.jpe; *.jfif; *.png";
            ofd.ShowDialog(); // pak vyresit kontrolu, zda neco bylo zvoleno apod..

            builder = new ImageBuilder(Image.FromFile(ofd.FileName), analyzer);
            builder.ConvertImage();
        }
    }
}
