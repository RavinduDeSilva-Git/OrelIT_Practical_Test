using System;
using System.Collections.Generic;

namespace AllowanceUpload.Models;

public partial class Employee
{
    public int EmployeeId { get; set; }

    public string EmployeeName { get; set; } = null!;

    public int? EmployeeAge { get; set; }

    public string Nic { get; set; } = null!;

    public virtual ICollection<EmployeeAllowance> EmployeeAllowances { get; } = new List<EmployeeAllowance>();
}
