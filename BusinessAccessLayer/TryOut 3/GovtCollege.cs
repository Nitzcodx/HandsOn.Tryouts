using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessAccessLayer.Constants;

namespace BusinessAccessLayer.TryOut_3
{
    public class GovtCollege:College
    {
        private Address govtCollegeAddress;

        public Address GovtCollegeAddress { get => govtCollegeAddress; set => govtCollegeAddress = value; }

        public GovtCollege()
        {
        }
        public GovtCollege(string collegeName, Address address) : base(collegeName)
        {
            GovtCollegeAddress = address;
        }

        public void CalculateFeesBasedOnMarks(Student studentObj)
        {
            studentObj.CollegeFees = (studentObj.Marks > 80) ?
                                        GovernmentCollegeConstants.ScholarshipFees :
                                        GovernmentCollegeConstants.Fees;
        }
        public void CalculateFeeBasedOnSportsQuota(Student studentObj)
        {
            if(studentObj.SportsQuota)
                studentObj.CollegeFees -= GovernmentCollegeConstants.SportsQuotaDiscount;
        }
        public void SetFees(Student studentObj)
        {
            try
            {
                StudentDelegate studentDelegate = new StudentDelegate(CalculateFeesBasedOnMarks);
                studentDelegate += CalculateFeeBasedOnSportsQuota;
                studentDelegate(studentObj);
            }
            catch (Exception)
            {
                throw;
            }
            
        }
    }
}
