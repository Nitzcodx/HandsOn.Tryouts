using Microsoft.VisualStudio.TestTools.UnitTesting;
using BusinessAccessLayer.TryOut_3;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessAccessLayer.Constants;

namespace BusinessAccessLayer.TryOut_3.Tests
{
    [TestClass()]
    public class PrivateCollegeTests
    {
        Address testAddress = new Address("Line 1", "Line 2", "Barcelona", 278365);
        Student testStudent = new Student("Topper", 90, 'F', true);
        Student teststudent2 = new Student("Cool Student", 70, 'F', false);
        PrivateCollege testPrivateCollege;

        [TestMethod()]
        public void CalculateFeesTest()
        {
            testPrivateCollege = new PrivateCollege("Private University", 105000, testAddress);
            double expectedFees = PrivateCollegeConstants.Fees -
                                    (105000 * PrivateCollegeConstants.DonationDiscount);
            testPrivateCollege.CalculateFees(testStudent);
            Assert.AreEqual(expectedFees, testStudent.CollegeFees);
            expectedFees = PrivateCollegeConstants.Fees;
            testPrivateCollege.CalculateFees(teststudent2);
            Assert.AreEqual(expectedFees, teststudent2.CollegeFees);
        }
    }
}