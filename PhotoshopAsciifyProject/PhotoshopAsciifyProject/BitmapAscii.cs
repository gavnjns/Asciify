using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PhotoshopAsciifyProject
{
    class BitmapAscii
    {
        public string one { get; set; }
        public string two { get; set; }
        public string three { get; set; }
        public string four { get; set; }
        public string five { get; set; }
        public string six { get; set; }

        public string Ascitize(Bitmap BmpImage, int Href, int Wref)
        {
           List<Color> kernel = new List<Color>();
            Color col_pixel = new Color();
            StringBuilder AsciiString = new StringBuilder();
           int Widthlocation = 0;
           int Heightlocation = 0;
            for (int totH = 0; totH < BmpImage.Height; totH += Href)
            {
                for (int totW = 0; totW < BmpImage.Width; totW += Wref)
                {
                    for (int y = 0; y < Href; y += 1)
                    {
                        for (int x = 0; x < Wref; x += 1)
                        {
                            if (Heightlocation + y >= BmpImage.Height)
                            {
                                col_pixel = BmpImage.GetPixel(Widthlocation, Heightlocation);
                                kernel.Add(col_pixel);
                                y += 1;
                            }
                            else if(Widthlocation + x >= BmpImage.Width)
                            {
                                col_pixel = BmpImage.GetPixel(Widthlocation, y + Heightlocation);
                                kernel.Add(col_pixel);
                                y += 1;
                            }
                            else
                            {
                                col_pixel = BmpImage.GetPixel(Widthlocation + x, y + Heightlocation);
                                kernel.Add(col_pixel);
                                y += 1;
                            }


                        }
                    }
                    AsciiString.Append(GrayToString(AverageColor(kernel), one, two, three, four, five, six));
                    kernel.Clear();
                    Widthlocation += Wref;
                }
                Heightlocation += Href;
                Widthlocation = 0;
                AsciiString.Append("\n");
            }
            return AsciiString.ToString();
       }
        public double AveragePixel(int R, int G, int B)
        {
            double gray_value = (R + G + B) / 3;
            return gray_value;
        }

        public double AveragePixel(Color col_pixel)
        {
            double gray_value = ((col_pixel.R * .21) + (col_pixel.G * .72) + (col_pixel.B * .07)) / 255;
            return gray_value;
        }
       
        public double AverageColor(List<Color> Clist)
        {
            double avg = 0;
            for (int i = 0; i < Clist.Count; i++)
            {
                avg = avg + (AveragePixel(Clist[i]));
            }
            return avg / Clist.Count;
        }
       
        public string GrayToString(double num, string one, string two, string three, string four, string five, string six)
        {

            if(num >= 1)
            {
                return one;
            }

            else if(num > .84)
            {
                return two;
            }

            else if(num > .68)
            {
                return three;
            }
            else if(num > .52)
            {
                return four;
            }
            else if(num > .36)
            {
                return five;
            }
            else
            {
                return six;
            }

        }
       
        //public string ToString()
        //{
        //    return 
        //}
    }
}
