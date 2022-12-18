using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Global.Etik.Application.Features.Users.Queries.GetUserById
{
    public class GetUserByIdQuery : IRequest<UserMV>
    {
        public Guid Id { get; set; }
    }
}
