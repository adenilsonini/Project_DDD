using JSP.Domain.Entities;
using JSP.Domain.Interfaces;
using JSP_Infra.Context;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JSP_Infra.Repository
{
    public class UserRepositoryMy : IRepositoryUser
    {
        protected readonly MySqlContext _mySqlContext;

        public UserRepositoryMy(MySqlContext mySqlContext)
        {
            _mySqlContext = mySqlContext;
        }

        protected virtual async Task<User> Select(int id)
        {
            IQueryable<User> query = _mySqlContext.Users;

            query = query.AsNoTracking()
                         .OrderBy(s => s.Id)
                         .Where(aluno => aluno.Id == id);

            return await query.FirstOrDefaultAsync();
        }

        public async Task Remove(int id) {
            _mySqlContext.Set<User>().Remove(await Select(id));
             await _mySqlContext.SaveChangesAsync();
        }

        public async Task Save(User obj)
        {
            if (obj.Id == 0)
            {
                _mySqlContext.Set<User>().Add(obj);
                await _mySqlContext.SaveChangesAsync();
            }
            else
            {
                _mySqlContext.Set<User>().Update(await Select(obj.Id));
                await _mySqlContext.SaveChangesAsync();
            }
        }

        public async Task<User> GetById(int id) =>
           await Select(id);

        public async Task<IList<User>> GetAll() {
            IQueryable<User> query = _mySqlContext.Users;

            query = query.AsNoTracking()
                         .OrderBy(s => s.Id);

            return await query.ToListAsync();
        }

    }
}
