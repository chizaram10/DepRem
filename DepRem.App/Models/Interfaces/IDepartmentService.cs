using DepRem.App.Models.DTOs;
using DepRem.App.Models.Entites;
using DepRem.App.Models.ViewModels;

namespace DepRem.App.Models.Interfaces
{
    public interface IDepartmentService
    {
        Task<IEnumerable<DepartmentListDTO>> GetAllDepartmentsAsync();
        Task<DepartmentDTO> GetDepartmentByIdAsync(int id);
        Task CreateDepartmentAsync(DepartmentDTO departmentDTO);
        Task<IEnumerable<Department>> GetSubDepartmentsAsync(int parentId);
        Task<IEnumerable<string>> GetParentDepartmentsAsync(int id);
    }
}
