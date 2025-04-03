using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MVC_CRUD_with_DDL.Models;
using MVC_CRUD_with_DDL.Repository;

namespace MVC_CRUD_with_DDL.Controllers
{
    public class EmpController : Controller
    {
        private readonly IEmpRepo _empRepo;

        public EmpController(IEmpRepo empRepo)
        {
            //_empRepo = new EmpRepo();  //made object of child using parent variable.

            _empRepo = empRepo;

        }
        // GET: EmpController
        public ActionResult Index()
        {
            List<EmpModel> employees = _empRepo.GetEmployees();

            return View(employees);
        }

        // GET: EmpController/Details/5
        public ActionResult Details(int id)
        {
            var emp = _empRepo.GetEmployeeById(id);
            return View(emp);
        }

        // GET: EmpController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: EmpController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(EmpModel emp)
        {
            try
            {
                _empRepo.AddEmployee(emp);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: EmpController/Edit/5
        public ActionResult Edit(int id)
        {
            var emp = _empRepo.GetEmployeeById(id);
            return View(emp);
        }

        // POST: EmpController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, EmpModel emp)
        {
            try
            {
                _empRepo.UpdateEmployee(emp);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: EmpController/Delete/5
        public ActionResult Delete(int id)
        {
            var emp = _empRepo.GetEmployeeById(id);
            return View(emp);
        }

        // POST: EmpController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, EmpModel emp)
        {
            try
            {
                _empRepo.DeleteEmployee(id);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
