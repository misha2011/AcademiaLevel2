using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace AcademiaLevel2.Models
{
    public class Friends
    {        
        [Key]
        public string idFriends { get; set; }
        public string status { get; set; }
        public ApplicationUser userThis { get; set; }
        public ApplicationUser userAnother { get; set; }

        public static implicit operator List<object>(Friends v)
        {
            throw new NotImplementedException();
        }
    }
}