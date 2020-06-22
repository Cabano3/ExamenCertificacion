using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BEUBiblioteca.Transactions
{
	public class VideoBLL
	{
		public static Video Get(int? id)
		{
			Entities db = new Entities();
			return db.Video.Find(id);
		}

		public static void Create(Video v)
		{
			using (Entities db = new Entities())
			{
				using (var transaction = db.Database.BeginTransaction())
				{
					try
					{
						db.Video.Add(v);
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

		public static void Update(Video v)
		{
			using (Entities db = new Entities())
			{
				using (var transaction = db.Database.BeginTransaction())
				{
					try
					{
						db.Video.Attach(v);
						db.Entry(v).State = System.Data.Entity.EntityState.Modified;
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
						Video v = db.Video.Find(id);
						db.Entry(v).State = System.Data.Entity.EntityState.Deleted;
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

		public static List<Video> List()
		{
			Entities db = new Entities();
			return db.Video.ToList();
		}
	}
}
