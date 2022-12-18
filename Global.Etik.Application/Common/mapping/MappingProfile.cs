using AutoMapper;
using Global.Etik.Application.Features.Users.Commands.CreateUsers;
using Global.Etik.Application.Features.Users.Commands.DeleteUsers;
using Global.Etik.Application.Features.Users.Commands.UpdateUsers;
using Global.Etik.Application.Features.Users.Queries.GetUserById;
using Global.Etik.Application.Features.Users.Queries.ListUsers;
using Global.Etik.Domain.entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Global.Etik.Application.Common.mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<User, CreateUserCommand>().ReverseMap();
            CreateMap<User, UpdateUserCommand>().ReverseMap();
            CreateMap<User, DeleteUserCommand>().ReverseMap();
            CreateMap<User, ListUsersMV>().ReverseMap();
            CreateMap<User, UserMV>().ReverseMap();

        }
    }
}