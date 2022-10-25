using AllowanceUpload.Data;
using AllowanceUpload.Models;
using CsvHelper;
using CsvHelper.Configuration;
using EFCore.BulkExtensions;
using System.Globalization;
using IHostingEnvironment = Microsoft.AspNetCore.Hosting.IHostingEnvironment;

namespace AllowanceUpload.Services
{
    public class AllowanceUploadService : IAllowanceUploadService
    {
        private IHostingEnvironment Environment;
        OrelContext _dBContext = null;
        
        List<EmployeeAllowance> _employeeAllowances = new List<EmployeeAllowance>();
        OrelContext _context = new OrelContext();
        public AllowanceUploadService(OrelContext dBContext, IHostingEnvironment _environment)
        {
            _dBContext = dBContext;
            Environment = _environment;
        }

        public List<EmployeeAllowance> GetEmployeeAllowances()
        {
            return _dBContext.EmployeeAllowances.ToList();
        }

        public string SaveEmployeeAllowanceseCSV(IFormFile files)
        {
            try
            {
                var fileextension = Path.GetExtension(files.FileName);
                var filename = Guid.NewGuid().ToString() + fileextension;
                var filepath = Path.Combine(Directory.GetCurrentDirectory(), "temp", filename);

                //Copy file to ~\AllowanceUpload\temp
                using (FileStream fs = System.IO.File.Create(filepath))
                {
                    files.CopyTo(fs);
                }
                //Check is CSV file
                if (fileextension == ".csv")
                {

                    //CSV Validations
                    var conf = new CsvConfiguration(CultureInfo.InvariantCulture)
                    {
                        HasHeaderRecord = true,
                        MissingFieldFound = null,
                        HeaderValidated = null
                    };
                    using (var reader = new StreamReader(filepath))
                    using (var csv = new CsvReader(reader, conf))
                    {
                        var records = csv.GetRecords<CSVFile>();
                        foreach (var record in records)
                        {
                            EmployeeAllowance employeeAllowance = new EmployeeAllowance();

                            employeeAllowance.EmployeeId = record.EmployeeId;
                            employeeAllowance.DepartmentId = record.DepartmentId;
                            employeeAllowance.Date = record.Date;
                            employeeAllowance.Amount = record.Amount;
                            employeeAllowance.Status = record.Status;
                            _context.Add(employeeAllowance);
                        }
                        _context.SaveChanges();
                        return "0";
                    }
                }
                else
                {
                    return "1";
                }
            }
            catch (Exception e)
            {
                return "2";

            }


        }
    }
}

