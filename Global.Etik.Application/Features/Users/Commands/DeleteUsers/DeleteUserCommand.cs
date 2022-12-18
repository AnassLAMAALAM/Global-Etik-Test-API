using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Global.Etik.Application.Features.Users.Commands.DeleteUsers
{
    public class DeleteUserCommand : IRequest
    {
        public Guid Id { get; set; }
    }
}
