using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace BastardFat.AgileBoard.Site.Database.Tables
{
    public class User
    {
        [Key]
        public int Id { get; set; }

        public string Name { get; set; }

        public string PasswordHash { get; set; }

        [ForeignKey(nameof(Tables.Role))]
        [InverseProperty(nameof(Tables.Role.Id))]
        public int RoleId { get; set; }

        public virtual Role Role { get; set; }
    }
}