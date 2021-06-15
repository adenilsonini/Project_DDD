using JSP.Domain.Entities;
using JSP.Domain.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace JSP.Domain.Interfaces
{
    public interface IServiceUserLoginApp
    {
        Task<UserView> GetById(int id);
        Task<AuthenticateResponse> Authenticate(AuthenticateRequest model);
    }
}
