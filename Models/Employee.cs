using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Zen.intranet.web.Models
{
    public class Employee
    {
        public  Employee()
        {

        }

        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(40)]
        public String Firstname { get; set; }
        public int FieldExperience { get; set; }
        public int Salary { get; set; }

        public int DOb { get; set; }

    }
    public class Department
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public String Name { get; set; }

        [Required]
        public String Description { get; set; }

        public virtual ICollection<Employee> Employees { get; set; }
    }

    public class User
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public String UserName { get; set; }

        [DataType(DataType.Password)]
        [Required]
         public String Password { get; set; }
        
    }

    
}