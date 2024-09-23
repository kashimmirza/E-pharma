using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Emedicine.Models;
using System.Data.SqlClient;
using  System.Security.Cryptography.Xml;

namespace Emedicine.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        public UsersController(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        [HttpPost]
        [Route("registration")]
        public Response register(Users users)
        {
            Response response = new Response();
            SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("EMedcs").ToString());
            return response;
        }
        [HttpPost]
        [Route("login")]
        public Response login(Users users)
        {
            DAL dal = new DAL();
            SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("EMedcs").ToString());
            Response response = new Response();
            response = dal.Login(users, connection);
            return response;
        }

        [HttpPost]
        [Route("viewUser")]
        public Response viewUser(Users users)
        {
            DAL dal = new DAL();
            SqlConnection con = new SqlConnection(_configuration.GetConnectionString("EMedcs").ToString());
            Response response = dal.viewUser(users, con);
            return response;
        }
        [HttpPost]
        [Route("UpdateProfile")]
        public Response UpdateProfile(Users users)
        {
            DAL dal = new DAL();
            
            SqlConnection connection = new SqlConnection( _configuration.GetConnectionString("EMedcs ").ToString());
            Response response = dal.UpdateProfile(users, connection);
            return response;
        }


    }
}
