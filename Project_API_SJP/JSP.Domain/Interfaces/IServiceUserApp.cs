using JSP.Domain.Entities;
using JSP.Domain.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace JSP.Domain.Interfaces
{
    public interface IServiceUserApp
    {
        Task<UserView> Insert(InputUser userModel);

        Task<UserView> Update(int id, InputUser userModel);

        Task Delete(int id);

        Task<UserView> RecoverById(int id);

        Task<IEnumerable<UserView>> RecoverAll();

    }
}
