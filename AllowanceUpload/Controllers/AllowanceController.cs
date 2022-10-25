
using AllowanceUpload.Data;
using AllowanceUpload.Models;
using AllowanceUpload.Services;
using CsvHelper;
using CsvHelper.Configuration;
using Microsoft.AspNetCore.Mvc;
using System.Globalization;

namespace AllowanceUpload.Controllers
{
    public class AllowanceController : Controller
    {
        IAllowanceUploadService _allowanceUploadService = null;
        List<EmployeeAllowance> _employeeAllowances = new List<EmployeeAllowance>();

        public AllowanceController(IAllowanceUploadService allowanceUploadService)
        {
            _allowanceUploadService = allowanceUploadService;

        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Index(IFormFile files)
        {
            string resultMsg = string.Empty;

            if (files != null)
            {
                resultMsg = _allowanceUploadService.SaveEmployeeAllowanceseCSV(files);

                if (resultMsg == "0")
                {
                    ViewBag.Message = "Successfully Saved !";
                }
                else if (resultMsg == "1")
                {
                    ViewBag.Error = "Please Upload CSV File !";
                }
                else if (resultMsg == "2")
                {
                    ViewBag.Error = "Error in Saving !";
                }

            }
            else
            {
                ViewBag.Error = "Please Select File !";
            }  

                 

            return View();
        }


    }
}
