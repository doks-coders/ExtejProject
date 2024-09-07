using ExtejProject.Infrastructure.Data;
using ExtejProject.Infrastructure.Interfaces;
using LinqKit;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ExtejProject.Infrastructure.Repositories
{

		public class BaseRepository<T> : IBaseRepository<T> where T : class
		{
			internal readonly DbSet<T> _dbSet;
			internal readonly ApplicationDbContext _context;
			public BaseRepository(ApplicationDbContext context)
			{
				_dbSet = context.Set<T>();
				_context = context;
			}

			public async Task<T> GetItem(Expression<Func<T, bool>> query, string? includeProperties = null)
			{
				var dbSetQueryable = _dbSet.AsQueryable();
				dbSetQueryable = IncludeProperties(dbSetQueryable, includeProperties);
				return await dbSetQueryable.Where(query).FirstOrDefaultAsync();

			}
			public async Task<IEnumerable<T>> GetItems(Expression<Func<T, bool>> query, string? includeProperties = null)
			{
				var dbSetQueryable = _dbSet.AsQueryable();
				dbSetQueryable = IncludeProperties(dbSetQueryable, includeProperties);
				return await dbSetQueryable.Where(query).ToListAsync(); ;
			}




			public async Task<bool> AddItem(T entity)
			{
				await _dbSet.AddAsync(entity);
				return 0 < await _context.SaveChangesAsync();
			}

			public async Task<bool> AddItems(IEnumerable<T> entities)
			{
				await _dbSet.AddRangeAsync(entities);
				return 0 < await _context.SaveChangesAsync();
			}


			public async Task<bool> DeleteItem(T entity)
			{
				_dbSet.Remove(entity);
				return 0 < await _context.SaveChangesAsync();
			}

			public async Task<bool> DeleteItems(IEnumerable<T> entities)
			{
				_dbSet.RemoveRange(entities);
				return 0 < await _context.SaveChangesAsync();

			}
		private IQueryable<T> IncludeProperties(IQueryable<T> dbSetQueryable, string includeProperties)
		{
			if (includeProperties != null)
			{
				var properties = includeProperties.Split(",", StringSplitOptions.RemoveEmptyEntries);
				foreach (var property in properties)
				{
					dbSetQueryable = dbSetQueryable.Include(property);
				}
			}
			return dbSetQueryable;
		}


	}
}
