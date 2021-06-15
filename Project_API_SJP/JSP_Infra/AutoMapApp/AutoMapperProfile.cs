using AutoMapper;
using JSP.Domain.Entities;
//using JSP.Domain.Entities;
using JSP.Domain.Models;
//using Project_API_SJP.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JSP_Infra.AutoMapApp
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            // User -> AuthenticateResponse
            CreateMap<User, AuthenticateResponse>();

            CreateMap<User, UserView>();

            CreateMap<InputUser, User>();
          //  .ConstructUsing(src => new User(src.Id, src.UserName, src.Email, src.Password));

            // CreateMap<UserView, User>();

            //Rotina abaixo para mapear um campo de type class para um campo especifico type string
            // CreateMap<Doacao, DoadorViewModel>()
            //  .ForMember(dest => dest.Nome, m => m.MapFrom(src => src.DadosPessoais.Nome))
            //  .ForMember(dest => dest.Anonima, m => m.MapFrom(src => src.DadosPessoais.Anonima))
            //  .ForMember(dest => dest.MensagemApoio, m => m.MapFrom(src => src.DadosPessoais.MensagemApoio))
            //  .ForMember(dest => dest.Valor, m => m.MapFrom(src => src.Valor))
            //  .ForMember(dest => dest.DataHora, m => m.MapFrom(src => src.DataHora));

            //Rotina abaixo para mapear um ViewModel para uma EntityModel
            //  CreateMap<PessoaViewModel, Pessoa>()
            //  .ConstructUsing(src => new Pessoa(Guid.NewGuid(), src.Nome, src.Email, src.Anonima, src.MensagemApoio));

            //Rotina abaixo para mapear um ModelView para EntityModel
            // CreateMap<DoacaoViewModel, Doacao>()
            //  .ForCtorParam("valor", opt => opt.MapFrom(src => src.Valor))
            //  .ForCtorParam("dadosPessoais", opt => opt.MapFrom(src => src.DadosPessoais))
            //  .ForCtorParam("formaPagamento", opt => opt.MapFrom(src => src.FormaPagamento))
            //  .ForCtorParam("enderecoCobranca", opt => opt.MapFrom(src => src.EnderecoCobranca));
        }
    }
}
