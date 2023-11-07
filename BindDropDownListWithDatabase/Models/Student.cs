using System;
using System.Collections.Generic;

namespace BindDropDownListWithDatabase.Models
{
    public partial class Student
    {
        public int? StdId { get; set; }
        public string? StdName { get; set; }
        public string? StdGender { get; set; }
        public int? StdAge { get; set; }
        public string? StdClass { get; set; }
    }
}
