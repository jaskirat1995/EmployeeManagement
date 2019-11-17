using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EmployeeManagement.Models
{
    public class DepartmenModel
    {
        public int ID { get; set; }
        public string Name { get; set; }
    }
    public class DepartmenModelList
    {
        public List<DepartmenModel> list { get; set; }
    }
}