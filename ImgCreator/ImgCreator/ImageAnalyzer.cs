using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Drawing;
using System.Windows.Forms;
using System.Drawing.Imaging;
using Microsoft.VisualBasic;
using System.Threading;
using System.Drawing.Drawing2D;
using System.Text.RegularExpressions;

namespace ImgCreator
{
    class ImageAnalyzer
    {

        /*public static Dictionary<string, Color> colors = new Dictionary<string, Color>();*/
        public static List<string> colorsS;
        public static List<Color> colorsC;

       

        public void AnalyzeImages(string folder)
        {
            List<FileInfo> files = new List<FileInfo>();
            DirectoryInfo di = new DirectoryInfo(folder);
            files = di.GetFiles().ToList();

            int imgCounter = 0;
            colorsS = new List<string>();
            colorsC = new List<Color>();


            for (int i = 0; i < files.Count; i++)
            {
                Bitmap bmp = (Bitmap)Image.FromFile(files[i].FullName);
                imgCounter++;
                Color average = BitmapUtilities.GetAverageColor(bmp);

                colorsS.Add(files[i].FullName);
                colorsC.Add(BitmapUtilities.GetAverageColor(bmp));
            }
            
            files = null;
            di = null;

            GC.Collect();
            GC.WaitForPendingFinalizers();


        }

        //získá cestu k obrázku, který má průměrnou barvu nejbližší k barvě v parametru
        public string GetClosestColorMatchingImage(Color color)
        {
            int closestMatch = GetClosestColorRGBIndex(color);

            return colorsS.ElementAt(closestMatch); //nebo proste colortsS[closestMatch]... ale toto vypada vice kůl

        }
    
        private int GetClosestColorRGBIndex(Color color)
        {
            //1 IQ reseni, ale funguje zatim spolehlive

            Color first = colorsC[0];
            int distance = (int)Math.Sqrt(Math.Pow(first.R - color.R, 2) + Math.Pow(first.G - color.G, 2) + Math.Pow(first.B - color.B, 2));

            int toReturn = 0;

            for (int i = 0; i < colorsC.Count; i++)
            {
                int colorDist = (int)Math.Sqrt(Math.Pow(colorsC[i].R - color.R, 2) + Math.Pow(colorsC[i].G - color.G, 2) + Math.Pow(colorsC[i].B - color.B, 2));

                if (colorDist < distance)
                {
                    distance = colorDist;
                    toReturn = i;
                }

            }
            return toReturn;
        }




    }
}
