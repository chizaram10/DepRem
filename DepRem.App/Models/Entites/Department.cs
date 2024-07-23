namespace DepRem.App.Models.Entites
{
    public class Department : BaseEntity
    {
#nullable disable
        public string Name { get; set; }
        public string Logo { get; set; }
        public int? ParentDepartmentId { get; set; }
        public Department ParentDepartment { get; set; }
        public ICollection<Department> SubDepartments { get; set; }
    }
}
