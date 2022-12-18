using Global.Etik.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Global.Etik.Application.Features.Users.Queries.GetUserById
{
    public class UserMV
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Birthday { get; set; }
        public Status Status { get; set; }
        public string Password { get; set; }
    }
}
