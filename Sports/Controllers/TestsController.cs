﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Sports.Data;
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
        public async Task<IActionResult> Index()
        {
            List<Test> tests = new List<Test>();
            return View(tests);
        }

        //// GET: Tests/Details/5
        //public async Task<IActionResult> Details(int? id)
        //{
        //    if (id == null)
        //    {
        //        return NotFound();
        //    }

        //    var test = await _context.Test
        //        .FirstOrDefaultAsync(m => m.Id == id);
        //    if (test == null)
        //    {
        //        return NotFound();
        //    }

        //    return View(test);
        //}

        // GET: Tests/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Tests/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,TypeOfTest,TestDate")] Test test)
        {
            if (ModelState.IsValid)
            {
                await _testService.AddTest(test);
                return RedirectToAction(nameof(Index));
            }
            return View(test);
        }

    }
}