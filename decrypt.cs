using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace IMG_STEGO
{
    public class decrypt
    {
        public void LSBDec(string imagelocation, string destination)
        {
            int m = 0, n = 0, y = 0, h, r, s, i;
            // Bitmap img = new Bitmap(@"C:\Users\Dharupal\Desktop\x.bmp");
            Bitmap img = new Bitmap(imagelocation);
            Color slastpix = img.GetPixel(img.Width - 2, img.Height - 2);
            int q = slastpix.B;
            Console.Write("q is " + q);
            if (q == 1)
            {

                Color lastpixel = img.GetPixel(img.Width - 1, img.Height - 1);
                //  Console.Write("in decrpt mode...r" + lastpixel.R + "\tg" + lastpixel.G + "\tb" + lastpixel.B);
                int size1 = lastpixel.B, val;
                //    int size = 6,val;
                // int i, m=0, n=0, y = 0,h;

                y = 0;
                Console.Write("\n size is:" + size1);
                int[] a = new int[8];
                //right
                r = img.Width / 8;
                r = (r * 8);
                s = ((int)size1 * 8 / r) + 1;
                System.Text.StringBuilder sb = new System.Text.StringBuilder();

                for (m = 0; m < s; m++)
                {
                    //   Console.Write("inside first loop");
                    for (n = 0; n <= r - 8; n = n + 8)
                    {
                        //   Console.Write("inside double loop");
                        if (y < size1)
                        {
                            //    Console.Write("inside if");
                            for (h = 0; h < 8; h++) a[h] = 0;
                            i = 0;

                            //  Console.Write("\nm is" + m + "\t n is" + n);
                            //   Console.Write("binary..");
                            for (h = 0; h < 8; h++)
                            {

                                Color pixel12 = img.GetPixel(n + h, m);
                                int b = pixel12.B;
                                //  Console.Write("");
                                a[h] = (b % 2);

                                Console.Write(a[h]);
                            }


                            val = binaryTo_decimal(a);
                            char text = Convert.ToChar(val);

                            // Console.Write(text);
                            sb.Append(text);
                            y++;
                            //Console.Write("\nchar's value" + text + "\ty's value:" + y);
                        }
                    }

                }
                Console.Write("\nmsg is" + sb.ToString());
                string path1 = null;

                StreamWriter file = new StreamWriter(destination);
                file.Close();
                file = new StreamWriter(destination);
                file.WriteLine(sb.ToString());
                file.Close();
                MessageBox.Show("YOUR IMAGE IS DECRYPTED..SUCCESSFULLY!!!");

            }
            else
                MessageBox.Show("Sorry..you select wrong method to decrypt");
        }
        public int binaryTo_decimal(int[] a)
        {
            int value = 0;
            int base_value = 1, i = 7;
            while (i >= 0)
            {

                value += (a[i] * base_value);
                base_value *= 2;
                i--;
            }
            return value;

        }



        public void changBDecr(string imagelocation, string destination)
        {
            Bitmap img = new Bitmap(imagelocation);
            Color slastpix = img.GetPixel(img.Width - 2, img.Height - 2);
            int q = slastpix.B;

            Console.Write("\n Q value is " + q);
            if (q == 2)
            {

                Console.Write("\n\nIN DECODE");
                char m;
                int z = 0;
                System.Text.StringBuilder sb = new System.Text.StringBuilder();
                Color lastpix = img.GetPixel(img.Width - 1, img.Height - 1);
                int size1 = lastpix.B;
               // Console.Write("size is..." + size);
                for (int i = 0; i < img.Height; i++)
                {
                    for (int j = 0; j < img.Width; j++)
                    {
                        if (z < size1)
                        {




                            //  Console.Write("\ni is" + i + "\t j is" + j);
                            //   Console.Write("binary..");


                            Color pixel12 = img.GetPixel(j, i);
                            int c = Convert.ToInt32(pixel12.B);
                            //  Console.Write("");
                            m = Convert.ToChar(c);


                            sb.Append(m);
                            z++;
                        }
                        else
                            break;
                    }


                }
                string path1 = null;

                Console.Write("\nmsg is \t" + sb.ToString());

                StreamWriter file = new StreamWriter(destination);
                file.Close();
                file = new StreamWriter(destination);
                file.WriteLine(sb.ToString());
                file.Close();
                MessageBox.Show("YOUR IMAGE IS DECRYPTED..SUCCESSFULLY!!!");

            }
            else
            {
                MessageBox.Show("Sorry..you select wrong method to decrypt");
            }
        }
    }
}