using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace IMG_STEGO
{
   public class encrypt
    {
        public void convert_to_bin(int a, int[] bin)
        {
            int i = 0, tmp, b, j;
            b = a;
            int[] temp = new int[8];
            while (i < 8)
            {
                tmp = b % 2;
                temp[i] = tmp;

                b = b / 2;
                i++;
            }
            i = 0;
            for (j = 7; j >= 0; j--)
            {
                bin[i] = temp[j];
                i++;
            }
        }
       
       public void LSBchange(string imagelocation,string textlocation,long size)
       {
           if ((int)size > 253)
               MessageBox.Show("Text file is sooo big");

           Bitmap img = new Bitmap(imagelocation);

           int j, m, n, y = 0, i;
           //char msg ='A';
           string msg = System.IO.File.ReadAllText(textlocation);

           int r = img.Width / 8;
           r = (r * 8);
           int s = ((int)size * 8 / r) + 1;

           if (size * 8 > img.Width * img.Height)
           {

           }

           //      Console.Write("\n\nwidth " + img.Width + "\theight is" + img.Height + "and size " + size + "\tr is" + r + "\t s is " + s + "\tr is " + r);
           for (m = 0; m < s; m++)
           {

               for (n = 0; n < r - 8; n = n + 8)
               {

                   if (y < size)
                   {
                       char z = msg[y];
                       int[] bin = new int[8];
                       int digit = Convert.ToInt32(z);
                       convert_to_bin(digit, bin);
                       //      Console.Write("\nchar" + z);
                       //      Console.Write("\tbinary array:");
                       for (j = 0; j < 8; j++)
                           //       Console.Write(bin[j]);
                           for (i = 0; i < 8; i++)
                           {
                               Color pixel1 = img.GetPixel(n + i, m);
                               int b = pixel1.B;
                               //      Console.Write("\nm's value" + m + "\tn's value" + (n+i));
                               //        Console.Write("\n.....befor updation...r:" + pixel1.R + "\t g:" + pixel1.G + "\tb:" + pixel1.B);
                               if (b % 2 == 0 && bin[i] == 1)
                               {
                                   b++;
                               }
                               else if (b % 2 == 1 && bin[i] == 0)
                               {
                                   b--;
                               }
                               img.SetPixel(n + i, m, Color.FromArgb(pixel1.R, pixel1.G, b));
                               pixel1 = img.GetPixel(n + i, m);
                               //     Console.Write("\n.....After updation...r:" + pixel1.R + "\t g:" + pixel1.G + "\tb:" + pixel1.B);
                           }

                   }
                   y++;

               }
           }
           Color pixel2 = img.GetPixel(img.Width - 1, img.Height - 1);
           img.SetPixel(img.Width - 1, img.Height - 1, Color.FromArgb(pixel2.R, pixel2.G, (int)size));
           pixel2 = img.GetPixel(img.Width - 2, img.Height - 2);
           img.SetPixel(img.Width - 2, img.Height - 2, Color.FromArgb(pixel2.R, pixel2.G, 1));

           //   Console.Write("\nlast pixelll...r:"+pixel2.R+"\tg:"+pixel2.G+"\tb:"+pixel2.B);
           SaveFileDialog savefile = new SaveFileDialog();
           savefile.Filter = "Image Files(*.bmp)| ; *.bmp";

           if (savefile.ShowDialog() == DialogResult.OK)
           {
             //  textBox1.Text = savefile.FileName.ToString();
              // pictureBox1.ImageLocation = textBox1.Text;
               img.Save(savefile.FileName.ToString());
           }
           MessageBox.Show("YOUR IMAGE IS INCRYPTED..SUCCESSFULLY!!!");
       }

       public void changeB(string imagelocation, string textlocation, long size)
       {

           if ((int)size > 253)
               MessageBox.Show("Text file is sooo big");
           int y = 0;
           string msg = System.IO.File.ReadAllText(textlocation);
           Bitmap img = new Bitmap(imagelocation);
           for (int i = 0; i < img.Height; i++)
           {
               for (int j = 0; j < img.Width; j++)
               {
                   Color pixel = img.GetPixel(j, i);
                   if (y < size)
                   {
                       char ch = msg[y];
                       int digit = Convert.ToInt32(ch);

                       img.SetPixel(j, i, Color.FromArgb(pixel.R, pixel.B, digit));
                   }
                   if (i == img.Height - 1 && j == img.Width - 1)
                   {
                       img.SetPixel(j, i, Color.FromArgb(pixel.R, pixel.G, (int)size));
                   }
                   if (i == img.Height - 2 && j == img.Width - 2)
                   {
                       img.SetPixel(j, i, Color.FromArgb(pixel.R, pixel.G, 2));
                   }
                   y++;
               }


           }
           SaveFileDialog savefile = new SaveFileDialog();
           savefile.Filter = "Image Files(*.bmp)| ; *.bmp";

           if (savefile.ShowDialog() == DialogResult.OK)
           {
               // textBox1.Text = savefile.FileName.ToString();
               // pictureBox1.ImageLocation = textBox1.Text;
               img.Save(savefile.FileName.ToString());
           }
           MessageBox.Show("YOUR IMAGE IS INCRYPTED..SUCCESSFULLY!!!");
       }
    }
   
}
