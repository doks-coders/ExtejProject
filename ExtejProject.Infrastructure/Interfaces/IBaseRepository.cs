﻿using System.Linq.Expressions;

namespace ExtejProject.Infrastructure.Interfaces
{

	public interface IBaseRepository<T> where T : class
	{
		Task<T> GetItem(Expression<Func<T, bool>> query, string? includeProperties = null);
		Task<IEnumerable<T>> GetItems(Expression<Func<T, bool>> query, string? includeProperties = null);
		Task<bool> AddItem(T entity);
		Task<bool> AddItems(IEnumerable<T> entities);
		Task<bool> DeleteItem(T entity);
		Task<bool> DeleteItems(IEnumerable<T> entities);
	}
}
