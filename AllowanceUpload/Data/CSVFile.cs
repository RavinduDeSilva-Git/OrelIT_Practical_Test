namespace AllowanceUpload.Data
{
    public class CSVFile
    {
        public int EmployeeId { get; set; }

        public int DepartmentId { get; set; }

        public string? Date { get; set; }

        public decimal Amount { get; set; }

        public string? Status { get; set; }
    }
}
