using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using InAndOut.Models;
using Microsoft.EntityFrameworkCore;

namespace InAndOut.Data
{
	public class AppDbContext : DbContext
	{
		public AppDbContext(DbContextOptions<AppDbContext> options): base(options)
		{

		}

		//dbsets
		public DbSet<Item> Items { get; set; }
		public DbSet<Expense> Expenses { get; set; }
	}
}
