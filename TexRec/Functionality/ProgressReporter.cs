using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TexRec.Functionality
{
    class ProgressReporter
    {
        public int CurrentProgress {get; set;}
        public int MaxProgress { get; set; }
        public int Percentage { get
            {

                return (MaxProgress!=0) ? 
                   (int)((double)CurrentProgress / MaxProgress*100):
                    throw new Exception("MaxProgress должен иметь значение больше 0.");
            }
                  }


    }
}
