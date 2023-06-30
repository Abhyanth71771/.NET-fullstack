using Castle.Components.DictionaryAdapter.Xml;
using EFCoreRelatedEntities1;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Microsoft.Identity.Client;
using System.Runtime.Intrinsics.Arm;

namespace EfCoreDay3
{
    internal class Relationships_demo
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");
            using (MyDbContext context = new MyDbContext())
            {
                context.Database.EnsureCreated();
                Console.WriteLine("DataBase Created");
                //AddBrandsModels(context);
                //AddOnlyModel(context);
                //AddCountry(context);
                //AddCapital(context);
                //AddTrainers(context);
                //AddTopic(context);
                //EagerLoadBrandsModels(context);
                //ExplicitLoadModelsForBrand(context);
                //LazyLoadBrandsModels(context);
                EagerLoadDeptEmp(context);
                //EagerLoadEmpDept(context);
                 //ExplicitLoadDeptEmp(context);
                //ExplicitLoadEmpDept(context);
            }//using this the dispose methoode is called as sooon as the control comes ut of this block and the connection is closed
        }
        //ONE to ONE RELATIONSHIP
        public static void AddCountry(MyDbContext db)
        {
            //Country con = new Country()
            //{
            //    CountryId = 1,
            //    CountryName = "INDIA"
            //};
            Country con1 = new Country()
            {
                CountryId = 2,
                CountryName = "America",
                Capital = new Capital { CapitalId = 3, CapitalName = "New York" }
            };
            db.AllCountry.Add(con1);
            //db.AllCountry.Add(con1);
            int records = db.SaveChanges();
            Console.WriteLine("{0} Countries Added", records);
        }
        public static void AddCapital(MyDbContext db)
        {
            Capital cap = new Capital()
            {
                CapitalId = 1,
                CapitalName = "DELHI",
                CountryId = 1
            };
            db.AllCapital.Add(cap);
            int records = db.SaveChanges();
            Console.WriteLine("{0} Countries Added", records);

        }
        //MANY TO ONE RELATIONSHIP
        public static void AddBrandsModels(MyDbContext db)
        {
            Brand b1 = new Brand()
            {
                BrandId = 100,
                BrandName = "WOLKSWAGON"
            };



            Brand b2 = new Brand()
            {
                BrandId = 101,
                BrandName = "FORD",
                Models = new[]
                 {
                    new Model { ModelId = 1, ModelName = "Figo Aspire" },
                    new Model { ModelId = 2, ModelName = "Endaveour" }
                }
            };
            db.AllBrands.Add(b1);
            db.AllBrands.Add(b2);
            int records = db.SaveChanges();
            Console.WriteLine("{0} Brand added", records);
        }
        public static void AddOnlyModel(MyDbContext db)
        {
            //add a model for a brand
            Model m1 = new Model
            {
                ModelId = 1234,
                ModelName = "Polo",
                BrandId = 100
            };



            Model m2 = new Model
            {
                ModelId = 4772,
                ModelName = "Ameo",
                BrandId = 100
            };



            db.AllModels.Add(m1);
            db.AllModels.Add(m2);
            int recordsinserted = db.SaveChanges();
            Console.WriteLine("{0} model(s) added", recordsinserted);
        }
        //MANY TO MANY RELATIONSHIP
        public static void AddTrainers(MyDbContext db)
        {
            Trainer t1 = new Trainer()
            {
                TrainerId = 1,
                TrainerName = "Hassan",

            };
            Trainer t2 = new Trainer()
            {
                TrainerId = 2,
                TrainerName = "Karthik",
                Topics = new[]
                {
                    new Topic{TopicId=100,TopicName="Angular"},
                    new Topic{TopicId=101,TopicName="SQL Server"},
                    new Topic{TopicId=102,TopicName="Javascript"},
                }
            };
            db.Trainers.Add(t1);
            db.Trainers.Add(t2);
            int records = db.SaveChanges();
            Console.WriteLine("{0} Trainer added", records);


        }
        public static void AddTopic(MyDbContext db)
        {
            Topic t1 = new Topic()
            {
                TopicId = 103,
                TopicName = "Html"
            };
            Topic t2 = new Topic()
            {
                TopicId = 104,
                TopicName = "Css",
                Trainers = new[]
                {
                    new Trainer() { TrainerId=3,TrainerName="Vijay" },
                    new Trainer() { TrainerId=4,TrainerName="RamNath" }

                }

            };
            db.Topic.Add(t1); db.Topic.Add(t2);
            int records = db.SaveChanges();
            Console.WriteLine("{0} Trainer added", records);
        }
        static void EagerLoadBrandsModels(MyDbContext db)
        {
            var brands = db.AllBrands.Include(b => b.Models);
            foreach (var b in brands)
            {
                Console.WriteLine("Brand Name: {0}", b.BrandName);
                Console.WriteLine("\tMODEL COUNT: {0}", b.Models.Count);
                foreach (var m in b.Models)
                {
                    Console.WriteLine("\tModel: {0}", m.ModelName);
                }
            }
        }
        static void EagerLoadDeptEmp(MyDbContext db)
        {
            var depts = db.Departments.Include(b => b.Employees).ThenInclude(b => b.Colors);
            foreach (var e in depts)
            {
                Console.WriteLine("Department Name: {0}", e.DepartmentName);
                Console.WriteLine("Employees COUNT: {0}", e.Employees.Count);
                foreach (var m in e.Employees)
                {
                    Console.WriteLine("\tModel: {0}", m.EmployeeName);
                    foreach (var n in m.Colors)
                    {
                        Console.WriteLine("Fav Color:{0}",n.ColorsName);
                    }
                }

            }

        }

        static void EagerLoadEmpDept(MyDbContext db)
        {
            var color = db.Colors.Include(b => b.employee).ThenInclude(b=>b.department);
            foreach (var e in color)
            {
                Console.WriteLine("Fav color is{0}",e.ColorsName);
                Console.WriteLine("Employee Name: {0}", e.employee.EmployeeName);
                Console.WriteLine("Dept Name: {0}", e.employee.department.DepartmentName);
                
            }

        }

        static void ExplicitLoadModelsForBrand(MyDbContext db)
        {
            Console.Write("Enter brand id: ");
            int brandid = int.Parse(Console.ReadLine());
            var brand = db.AllBrands.Find(brandid);
            if (brand == null)
            {
                Console.WriteLine("Brand not found");
            }
            else
            {
                db.Entry(brand).Collection(b => b.Models).Load();//.reference is added to get child to parent
                Console.WriteLine("Brand name: {0}", brand.BrandName);
                Console.WriteLine("Models...");
                foreach (var m in brand.Models)
                {
                    Console.WriteLine("\t{0}", m.ModelName);
                }
            }
        }

        static void ExplicitLoadDeptEmp(MyDbContext db)
        {
            Console.WriteLine("Enter the Dept ID:");
            int deptid = int.Parse(Console.ReadLine());
            var dept = db.Departments.Find(deptid);
            if (dept == null)
            {
                Console.WriteLine("Dept ID not found");
            }
            else
            {
                db.Entry(dept).Collection(dept => dept.Employees).Load();

                Console.WriteLine("Dept Name: {0}", dept.DepartmentName);
                Console.WriteLine("Employees:->");
                foreach (var m in dept.Employees)
                {
                    
                    Console.WriteLine("\t{0}", m.EmployeeName);
                    //db.Entry(m).Collection(col => col.Colors).Load();
                    foreach(var c in m.Colors)
                    {
                        Console.WriteLine("Fav Color is:{0}",c.ColorsName);
                    }
                }

            }

        }

        static void ExplicitLoadEmpDept(MyDbContext db)
        {
            Console.WriteLine("Enter EmpID");
            int empid = int.Parse(Console.ReadLine());
            var emp = db.Employees.Find(empid);
            if (emp == null)
            {
                Console.WriteLine("Employee not found");

            }
            else
            {
                db.Entry(emp).Reference(emp => emp.department).Load();
                Console.WriteLine("Employee Name: {0}", emp.EmployeeName);
                Console.WriteLine("Department Name:{0}", emp.department.DepartmentName);

            }
            static void LazyLoadBrandsModels(MyDbContext db)
            {
                var brands = db.AllBrands;
                foreach (var b in brands)
                {
                    Console.WriteLine(b.BrandName);
                    foreach (var m in b.Models)
                    {
                        Console.WriteLine("\t{0}", m.ModelName);
                    }
                }
            }

        }

        public class MyDbContext : DbContext
        {
            public DbSet<Brand> AllBrands { get; set; }
            public DbSet<Model> AllModels { get; set; }

            public DbSet<Country> AllCountry { get; set; }
            public DbSet<Capital> AllCapital { get; set; }
            public DbSet<Trainer> Trainers { get; set; }
            public DbSet<Topic> Topic { get; set; }
            public DbSet<Department> Departments { get; set; }
            public DbSet<Employee> Employees { get; set; }
            public DbSet<Colors> Colors {get; set; }
            protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
            {



                //string connstring = "server=CTAADPG038Q88\\SQLEXPRESS;database=efcoredb;integrated security=true;TrustServerCertificate=true";
                //string connstring = "server=CTAADPG038Q88\\SQLEXPRESS;database = efcoredb;uid = sa; pwd = Password_123;TrustServerCertificate=true;";
                string connstring = "server=CTAADPG038Q88\\SQLEXPRESS;database=efcorerelationshipdb;integrated security=true;TrustServerCertificate=True;MultipleActiveResultSets=True";
                optionsBuilder.UseSqlServer(connstring).LogTo(Console
                    .WriteLine, new[] { DbLoggerCategory.Database.Command.Name }, Microsoft.Extensions.Logging.LogLevel.Information);//writeline -->logs will be written to the console,new...->give me onlt the name of SQL command
                                                                                                                                     //if we dont give that second parmameter it will also display some other info,again a way to filter the logs which tells dont give me meta data but onl sql querries
                                                                                                                                     //overide the on congiguring methood and specify which database you want to conect your database to and userSqlServer is used to connect to a database 
                optionsBuilder.UseLazyLoadingProxies();

            }

        }
    }
}