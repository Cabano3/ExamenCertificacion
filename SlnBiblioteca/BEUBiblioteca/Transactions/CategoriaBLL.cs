﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BEUBiblioteca.Transactions
{
	public class CategoriaBLL
	{
		public static Categoria Get(int? id)
		{
			Entities db = new Entities();
			return db.Categoria.Find(id);
		}

		public static void Create(Categoria c)
		{
			using (Entities db = new Entities())
			{
				using (var transaction = db.Database.BeginTransaction())
				{
					try
					{
						db.Categoria.Add(c);
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

		public static void Update(Categoria c)
		{
			using (Entities db = new Entities())
			{
				using (var transaction = db.Database.BeginTransaction())
				{
					try
					{
						db.Categoria.Attach(c);
						db.Entry(c).State = System.Data.Entity.EntityState.Modified;
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
						Categoria c = db.Categoria.Find(id);
						db.Entry(c).State = System.Data.Entity.EntityState.Deleted;
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

		public static List<Categoria> List()
		{
			Entities db = new Entities();
			return db.Categoria.ToList();
		}
	}
}
