using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AcademiaLevel2.Models
{
    public class Post
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime Date { get; set; }
        public ApplicationUser IdUser { get; set; }
    }
}