using System;
using System.Collections.Generic;

namespace AllowanceUpload.Models;

public partial class EmployeeAllowance
{
    public int EmployeeAllowanceId { get; set; }

    public int EmployeeId { get; set; }

    public int DepartmentId { get; set; }

    public string? Date { get; set; }

    public decimal Amount { get; set; }

    public string? Status { get; set; }

    public virtual Department Department { get; set; } = null!;

    public virtual Employee Employee { get; set; } = null!;
}
