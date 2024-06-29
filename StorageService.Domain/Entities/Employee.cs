﻿namespace StorageService.Models
{
    public class Employee
    {
        public long EmployeeId { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public long DepartmentId { get; set; }
        public Department Department { get; set; }
    }
}