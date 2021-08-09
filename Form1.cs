using MediaToolkit;
using System;
using System.IO;
using System.Windows.Forms;
using VideoLibrary;


namespace Proje
{
    public partial class Form1 : Form
    {



        Boolean Format;


        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }





        private void button1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }




        private async void Button2_Click(object sender, EventArgs e)
        {

            using (FolderBrowserDialog fbd = new FolderBrowserDialog() { Description = "Lütfen Klasör Seçiniz!" })
            {

                if (fbd.ShowDialog() == DialogResult.OK)
                {
                    MessageBox.Show("İndirme Başladı , Lütfen Bekleyiniz......", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    var yt = YouTube.Default;
                    var video = await yt.GetVideoAsync(link.Text);
                    File.WriteAllBytes(fbd.SelectedPath + @"\" + video.FullName, await video.GetBytesAsync());


                    var inputfile = new MediaToolkit.Model.MediaFile { Filename = fbd.SelectedPath + @"\" + video.FullName };

                    var outputfile = new MediaToolkit.Model.MediaFile { Filename = $"{fbd.SelectedPath + @"\" + video.FullName }.mp3" };







                    using (var enging = new Engine())
                    {
                        enging.GetMetadata(inputfile);

                        enging.Convert(inputfile, outputfile);
                    }

                    if (Format == true)
                    {
                        File.Delete(fbd.SelectedPath + @"\" + video.FullName);
                    }

                    if (Format == false)
                    {
                        File.Delete($"{fbd.SelectedPath + @"\" + video.FullName}.mp3");
                    }



                    progressBar1.Value = 100;

                    MessageBox.Show("İndirme İşlemi Tamamlandı....", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    progressBar1.Value = 0;
                }

                else
                {
                    MessageBox.Show("Lütfen bir Dosya Yolu Seçiniz...", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void mp3_CheckedChanged(object sender, EventArgs e)
        {
            Format = true;
        }

        private void mp4_CheckedChanged(object sender, EventArgs e)
        {
            Format = false;
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("https://github.com/Hasan-H-KARAKAYA");
        }

        private void pictureBox1_MouseEnter(object sender, EventArgs e)
        {
          
        }
    }
}

