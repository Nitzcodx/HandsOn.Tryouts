using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessAccessLayer.TryOut_2
{
    public class PostPaidService:ServiceCenter
    {
        private int counter;

        public double CallRatePerMinute { get; set; }
        public double CarryForward { get; set; }
        public double DataRate { get; set; }
        public string PostPaidPlan { get; set; }
        public double SmsRate { get; set; }

        public PostPaidService()
        {

        }
        public PostPaidService(Usage usage, string postPaidPlan, double carryForward, long phoneNumber, string location)
        {

        }

        public override int MakePayment(double amountPaid, out string billId, bool notifyBySms)
        {
            return base.MakePayment(amountPaid, out billId, notifyBySms);
        }

        public override bool ValidatePlanDetails(List<string> availablePostPaidPlans)
        {
            return base.ValidatePlanDetails(availablePostPaidPlans);
        }

        public double CalculatePostPaidBill()
        {

        }
        public void GetPhoneRates()
        {

        }
    }
}
