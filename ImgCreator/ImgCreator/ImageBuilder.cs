using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ImgCreator
{
    class ImageBuilder
    {
        private Bitmap sourceImage;
        private ImageAnalyzer imageAnalyzer;

        public ImageBuilder(Image source, ImageAnalyzer analyzer)
        {
            sourceImage = (Bitmap)source;
        }

        public ImageBuilder(Bitmap source, ImageAnalyzer analyzer)
        {
            sourceImage = source;
        }

        public void ConvertImage()
        {

            //pokud to teda budu posilat dal a nenecham si to jen pro sebe, tak osetrit vstupy
            bool debugMode = false;
            Bitmap finalImage;

            string input = Interaction.InputBox("ImgPerX;ImgPerY;imgScale", "Pocet", "", 20, 20);
            string[] separated = input.Split(';');

            int imgPerX = int.Parse(separated[0]);
            int imgPerY = int.Parse(separated[1]);
            int imgScale = int.Parse(separated[2]);

            if (separated.Length > 3 && separated[3] != "")
            {
                debugMode = true;
            }

            finalImage = new Bitmap(sourceImage.Width * imgScale, sourceImage.Height * imgScale); //20
            int originalSingleRegionWidth = sourceImage.Width / imgPerX;
            int originalSingleRegionHeight = sourceImage.Height / imgPerY;

            int singleWidth = finalImage.Width / imgPerX;
            int singleHeight = finalImage.Height / imgPerY; //osetrit, aby tam nebyla moc velka cisla, ktera by dala vice obrazku na jednu osu, nez je cela delka v pixelech


            for (int y = 0; y < imgPerY; y++)
            {
                for (int x = 0; x < imgPerX; x++)
                {
                   
                    using (Bitmap region = BitmapUtilities.GetBitmapRegion(sourceImage, x * originalSingleRegionWidth, y * originalSingleRegionHeight, originalSingleRegionWidth, originalSingleRegionHeight))
                    {
                        Color avgRegion = BitmapUtilities.GetAverageColor(region);

                        string imageFileName = imageAnalyzer.GetClosestColorMatchingImage(avgRegion);

                        using (Graphics g = Graphics.FromImage(finalImage))
                        {

                            using (FileStream stream = new FileStream(imageFileName, FileMode.Open, FileAccess.Read))
                            {

                                using (Image toResize = Image.FromStream(stream))
                                {
                                    Image toDraw = BitmapUtilities.ResizeImage(toResize, singleWidth, singleHeight);
                                    g.DrawImage(toDraw, x * singleWidth, y * singleHeight/*, singleWidth, singleHeight*/);

                                    if (debugMode)
                                    {
                                        string imgNumber = Regex.Match(imageFileName, @"\d+").Value;
                                        g.DrawString(imgNumber, new Font(FontFamily.GenericSansSerif, 10f, FontStyle.Regular), Brushes.Red, x * singleWidth, y * singleHeight);
                                    }
                                    

                                    //tady byla zajimava chyba v .NET ze using ktery ma na konci volat ukonceni a uvolneni z pameti to nedelal, takze je vse pro jistotu v usingu
                                }
                            }

                        }
                    }



                }


            }

            finalImage.Save(String.Format(@"D:\finalimage_{0}x_{1}y_{2}s.jpg", imgPerX, imgPerY, imgScale)); //pokud pujde ven, tak udelat openfiledialog
        }

        
    }
}
