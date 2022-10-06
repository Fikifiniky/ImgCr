using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImgCreator
{
    public static class BitmapUtilities
    {
        //StackOverflow genius metoda
        public static Color GetAverageColor(Bitmap bitmap)
        {
            BitmapData srcData = bitmap.LockBits(
                    new Rectangle(0, 0, bitmap.Width, bitmap.Height),
                    ImageLockMode.ReadOnly,
                    PixelFormat.Format32bppArgb);

            int stride = srcData.Stride;

            IntPtr Scan0 = srcData.Scan0;

            long[] totals = new long[] { 0, 0, 0 };

            int width = bitmap.Width;
            int height = bitmap.Height;

            unsafe
            {
                byte* p = (byte*)(void*)Scan0;

                for (int y = 0; y < height; y++)
                {
                    for (int x = 0; x < width; x++)
                    {
                        for (int color = 0; color < 3; color++)
                        {
                            int idx = (y * stride) + x * 4 + color;

                            totals[color] += p[idx];
                        }
                    }
                }
            }

            long avgB = totals[0] / (width * height);
            long avgG = totals[1] / (width * height);
            long avgR = totals[2] / (width * height);

            totals = null;
            bitmap.UnlockBits(srcData);
            srcData = null;
            Scan0 = IntPtr.Zero;

            return Color.FromArgb((int)avgR, (int)avgG, (int)avgB);
        }

        public static Bitmap GetBitmapRegion(Bitmap source, int x, int y, int width, int height)
        {

            Rectangle section = new Rectangle(new Point(x, y), new Size(width, height));

            Bitmap bmp = new Bitmap(section.Width, section.Height);

            using (Graphics g = Graphics.FromImage(bmp))
            {
                g.DrawImage(source, 0, 0, section, GraphicsUnit.Pixel);

            }
            GC.Collect();
            GC.WaitForPendingFinalizers();

            return bmp;

        }
        public static Bitmap ResizeImage(Image image, int width, int height)
        {
            return new Bitmap(image, width, height); //TODO udelat spravne
        }
    }
}
