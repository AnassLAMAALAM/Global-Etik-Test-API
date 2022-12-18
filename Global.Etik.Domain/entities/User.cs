using Global.Etik.Domain.entities.Common;
using Global.Etik.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Global.Etik.Domain.entities
{
    public class User : AuditableEntity
    {

        /// <summary>
        /// Name of user
        /// </summary>
        public string? Name { get; set; }

        /// <summary>
        /// Email of User
        /// </summary>
        public string? Email { get; set; }

        /// <summary>
        /// Birthday of User
        /// </summary>
        public string? Birthday { get; set; }

        /// <summary>
        /// Status of user account 
        /// </summary>
        public Status Status { get; set; }

        /// <summary>
        /// Password of user account
        /// </summary>
        public string? Password { get; set; }
    }
}
