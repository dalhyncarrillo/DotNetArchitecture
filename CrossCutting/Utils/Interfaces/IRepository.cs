using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Solution.CrossCutting.Utils
{
	public interface IRepository<TEntity> where TEntity : class
	{
		void Add(TEntity entity);

		void AddAsync(TEntity entity);

		void AddRange(params TEntity[] entities);

		void AddRangeAsync(params TEntity[] entities);

		bool Any();

		bool Any(Expression<Func<TEntity, bool>> where);

		Task<bool> AnyAsync();

		Task<bool> AnyAsync(Expression<Func<TEntity, bool>> where);

		long Count();

		long Count(Expression<Func<TEntity, bool>> where);

		Task<long> CountAsync();

		Task<long> CountAsync(Expression<Func<TEntity, bool>> where);

		void Delete(object key);

		TEntity Find(object key);

		Task<TEntity> FindAsync(object key);

		TEntity FirstOrDefault(params Expression<Func<TEntity, object>>[] properties);

		TEntity FirstOrDefault(Expression<Func<TEntity, bool>> where, params Expression<Func<TEntity, object>>[] properties);

		Task<TEntity> FirstOrDefaultAsync(params Expression<Func<TEntity, object>>[] properties);

		Task<TEntity> FirstOrDefaultAsync(Expression<Func<TEntity, bool>> where, params Expression<Func<TEntity, object>>[] properties);

		TEntity LastOrDefault(params Expression<Func<TEntity, object>>[] properties);

		TEntity LastOrDefault(Expression<Func<TEntity, bool>> where, params Expression<Func<TEntity, object>>[] properties);

		Task<TEntity> LastOrDefaultAsync(params Expression<Func<TEntity, object>>[] properties);

		Task<TEntity> LastOrDefaultAsync(Expression<Func<TEntity, bool>> where, params Expression<Func<TEntity, object>>[] properties);

		IEnumerable<TEntity> List(params Expression<Func<TEntity, object>>[] properties);

		IEnumerable<TEntity> List(Expression<Func<TEntity, bool>> where, params Expression<Func<TEntity, object>>[] properties);

		PagedList<TEntity> List(PagedListParameters parameters, params Expression<Func<TEntity, object>>[] properties);

		PagedList<TEntity> List(PagedListParameters parameters, Expression<Func<TEntity, bool>> where, params Expression<Func<TEntity, object>>[] properties);

		Task<IEnumerable<TEntity>> ListAsync(params Expression<Func<TEntity, object>>[] properties);

		Task<IEnumerable<TEntity>> ListAsync(Expression<Func<TEntity, bool>> where, params Expression<Func<TEntity, object>>[] properties);

		IQueryable<TEntity> Queryable(params Expression<Func<TEntity, object>>[] properties);

		IQueryable<TEntity> Queryable(Expression<Func<TEntity, bool>> where, params Expression<Func<TEntity, object>>[] properties);

		IQueryable<TEntityResult> QueryableMapResult<TEntityResult>(Expression<Func<TEntity, TEntityResult>> result);

		IQueryable<TEntityResult> QueryableMapResult<TEntityResult>(Expression<Func<TEntity, TEntityResult>> result, Expression<Func<TEntity, bool>> where);

		TEntity SingleOrDefault(Expression<Func<TEntity, bool>> where, params Expression<Func<TEntity, object>>[] properties);

		Task<TEntity> SingleOrDefaultAsync(Expression<Func<TEntity, bool>> where, params Expression<Func<TEntity, object>>[] properties);

		void Update(TEntity entity, object key);
	}
}
