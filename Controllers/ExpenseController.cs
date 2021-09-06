using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using InAndOut.Data;
using InAndOut.Models;
using Microsoft.AspNetCore.Mvc;

namespace InAndOut.Controllers
{
	public class ExpenseController : Controller
	{

		//dependency injection
		private readonly AppDbContext _db;

		public ExpenseController(AppDbContext db)
		{
			_db = db;
		}
		public IActionResult Index()
		{
			IEnumerable<Expense> objList = _db.Expenses;

			return View(objList);
		}

		//GET
		public IActionResult Create()
		{
			return View();
		}

		//POST
		[HttpPost]
		[ValidateAntiForgeryToken]

		public IActionResult Create(Expense obj)
		{
			//check for valid data
			if (ModelState.IsValid)
			{
				_db.Expenses.Add(obj);
				_db.SaveChanges();
				return RedirectToAction("Index");
			}
			return View(obj);
		}


		//to send the user to another page


		// GET-Delete
		public IActionResult Delete(int? id)
		{
			if (id == null || id == 0)
			{
				return NotFound();
			}
			var obj = _db.Expenses.Find(id);
			if (obj == null)
			{
				return NotFound();
			}
			return View(obj);
		}

		[HttpPost]
		[ValidateAntiForgeryToken]
		public IActionResult DeletePost(int? id)
		{
			var obj = _db.Expenses.Find(id);
			if (obj == null)
			{
				return NotFound();
			}
			_db.Expenses.Remove(obj);
			_db.SaveChanges();
			return RedirectToAction("Index");
		}

		//for update
		public IActionResult Update(int? id)
		{
			if (id == null || id == 0)
			{
				return NotFound();
			}
			var obj = _db.Expenses.Find(id);
			if (obj == null)
			{
				return NotFound();
			}
			return View(obj);
		}

		[HttpPost]
		[ValidateAntiForgeryToken]
		public IActionResult Update(Expense obj)
		{
			if (ModelState.IsValid)
			{
				_db.Expenses.Update(obj);
				_db.SaveChanges();
				return RedirectToAction("Index");
			}
			return View(obj);


		}


	}
}
