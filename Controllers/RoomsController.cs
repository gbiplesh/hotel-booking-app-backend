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
    public class RoomsController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        public RoomsController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        [HttpGet]
        public JsonResult Get()
        {
            string query = @"
                            select Id, RoomType, Price, Beds, Available from
                            dbo.Rooms";
            DataTable table = new DataTable();
            string sqlDataSource = _configuration.GetConnectionString("HotelAppConnection");
            SqlDataReader myReader;
            using(SqlConnection myConn = new SqlConnection(sqlDataSource))
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
        public JsonResult Post(Rooms room)
        {
            string query = @"
                            insert into dbo.Rooms
                            values (@RoomType, @Price, @Beds, @Available)";
            DataTable table = new DataTable();
            string sqlDataSource = _configuration.GetConnectionString("HotelAppConnection");
            SqlDataReader myReader;
            using (SqlConnection myConn = new SqlConnection(sqlDataSource))
            {
                myConn.Open();
                using (SqlCommand myCommand = new SqlCommand(query, myConn))
                {
                    myCommand.Parameters.AddWithValue("@RoomType", room.RoomType);
                    myCommand.Parameters.AddWithValue("@Price", room.Price);
                    myCommand.Parameters.AddWithValue("@Beds", room.Beds);
                    myCommand.Parameters.AddWithValue("@Available", room.Available);
                    myReader = myCommand.ExecuteReader();   
                    table.Load(myReader);
                    myReader.Close();
                    myConn.Close();
                }
            }

            return new JsonResult("Added.");
        }

        [HttpPut]
        public JsonResult Put(Rooms room)
        {
            string query = @"
                            update dbo.Rooms
                            set RoomType= @RoomType, Price = @Price, Beds = @Beds, Available = @Available
                            where Id=@Id";
            DataTable table = new DataTable();
            string sqlDataSource = _configuration.GetConnectionString("HotelAppConnection");
            SqlDataReader myReader;
            using (SqlConnection myConn = new SqlConnection(sqlDataSource))
            {
                myConn.Open();
                using (SqlCommand myCommand = new SqlCommand(query, myConn))
                {
                    myCommand.Parameters.AddWithValue("@Id", room.Id);
                    myCommand.Parameters.AddWithValue("@RoomType", room.RoomType);
                    myCommand.Parameters.AddWithValue("@Price", room.Price);
                    myCommand.Parameters.AddWithValue("@Beds", room.Beds);
                    myCommand.Parameters.AddWithValue("@Available", room.Available);
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
                            delete from dbo.Rooms
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
