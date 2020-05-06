using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinqExample
{
    public class Incentives
    {
        public int EMPLOYEE_REF_ID { get; set; }
        public DateTime INCENTIVE_DATE { get; set; }
        public int INCENTIVE_AMOUNT { get; set; }

        public Incentives(int eMPLOYEE_REF_ID, DateTime iNCENTIVE_DATE, int iNCENTIVE_AMOUNT)
        {
            EMPLOYEE_REF_ID = eMPLOYEE_REF_ID;
            INCENTIVE_DATE = iNCENTIVE_DATE;
            INCENTIVE_AMOUNT = iNCENTIVE_AMOUNT;
        }

        public Incentives()
        {
        }
    }
}
