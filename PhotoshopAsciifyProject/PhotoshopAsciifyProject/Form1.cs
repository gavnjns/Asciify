using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
namespace PhotoshopAsciifyProject
{

    public partial class AsciifyForm : Form
    {
        public Form AsciifyFor = new Form();
        public AsciifyForm()
        {
            InitializeComponent();
        }

        private void OpenPic(object sender, EventArgs e)
        {
            openFileDialog1.Filter = "jpg files (*.jpg)|*.jpg|All files (*.*)|*.*";
            openFileDialog1.Title = "Please pick your image";
            openFileDialog1.ShowDialog();
        }

        private void ValueChange1(object sender, EventArgs e)
        {
            BitmapAscii Asciify = new BitmapAscii();
            pictureBox3.Height = (int)numericUpDown1.Value * 4;
            pictureBox3.Width = (int)numericUpDown2.Value * 4;
        }

        private void ValueChange2(object sender, EventArgs e)
        {
            BitmapAscii Asciify = new BitmapAscii();
            pictureBox3.Height = (int)numericUpDown1.Value * 4;
            pictureBox3.Width = (int)numericUpDown2.Value * 4;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            BitmapAscii Asciify = new BitmapAscii();
            Asciify.one = textOne.Text;
            Asciify.two = textTwo.Text;
            Asciify.three = textThree.Text;
            Asciify.four = textFour.Text;
            Asciify.five = textFive.Text;
            Asciify.six = textSix.Text;
            Bitmap Bitmp = new Bitmap(pictureBox1.Image);
            richTextBox1.Text = Asciify.Ascitize(Bitmp, (int)numericUpDown1.Value, (int)numericUpDown2.Value);           
        }


        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if(checkBox1.Checked == true)
            {
                timer1.Start();

            }
            else
            {
                timer1.Stop();
            }

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            BitmapAscii Asciify = new BitmapAscii();
            Asciify.one = textOne.Text;
            Asciify.two = textTwo.Text;
            Asciify.three = textThree.Text;
            Asciify.four = textFour.Text;
            Asciify.five = textFive.Text;
            Asciify.six = textSix.Text;
            Bitmap Bitmp = new Bitmap(pictureBox1.Image);
            richTextBox1.Text = Asciify.Ascitize(Bitmp, (int)numericUpDown1.Value, (int)numericUpDown2.Value);
        }

        private void openFileDialog1_FileOk(object sender, CancelEventArgs e)
        {

            Bitmap colorPic = new Bitmap(openFileDialog1.FileName);
            pictureBox1.Image = colorPic;
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            Bitmap BmpImage = new Bitmap(pictureBox1.Image);

            for (int y = 0; y < BmpImage.Height; y += 1)
            {
                for (int x = 0; x < BmpImage.Width; x += 1)
                {
                    Color col_pixel = BmpImage.GetPixel(x, y);

                    int gray_value = (int)(col_pixel.R * .21 + col_pixel.G * .72 + col_pixel.B * .07);

                    Color gray_pixel = Color.FromArgb(gray_value, gray_value, gray_value);

                    BmpImage.SetPixel(x, y, gray_pixel);
                }
            }
            pictureBox3.Image = BmpImage;
            pictureBox3.Height = (int)numericUpDown1.Value * 4;
            pictureBox3.Width = (int)numericUpDown2.Value * 4;
            pictureBox3.SizeMode = PictureBoxSizeMode.StretchImage;
        }
    }
}
