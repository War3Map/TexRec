using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ImageProcessor
{
    public class Image
    {

        public string Filename { get;private set; }
        public Image(string imageFilename)
        {
            Filename = imageFilename;

        }
    }
}
