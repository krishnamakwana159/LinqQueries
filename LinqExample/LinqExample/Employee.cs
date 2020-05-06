using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinqExample
{
    public class Employee
    { 
        public  int EMPLOYEE_ID { get; set; }
        public string FIRST_NAME { get; set; }
        public string LAST_NAME { get; set; }
        public int SALARY { get; set; }
        public DateTime JOINING_DATE {get; set;}
        public string DEPARTMENT { get; set; }

        public Employee(int eMPLOYEE_ID, string fIRST_NAME, string lAST_NAME, int sALARY, DateTime jOINING_DATE, string dEPARTMENT)
        {
            EMPLOYEE_ID = eMPLOYEE_ID;
            FIRST_NAME = fIRST_NAME;
            LAST_NAME = lAST_NAME;
            SALARY = sALARY;
            JOINING_DATE = jOINING_DATE;
            DEPARTMENT = dEPARTMENT;
        }

        public Employee()
        {
        }
    }
}
