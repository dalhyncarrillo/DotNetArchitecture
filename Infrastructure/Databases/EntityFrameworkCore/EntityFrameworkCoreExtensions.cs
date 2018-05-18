using System;
using System.Linq;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;

namespace Solution.Infrastructure.Databases.EntityFrameworkCore
{
	public static class EntityFrameworkCoreExtensions
	{
		public static IQueryable<TEntity> Include<TEntity>(this IQueryable<TEntity> queryable, Expression<Func<TEntity, object>>[] properties) where TEntity : class
		{
			properties?.ToList().ForEach(property => queryable = queryable.Include(property));
			return queryable;
		}
	}
}
