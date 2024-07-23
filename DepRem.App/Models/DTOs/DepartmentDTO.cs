using System.ComponentModel.DataAnnotations;

namespace DepRem.App.Models.DTOs
{
    public class DepartmentDTO : DepartmentListDTO
    {
        public int? ParentDepartmentId { get; set; }
        public IEnumerable<string> ParentDepartments { get; set; } = Enumerable.Empty<string>();
        public IEnumerable<string> SubDepartments { get; set; } = Enumerable.Empty<string>();

        [Required]
        public IFormFile? LogoFile { get; set; }
    }
}
