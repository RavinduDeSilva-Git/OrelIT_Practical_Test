using AllowanceUpload.Models;

namespace AllowanceUpload.Services
{
    public interface IAllowanceUploadService
    {
        List<EmployeeAllowance> GetEmployeeAllowances();
        string SaveEmployeeAllowanceseCSV(IFormFile files);
    }
}
