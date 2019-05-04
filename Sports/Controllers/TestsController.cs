using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Sports.Models;
using Sports.Services.Interface;

namespace Sports.Controllers
{
   
    public class TestsController : Controller
    {
        private readonly ITestService _testService;

        public TestsController(ITestService testService)
        {
            _testService = testService;
        }

        // GET: Tests
        public IActionResult Index()
        {
            var tests = _testService.GetAll();
            return View(tests);
        }


        //// GET: Tests/Details/5
        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var testDetails = _testService.GetDetailsOfTest((int)id);
            return View(testDetails);
        }

        // GET: Tests/Create
        public IActionResult Create()
        {
            return View();
        }


        //[Authorize(Roles = "Coach")]
        // POST: Tests/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,TypeOfTest,TestDate")] Test test)
        {
            if (ModelState.IsValid)
            {
                await _testService.Add(test);
                return RedirectToAction(nameof(Index));
            }
            return View(test);
        }

        //[Authorize(Roles = "Coach")]
        // GET: TestDetails/Delete/5
        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            _testService.Delete((int)id);
            return RedirectToAction("Index", "Tests");
        }
    }
}
