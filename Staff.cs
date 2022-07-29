using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StaffGrid
{
    public class Staff
    {
        public string ID { get; set; }
        public string Name { get; set; }
        public string Role { get; set; }

        public string Salary { get; set; }

        public string Address { get; set; }


        public List<Staff> StaffList = new List<Staff>();
        //public List<string[]>

        public Staff()
        {
            
        }
        public Staff(string staffId, string staffName, string staffRole, string salary, string address)
        {
            ID = staffId;
            Name = staffName;
            Role = staffRole;
            Salary = salary;
            Address = address;
        }
        public List<Staff> StaffGenerator(string[] nameArr, string[] roleArr, string[] addressArr , int iterations)
        {
            Random rnd = new Random();
            for (int i = 0; i < iterations; i++)
            {
                string id = Convert.ToString(i + 1) + Convert.ToString(rnd.Next(10, 100));
                StaffList.Add(new Staff(id, nameArr[i % nameArr.Length], roleArr[i % roleArr.Length] , Convert.ToString(rnd.Next(50000, 100000)), addressArr[i % addressArr.Length]));
            }

            return StaffList;
        }

        
    }
}