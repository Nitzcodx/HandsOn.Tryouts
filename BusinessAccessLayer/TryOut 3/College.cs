using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessAccessLayer.TryOut_3
{
    public delegate void StudentDelegate(Student studentObj);
    public class College
    {
        private static int counter;
        public int CollegeId { get; set; }
        public string CollegeName { get; set; }

        static College()
        {
            counter = 1000;
        }
        public College()
        {
            CollegeId = ++counter;
        }
        public College(string collegeName):this()
        {
            CollegeName = collegeName;
        }
    }
}
