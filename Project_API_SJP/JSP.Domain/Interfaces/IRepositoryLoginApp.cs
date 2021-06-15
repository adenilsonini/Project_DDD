using JSP.Domain.Entities;
using JSP.Domain.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace JSP.Domain.Interfaces
{
    public interface IRepositoryLoginApp
    {
        Task<User> SelectId(int id);
        Task<User> LoginUser(AuthenticateRequest model);

    }
}
