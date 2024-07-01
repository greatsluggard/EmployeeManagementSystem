using System.Text.Json.Serialization;

namespace StorageService.Models
{
    public class Department
    {
        public long DepartmentId { get; set; }
        public string DepartmentName { get; set; }

        [JsonIgnore]
        public List<Employee> Employees { get; set; } = new List<Employee>();
    }
}