using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.Extensions.Primitives;

namespace sodsag.Models
{
        public class Patient
    {
        public Patient()
        {

        }

        [Key]
        public int Id { get; set; }
        [ForeignKey("NurseRequest")]
        public int ReqId {get; set; }
        public virtual NurseRequest NurseRequest {get ; private set ;}
        [Required]
        public string? Qn { get; set; }
        

    }

}
