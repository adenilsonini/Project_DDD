using JSP.Domain.Entities;
using JSP.Domain.Interfaces;
using JSP_Infra.Context;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace JSP_Infra.Repository
{
    public class UserRepository : BaseRepository<User>, IRepositoryUser
    {
        public UserRepository(MySqlContext mySqlContext) : base(mySqlContext)
        {
        }

        public async Task Remove(int id) =>
          await base.Delete(id);

        public async Task Save(User obj)
        {
            if (obj.Id == 0)
              await base.Insert(obj);
            else
              await base.Update(obj, _mySqlContext.Entry(obj).Property(prop => prop.Password));
        }

        public async Task<User> GetById(int id) =>
           await base.Select(id);

        public async  Task<IList<User>> GetAll() =>
           await base.Select();

    }
}
