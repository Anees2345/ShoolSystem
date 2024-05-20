using System.ComponentModel.DataAnnotations;

namespace School_01.Models
{
    public class Student
    {
        [Key]
        public int Id { get; set; }
        public string StudentCode { get; set; }
        public string AdmitCode { get; set; }
        public string Name { get; set; }
        public string CNIC { get; set; }
        public string Gender { get; set; }
        public string Age { get; set; }
        public DateTime? DOB { get; set; }
        public string FatherName { get; set; }
        public string FatherCNIC { get; set; }
        public string ContactNo { get; set; }
        public string EmergencyPerson { get; set; }
        public string EmergencyContact { get; set; }
        public string Relation { get; set; }
        public int? InstituteId { get; set; }
        public int? CampusId { get; set; }
        public int? CreatedBy { get; set; }
        public DateTime? CreatedOn { get; set; }
        public int? UpdatedBy { get; set; }
        public DateTime? UpdatedOn { get; set; }
    }

}
