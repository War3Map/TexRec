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
    public class Image
    {

        
        public string Filename { get;private set; }
        public Image(string imageFilename)
        {
            Filename = imageFilename;

        }

        public Image<Bgr, Byte> Data
        {
            get {return new Image<Bgr, byte>(Filename); }            
        }

        /// <summary>
        /// Конвертирует картинку в серую.
        /// </summary>
        public void ConvertToGray(string newPath)
        {
            FileStream fileStream = new FileStream(newPath, FileMode.OpenOrCreate, FileAccess.Write);           
            Image<Bgr, Byte> sourceImage = new Image<Bgr, byte>(Filename);
            Image<Gray, byte> grayImage = sourceImage.Convert<Gray, byte>();
            grayImage.ToBitmap().Save(fileStream, ImageFormat.Png);
            fileStream.Close();           
        }


    }
}
