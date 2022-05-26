using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Npgsql;
using System.Data;
using Microsoft.Extensions.Configuration;

namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReceiptController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        public ReceiptController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        [HttpGet]
        public JsonResult Get()
        {
            string query = @"
                select Id as ""Id"",
                        companyName as ""companyName""
                        vatRate as ""vatRate""
                        dateOfPurcase as ""dateOfPurcase""
                        vatCode as ""vatCode""
                        country as ""country""
                        dateOfTaxRegistration as ""dateOfTaxRegistration""
                from Department
            ";

            DataTable table = new DataTable();
            string sqlDataSource = _configuration.GetConnectionString("ReceiptAppCon");
            NpgsqlDataReader myReader;
            using (NpgsqlConnection myCon = new NpgsqlConnection(sqlDataSource))
            {
                myCon.Open();
                using (NpgsqlCommand myCommand = new NpgsqlCommand(query, myCon))
                {
                    myReader = myCommand.ExecuteReader();
                    table.Load(myReader);

                    myReader.Close();
                    myCon.Close();

                }
            }

            return new JsonResult(table);
        }

    }
}
