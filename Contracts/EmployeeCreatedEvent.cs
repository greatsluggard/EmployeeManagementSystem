namespace Contracts
{
    public record class EmployeeCreatedEvent
    {
        public string Name { get; set; }
        public string LastName { get; set; }
        public string DepartmentName { get; set; }
    }
}