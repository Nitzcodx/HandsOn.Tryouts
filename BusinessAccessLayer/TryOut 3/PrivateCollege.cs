using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessAccessLayer.Constants;

namespace BusinessAccessLayer.TryOut_3
{
    public class PrivateCollege:College
    {
        private int donation;
        private Address privateCollegeAddress;

        public int Donation { get => donation; set => donation = value; }
        public Address PrivateCollegeAddress { get => privateCollegeAddress; set => privateCollegeAddress = value; }

        public PrivateCollege()
        {
        }

        public PrivateCollege(string collegeName, int donation, Address privateCollegeAddress) : base(collegeName)
        {
            Donation = donation;
            PrivateCollegeAddress = privateCollegeAddress;
        }
        
        public void CalculateFees(Student studentObj)
        {
            studentObj.CollegeFees = (studentObj.Marks > PrivateCollegeConstants.MarksLimit &&
                                        Donation > PrivateCollegeConstants.DonationLimit) ?
                                        PrivateCollegeConstants.Fees -
                                        (Donation * PrivateCollegeConstants.DonationDiscount) :
                                        PrivateCollegeConstants.Fees;
        }
    }
}
