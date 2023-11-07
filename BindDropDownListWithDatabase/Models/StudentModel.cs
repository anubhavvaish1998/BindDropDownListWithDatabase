using Microsoft.AspNetCore.Mvc.Rendering;

namespace BindDropDownListWithDatabase.Models
{
    public class StudentModel
    {
        public int Id { get; set; } 
        public List<SelectListItem> StudentsList { get; set; }
    }
}
