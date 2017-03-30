using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace BastardFat.AgileBoard.Site.Database.Tables
{
    public class Task
    {
        [Key]
        public int Id { get; set; }

        public string Title { get; set; }

        public string Markdown { get; set; }

        public bool HasImage { get; set; }

        public string ImageUrl { get; set; }

        public int Stage { get; set; }

        public DateTime AddingDate { get; set; }

        public DateTime LastModified { get; set; }

        [ForeignKey(nameof(Tables.User))]
        [InverseProperty(nameof(Tables.User.Id))]
        public int UserId { get; set; }

        public virtual User User { get; set; }
    }
}