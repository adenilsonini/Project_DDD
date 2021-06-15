using AutoMapper;
using AutoMapper.Configuration;
using Flunt.Validations;
using JSP.Domain.Authorization;
using JSP.Domain.Entities;
using JSP.Domain.ExceptionApp;
using JSP.Domain.Interfaces;
using JSP.Domain.Models;
using JSP_Infra.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JSP.Service.Service
{
    public class UserServiceLoginApp : IServiceUserLoginApp
    {
        private readonly IRepositoryLoginApp _repositoryUser;
        private IJwtUtils _jwtUtils;
        private readonly IMapper _mapper;
        private readonly NotificationContext _notificationContext;

        public UserServiceLoginApp(IRepositoryLoginApp repositoryUser, IJwtUtils jwtUtils, IMapper mapper,
            NotificationContext notificationContext)
        {
            _repositoryUser = repositoryUser;
            _jwtUtils = jwtUtils;
            _mapper = mapper;
            _notificationContext = notificationContext;
        }

        public async Task<UserView> GetById(int id)
        {
            var user = await _repositoryUser.SelectId(id);

            return _mapper.Map<UserView>(user);
        }

        public async Task<AuthenticateResponse> Authenticate(AuthenticateRequest model)
        {
            var user = await _repositoryUser.LoginUser(model);
            //  var user = await GetLogin(model.Username, model.Password);

            // validate
            if (user == null)
            {
                Contract contractid = new Contract();
                contractid.AddNotification(nameof(Authenticate), "Usuário ou senha Invalidos !!!");
                _notificationContext.AddNotifications(contractid);
                return default;
            }

            // authentication successful
            var response = _mapper.Map<AuthenticateResponse>(user);
            response.Token = _jwtUtils.GenerateToken(user);
            return response;
        }

    }
}
