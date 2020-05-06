using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace LinqExample
{
    class Program
    {
        static void Main(string[] args)
        {  
            //public DateTime(int year, int month, int day, int hour, int minute, int second, int millisecond);
            DateTime dateTime = new DateTime(2013, 01, 01, 12, 00, 00, 00);            
            DateTime dateTime1 = new DateTime(2013, 02, 01, 12, 00, 00, 00);

            Console.WriteLine("2. Get all employee details from the employee table");
            IList<Employee> employeeList = new List<Employee>()
             {
                 new Employee() { EMPLOYEE_ID = 1, FIRST_NAME= "John", LAST_NAME= "Abraham", SALARY= 1000000, JOINING_DATE= dateTime, DEPARTMENT= "Banking"},
                 new Employee() { EMPLOYEE_ID= 2, FIRST_NAME="Michael", LAST_NAME = "Clarke", SALARY= 800000, JOINING_DATE= dateTime , DEPARTMENT = "Insurance" },
                 new Employee() { EMPLOYEE_ID= 3, FIRST_NAME="Roy" , LAST_NAME ="Thomas", SALARY=  700000, JOINING_DATE= dateTime1, DEPARTMENT = "Banking" },
                 new Employee() {EMPLOYEE_ID = 4, FIRST_NAME = "Tom" , LAST_NAME= "Jose" , SALARY =  600000, JOINING_DATE = dateTime1 , DEPARTMENT = "Insurance" },
                 new Employee() { EMPLOYEE_ID = 5, FIRST_NAME ="Jerry" , LAST_NAME= "Pinto" , SALARY = 650000, JOINING_DATE = dateTime1 , DEPARTMENT = "Insurance" },
                 new Employee() { EMPLOYEE_ID = 6, FIRST_NAME ="Philip" , LAST_NAME= "Mathew" , SALARY = 750000, JOINING_DATE = dateTime , DEPARTMENT = "Services" },
                 new Employee() { EMPLOYEE_ID = 7, FIRST_NAME ="TestName1" , LAST_NAME= "123" , SALARY = 650000, JOINING_DATE = dateTime , DEPARTMENT = "Services" },
                 new Employee() { EMPLOYEE_ID = 8, FIRST_NAME ="TestName2" , LAST_NAME= "Lname%" , SALARY = 600000 , JOINING_DATE = dateTime1 , DEPARTMENT = "Insurance" }
            };

            IEnumerable<Employee> query1 = from emp in employeeList
                                           select emp;
            foreach (Employee emp in query1)
            {
                Console.WriteLine("\t Getting all the records------------" + emp.EMPLOYEE_ID + ", " + emp.FIRST_NAME +
                     ", " + emp.LAST_NAME + ", " + emp.JOINING_DATE + ", " + emp.SALARY);
            }

            Console.WriteLine("3. Get First_Name, Last_Name from employee table");            
            foreach (Employee i in query1)
                Console.WriteLine(i.FIRST_NAME + "  " + i.LAST_NAME);
            
            Console.WriteLine("4.Get First_Name from employee table using alias name Employee Name");
            query1.ToList().ForEach(s => Console.WriteLine("Employee Name : " + s.FIRST_NAME + " " + s.LAST_NAME));

            Console.WriteLine("5.Get First_Name from employee table in upper case");
            var z = from e in employeeList
                    select e.FIRST_NAME;

            foreach(Employee e in employeeList)
                Console.WriteLine(e.FIRST_NAME.ToUpper());
            
            Console.WriteLine("6.Get First_Name from employee table in lower case");
            query1.ToList().ForEach(s => Console.WriteLine("Employee Name Lower : " + s.FIRST_NAME.ToLower()));
            
            Console.WriteLine("7.Get unique DEPARTMENT from employee table");               
            var distinctDept = employeeList.Select(s => s.DEPARTMENT).Distinct();
            foreach (var i in distinctDept)            
                Console.WriteLine(i);
            
            Console.WriteLine("8.Select first 3 characters of FIRST_NAME from EMPLOYEE.");            
            foreach(Employee i in query1)
                Console.WriteLine(" " + i.FIRST_NAME.Substring(0,3));
            
            Console.WriteLine("9.Get position of 'o' in name 'John' from employee table");
            var result = employeeList.Where(s => s.FIRST_NAME.ToLower().Contains("o"));
            foreach (var i in result)
                Console.WriteLine(i.FIRST_NAME.ToLower().IndexOf("o"));
            
            Console.WriteLine("10.Get FIRST_NAME from employee table after removing white spaces from right side");
            foreach(var i in result)
                Console.WriteLine(i.FIRST_NAME.TrimEnd());

            Console.WriteLine("11.Get FIRST_NAME from employee table after removing white spaces from left side");
            foreach (Employee i in result)
                Console.WriteLine(i.FIRST_NAME.TrimStart());

            Console.WriteLine("12.Get length of FIRST_NAME from employee table");
            foreach (Employee i in query1)           
                Console.WriteLine(i.FIRST_NAME + " , Length = " +  i.FIRST_NAME.Length);
            
            Console.WriteLine("13.Get First_Name from employee table after replacing 'o' with '$'");
            foreach (Employee i in query1)
                Console.WriteLine(i.FIRST_NAME.ToLower().Replace("o", "$"));
            
            Console.WriteLine("14. Get First_Name and Last_Name as single column from employee table separated by a '_'");
            foreach (Employee i in query1)
                Console.WriteLine(string.Join("_", i.FIRST_NAME, i.LAST_NAME));

            Console.WriteLine("15.Get FIRST_NAME, Joining year, Joining Month and Joining Date from employee table");
            foreach(Employee i in query1)
                Console.WriteLine($"Name : {i.FIRST_NAME}\tJoining Year: {i.JOINING_DATE.Year}\tJoining Month: {i.JOINING_DATE.Month}\tJoining Date: {i.JOINING_DATE.Date}");

            Console.WriteLine("16. Get all employee details from the employee table order by First_Name Ascending");
            IEnumerable<Employee> q16 =
                         from e in employeeList
                         orderby e.FIRST_NAME ascending
                         select e;
            foreach (Employee e in q16)
                Console.WriteLine(e.FIRST_NAME);

            Console.WriteLine("17. Get all employee details from the employee table order by First_Name descending");
            IEnumerable<Employee> q17 =
                        from e in employeeList
                        orderby e.FIRST_NAME descending
                        select e;
            foreach (Employee e in q17)
                Console.WriteLine(e.FIRST_NAME);

            Console.WriteLine("18.Get all employee details from the employee table order by First_Name Ascending and Salary descending");
            IEnumerable<Employee> q18 =
                        from e in employeeList
                        orderby e.FIRST_NAME ascending, e.SALARY descending
                        select e;
            foreach (Employee e in q18)
                Console.WriteLine("Name : " + e.FIRST_NAME + "Salary: "+  e.SALARY);

            Console.WriteLine("19. Get employee details from employee table whose employee name is “John”");
            var res = from s in employeeList
                      where s.FIRST_NAME == "John"
                      select s;
            foreach (Employee i in res)            
                Console.WriteLine(i.FIRST_NAME);

            Console.WriteLine("20. Get employee details from employee table whose employee name are “John” and “Roy”");
            var res1 = from s in employeeList
                       where s.FIRST_NAME == "John" || s.FIRST_NAME == "Roy"
                       select s;
            foreach(Employee i in res1)
                Console.WriteLine(i.FIRST_NAME);

            Console.WriteLine("21.Get employee details from employee table whose employee name are not “John” and “Roy”");
            var q21 = from s in employeeList
                       where s.FIRST_NAME != "John" || s.FIRST_NAME != "Roy"
                       select s;
            foreach (Employee i in q21)
                Console.WriteLine(i.FIRST_NAME);

            Console.WriteLine("22. Get employee details from employee table whose first name starts with 'J'");
            var q22 = from s in employeeList
                      where s.FIRST_NAME.StartsWith("J")
                      select s;
            foreach (Employee i in q22)
                Console.WriteLine(i.FIRST_NAME);

            Console.WriteLine("23. Get employee details from employee table whose first name contains 'o'");
            var q23 = from s in employeeList
                      where s.FIRST_NAME.ToString().Contains("o")
                      select s;
            foreach (Employee i in q23)
                Console.WriteLine(i.FIRST_NAME);

            Console.WriteLine("24. Get employee details from employee table whose first name ends with 'n'");
            var q24 = from s in employeeList
                      where s.FIRST_NAME.EndsWith("n")
                      select s;
            foreach (Employee i in q24)
                Console.WriteLine(i.FIRST_NAME);

            Console.WriteLine("25. Get employee details from employee table whose first name ends with 'n' and name contains 4 letters");
            var q25 = from s in employeeList
                      where s.FIRST_NAME.EndsWith("n") && s.FIRST_NAME.Length == 4
                      select s;
            foreach (Employee i in q25)
                Console.WriteLine(i.FIRST_NAME);
           
            Console.WriteLine("26.Get employee details from employee table whose first name starts with 'J' and name contains 4 letters");
            var q26 = from s in employeeList
                      where s.FIRST_NAME.StartsWith("J") && s.FIRST_NAME.Length == 4
                      select s;
            foreach (Employee i in q26)
                Console.WriteLine(i.FIRST_NAME);


            Console.WriteLine("27.Get employee details from employee table whose Salary greater than 600000");
            var q27 = from s in employeeList
                      where s.SALARY > 600000
                      select s;
            foreach (Employee i in q27)
                Console.WriteLine(i.FIRST_NAME);

            Console.WriteLine("28.Get employee details from employee table whose Salary less than 800000");
            var q28 = from s in employeeList
                      where s.SALARY < 800000
                      select s;
            foreach (Employee i in q28)
                Console.WriteLine(i.FIRST_NAME);

            Console.WriteLine("29.Get employee details from employee table whose Salary between 500000 and 800000");
            var q29 = from s in employeeList
                      where s.SALARY > 500000 && s.SALARY < 800000
                      select s;
            foreach (Employee i in q29)
                Console.WriteLine(i.FIRST_NAME);

            Console.WriteLine("30.Get employee details from employee table whose name is 'John' and 'Michael'");
            var q30 = from s in employeeList
                      where s.FIRST_NAME == "John" && s.LAST_NAME == "Michael"
                      select s;
            foreach (Employee i in q30)
                Console.WriteLine(i.FIRST_NAME);

            Console.WriteLine("31. Get employee details from employee table whose joining year is 2013");
            foreach (var e in query1)
            {
                if (e.JOINING_DATE.Year == 2013)
                    Console.WriteLine($"Name : { e.FIRST_NAME } { e.LAST_NAME }\nJoining date: {e.JOINING_DATE}\nDepartment : {e.DEPARTMENT}\nSalary: {e.SALARY}\n");
            }

            Console.WriteLine("32. Get employee details from employee table whose joining month is January");
            foreach (Employee e in employeeList)
            {
                if (e.JOINING_DATE.Month == 01)
                {
                    Console.WriteLine($"Name : { e.FIRST_NAME } { e.LAST_NAME }\nJoining date: {e.JOINING_DATE}\nDepartment : {e.DEPARTMENT}\nSalary: {e.SALARY}\n");
                }
            }

            Console.WriteLine("33.Get employee details from employee table who joined before January 31st 2013");            
            var q33 = (from e in employeeList
                     where e.JOINING_DATE < new DateTime(2013, 01, 31)
                       select e).ToList();
            foreach(var i in q33)            
                Console.WriteLine($"Name:  {i.FIRST_NAME}\nnJoining Date: {i.JOINING_DATE}\nDepartment : {i.DEPARTMENT}\nSalary: {i.SALARY}\n ");
            

            Console.WriteLine("\n34.Get employee details from employee table who joined after January 31st");
            var q34 = (from e in employeeList
                       where e.JOINING_DATE > new DateTime(2013, 01, 31)
                       select e).ToList();
            foreach (var i in q34)
                Console.WriteLine($"Name:  {i.FIRST_NAME}\nnJoining Date: {i.JOINING_DATE}\nDepartment : {i.DEPARTMENT}\nSalary: {i.SALARY}\n ");

            Console.WriteLine("\n35.  Get Joining Date and Time from employee table");
            foreach(Employee e in query1)
                Console.WriteLine($"Joining Date: {e.JOINING_DATE.Date} Time: { e.JOINING_DATE.TimeOfDay } ");

            Console.WriteLine("36. Get Joining Date,Time including milliseconds from employee table");
            foreach (Employee e in query1)
                Console.WriteLine($"Joining Date: {e.JOINING_DATE.Date} Time in milliseconds : { e.JOINING_DATE.Millisecond } ");

            IList<Incentives> incentivesList = new List<Incentives>()
            {
                new Incentives() { EMPLOYEE_REF_ID = 1, INCENTIVE_DATE = dateTime1, INCENTIVE_AMOUNT = 5000 },
                new Incentives() {EMPLOYEE_REF_ID = 2, INCENTIVE_DATE= dateTime1 , INCENTIVE_AMOUNT = 3000 },
                new Incentives() {EMPLOYEE_REF_ID =3, INCENTIVE_DATE= dateTime1, INCENTIVE_AMOUNT =  4000 },
                new Incentives() {EMPLOYEE_REF_ID =1, INCENTIVE_DATE= dateTime , INCENTIVE_AMOUNT = 4500 },
                new Incentives() {EMPLOYEE_REF_ID =2, INCENTIVE_DATE= dateTime, INCENTIVE_AMOUNT= 3500 }
            };

            IEnumerable<Incentives> incentives = from i in incentivesList select i;
            Console.WriteLine("37. Get difference between JOINING_DATE and INCENTIVE_DATE from employee and incentives table");
            //List<DateTime> q37 = (from i in incentives select i.INCENTIVE_DATE).ToList();
            //List<DateTime> e_q37 = (from i in employeeList select i.JOINING_DATE).ToList();
            //foreach (var i in q37)
            //{
            //    foreach(var e in e_q37)
            //    {
            //        
            //    }                
            //}

            //var q38 = from system in System
            //        select getDate();
            Console.WriteLine("\n39.  Get names of employees from employee table who has '%' in Last_Name.");
            foreach (Employee i in employeeList)
            {
                if(i.LAST_NAME.Contains('%'))
                {
                    Console.WriteLine("\tLastName : " + i.LAST_NAME);
                }
            }

            Console.WriteLine("\n40.Get Last Name from employee table after replacing special character with white space");
            foreach (Employee i in employeeList)
            {
                if (i.LAST_NAME.Contains('%'))
                {
                    Console.WriteLine("\tLastName : " + i.LAST_NAME.Replace('%', ' '));
                }
            }

            Console.WriteLine("\n41.Get department,total salary with respect to a department from employee table.");            
            var q41 = employeeList.GroupBy(e => e.DEPARTMENT).Select(e => new
            {
                DEPARTMENT = e.Key,
                salary = e.Sum(t => t.SALARY)
            });
            foreach(var i in q41)
                Console.WriteLine($"Department : {i.DEPARTMENT}\tSalary: { i.salary } ");

            Console.WriteLine("\n42.Get department,total salary with respect to a department from employee table order by total salary descending");
            var q42 = employeeList.GroupBy(e => e.DEPARTMENT).Select(e => new
            {
                DEPARTMENT = e.Key,
                salary = e.Sum(t => t.SALARY)
            }).OrderByDescending(e => e.salary);
            foreach (var i in q42)
                Console.WriteLine($"Department : {i.DEPARTMENT}\tSalary: { i.salary } ");

            Console.WriteLine("\n43.Get department,no of employees in a department, total salary with respect to a department from employee table order by total salary descending");
            var q43 = employeeList.GroupBy(e => e.DEPARTMENT).Select(e => new
            {
                DEPARTMENT = e.Key,
                salary = e.Sum(s => s.SALARY),
                emp = e.Count()
            }).OrderByDescending(e => e.salary);
            foreach (var i in q43)
                Console.WriteLine($"Department : {i.DEPARTMENT}\tSalary: { i.salary }\tEmployees : { i.emp }");

            Console.WriteLine("\n44.Get department wise average salary from employee table order by salary ascending");
            var q44 = employeeList.GroupBy(e => e.DEPARTMENT).Select(e => new
            {
                DEPARTMENT = e.Key,
                salary = e.Average(t => t.SALARY)
            }).OrderBy(e => e.salary);
            foreach (var i in q44)
                Console.WriteLine($"Department : {i.DEPARTMENT}\tSalary: { i.salary } ");

            Console.WriteLine("\n45.Get department wise maximum salary from employee table order by salary ascending");
            var q45 = employeeList.GroupBy(e => e.DEPARTMENT).Select(e => new
            {
                DEPARTMENT = e.Key,
                salary = e.Max(t => t.SALARY)
            }).OrderBy(e => e.salary);
            foreach (var i in q45)
                Console.WriteLine($"Department : {i.DEPARTMENT}\tSalary: { i.salary } ");

            Console.WriteLine("\n46.Get department wise minimum salary from employee table order by salary ascending");
            var q46 = employeeList.GroupBy(e => e.DEPARTMENT).Select(e => new
            {
                DEPARTMENT = e.Key,
                salary = e.Min(t => t.SALARY)
            }).OrderBy(e => e.salary);
            foreach (var i in q46)
                Console.WriteLine($"Department : {i.DEPARTMENT}\tSalary: { i.salary } ");

            Console.WriteLine("\n47.Select no of employees joined with respect to year and month from employee table");

            Console.WriteLine("\n48.Select department,total salary with respect to a department from employee table where total salary greater than 800000 order by Total_Salary descending");
            var q48 = employeeList.GroupBy(e => e.DEPARTMENT).Select(e => new
            {
                DEPARTMENT = e.Key,
                salary = e.Sum(s => s.SALARY)                
            }).OrderByDescending(e => e.salary).Where(e => e.salary > 800000);
            foreach (var i in q48)
                Console.WriteLine($"Department : {i.DEPARTMENT}\tSalary: { i.salary }");

            Console.WriteLine("\n49.Select first_name, incentive amount from employee and incentives table for those employees who have incentives");
            var q49 = from emp in employeeList
                               join inc in incentivesList on emp.EMPLOYEE_ID equals inc.EMPLOYEE_REF_ID
                               select new
                               {
                                   emp.FIRST_NAME,
                                   inc.INCENTIVE_AMOUNT
                               };
            foreach(var i in q49)
                Console.WriteLine($"First_Name: {i.FIRST_NAME} Amount: {i.INCENTIVE_AMOUNT} ");

            Console.WriteLine("\n50.Select first_name, incentive amount from employee and incentives table for those employees who have incentives and incentive amount greater than 3000");
            var q50 = (from emp in employeeList
                      join inc in incentivesList on emp.EMPLOYEE_ID equals inc.EMPLOYEE_REF_ID
                      select new
                      {
                          emp.FIRST_NAME,
                          inc.INCENTIVE_AMOUNT
                      }).Where(s => s.INCENTIVE_AMOUNT > 3000);
            foreach (var i in q50)
                Console.WriteLine($"First_Name: {i.FIRST_NAME} Amount: {i.INCENTIVE_AMOUNT}\n");

            Console.WriteLine("\n51.Select first_name, incentive amount from employee and incentives table for all employed even if they didn't get incentives.");
            var q51 = (from emp in employeeList
                       join inc in incentivesList on emp.EMPLOYEE_ID equals inc.EMPLOYEE_REF_ID into empIncentive
                       from r in empIncentive.DefaultIfEmpty()
                       select new
                       {
                           emp.FIRST_NAME,
                           INCENTIVE_AMOUNT = r == null
                       });
            foreach (var i in q51)
                Console.WriteLine($"First_Name: {i.FIRST_NAME} Amount: {i.INCENTIVE_AMOUNT}\n");

            Console.WriteLine("\n52.Select first_name, incentive amount from employee and incentives table for all employees even if they didn't get incentives and set incentive amount as 0 for those employees who didn't get incentives.");
            var q52 = (from emp in employeeList
                       join inc in incentivesList on emp.EMPLOYEE_ID equals inc.EMPLOYEE_REF_ID into empIncentive
                       from r in empIncentive.DefaultIfEmpty()
                       select new
                       {
                           emp.FIRST_NAME,
                           INCENTIVE_AMOUNT = r == null ? 0 : r.INCENTIVE_AMOUNT
                       });
            foreach (var i in q52)
                Console.WriteLine($"First_Name: {i.FIRST_NAME} Amount: {i.INCENTIVE_AMOUNT}\n");

            Console.WriteLine("\n53.Select first_name, incentive amount from employee and incentives table for all employees who got incentives using left join");
            var q53 = (from emp in employeeList
                       join inc in incentivesList on emp.EMPLOYEE_ID equals inc.EMPLOYEE_REF_ID into empIncentive
                       from r in empIncentive.DefaultIfEmpty()
                       select new
                       {
                           emp.FIRST_NAME,
                           INCENTIVE_AMOUNT = r == null ? 0 : r.INCENTIVE_AMOUNT
                       });
            foreach (var i in q53)
                Console.WriteLine($"First_Name: {i.FIRST_NAME} Amount: {i.INCENTIVE_AMOUNT}\n");

            Console.WriteLine("\n54. Select TOP 2 salary from employee table");
            var q54 = (from emp in employeeList select emp.SALARY).Take(2);
            foreach (var i in q54)
                Console.WriteLine("TOP 2 Salary : " + i);

            Console.WriteLine("\n55. Select TOP N salary from employee table");
            Console.WriteLine("Enter no for TOP N salary: ");
            int n = Convert.ToInt32(Console.ReadLine());
            var q55 = (from emp in employeeList select emp.SALARY).Take(n);
            foreach (var i in q55)
                Console.WriteLine($"TOP { n } Salary : {i} " );

            Console.WriteLine("\n56. Select 2nd Highest salary from employee table");
            var max2 = employeeList.OrderByDescending(x => x.SALARY).Select(x => x.SALARY).Distinct().Skip(1).First();
            Console.WriteLine(max2);

            Console.WriteLine("\n57.  Select Nth Highest salary from employee table ");
            Console.WriteLine("Enter no for Nth highest salary: ");
            int num = Convert.ToInt32(Console.ReadLine());
            var maxSalary = employeeList.OrderByDescending(x => x.SALARY).Select(x => x.SALARY).Distinct().Take(num).Skip(num - 1).FirstOrDefault();
            Console.WriteLine($"{num}th Highest salary : {maxSalary} ");

            Console.WriteLine("\n58.  Select First_Name,LAST_NAME from employee table as separate rows");
            foreach(Employee i in employeeList)
                Console.WriteLine($"First_Nme : { i.FIRST_NAME }\nLast_Name : { i.LAST_NAME }\n");
                        
            Console.WriteLine("60. Select employee details from employee table if data exists in incentive table");
            var q60 = (from emp in employeeList
                       join inc in incentivesList on emp.EMPLOYEE_ID equals inc.EMPLOYEE_REF_ID 
                       select new
                       {
                           emp.FIRST_NAME,
                           inc.INCENTIVE_AMOUNT                           
                       });
            foreach (var i in q60)
                Console.WriteLine($"First_Name: {i.FIRST_NAME} Incentive Amount: {i.INCENTIVE_AMOUNT}\n");

            Console.WriteLine("61. How to fetch data that are common in two query results ?");
            var q61 = employeeList.Select(e => e.EMPLOYEE_ID).Union(incentivesList.Select(s => s.EMPLOYEE_REF_ID)).ToList();
            foreach (var i in q61)            
                Console.WriteLine($"Name : {i} ");            
            
            Console.WriteLine("62. Get Employee ID's of those employees who didn't receive incentives without using sub query");
            var q62 = employeeList.Select(x => x.EMPLOYEE_ID).Except(incentivesList.Select(y => y.EMPLOYEE_REF_ID)).ToList();
            foreach (var i in q62)
                Console.WriteLine("Employee Id : " + i);

            Console.WriteLine("63. Select 20 % of salary from John , 10 % of Salary for Roy and for other 15 % of salary from employee table");
            foreach (var i in query1)
            {
                double Jsal = 0.0, Rsal = 0.0, Osal = 0.0;
                Regex regex = new Regex("[^A-Za-z]");
                if (i.FIRST_NAME == "John")
                {
                    Jsal = i.SALARY * .2;
                    Console.WriteLine("After 20% of John : " + Jsal);
                }
                else if (i.FIRST_NAME == "Roy")
                {
                    Rsal = i.SALARY * .1;
                    Console.WriteLine("After 10% of Roy : " + Rsal);
                }
                else if (regex.IsMatch(i.FIRST_NAME))
                {
                    Osal = i.SALARY * .15;
                    Console.WriteLine("After 15% of Others : " + Osal);
                }
                Console.WriteLine("Name : " + i.FIRST_NAME + "\tSalary : " + i.SALARY);
                //Console.WriteLine(Jsal +  " " + Rsal + " " + Osal);
            }
            
            Console.WriteLine("64. Select Banking as 'Bank Dept', Insurance as 'Insurance Dept' and Services as 'Services Dept' from employee table");
            var q64 = employeeList.Select(s => new { Department = s.DEPARTMENT == "Banking" ? "Bank Dept" : s.DEPARTMENT == "Insurance" ? "Insurance Dept" : s.DEPARTMENT == "Services" ? "Services Dept" : "-" });
            foreach(var i in q64)
            {
                Console.WriteLine($"Department : { i.Department } \n");
            }

            Console.ReadLine();
        }
    }
}
