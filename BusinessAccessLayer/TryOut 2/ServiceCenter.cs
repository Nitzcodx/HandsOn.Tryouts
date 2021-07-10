using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

        }

        public virtual int MakePayment(double amountPaid, out string billId, bool notifyBySms){}

        public virtual bool ValidatePlanDetails(List<string> availablePostPaidPlans) { }
    }
}
