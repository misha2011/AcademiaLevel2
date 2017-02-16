using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;
using System.Web.Script.Serialization;

namespace AcademiaLevel2.Models
{
    
    public class Likes
    {
        public int id { get; set; }       
        public ApplicationUser iduser { get; set; }
        public int idPost { get; set; }

        [ForeignKey("idPost")]
        [ScriptIgnore(ApplyToOverrides = true)]
        public virtual Post Post{ get; set; }
    }
}