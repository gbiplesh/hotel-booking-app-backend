using HotelAppAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System.Data.SqlClient;
using System.Data;

namespace HotelAppAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CheckoutsController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        public CheckoutsController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        [HttpGet]
        public JsonResult Get()
        {
            string query = @"
                            select Id, FirstName, LastName, Email, Phone, DOB, VerificationID from
                            dbo.Checkouts";
            DataTable table = new DataTable();
            string sqlDataSource = _configuration.GetConnectionString("HotelAppConnection");
            SqlDataReader myReader;
            using (SqlConnection myConn = new SqlConnection(sqlDataSource))
            {
                myConn.Open();
                using (SqlCommand myCommand = new SqlCommand(query, myConn))
                {
                    myReader = myCommand.ExecuteReader();
                    table.Load(myReader);
                    myReader.Close();
                    myConn.Close();
                }
            }

            return new JsonResult(table);
        }

        [HttpPost]
        public JsonResult Post(Checkouts checkout)
        {
            string query = @"
                            insert into dbo.Checkouts
                            (FirstName, LastName, Email, Phone, DOB, VerificationID)
                            values (@FirstName, @LastName, @Email, @Phone, @DOB, @VerificationID)";
            DataTable table = new DataTable();
            string sqlDataSource = _configuration.GetConnectionString("HotelAppConnection");
            SqlDataReader myReader;
            using (SqlConnection myConn = new SqlConnection(sqlDataSource))
            {
                myConn.Open();
                using (SqlCommand myCommand = new SqlCommand(query, myConn))
                {
                    myCommand.Parameters.AddWithValue("@FirstName", checkout.FirstName);
                    myCommand.Parameters.AddWithValue("@LastName", checkout.LastName);
                    myCommand.Parameters.AddWithValue("@Email", checkout.Email);
                    myCommand.Parameters.AddWithValue("@Phone", checkout.Phone);
                    myCommand.Parameters.AddWithValue("@DOB", checkout.DOB);
                    myCommand.Parameters.AddWithValue("@VerificationID", checkout.VerificationID);
                    myReader = myCommand.ExecuteReader();
                    table.Load(myReader);
                    myReader.Close();
                    myConn.Close();
                }
            }

            return new JsonResult("Added.");
        }

        [HttpPut]
        public JsonResult Put(Checkouts checkout)
        {
            string query = @"
                            update dbo.Checkouts
                            set FirstName= @FirstName, 
                                LastName= @LastName, 
                                Email= @Email, 
                                Phone= @Phone, 
                                DOB= @DOB, 
                                VerificationID= @VerificationID
                            where Id=@Id";
            DataTable table = new DataTable();
            string sqlDataSource = _configuration.GetConnectionString("HotelAppConnection");
            SqlDataReader myReader;
            using (SqlConnection myConn = new SqlConnection(sqlDataSource))
            {
                myConn.Open();
                using (SqlCommand myCommand = new SqlCommand(query, myConn))
                {
                    myCommand.Parameters.AddWithValue("@Id", checkout.Id);
                    myCommand.Parameters.AddWithValue("@FirstName", checkout.FirstName);
                    myCommand.Parameters.AddWithValue("@LastName", checkout.LastName);
                    myCommand.Parameters.AddWithValue("@Email", checkout.Email);
                    myCommand.Parameters.AddWithValue("@Phone", checkout.Phone);
                    myCommand.Parameters.AddWithValue("@DOB", checkout.DOB);
                    myCommand.Parameters.AddWithValue("@VerificationID", checkout.VerificationID);
                    myReader = myCommand.ExecuteReader();
                    table.Load(myReader);
                    myReader.Close();
                    myConn.Close();
                }
            }

            return new JsonResult("Updated.");
        }

        [HttpDelete("{id}")]
        public JsonResult Delete(int Id)
        {
            string query = @"
                            delete from dbo.Checkouts
                            where Id=@Id";
            DataTable table = new DataTable();
            string sqlDataSource = _configuration.GetConnectionString("HotelAppConnection");
            SqlDataReader myReader;
            using (SqlConnection myConn = new SqlConnection(sqlDataSource))
            {
                myConn.Open();
                using (SqlCommand myCommand = new SqlCommand(query, myConn))
                {

                    myCommand.Parameters.AddWithValue("@Id", Id);
                    myReader = myCommand.ExecuteReader();
                    table.Load(myReader);
                    myReader.Close();
                    myConn.Close();
                }
            }

            return new JsonResult("Deleted.");
        }
    }
}
