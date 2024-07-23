using DepRem.App.Models.DTOs;

namespace DepRem.App.Models.ViewModels
{
#nullable disable
    public class DepartmentViewModel
    {
        public DepartmentDTO Department { get; set; }
        public IEnumerable<DepartmentListDTO> ParentDepartments { get; set; }
    }
}
