using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessAccessLayer.Enums;

namespace BusinessAccessLayer.Constants
{
    public static class PostPaidServiceConstants
    {
        public const double BPCallRate = 1;
        public const double BPSmsRate = 0.5;
        public const double BPDataRate = 250;

        public const double FSPCallRate = 1.25;
        public const double FSPSmsRate = 0;
        public const double FSPDataRate = 200;

        public const double CPCallRate = 0.95;
        public const double CPSmsRate = 0.55;
        public const double CPDataRate = 300;

        public const int BPBill = 999;

        public const string BillIdPrefix = "T";

        public const string InvalidBillId = "NA";
    }
}
