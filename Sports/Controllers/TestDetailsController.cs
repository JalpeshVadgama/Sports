using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Sports.Models;
using Sports.Services.Interface;

namespace Sports.Controllers
{
    /// <summary>
    /// Controller to show Add,Edit and Delete ahthlete 
    /// </summary>
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

        /// <summary>
        /// A action result to create athelete for a test
        /// </summary>
        /// <param name="id">Test idfor which to create athelete</param>
        /// <returns>View of create</returns>
        public async Task<IActionResult> Create(int? id)
        {
            var users = await _userService.GetAllAsync();
            ViewData["UserId"] = new SelectList(users, "Id", "UserName");
            ViewData["TestId"] = id;
            return View();
        }

        //  [Authorize(Roles = "Coach")]
        /// <summary>
        /// A post method to create athlete for the test
        /// </summary>
        /// <param name="id">Test for which mehtod need to be created</param>
        /// <param name="testDetail">Details of Athelete</param>
        /// <returns>Redirect back to details view of test</returns>
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

        /// <summary>
        /// A method to edit Athelete details for a test
        /// </summary>
        /// <param name="id">Id of Athelete details</param>
        /// <returns>return view of edit </returns>
        //  [Authorize(Roles = "Coach")]
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

        /// <summary>
        /// A post method to edit athelete details for a test
        /// </summary>
        /// <param name="id">Id for which athelte details need to be updated</param>
        /// <param name="returnUrl">A url to return back on previous page</param>
        /// <param name="testDetail">Details of ahtelete</param>
        /// <returns>return to previous url</returns>
        //  [Authorize(Roles = "Coach")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, string returnUrl, [Bind("Id,UserId,TestId,Distnace")] TestDetail testDetail)
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

         /// <summary>
         /// A method to delete athelte result for a test
         /// </summary>
         /// <param name="id">Id of athlete details</param>
         /// <param name="testId">Id for the test</param>
         /// <returns>redirect back to details page of test</returns>
        //  [Authorize(Roles = "Coach")]
        public async Task<IActionResult> Delete(int id, int testId)
        {
            var returnUrl = Request.Headers["Referer"].ToString();
            await _testDetailService.Delete((int)id);
            return RedirectToAction("Details","Tests", new { id = testId });
        }
    }
}
