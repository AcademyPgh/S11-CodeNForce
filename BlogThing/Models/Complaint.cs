using System;
using System.ComponentModel.DataAnnotations;

namespace BlogThing.Models
{
    public class Complaint
    {
        public int Id { get; set; }
        public int Pacc { get; set; }

        [DataType(DataType.Date)]
        public DateTime SubmissionDate { get; set; }
        public string Address1 { get; set; }
        public string Address2 { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public int ZIP { get; set; }
        [Required]
        [Phone]
        public string Phone { get; set; }
        public int AddressID { get; set; }
        public IssueType IssueType { get; set; }
        public string ComplaintDescription { get; set; }
        public string PublicNotes { get; set; }
        public string PrivateNotes { get; set; }
        public bool HumanSafety { get; set; }
        public string Notes { get; set; }
        public SecurityUser User { get; set; }
        public CECase CECase { get; set; }

    }

    public class CECase
    {
        public int Id {get; set;}

    }

    public class IssueType
    {
        public int Id { get; set; }
        public string IssueDescription { get; set; }
    }
}