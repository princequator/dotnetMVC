using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace VegamTask.Models
{
    public partial class Student
    {
        public int? FstudentId { get; set; }
        public string FstudentName { get; set; }
        public string Fsubject { get; set; }
        public int? Fmarks { get; set; }
    }
}
