using System.ComponentModel.DataAnnotations;

namespace DepRem.App.Models.DTOs
{
    public class DepartmentListDTO
    {
        public int Id { get; set; }

        [Required, MaxLength(50)]
        public string Name { get; set; } = string.Empty;
        public string Logo { get; set; } = string.Empty;
    }
}
