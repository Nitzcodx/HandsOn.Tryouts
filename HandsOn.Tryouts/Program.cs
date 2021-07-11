using System;
using BusinessAccessLayer.TryOut_3;

namespace HandsOn.Tryouts
{
    class Program
    {
        static void Main(string[] args)
        {
            //Console.WriteLine("Hello World!");
            #region Test Code for TryOut 3
            try
            {
                Address adObj1 = new Address("Sreekrishnapuram", "Shornur-Kodugallur Road", "Thrissur", 680001);
                Student stdObj = new Student("Haridas", 87, 'M', true);
                GovtCollege gcObj = new GovtCollege("Govt Engineering College", adObj1);
                Console.WriteLine("CollegeDetails");
                Console.WriteLine("--------------\n");
                Console.WriteLine("College Id:" + gcObj.CollegeId);
                Console.WriteLine("College Name:" + gcObj.CollegeName);
                Console.WriteLine("College Address:" + gcObj.GovtCollegeAddress.AddressLine1 + "," + gcObj.GovtCollegeAddress.AddressLine2 + "," + gcObj.GovtCollegeAddress.City + "," + gcObj.GovtCollegeAddress.PinCode);
                Console.WriteLine("Student Name:" + stdObj.StudentName);
                Console.WriteLine("Student Gender:" + stdObj.Gender);
                Console.WriteLine("Student Marks:" + stdObj.Marks);
                Console.WriteLine("Sports Quota Applicable:" + stdObj.SportsQuota);
                gcObj.SetFees(stdObj);
                Console.WriteLine("College Fees:" + stdObj.CollegeFees);
                Console.WriteLine("\n************************************************************************\n");
                Address adObj2 = new Address("Poojapura", "Vazhuthakaud-Thycaud Road", "Thiruvananthapuram", 560001);
                Student stdObj2 = new Student("Gayathri", 75, 'F', false);
                PrivateCollege pcObj = new PrivateCollege("St. Josephs College Of Engineering", 10001, adObj2);
                Console.WriteLine("CollegeDetails");
                Console.WriteLine("--------------\n");
                Console.WriteLine("College Id:" + pcObj.CollegeId);
                Console.WriteLine("College Name:" + pcObj.CollegeName);
                Console.WriteLine("College Address:" + pcObj.PrivateCollegeAddress.AddressLine1 + "," + pcObj.PrivateCollegeAddress.AddressLine2 + "," + pcObj.PrivateCollegeAddress.City + "," + pcObj.PrivateCollegeAddress.PinCode);
                Console.WriteLine("Student Name:" + stdObj2.StudentName);
                Console.WriteLine("Student Gender:" + stdObj2.Gender);
                Console.WriteLine("Student Marks:" + stdObj2.Marks);
                Console.WriteLine("Sports Quota Applicable:" + stdObj2.SportsQuota);
                pcObj.CalculateFees(stdObj2);
                Console.WriteLine("College Fees:" + stdObj2.CollegeFees);
            }
            catch (Exception)
            {
                Console.WriteLine("SOME ERROR OCCURED!!!");
            }
            #endregion
        }
    }
}
