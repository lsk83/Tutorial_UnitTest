using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tutorial_UnitTest.Model
{
    public class PatientInfo : Person
    {
        public string PatientID { get; set; } = string.Empty;

        public string PatientName { get; set; } = string.Empty;

        public int Age { get; set; }

        public string Phone { get; set; } = string.Empty;

        public void Test(string patientID)
        {
            if (string.IsNullOrEmpty(patientID))
                throw new ArgumentException("Patient ID Cannot be null");
        }
        
        public string[] GetCollection()
        {
            return new string[] { "abc"};
        }
    }
}
