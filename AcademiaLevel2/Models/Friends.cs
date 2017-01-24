using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace AcademiaLevel2.Models
{
    public class Friends
    {
        public int id { get; set; }
        public string status { get; set; }
        public ApplicationUser userThis { get; set; }
        public ApplicationUser userAnother { get; set; }

        public static implicit operator List<object>(Friends v)
        {
            throw new NotImplementedException();
        }
    }
}