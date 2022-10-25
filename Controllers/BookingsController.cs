using HotelAppAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace HotelAppAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookingsController : ControllerBase
    {

        private readonly IConfiguration _configuration;
        public BookingsController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        [HttpGet]
        public JsonResult Get()
        {
            string query = @"
                            select Id, RoomType, FullName, RoomQuantity, convert(varchar(10), CheckIn, 120) as CheckIn,  convert(varchar(10), CheckOut, 120) as  CheckOut, Price from
                            dbo.Bookings";
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
        public JsonResult Post(Bookings booking)
        {
            string query = @"
                            insert into dbo.Bookings
                                    (RoomType, FullName, RoomQuantity, CheckIn, CheckOut, Price)
                            values (@RoomType, @FullName, @RoomQuantity, @CheckIn, @CheckOut, @Price)";
            DataTable table = new DataTable();
            string sqlDataSource = _configuration.GetConnectionString("HotelAppConnection");
            SqlDataReader myReader;
            using (SqlConnection myConn = new SqlConnection(sqlDataSource))
            {
                myConn.Open();
                using (SqlCommand myCommand = new SqlCommand(query, myConn))
                {
                    myCommand.Parameters.AddWithValue("@RoomType", booking.RoomType);
                    myCommand.Parameters.AddWithValue("@FullName", booking.FullName);
                    myCommand.Parameters.AddWithValue("@RoomQuantity", booking.RoomQuantity);
                    myCommand.Parameters.AddWithValue("@CheckIn", booking.CheckIn);
                    myCommand.Parameters.AddWithValue("@CheckOut", booking.CheckOut);
                    myCommand.Parameters.AddWithValue("@Price", booking.Price);
                    myReader = myCommand.ExecuteReader();
                    table.Load(myReader);
                    myReader.Close();
                    myConn.Close();
                }
            }
            return new JsonResult("Added.");
        }

        [HttpPut]
        public JsonResult Put(Bookings booking)
        {
            string query = @"
                            update dbo.Bookings
                            set RoomType = @RoomType, 
                                FullName = @FullName, 
                                RoomQuantity = @RoomQuantity, 
                                CheckIn = @CheckIn, 
                                CheckOut = @CheckOut, 
                                Price = @Price 
                            where Id=@Id";
            DataTable table = new DataTable();
            string sqlDataSource = _configuration.GetConnectionString("HotelAppConnection");
            SqlDataReader myReader;
            using (SqlConnection myConn = new SqlConnection(sqlDataSource))
            {
                myConn.Open();
                using (SqlCommand myCommand = new SqlCommand(query, myConn))
                {
                    myCommand.Parameters.AddWithValue("@Id", booking.Id);
                    myCommand.Parameters.AddWithValue("@RoomType", booking.RoomType);
                    myCommand.Parameters.AddWithValue("@FullName", booking.FullName);
                    myCommand.Parameters.AddWithValue("@RoomQuantity", booking.RoomQuantity);
                    myCommand.Parameters.AddWithValue("@CheckIn", booking.CheckIn);
                    myCommand.Parameters.AddWithValue("@CheckOut", booking.CheckOut);
                    myCommand.Parameters.AddWithValue("@Price", booking.Price);
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
                            delete from dbo.Bookings
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
