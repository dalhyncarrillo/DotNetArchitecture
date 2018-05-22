using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Solution.CrossCutting.Utils;

namespace Solution.Infrastructure.Databases.EntityFrameworkCore
{
	public class EntityFrameworkCoreRepository<TEntity> : IRepository<TEntity> where TEntity : class
	{
		protected EntityFrameworkCoreRepository(DbContext context)
		{
			Context = context;
			Context.ChangeTracker.AutoDetectChangesEnabled = false;
			Context.ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
		}

		private DbSet<TEntity> Set => Context.Set<TEntity>();

		private DbContext Context { get; }

		public void Add(TEntity entity)
		{
			Set.Add(entity);
		}

		public void AddRange(params TEntity[] entities)
		{
			Set.AddRange(entities);
		}

		public bool Any()
		{
			return Set.Any();
		}

		public bool Any(Expression<Func<TEntity, bool>> where)
		{
			return Set.Any(where);
		}

		public Task<bool> AnyAsync()
		{
			return Set.AnyAsync();
		}

		public Task<bool> AnyAsync(Expression<Func<TEntity, bool>> where)
		{
			return Set.AnyAsync(where);
		}

		public long Count()
		{
			return Set.LongCount();
		}

		public long Count(Expression<Func<TEntity, bool>> where)
		{
			return Set.LongCount(where);
		}

		public Task<long> CountAsync()
		{
			return Set.LongCountAsync();
		}

		public Task<long> CountAsync(Expression<Func<TEntity, bool>> where)
		{
			return Set.LongCountAsync(where);
		}

		public void Delete(object key)
		{
			var entityContext = Find(key);

			if (entityContext != null)
			{
				Set.Remove(entityContext);
			}
		}

		public TEntity Find(object key)
		{
			return Set.Find(key);
		}

		public Task<TEntity> FindAsync(object key)
		{
			return Set.FindAsync(key);
		}

		public TEntity FirstOrDefault(params Expression<Func<TEntity, object>>[] properties)
		{
			return Queryable(properties).FirstOrDefault();
		}

		public TEntity FirstOrDefault(Expression<Func<TEntity, bool>> where, params Expression<Func<TEntity, object>>[] properties)
		{
			return Queryable(where, properties).FirstOrDefault();
		}

		public Task<TEntity> FirstOrDefaultAsync(params Expression<Func<TEntity, object>>[] properties)
		{
			return Queryable(properties).FirstOrDefaultAsync();
		}

		public Task<TEntity> FirstOrDefaultAsync(Expression<Func<TEntity, bool>> where, params Expression<Func<TEntity, object>>[] properties)
		{
			return Queryable(where, properties).FirstOrDefaultAsync();
		}

		public TEntity LastOrDefault(params Expression<Func<TEntity, object>>[] properties)
		{
			return Queryable(properties).LastOrDefault();
		}

		public TEntity LastOrDefault(Expression<Func<TEntity, bool>> where, params Expression<Func<TEntity, object>>[] properties)
		{
			return Queryable(where, properties).LastOrDefault();
		}

		public Task<TEntity> LastOrDefaultAsync(params Expression<Func<TEntity, object>>[] properties)
		{
			return Queryable(properties).LastOrDefaultAsync();
		}

		public Task<TEntity> LastOrDefaultAsync(Expression<Func<TEntity, bool>> where, params Expression<Func<TEntity, object>>[] properties)
		{
			return Queryable(where, properties).LastOrDefaultAsync();
		}

		public IEnumerable<TEntity> List(params Expression<Func<TEntity, object>>[] properties)
		{
			return Queryable(properties).ToList();
		}

		public IEnumerable<TEntity> List(Expression<Func<TEntity, bool>> where, params Expression<Func<TEntity, object>>[] properties)
		{
			return Queryable(where, properties).ToList();
		}

		public PagedList<TEntity> List(PagedListParameters parameters, params Expression<Func<TEntity, object>>[] properties)
		{
			return new PagedList<TEntity>(Queryable(properties), parameters);
		}

		public PagedList<TEntity> List(PagedListParameters parameters, Expression<Func<TEntity, bool>> where, params Expression<Func<TEntity, object>>[] properties)
		{
			return new PagedList<TEntity>(Queryable(where, properties), parameters);
		}

		public async Task<IEnumerable<TEntity>> ListAsync(params Expression<Func<TEntity, object>>[] properties)
		{
			return await Queryable(properties).ToListAsync().ConfigureAwait(false);
		}

		public async Task<IEnumerable<TEntity>> ListAsync(Expression<Func<TEntity, bool>> where, params Expression<Func<TEntity, object>>[] properties)
		{
			return await Queryable(where, properties).ToListAsync().ConfigureAwait(false);
		}

		public IQueryable<TEntity> Queryable(params Expression<Func<TEntity, object>>[] properties)
		{
			return Set.AsQueryable().Include(properties);
		}

		public IQueryable<TEntity> Queryable(Expression<Func<TEntity, bool>> where, params Expression<Func<TEntity, object>>[] properties)
		{
			return Set.Where(where).Include(properties);
		}

		public IQueryable<TEntityResult> QueryableMapResult<TEntityResult>(Expression<Func<TEntity, TEntityResult>> result)
		{
			return Queryable().Select(result);
		}

		public IQueryable<TEntityResult> QueryableMapResult<TEntityResult>(Expression<Func<TEntity, TEntityResult>> result, Expression<Func<TEntity, bool>> where)
		{
			return Queryable(where).Select(result);
		}

		public TEntity SingleOrDefault(Expression<Func<TEntity, bool>> where, params Expression<Func<TEntity, object>>[] properties)
		{
			return Queryable(where, properties).SingleOrDefault();
		}

		public Task<TEntity> SingleOrDefaultAsync(Expression<Func<TEntity, bool>> where, params Expression<Func<TEntity, object>>[] properties)
		{
			return Queryable(where, properties).SingleOrDefaultAsync();
		}

		public void Update(TEntity entity, object key)
		{
			var entityContext = Find(key);

			if (entityContext != null)
			{
				Context.Entry(entityContext).CurrentValues.SetValues(entity);
			}
		}
	}
}
