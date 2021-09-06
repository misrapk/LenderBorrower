using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using InAndOut.Data;
using InAndOut.Models;
using Microsoft.AspNetCore.Mvc;

namespace InAndOut.Controllers
{
	public class ItemController : Controller
	{
		//dependency injection
		private readonly AppDbContext _db;

		public ItemController(AppDbContext db)
		{
			_db = db;
		}
		public IActionResult Index()
		{
			IEnumerable<Item> objList = _db.Items;
			
			return View(objList);
		}

		//Get Create
		public IActionResult Create()
		{
			return View();
		}


		//POst Create
		[HttpPost]
		[ValidateAntiForgeryToken]
		public IActionResult Create(Item obj)
		{
			////make entry to db
			_db.Items.Add(obj);
			_db.SaveChanges();
			return RedirectToAction("Index");
		}
	}
}
