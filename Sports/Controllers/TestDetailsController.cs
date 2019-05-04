using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Sports.Models;
using Sports.Services.Interface;

namespace Sports.Controllers
{
    public class TestDetailsController : Controller
    {
        private readonly ITestDetailService _testDetailService;
        private readonly IUserService _userService;
        private readonly ITestService _testService;

        public TestDetailsController(ITestDetailService testDetailService, IUserService userService, ITestService testService)
        {
            _testDetailService = testDetailService;
            _userService = userService;
            _testService = testService;
        }

        // GET: TestDetails/Create
        public async Task<IActionResult> Create(int? id)
        {
            var users = await _userService.GetAllAsync();
            ViewData["UserId"] = new SelectList(users, "Id", "UserName");
            ViewData["TestId"] = id;
            return View();
        }

        // POST: TestDetails/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(int? id, [Bind("UserId,TestId,Distnace")] TestDetail testDetail)
        {
            if (ModelState.IsValid)
            {
                testDetail.TestId = (int)id;
                await _testDetailService.Add(testDetail);
                return RedirectToAction("Details", "Tests", new { @id = id });
            }
            var users = await _userService.GetAllAsync();
            ViewData["UserId"] = new SelectList(users, "Id", "UserName");
            return View(testDetail);
        }

        // GET: TestDetails/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            ViewBag.returnUrl = Request.Headers["Referer"].ToString();
            if (id == null)
            {
                return NotFound();
            }

            var testDetail = await _testDetailService.Get((int)id);
            if (testDetail == null)
            {
                return NotFound();
            }

            var users = await _userService.GetAllAsync();
            ViewData["UserId"] = new SelectList(users, "Id", "UserName");
         
            return View(testDetail);
        }

        // POST: TestDetails/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id,string returnUrl, [Bind("Id,UserId,TestId,Distnace")] TestDetail testDetail)
        {
            if (id != testDetail.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    await _testDetailService.Update(testDetail);
                }
                catch (Exception)
                {
                    return View(testDetail);
                }
                return Redirect(returnUrl);
            }
          
            return View(testDetail);
        }

        //// GET: TestDetails/Delete/5
        //public async Task<IActionResult> Delete(int? id)
        //{
        //    if (id == null)
        //    {
        //        return NotFound();
        //    }

        //    var testDetail = await _context.TestDetail
        //        .Include(t => t.ApplicationUser)
        //        .Include(t => t.Test)
        //        .FirstOrDefaultAsync(m => m.Id == id);
        //    if (testDetail == null)
        //    {
        //        return NotFound();
        //    }

        //    return View(testDetail);
        //}

        //// POST: TestDetails/Delete/5
        //[HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> DeleteConfirmed(int id)
        //{
        //    var testDetail = await _context.TestDetail.FindAsync(id);
        //    _context.TestDetail.Remove(testDetail);
        //    await _context.SaveChangesAsync();
        //    return RedirectToAction(nameof(Index));
        //}
    }
}
