using JSP.Domain.Entities;
using JSP.Domain.Interfaces;
using JSP_Infra.Context;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JSP.Domain.Validation.CadUser;
using JSP.Domain.Models;

namespace JSP_Infra.Repository
{
    public class UserLoginRepositoryMy : IRepositoryLoginApp
    {
        protected readonly MySqlContext _mySqlContext;

        public UserLoginRepositoryMy(MySqlContext mySqlContext)
        {
            _mySqlContext = mySqlContext;
        }

       public virtual async Task<User> SelectId(int id)
        {
            IQueryable<User> query = _mySqlContext.Users;

            query = query.AsNoTracking()
                         .OrderBy(s => s.Id)
                         .Where(aluno => aluno.Id == id);

            return await query.FirstOrDefaultAsync();
        }

        public virtual async Task<User> LoginUser(AuthenticateRequest model)
        {
            
            IQueryable<User> query = _mySqlContext.Users;

            query = query.AsNoTracking()
                         .Where(U => U.Email == model.Username && U.Password == model.Password);

            return await query.FirstOrDefaultAsync();
        }

       
    }
}
