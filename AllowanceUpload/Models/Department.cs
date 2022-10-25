using System;
using System.Collections.Generic;

namespace AllowanceUpload.Models;

public partial class Department
{
    public int DepartmentId { get; set; }

    public string DepartmentName { get; set; } = null!;

    public string? DepartmentDescription { get; set; }

    public virtual ICollection<EmployeeAllowance> EmployeeAllowances { get; } = new List<EmployeeAllowance>();
}
