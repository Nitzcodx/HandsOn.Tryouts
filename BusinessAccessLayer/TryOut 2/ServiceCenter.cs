using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessAccessLayer.Enums;

namespace BusinessAccessLayer.TryOut_2
{
    public class ServiceCenter
    {
        public string LocationId { get; set; }
        public long PhoneNumber { get; set; }

        public ServiceCenter()
        {

        }
        public ServiceCenter(long phoneNumber, string locationId)
        {
            PhoneNumber = phoneNumber;
            LocationId = locationId;
        }

        public virtual int MakePayment(double amountPaid, out string billId, bool notifyBySms)
        {
            billId = null;
            return 0;
        }

        public virtual bool ValidatePlanDetails(List<PostPaidPlan> availablePostPaidPlans)
        {
            return false;
        }
    }
}
