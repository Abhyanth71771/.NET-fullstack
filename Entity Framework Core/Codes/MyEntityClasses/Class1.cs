﻿using System.ComponentModel.DataAnnotations.Schema;

namespace MyEntityClasses
{
    public class User
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)] //if this is not given thn USerID becomes an identity column and SQL add autogenerated values to this feild 
                                                          //but if this is given the column will onl be a primary e=key and not a identity column so data is not autogenerated and we can give values to the column
                                                          //this line is similar to decorator in angular(meta data)
        public int UserID { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        //public string Gender { get; set; }//if a column is added after the database and table is generated the new column wont be modified in SQL 

    }

    public class Employee
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int EmployeeID { get; set; }
        public string EmpName { get; set; }
        //by default all the entries to the table are not nullable to make it nullable  put a ? in front  of the string
        //to make it nullabe all the primary key are not nullable by default 

    }
}