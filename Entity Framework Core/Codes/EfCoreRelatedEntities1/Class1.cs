using System.ComponentModel.DataAnnotations.Schema;
using System.Drawing;

namespace EFCoreRelatedEntities1
{
    //one to many relationship
    public class Brand
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int BrandId { get; set; }
        public string BrandName { get; set; }
        public virtual ICollection<Model> Models { get; set; }

    }

    public class Model
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int ModelId { get; set; }
        public string ModelName { get; set; }
        //optional 
        //navigation prop
        public virtual Brand Brand { get; set; }//from the child you can get the parent 
        //a dependant entity can have a fk property //this will give us the whole brand based on the model we tell it this is used for our reference
        public int BrandId { get; set; }
    }
    //One to One relationship (1:1)
    public class Country
    { 
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int CountryId { get; set; }
        public string CountryName { get; set; }
        public virtual Capital Capital { get; set; } 
    }
    public class Capital
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int CapitalId { get; set; }                                 
        public string CapitalName { get; set; }
        public int CountryId { get; set; }    
    } 
    //many to many relationship
    public class Trainer
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int TrainerId { get; set; }
        public string TrainerName { get; set; }
        public virtual ICollection<Topic> Topics { get; set; }
    }
    public class Topic
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int TopicId { get; set; }
        public string TopicName { get; set; }
        public virtual ICollection<Trainer> Trainers { get; set; }
    }

    public class Department
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int DepartmentId { get; set;}
        public string DepartmentName { get; set;}
        public virtual ICollection<Employee> Employees { get; set; }


    }

    public class Employee
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int EmployeeId { get; set; }
        public string EmployeeName { get; set; }
        public virtual Department department { get; set; }

        public virtual ICollection<Colors> Colors { get; set; }

    }
    public class Colors
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
         public int ColorsId { get; set;}
        public string ColorsName { get; set;}

        public virtual Employee employee { get; set; }
       
    }
        
}