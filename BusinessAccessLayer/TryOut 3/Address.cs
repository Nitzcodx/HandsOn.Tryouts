using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessAccessLayer.Constants;

namespace BusinessAccessLayer.TryOut_3
{
    public class Address
    {
        private int pinCode;
        public string AddressLine1 { get; set; }
        public string AddressLine2 { get; set; }
        public string City { get; set; }
        public int PinCode
        {
            get
            {
                return pinCode;
            }
            set
            {
                pinCode = (value >= AddressConstants.minPinCode && value <= AddressConstants.maxPinCode) ?
                            value :
                            AddressConstants.defaultPinCode;
            }
        }

        public Address()
        {

        }
        public Address(string addressLine1,string addressLine2,string city,int pinCode)
        {
            AddressLine1 = addressLine1;
            AddressLine2 = addressLine2;
            City = city;
            PinCode = pinCode;
        }
    }
}
