using EmployeeManagement.db;
using EmployeeManagement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EmployeeManagement.Controllers
{
    public class EmployeeController : Controller
    {
        // GET: Employee
        public ActionResult Add()
        {
            GetDepartmentsAndSalaries();

            return View();
        }
        public ActionResult Index()
        {
            dbEmployeeEntities entities = new dbEmployeeEntities();
            List<tblEmployee> employees = entities.tblEmployee.ToList();

            //Add a Dummy Row.
            // employees.Insert(0, new tblEmployee());
            return View(employees);
        }

        [HttpGet]
        public ActionResult Edit(int ID)
        {
            using (dbEmployeeEntities entities = new dbEmployeeEntities())
            {


                tblEmployee updatedEmployee = (from c in entities.tblEmployee
                                               where c.ID == ID
                                               select c).FirstOrDefault();
                if (updatedEmployee != null)
                {
                    EmpModel empModel = new EmpModel();
                    empModel.City = updatedEmployee.City;

                    empModel.DepartmentID = updatedEmployee.DepartmentID;
                    var departments = (from p in entities.tblDepartment.AsEnumerable()
                                       select new SelectListItem
                                       {
                                           Text = p.Name,
                                           Value = p.ID.ToString()

                                       }).ToList<SelectListItem>();
                    string deptID = Convert.ToString(updatedEmployee.DepartmentID);



                    var selectedDept = departments.FirstOrDefault(p => p.Value == deptID);
                    selectedDept.Selected = true;
                    empModel.Departments = departments;

                    empModel.FirstName = updatedEmployee.FirstName;
                    empModel.LastName = updatedEmployee.LastName;
                    empModel.SalaryID = updatedEmployee.SalaryID;
                    var salaries = (from p in entities.tblSalary.AsEnumerable()
                                    select new SelectListItem
                                    {
                                        Text = p.Salary.ToString(),
                                        Value = p.ID.ToString()

                                    }).ToList<SelectListItem>();
                    string salaryID = Convert.ToString(updatedEmployee.SalaryID);



                    var selectedSalary = salaries.FirstOrDefault(p => p.Value == salaryID);
                    selectedSalary.Selected = true;
                    empModel.Salaries = salaries;

                    empModel.State = updatedEmployee.State;
                    empModel.Gender = updatedEmployee.Gender;

                    return View(empModel);
                }
                else
                {
                    return HttpNotFound();
                }
            }

        }

        [HttpPost]
        public ActionResult Add(tblEmployee employee, FormCollection collection)
        {


            using (dbEmployeeEntities entities = new dbEmployeeEntities())
            {
                tblEmployee addedEmployee = new tblEmployee();
                addedEmployee.FirstName = employee.FirstName;
                addedEmployee.LastName = employee.LastName;
                addedEmployee.City = employee.City;
                //addedEmployee.DepartmentID = employee.DepartmentID;
                addedEmployee.Gender = employee.Gender;
                addedEmployee.DepartmentID = Convert.ToInt32(collection["DepartmentName"]);
                addedEmployee.SalaryID = Convert.ToInt32(collection["Salary"]);
                addedEmployee.State = employee.State;
                //var count = entities.tblEmployee.Count(p => p.FirstName == employee.FirstName && p.LastName == employee.LastName);
                //if (count > 0)
                //{
                //    ModelState.AddModelError("", "Employee with same name already exists");
                //    GetDepartmentsAndSalaries();

                //    return View();
                //}
                //else
                {
                    entities.tblEmployee.Add(addedEmployee);
                    entities.SaveChanges();
                }
            }

            return RedirectToAction("Index");
        }
        [HttpPost]
        public ActionResult Edit(int ID, tblEmployee employee, FormCollection collection)
        {
            using (dbEmployeeEntities entities = new dbEmployeeEntities())
            {
                tblEmployee updatedEmployee = (from c in entities.tblEmployee
                                               where c.ID == ID
                                               select c).FirstOrDefault();
                updatedEmployee.FirstName = employee.FirstName;
                updatedEmployee.LastName = employee.LastName;
                updatedEmployee.City = employee.City;
                updatedEmployee.DepartmentID = Convert.ToInt32(collection["DepartmentName"]);
                updatedEmployee.SalaryID = Convert.ToInt32(collection["Salary"]);
                updatedEmployee.Gender = employee.Gender;
                updatedEmployee.State = employee.State;
                entities.SaveChanges();
            }

            return RedirectToAction(
"Index");
        }

     

        public ActionResult GetDepartmentsAndSalaries()
        {

            dbEmployeeEntities entities = new dbEmployeeEntities();
            EmpModel tblEmployee = new EmpModel();
            tblEmployee.Departments = (from p in entities.tblDepartment.AsEnumerable()
                                       select new SelectListItem
                                       {
                                           Text = p.Name,
                                           Value = p.ID.ToString()
                                       }).ToList<SelectListItem>();

            tblEmployee.Salaries = (from p in entities.tblSalary.AsEnumerable()
                                    select new SelectListItem
                                    {
                                        Text = p.Salary.ToString(),
                                        Value = p.ID.ToString()
                                    }).ToList<SelectListItem>();
            return View("Add", tblEmployee);
        }


        // GET: PersonalDetails/Delete/5
        public ActionResult Delete(int? id)
        {

            using (dbEmployeeEntities db = new dbEmployeeEntities())
            {

                tblEmployee emp = db.tblEmployee.Include("tblDepartment").Include("tblSalary").FirstOrDefault(p => p.ID == id);
                if (emp == null)
                {
                    return HttpNotFound();
                }
                return View(emp);
            }


        }

        // POST: PersonalDetails/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            using (dbEmployeeEntities db = new dbEmployeeEntities())
            {

                tblEmployee emp = db.tblEmployee.FirstOrDefault(p => p.ID == id);
                if (emp != null)
                {
                    db.tblEmployee.Remove(emp);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
                else
                {
                    return HttpNotFound();
                }
            }
        }
    }
}