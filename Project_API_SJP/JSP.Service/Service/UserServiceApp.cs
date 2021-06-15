using AutoMapper;
using AutoMapper.Configuration;
using Flunt.Validations;
using JSP.Domain.Entities;
using JSP.Domain.Interfaces;
using JSP.Domain.Models;
using JSP_Infra.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JSP.Service.Service
{
    public class UserServiceApp : IServiceUserApp
    {
        private readonly IRepositoryUser _repositoryUser;
        private readonly IMapper _mapper;
        private readonly NotificationContext _notificationContext;
        public UserServiceApp(IRepositoryUser repositoryUser, IMapper mapper, NotificationContext notificationContext)
        {
            _repositoryUser = repositoryUser;
            _mapper = mapper;
            _notificationContext = notificationContext;
        }
        public async Task<UserView> Insert(InputUser userModel)
        {
            var user = _mapper.Map<User>(userModel);

            _notificationContext.AddNotifications(user.Notifications);

            if (_notificationContext.Invalid)
                return default;

            await _repositoryUser.Save(user);

            return _mapper.Map<UserView>(user);
        }

        public async Task<UserView> Update(int id, InputUser userModel)
        {
            userModel.Id = id;
            var user = await _repositoryUser.GetById(id);

            if (user == null)
            {
                Contract contractid = new Contract();
                contractid.AddNotification(nameof(id), "Usuário não encontrado.");
                _notificationContext.AddNotifications(contractid);
                return default;
            }

            
            user = _mapper.Map<User>(userModel);

            _notificationContext.AddNotifications(user.Notifications);

            if (_notificationContext.Invalid)
                return default;

            await _repositoryUser.Save(user);


            return _mapper.Map<UserView>(user);
        }

        public async Task Delete(int id) =>
            await _repositoryUser.Remove(id);

        public async Task<IEnumerable<UserView>> RecoverAll()
        {
            var users = await _repositoryUser.GetAll();

            return _mapper.Map<IList<User>, IEnumerable<UserView>>(users);

        }
        public async Task<UserView> RecoverById(int id)
        {
            var user = await _repositoryUser.GetById(id);

            return _mapper.Map<UserView>(user);
        }

        public async Task<UserView> ById(int id)
        {
            var user = await _repositoryUser.GetById(id);

            return _mapper.Map<UserView>(user);
        }
    }
}
