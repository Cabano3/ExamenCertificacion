using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BEUBiblioteca.Transactions
{
	public class LibroBLL
	{
		public static Libro Get(int? id)
		{
			Entities db = new Entities();
			return db.Libro.Find(id);
		}

		public static void Create(Libro l)
		{
			using (Entities db = new Entities())
			{
				using (var transaction = db.Database.BeginTransaction())
				{
					try
					{
						db.Libro.Add(l);
						db.SaveChanges();
						transaction.Commit();
					}
					catch (Exception)
					{
						transaction.Rollback();
						throw;
					}
				}
			}
		}

		public static void Update(Libro l)
		{
			using (Entities db = new Entities())
			{
				using (var transaction = db.Database.BeginTransaction())
				{
					try
					{
						db.Libro.Attach(l);
						db.Entry(l).State = System.Data.Entity.EntityState.Modified;
						db.SaveChanges();
						transaction.Commit();
					}
					catch (Exception ex)
					{
						transaction.Rollback();
						throw ex;
					}
				}
			}
		}

		public static void Delete(int? id)
		{
			using (Entities db = new Entities())
			{
				using (var transaction = db.Database.BeginTransaction())
				{
					try
					{
						Libro l = db.Libro.Find(id);
						db.Entry(l).State = System.Data.Entity.EntityState.Deleted;
						db.SaveChanges();
						transaction.Commit();
					}
					catch (Exception ex)
					{
						transaction.Rollback();
						throw ex;
					}
				}
			}
		}

		public static List<Libro> List()
		{
			Entities db = new Entities();
			return db.Libro.ToList();
		}
	}
}
