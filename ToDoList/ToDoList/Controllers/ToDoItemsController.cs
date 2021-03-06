﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.EntityFrameworkCore;
using ToDoList.Data;
using ToDoList.Models;
using ToDoList.Models.ViewModels;

namespace ToDoList.Controllers
{
    [Authorize]
    public class ToDoItemsController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;


        public ToDoItemsController(ApplicationDbContext context, UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }


        // GET: ToDoItems
        public async Task<IActionResult> Index(string filterButton)
        {
            var user = await GetCurrentUserAsync();

            if (filterButton == "To Do")
            {
                var items = await _context.ToDoList
                  .Where(ti => ti.ApplicationUserId == user.Id)
                  .Where(ti => ti.ToDoStatusId == 1)
                  .Include(ti => ti.ToDoStatus)
                  .ToListAsync();


                return View(items);
            }
            else if (filterButton == "Progress")
            {
                var items = await _context.ToDoList
                  .Where(ti => ti.ApplicationUserId == user.Id)
                  .Where(ti => ti.ToDoStatusId == 2)
                  .Include(ti => ti.ToDoStatus)
                  .ToListAsync();

                return View(items);
            }
            else if (filterButton == "Done")
            {
                var items = await _context.ToDoList
                  .Where(ti => ti.ApplicationUserId == user.Id)
                  .Where(ti => ti.ToDoStatusId == 3)
                  .Include(ti => ti.ToDoStatus)
                  .ToListAsync();

                return View(items);
            }
            else
            {
                var items = await _context.ToDoList
                 .Where(si => si.ApplicationUserId == user.Id)
                 .Include(t => t.ToDoStatus)
                 .ToListAsync();

                return View(items);
            }
        }

        // GET: ToDoItems/Create
        public IActionResult Create()
        {
            ViewData["ApplicationUserId"] = new SelectList(_context.ApplicationUser, "Id", "Id");
            ViewData["ToDoStatusId"] = new SelectList(_context.ToDoStatuses, "Id", "Title");
            return View();
        }

  


        // POST: ToDoItems/Create
        [HttpPost]
        [ValidateAntiForgeryToken]

        public async Task<IActionResult> Create([Bind("Id, Title, ToDoStatusId, ApplicationUserId")] ToDoItem toDoItem)
        {
            try
            {
                var user = await GetCurrentUserAsync();
                toDoItem.ApplicationUserId = user.Id;

                _context.ToDoList.Add(toDoItem);
                await _context.SaveChangesAsync();

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

  


        // GET: ToDoItems/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var toDoItem = await _context.ToDoList.FindAsync(id);
            if (toDoItem == null)
            {
                return NotFound();
            }
            ViewData["ApplicationUserId"] = new SelectList(_context.ApplicationUser, "Id", "Id", toDoItem.ApplicationUserId);
            ViewData["ToDoStatusId"] = new SelectList(_context.ToDoStatuses, "Id", "Title", toDoItem.ToDoStatusId);
            return View(toDoItem);
        }




        // POST: ToDoItems/Edit/5
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Title,ToDoStatusId,ApplicationUserId")] ToDoItem toDoItem)
        {
            if (id != toDoItem.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(toDoItem);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ToDoItemExists(toDoItem.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["ApplicationUserId"] = new SelectList(_context.ApplicationUser, "Id", "Id", toDoItem.ApplicationUserId);
            ViewData["ToDoStatusId"] = new SelectList(_context.ToDoStatuses, "Id", "Id", toDoItem.ToDoStatusId);
            return View(toDoItem);
        }

        // GET: ToDoItems/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var toDoItem = await _context.ToDoList
                .Include(i => i.ToDoStatus)
                .FirstOrDefaultAsync(i => i.Id == id);
            if (toDoItem == null)
            {
                return NotFound();
            }

            return View(toDoItem);
        }




        // POST: ToDoItems/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }


        }

            private bool ToDoItemExists(int id)
            {
                return _context.ToDoList.Any(e => e.Id == id);
            }
            private Task<ApplicationUser> GetCurrentUserAsync() => _userManager.GetUserAsync(HttpContext.User);
        }
    }

