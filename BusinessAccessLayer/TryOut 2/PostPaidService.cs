using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessAccessLayer.Constants;
using BusinessAccessLayer.Enums;

namespace BusinessAccessLayer.TryOut_2
{
    public class PostPaidService:ServiceCenter
    {
        private static int counter;

        public double CallRatePerMinute { get; set; }
        public double CarryForward { get; set; }
        public double DataRate { get; set; }
        public PostPaidPlan PostPaidPlan { get; set; }
        public double SmsRate { get; set; }
        public Usage Usage { get; set; }

        static PostPaidService()
        {
            counter = 1;
        }
        public PostPaidService()
        {

        }
        public PostPaidService(
                                Usage usage,
                                PostPaidPlan postPaidPlan,
                                double carryForward,
                                long phoneNumber,
                                string location
                              ):base(phoneNumber,location)
        {
            Usage = usage;
            PostPaidPlan = postPaidPlan;
            CarryForward = carryForward;
        }

        public override int MakePayment(double amountPaid, out string billId, bool notifyBySms)
        {
            double billAmount = CalculatePostPaidBill();
            if (amountPaid >= billAmount)
            {
                CarryForward = amountPaid - billAmount;
                billId = PostPaidServiceConstants.BillIdPrefix + (counter++).ToString();
                return 1;
            }
            else
            {
                billId = PostPaidServiceConstants.InvalidBillId;
                return -1;
            }
            
        }

        public override bool ValidatePlanDetails(List<PostPaidPlan> availablePostPaidPlans)
        {
            var _query = from plans in availablePostPaidPlans
                        where plans.Equals(PostPaidPlan)
                        select plans;
            if (_query == null) return false;
            return true;
        }

        public double CalculatePostPaidBill()
        {
            double bill;
            GetPhoneRates();
            if(PostPaidPlan is PostPaidPlan.BP)
            {
                bill = PostPaidServiceConstants.BPBill - CarryForward;
            }
            else
            {
                bill = (Usage.CallDurationInMins * CallRatePerMinute) +
                       (Usage.NumberOfSmsSent * SmsRate) +
                       (Usage.DataUsageInGB * DataRate) -
                       CarryForward;
            }
            return bill;
        }
        public void GetPhoneRates()
        {
            switch (PostPaidPlan)
            {
                case PostPaidPlan.BP:
                    {
                        CallRatePerMinute = PostPaidServiceConstants.BPCallRate;
                        SmsRate = PostPaidServiceConstants.BPSmsRate;
                        DataRate = PostPaidServiceConstants.BPDataRate;
                        break;
                    }
                case PostPaidPlan.FSP:
                    {
                        CallRatePerMinute = PostPaidServiceConstants.FSPCallRate;
                        SmsRate = PostPaidServiceConstants.FSPSmsRate;
                        DataRate = PostPaidServiceConstants.FSPDataRate;
                        break;
                    }
                case PostPaidPlan.CP:
                    {
                        CallRatePerMinute = PostPaidServiceConstants.CPCallRate;
                        SmsRate = PostPaidServiceConstants.CPSmsRate;
                        DataRate = PostPaidServiceConstants.CPDataRate;
                        break;
                    }
            }
        }
    }
}
