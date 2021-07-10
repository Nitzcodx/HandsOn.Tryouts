using Microsoft.VisualStudio.TestTools.UnitTesting;
using BusinessAccessLayer.TryOut_2;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessAccessLayer.Enums;
using BusinessAccessLayer.Constants;


namespace BusinessAccessLayer.TryOut_2.Tests
{
    [TestClass()]
    public class PostPaidServiceTests
    {
        Usage testUsage = new Usage(2, 20, 1);
        ServiceCenter testServiceCenter;
       
        [TestMethod()]
        public void MakePaymentTest()
        {
            string billId = string.Empty;
            testServiceCenter = new PostPaidService(testUsage, PostPaidPlan.BP, 20, 1234567890, "404/F");
            (testServiceCenter as PostPaidService).MakePayment(PostPaidServiceConstants.BPBill, out billId, false);
            string expectedBillId = "T1";
            Assert.AreEqual(expectedBillId, billId);
            (testServiceCenter as PostPaidService).MakePayment(20, out billId, false);
            expectedBillId = PostPaidServiceConstants.InvalidBillId;
            Assert.AreEqual(expectedBillId, billId);
        }

        [TestMethod()]
        public void ValidatePlanDetailsTest()
        {
            
            testServiceCenter = new PostPaidService(testUsage,PostPaidPlan.BP,20, 1234567890,"404/F");
            (testServiceCenter as PostPaidService).PostPaidPlan = Enums.PostPaidPlan.BP;
            Assert.IsTrue(testServiceCenter.ValidatePlanDetails(new List<PostPaidPlan> {
                                                                                            PostPaidPlan.BP,
                                                                                            PostPaidPlan.FSP,
                                                                                            PostPaidPlan.CP
                                                                                        }));
        }
        
        [TestMethod()]
        public void CalculatePostPaidBillTest()
        {
            testServiceCenter = new PostPaidService(testUsage, PostPaidPlan.FSP, 20, 1234567890, "404/F");
            double expectedBill = (20 * PostPaidServiceConstants.FSPCallRate) +
                                    (PostPaidServiceConstants.FSPSmsRate) +
                                    (2 * PostPaidServiceConstants.FSPDataRate) -
                                    (20);
            Assert.AreEqual(expectedBill, (testServiceCenter as PostPaidService).CalculatePostPaidBill());
            testServiceCenter = new PostPaidService(testUsage, PostPaidPlan.BP, 20, 1234567890, "ANR");
            expectedBill = PostPaidServiceConstants.BPBill - 20;
            Assert.AreEqual(expectedBill, (testServiceCenter as PostPaidService).CalculatePostPaidBill());
        }

        [TestMethod()]
        public void GetPhoneRatesTest()
        {
            testServiceCenter = new PostPaidService(testUsage, PostPaidPlan.FSP, 20, 1234567890, "404/F");
            (testServiceCenter as PostPaidService).GetPhoneRates();
            double expectedRate = 0;
            Assert.AreEqual(expectedRate, (testServiceCenter as PostPaidService).SmsRate);
        }
    }
}