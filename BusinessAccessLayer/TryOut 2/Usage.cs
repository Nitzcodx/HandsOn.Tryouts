using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessAccessLayer.TryOut_2
{
    public class Usage
    {
        public int CallDurationInMins { get; set; }
        public int DataUsageInGB { get; set; }
        public int NumberOfSmsSent { get; set; }

        public Usage()
        {

        }
        public Usage(int dataUsage, int callDurationInMins, int numberOfSmsSent)
        {

        }
    }
}
