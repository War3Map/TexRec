using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Emgu.CV;
using Emgu.Util;
using Emgu.CV.Structure;
using System.Drawing.Imaging;
using System.IO;

namespace ImageProcessor
{
    public class ImageProcessor
    {

        public void CreateGrayScaleFile(string filename,FileStream fileStream)
        {
            Image<Bgr, Byte> sourceImage = new Image<Bgr, byte>(filename);
            Image<Gray, byte> grayImage = sourceImage.Convert<Gray, byte>();
            grayImage.ToBitmap().Save(fileStream, ImageFormat.Png);
        }
    }
}
