using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JSP_Infra.Context;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore;

namespace JSP_Infra.Repository
{
    public class BaseRepository<TEntity> where TEntity : class
    {
        protected readonly MySqlContext _mySqlContext;

        public BaseRepository(MySqlContext mySqlContext)
        {
            _mySqlContext = mySqlContext;
        }

        protected virtual async Task Insert(TEntity obj)
        {
            _mySqlContext.Set<TEntity>().Add(obj);
           await _mySqlContext.SaveChangesAsync();
        }

        protected virtual async Task Update(TEntity obj)
        {
            _mySqlContext.Entry(obj).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            await _mySqlContext.SaveChangesAsync();
        }

        protected virtual async Task Update<TProperty>(TEntity obj, params PropertyEntry<TEntity, TProperty>[] propsToIgnore)
        {
            _mySqlContext.Entry(obj).State = Microsoft.EntityFrameworkCore.EntityState.Modified;

            foreach (var item in propsToIgnore)
                item.IsModified = false;

            await _mySqlContext.SaveChangesAsync();
        }

        protected virtual async Task Delete(int id)
        { 
           _mySqlContext.Set<TEntity>().Remove(await Select(id));
            await _mySqlContext.SaveChangesAsync();

        }

        protected virtual async Task <IList<TEntity>> Select() =>
           await _mySqlContext.Set<TEntity>().ToArrayAsync();

        protected virtual async Task<TEntity> Select(int id) =>
          await _mySqlContext.Set<TEntity>().FindAsync(id);
    }
}
