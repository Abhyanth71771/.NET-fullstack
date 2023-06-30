using Azure;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using MyEntityClasses;
namespace efcoreDay1
{
    
    internal class CRUDops
    {
      //static  MyDbContext dbCon = new MyDbContext();//we addd static here because only static methoods can access static objects
        static void Main()
        {
            Console.WriteLine("Hello, World!");
            //create an object of the DbContext class
             MyDbContext dbCon = new MyDbContext();
            //tell ef core to create a db if it does not exist
            dbCon.Database.EnsureCreated();
            //ensureCreated will make sure that it will create database and tables if they do not exist
            //if database exist then ensure created will add the tables given in that class 
            //if the database exists and the tables already exist then it wont do anything 
            //AddEmp(i can also send a reference to the object here and in the function definition just input a object parameter)



                    AddEmp(dbCon);
                    //EditEmployee(dbCon);
                    //DeleteEmployee(dbCon);
                    //AddMultipleEmployees(dbCon);`
                   // GetEmployeesByName(dbCon, "A");
        }
        static void AddEmp(MyDbContext db)
        { 
            //step1
            Console.WriteLine("Enter the EmpID");
            int EmpId = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter the Emp Name");
            string EmpName = Console.ReadLine();
            //Step2
            Employee e = new Employee();
            e.EmployeeID = EmpId;
            e.EmpName = EmpName;
            //Step3
            //add this object to the Db context collection prop
            db.Employees.Add(e);

            EntityState es = db.Employees.Entry(e).State;
            Console.Write("Es value");
            Console.WriteLine(es);
            //Step4
            //Tell ef core to insert the querry 
            int RecInserted = db.SaveChanges();
            es = db.Employees.Entry(e).State;
            Console.WriteLine(es);
            Console.WriteLine("Employee Added Successfully{0}",RecInserted);
        }
        static void AddMultipleEmployees(MyDbContext db)
        {
            //create an array of Employee objects
            Employee[] emps =
            {
                new Employee { EmployeeID = 2153, EmpName = "Karthik"},
                new Employee { EmployeeID = 13989, EmpName = "Thendral"},
                new Employee { EmployeeID = 14050, EmpName = "Deepa"},
                new Employee { EmployeeID = 13981, EmpName = "Alekhya"},
                new Employee { EmployeeID = 14126, EmpName = "Asha"},
                new Employee { EmployeeID = 14064, EmpName = "Madhu"},
                new Employee { EmployeeID = 13994, EmpName = "Pratiksha"},
                new Employee { EmployeeID = 13963, EmpName = "Akhila"},
                new Employee { EmployeeID = 14066, EmpName = "Manoj"},
                new Employee { EmployeeID = 13980, EmpName = "Ovijeet"},
                new Employee { EmployeeID = 14074, EmpName = "Ramireddy"},
                new Employee { EmployeeID = 13965, EmpName = "Arun"},
                new Employee { EmployeeID = 14087, EmpName = "Raghul"},
                new Employee { EmployeeID = 14054, EmpName = "Hassan"},
                new Employee { EmployeeID = 14109, EmpName = "Sarthak"},
                new Employee { EmployeeID = 14048, EmpName = "Chirag"},
                new Employee { EmployeeID = 13692, EmpName = "Abhayanth"},
                new Employee { EmployeeID = 14027, EmpName = "Ambika"},
                new Employee { EmployeeID = 14111, EmpName = "Shravani"},
                new Employee { EmployeeID = 14080, EmpName = "Preetha"}
            };



            //to add multiple objects at one go
            db.Employees.AddRange(emps);
            int RecInserted = db.SaveChanges();

            Console.WriteLine("User Added Successfully{0}", RecInserted);
        }
        static void AddUser(MyDbContext db)
        {
            //step1
            Console.WriteLine("Enter the UserID");
            int UserId = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter the User Name");
            string UserName = Console.ReadLine();
            Console.WriteLine("Enter the Password");
            string Password = Console.ReadLine();
            //Step2
            User u = new User();
            u.UserID = UserId;
            u.UserName = UserName;
            u.Password = Password;
            //Step3
            //add this object to the Db context collection prop
            db.Users.Add(u);
            //Step4
            //Tell ef core to insert the querry 
            int RecInserted = db.SaveChanges();

            Console.WriteLine("User Added Successfully{0}", RecInserted);
        }
        static void EditEmployee(MyDbContext db)
        {
            Console.WriteLine("Enter the EmpID");
            int EmpId = int.Parse(Console.ReadLine());
            //we have to find the id in the list
            //1.linq querry
            var result=db.Employees.Where(e=>e.EmployeeID==EmpId).SingleOrDefault();//returns null or a single object instead of an array
                                                                              //in single or default it shud return only 1 row if multiple are returned it will throw an error
                                                                              //in first or default it will return the first element of the array so np its there are multiple results also
                                                                              //now when we execute this statement internallt .net fires a select * where querrry in sql and return sthe result 

            if (result == null) 
            {
                Console.WriteLine("Employee not found for editing");
            }
            else
            {
                Console.WriteLine("Enter the Emp Name");
                string EmpName = Console.ReadLine();
                result.EmpName = EmpName;
                EntityState es = db.Employees.Entry(result).State;
                Console.WriteLine(es);
                //tell ef to update the querry
                int edited = db.SaveChanges();
                es = db.Employees.Entry(result).State;
                Console.WriteLine(es);
                Console.WriteLine("Emp edited");  
            }
            //use the find()
            //var result1 = db.Employees.Find(EmpId);
            //if (result1 == null)
            //{
            //    Console.WriteLine("Employee not found for editing");
            //}
            //else
            //{
            //    Console.WriteLine(result.EmpName);
            //}

        }
        static void DeleteEmployee(MyDbContext db)
        {
            Console.WriteLine("Enter the EmpID");
            int EmpId = int.Parse(Console.ReadLine());
            //we have to find the id in the list
            //1.linq querry
            var result = db.Employees.Where(e => e.EmployeeID == EmpId).SingleOrDefault();//returns null or a single object instead of an array
                                                                                          //in single or default it shud return only 1 row if multiple are returned it will throw an error
                                                                                          //in first or default it will return the first element of the array so np its there are multiple results also
                                                                                          //now when we execute this statement internallt .net fires a select * where querrry in sql and return sthe result 

            if (result == null)
            {
                Console.WriteLine("Employee not found for editing");
            }
            else
            {

                db.Employees.Remove(result);
                //tell ef to update the querry
                int edited = db.SaveChanges();
                Console.WriteLine("Emp deleted");
            }
            //use the find()
            //var result1 = db.Employees.Find(EmpId);
            //if (result1 == null)
            //{
            //    Console.WriteLine("Employee not found for editing");
            //}
            //else
            //{
            //    Console.WriteLine(result.EmpName);
            //}

        }

        static void GetAllEmployees(MyDbContext db)
        {
            var result = db.Employees;//right now this querry wont be executed it wil wait for the for each loop thn only get fired
            foreach(var emp in result)
            {
                Console.Write("Employee Id is:{0}\t\t",emp.EmployeeID);
                Console.Write("Employee Name is:{0}",emp.EmpName);
                Console.WriteLine();
            }

        }
        static void GetEmployeesByName(MyDbContext db, string name)
        {
            var result =db.Employees.Where(e => e.EmpName.StartsWith("A"));


            //Console.WriteLine(result.Count());
            foreach (var emp in result)
            {
                Console.Write("Employee Id is:{0}\t\t", emp.EmployeeID);
                Console.Write("Employee Name is:{0}", emp.EmpName);
                Console.WriteLine();
            }

        }

    }
    //db context
    class MyDbContext : DbContext
    {
        //expose the required entities as collections
        public DbSet<User> Users { get; set; }//db set is a collection which will contain rows of the table to which its mapped (collection of rows)
                                              //now since there is no table named users it will creat a new table and add 3 columns because the class have 3 properties
                                              //users will be the table name created we still have not connected to the server
        public DbSet<Employee> Employees { get; set; }

        //now connect to the server
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {


            //string connstring = "server=CTAADPG038Q88\\SQLEXPRESS;database=efcoredb;integrated security=true;TrustServerCertificate=true";
            //string connstring = "server=CTAADPG038Q88\\SQLEXPRESS;database = efcoredb;uid = sa; pwd = Password_123;TrustServerCertificate=true;";
            string connstring = "server=CTAADPG038Q88\\SQLEXPRESS;database=efcoredb;integrated security=true;TrustServerCertificate=True";
            optionsBuilder.UseSqlServer(connstring).LogTo(Console
                .WriteLine, new[] {DbLoggerCategory.Database.Command.Name},LogLevel.Information);//writeline -->logs will be written to the console,new...->give me onlt the name of SQL command
            //if we dont give that second parmameter it will also display some other info,again a way to filter the logs which tells dont give me meta data but onl sql querries
            //overide the on congiguring methood and specify which database you want to conect your database to and userSqlServer is used to connect to a database 
             

        }

    }
}
