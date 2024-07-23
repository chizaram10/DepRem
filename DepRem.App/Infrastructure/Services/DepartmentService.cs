using DepRem.App.Infrastructure.Data;
using DepRem.App.Models.DTOs;
using DepRem.App.Models.Entites;
using DepRem.App.Models.Interfaces;
using DepRem.App.Models.ViewModels;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DepRem.App.Infrastructure.Services
{
    public class DepartmentService : IDepartmentService
    {
        private readonly AppDbContext _context;

        public DepartmentService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<DepartmentListDTO>> GetAllDepartmentsAsync()
        {
            return await _context.Departments
                .Select(x => new DepartmentListDTO
                {
                    Id = x.Id,
                    Logo = x.Logo,
                    Name = x.Name,
                })
                .ToListAsync();
        }

        public async Task<DepartmentDTO> GetDepartmentByIdAsync(int id)
        {
            Department? department = await _context.Departments
                .Include(d => d.SubDepartments)
                .FirstOrDefaultAsync(d => d.Id == id);

            if (department == null)
            {
                return null!;
            }

            var departmentDTO = new DepartmentDTO
            {
                Id = department.Id,
                Name = department.Name,
                Logo = department.Logo,
                ParentDepartmentId = department.ParentDepartmentId,
                SubDepartments = department.SubDepartments.Select(sd => sd.Name).ToList()
            };

            departmentDTO.ParentDepartments = (await GetParentDepartmentsAsync(id)).ToList();

            return departmentDTO;
        }

        public async Task CreateDepartmentAsync(DepartmentDTO departmentDTO)
        {
            if (departmentDTO.LogoFile != null)
            {
                using (var memoryStream = new MemoryStream())
                {
                    await departmentDTO.LogoFile.CopyToAsync(memoryStream);
                    departmentDTO.Logo = Convert.ToBase64String(memoryStream.ToArray());
                }
            }

            var department = MapToEntity(departmentDTO);
            _context.Departments.Add(department);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Department>> GetSubDepartmentsAsync(int parentId)
        {
            return await _context.Departments
                .Where(d => d.ParentDepartmentId == parentId)
                .Include(d => d.SubDepartments)
                .ToListAsync();
        }

        public async Task<IEnumerable<string>> GetParentDepartmentsAsync(int id)
        {
            var parents = new List<string>();
            var current = await _context.Departments.FirstOrDefaultAsync(d => d.Id == id);

            while (current != null && current.ParentDepartmentId != null)
            {
                var parent = await _context.Departments.FirstOrDefaultAsync(d => d.Id == current.ParentDepartmentId);

                if (parent != null)
                {
                    parents.Insert(0, parent.Name);
                    current = parent;
                }
                else
                {
                    current = null;
                }
            }

            return parents;
        }

        private Department MapToEntity(DepartmentDTO dto)
        {
            return new Department
            {
                Id = dto.Id,
                Name = dto.Name,
                Logo = dto.Logo,
                ParentDepartmentId = dto.ParentDepartmentId
            };
        }
    }
}