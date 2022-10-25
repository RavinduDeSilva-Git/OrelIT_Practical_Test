using AllowanceUpload.Data;
using AllowanceUpload.Models;
using Microsoft.AspNetCore.Mvc;
using System.Data.SqlClient;
using System.Diagnostics;

namespace AllowanceUpload.Controllers
{
    public class HomeController : Controller
    {
        SqlConnection con = new SqlConnection();
        SqlCommand command = new SqlCommand();
        SqlDataReader reader;
        List<EmployeeAllowanceData> employeeAllowanceDatas = new List<EmployeeAllowanceData>(); 

        private readonly ILogger<HomeController> _logger;
        private readonly IConfiguration _config;
        public HomeController(ILogger<HomeController> logger, IConfiguration config)
        {
            _logger = logger;
            _config = config;
            con.ConnectionString = this._config["ConnectionStrings:DbContextConnectionString"];
        }

        public IActionResult Index()
        {
            FetchData();
            return View(employeeAllowanceDatas);
        }

        private void FetchData()
        {
            
            if (employeeAllowanceDatas.Count>0)
            {
                employeeAllowanceDatas.Clear();
            }
            try
            {
                con.Open();
                command.Connection = con;
                command.CommandText = "SELECT ea.EmployeeId,EmployeeName,NIC,DepartmentName,Date,Amount,Status " +
                    "FROM EmployeeAllowance ea " +
                    "INNER JOIN Employee e ON ea.EmployeeId = e.EmployeeId " +
                    "INNER JOIN Departments d ON ea.DepartmentId = d.DepartmentId";
                reader = command.ExecuteReader();
                while (reader.Read())
                {
                    employeeAllowanceDatas.Add(new EmployeeAllowanceData()
                    {
                        EmployeeId = (int)reader["EmployeeId"],
                        EmployeeName = reader["EmployeeName"].ToString(),
                        NIC=reader["NIC"].ToString(),
                        DepartmentName= reader["DepartmentName"].ToString(),
                        Date = reader["DepartmentName"].ToString(),
                        Amount = (decimal)reader["Amount"],
                        Status = reader["Status"].ToString()

                    });
                }
                con.Close();
            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {
                
            }

        }
        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}