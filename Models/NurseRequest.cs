using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.Extensions.Primitives;

namespace sodsag.Models;

public class NurseRequest
{

    [Key]
    public int  JobId   { get; set; } 
    public DateTime? EndTime { get; set; }
    public DateTime? CreateDate { get; set;} = DateTime.Now; 
    public string? StartPoint { get; set; } = "";
   
    public string? EndPoint1 { get; set; } = "";

    public string? JobStatusName { get; set; } = "";
 
    public string? MaterialType { get; set; }  = "";
  
    public string? UrgentType { get; set; } = "";  
  
    public string? PatientType { get; set; } = "";
   
    public string? PorterFname { get; set; }  = "";
    public string? Remark { get; set; } = ""; 
    
    public virtual List<Patient> Patients  { get; set; } = new List<Patient>();
    

}
