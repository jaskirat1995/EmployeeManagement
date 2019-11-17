using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EmployeeManagement.Models
{
    public class EmpModel
    {
        public int ID { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        public string Gender { get; set; }
        [Required]
        public string City { get; set; }
        [Required]
        public string State { get; set; }
        public Nullable<int> DepartmentID { get; set; }
        public Nullable<int> SalaryID { get; set; }
        public List<SelectListItem> Departments { get; set; }
        public List<SelectListItem> Salaries { get; set; }
    }

}