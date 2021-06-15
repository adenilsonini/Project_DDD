using JSP.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace JSP.Domain.Interfaces
{
    public interface IRepositoryUser
    {
        Task Save(User obj);

        Task Remove(int id);

        Task<User> GetById(int id);

        Task<IList<User>> GetAll();
    }
}

