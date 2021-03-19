using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VegamTask.ViewModels
{
    public class FakeModel
    {
        public string studentName { get; set; }

        public int? EC1 { get; set; }

        public int? EC2 { get; set; }

        public int? EC3 { get; set; }

        public int? EC4 { get; set; }

        public int? EC5 { get; set; }

        public string Status { get; set; }

        public int? Total { get; set; }

        public int? TotalFailedSubjects { get; set; } = 0;
    }
}
