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
    public class GovtCollegeTests
    {
        Address testAddress = new Address("Line 1", "Line 2", "Barcelona", 278365);
        Student testStudent = new Student("Topper", 90, 'F', true);
        Student teststudent2 = new Student("Cool Student", 70, 'F', false);
        GovtCollege testGovtCollege;

        [TestMethod()]
        public void CalculateFeesBasedOnMarksTest()
        {
            testGovtCollege = new GovtCollege("Govt College", testAddress);
            testGovtCollege.CalculateFeesBasedOnMarks(testStudent);
            float expectedFees = GovernmentCollegeConstants.ScholarshipFees;
            Assert.AreEqual(expectedFees, testStudent.CollegeFees);
            testGovtCollege.CalculateFeesBasedOnMarks(teststudent2);
            expectedFees = GovernmentCollegeConstants.Fees;
            Assert.AreEqual(expectedFees, teststudent2.CollegeFees);
        }

        [TestMethod()]
        public void CalculateFeeBasedOnSportsQuotaTest()
        {
            testGovtCollege = new GovtCollege("Govt College", testAddress);
            testStudent.CollegeFees = 60000;
            testGovtCollege.CalculateFeeBasedOnSportsQuota(testStudent);
            float expectedFees = 60000 - GovernmentCollegeConstants.SportsQuotaDiscount;
            Assert.AreEqual(expectedFees, testStudent.CollegeFees);
            teststudent2.CollegeFees = 60000;
            testGovtCollege.CalculateFeeBasedOnSportsQuota(teststudent2);
            expectedFees = 60000;
            Assert.AreEqual(expectedFees, teststudent2.CollegeFees);
        }

        [TestMethod()]
        public void SetFeesTest()
        {
            testGovtCollege = new GovtCollege("Govt College", testAddress);
            testGovtCollege.SetFees(testStudent);
            float expectedFees = GovernmentCollegeConstants.ScholarshipFees - 
                                    GovernmentCollegeConstants.SportsQuotaDiscount;
            Assert.AreEqual(expectedFees, testStudent.CollegeFees);
            testGovtCollege.SetFees(teststudent2);
            expectedFees = GovernmentCollegeConstants.Fees;
            Assert.AreEqual(expectedFees, teststudent2.CollegeFees);
        }
    }
}