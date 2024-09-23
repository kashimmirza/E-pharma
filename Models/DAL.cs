using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using Microsoft.AspNetCore.Components;
using System.Diagnostics.Eventing.Reader;


namespace Emedicine.Models
{
    public class DAL
    {
        public Response register(Users users, SqlConnection connection)
        {
            Response response = new Response();
            SqlCommand cmd = new SqlCommand("dp_register",connection);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@FirstName", users.FirstName);
            cmd.Parameters.AddWithValue("@LastName", users.LastName);
            cmd.Parameters.AddWithValue("@Password", users.Password);
            
            cmd.Parameters.AddWithValue("@Email",users.Email);
            cmd.Parameters.AddWithValue("@Fund", 0);
            cmd.Parameters.AddWithValue("@Type", users);
            cmd.Parameters.AddWithValue("@Status", "Pending");
            connection.Open();
            int i = cmd.ExecuteNonQuery();
            if (i > 0)
            {
                response.statusCode = 200;
                response.StatusMessage = "User registered successfully";
            }
            else
            {
                response.statusCode = 100;
                response.StatusMessage = "User register failed";
            }
            return response;
        }
        public Response Login(Users users, SqlConnection connection)
        {
            SqlDataAdapter da = new SqlDataAdapter("sp_login", connection);
            da.SelectCommand.CommandType = CommandType.StoredProcedure;
            da.SelectCommand.Parameters.AddWithValue("@Email", users.Email);
            da.SelectCommand.Parameters.AddWithValue("@Password", users.Password);
            DataTable dt = new DataTable();
            da.Fill(dt);
            Response response = new Response();
            if (dt.Rows.Count > 0)
            {
                users.ID = Convert.ToInt32(dt.Rows[0]["ID"]);
                users.FirstName = Convert.ToString(dt.Rows[0]["FirstName"]);
                users.LastName = Convert.ToString(dt.Rows[0]["LastName"]);
                users.Email = Convert.ToString(dt.Rows[0]["Email"]);
                users.Type = Convert.ToString(dt.Rows[0]["Type"]);
                users.Fund = Convert.ToDecimal(dt.Rows[0]["Fund"]);
                users.CreatedOn = Convert.ToDateTime(dt.Rows[0]["CreatedOn"]);
                users.Password = Convert.ToString(dt.Rows[0]["Password"]);
                response.statusCode = 200;
                response.StatusMessage = " User exists";
            }
            else
            {
                response.statusCode = 100;
                response.StatusMessage = "User does not exit";
                response.user = users;
            }
            return response;

        }
        public Response viewUser(Users users, SqlConnection connection) 
        {
            SqlDataAdapter da = new SqlDataAdapter("p_viewUser", connection);
            da.SelectCommand.CommandType = CommandType.StoredProcedure;
            da.SelectCommand.Parameters.AddWithValue("@ID", users.ID);
            DataTable dt = new DataTable();
            da.Fill(dt);
            Response response = new Response();


            if (dt.Rows.Count > 0)
            {
                response.statusCode = 200;
                response.StatusMessage = "User  exists";
            }
            else
            {
                response.statusCode = 100;
                response.StatusMessage = "User does not exist";
            }
            return response;
        }
        
        public Response UpdateProfile(Users users, SqlConnection connection) { 
        
         Response response = new Response();
            SqlCommand cmd = new SqlCommand("sp_updateProfile", connection);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@FirstName", users.FirstName);
            cmd.Parameters.AddWithValue("@LastName", users.LastName);
            cmd.Parameters.AddWithValue("@Password", users.Password);
           
            cmd.Parameters.AddWithValue("@Email", users.Email);
            connection.Open();
            int i = cmd.ExecuteNonQuery();
            connection.Close();
            if (i > 0)
            {
                response.statusCode = 200;
                response.StatusMessage = "Record updated successfully";
            }
            else
            {
                response.statusCode = 100;
                response.StatusMessage = "Some error occure please try few minute laters";
            }
            return response;
           

        }
        public Response addToCart(Cart cart, SqlConnection connection)
        {
            Response response = new Response();
            SqlCommand cmd = new SqlCommand("sp_AddToCart", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@UserID", cart.UserID);
            cmd.Parameters.AddWithValue("@MedicineID", cart.MedicineID);
            cmd.Parameters.AddWithValue("@UnitPrice", cart.UnitPrice);
            cmd.Parameters.AddWithValue("@Discount", cart.Discount);
            cmd.Parameters.AddWithValue("@Quantity", cart.Quantity);
            cmd.Parameters.AddWithValue("@TotalPrice", cart.TotalPrice);
            connection.Open();
            int i = cmd.ExecuteNonQuery();
            connection.Close();
            if (i > 0) 
            {
                response.statusCode = 200;
                response.StatusMessage = "Item added successfully";

            }
            else
            {
                response.statusCode = 100;
                response.StatusMessage = "Item couldn't be added";
            }
            return response;
            


        }
        public Response placeOrder(Users Users,SqlConnection Connection)
        {
            Response response = new Response();
            SqlCommand cmd = new SqlCommand("sp_PlaceOrder", Connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@ID", Users.ID);
            Connection.Open();
            int i = cmd.ExecuteNonQuery();
            Connection.Close();
            if (i > 0)
            {
                response.statusCode=200;
                response.StatusMessage = "order has been placed successfully";
            }
            else
            {
                response.statusCode = 100;
                response.StatusMessage = "Order couldn't be placed";
            }
            return response;
        }
        public Response OrderList(Users users,  SqlConnection connection)
        {
            Response response = new Response();
            List<Orders> listOrder = new List<Orders>();
            SqlDataAdapter da = new SqlDataAdapter("sp_OrderList", connection);
            da.SelectCommand.CommandType = CommandType.StoredProcedure;
            da.SelectCommand.Parameters.AddWithValue("@Type", users.Type);
            da.SelectCommand.Parameters.AddWithValue("@ID", users.ID);
            DataTable dt = new DataTable();
            da.Fill(dt);
            if(dt.Rows.Count > 0) {

                for (int i=0;  i < dt.Rows.Count; i++)
                {

                    Orders order = new Orders();
                    order.ID = Convert.ToInt32(dt.Rows[i]["ID"]);
                    order.OrderTotal = Convert.ToDecimal(dt.Rows[i]["OrderTotal"]);
                    order.OrderStatus = Convert.ToString(dt.Rows[i]["OrderStatus"]);
                    listOrder.Add(order);

                }
                if (listOrder.Count > 0)
                {
                    response.statusCode = 200;
                    response.StatusMessage = "Order details fetched";
                    response.listOrders = listOrder;
                }
                else
                {

                    response.statusCode = 100;
                    response.StatusMessage = "Order details are not available";
                    response.listOrders = null;
                }
                
                
            
            }
            else
            {

                response.statusCode = 100;
                response.StatusMessage = "Order details are not available";
                response.listOrders = null;
            }
            return response;

        }
        public Response addUpdateMedicine(Medicines medicines, SqlConnection connection)
        {
            Response response = new Response();
            SqlCommand cmd = new SqlCommand("sp_AddUpdateMedicine", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Name", medicines.Name);
            cmd.Parameters.AddWithValue("@Manufacturer", medicines.Manufacturer);
            cmd.Parameters.AddWithValue("@UnitPrice", medicines.UnitPrice);
            cmd.Parameters.AddWithValue("@Discount", medicines.Discount);
            cmd.Parameters.AddWithValue("@Quantity", medicines.Quantity);
            cmd.Parameters.AddWithValue("@ExpDate", medicines.ExpDate);
            cmd.Parameters.AddWithValue("@ImageUrl", medicines.ImageUrl);
            cmd.Parameters.AddWithValue("@Status", medicines.Status);
            //cmd.Parameters.AddWithValue("@Type", medicines.Type);
            connection.Open();
            int i = cmd.ExecuteNonQuery();
            connection.Close();
            if (i > 0)
            {
                response.statusCode = 100;
                response.StatusMessage = "Medicines inserted successfully";
            }
            else
            {
                response.statusCode = 100;
                response.StatusMessage = "Medicine didn't save. Try again.";
            }
            return response;
        }
        public Response userList(SqlConnection connection)
        {
            Response response = new Response();
            List<Users> listUsers = new List<Users>();
            SqlDataAdapter da = new SqlDataAdapter("sp_UserList", connection);
            da.SelectCommand.CommandType = CommandType.StoredProcedure;
            
            DataTable dt = new DataTable();
            da.Fill(dt);
            if (dt.Rows.Count > 0)
            {

                for (int i = 0; i < dt.Rows.Count; i++)
                {

                    Users user = new Users();
                    user.ID = Convert.ToInt32(dt.Rows[i]["ID"]);
                    user.FirstName = Convert.ToString(dt.Rows[i]["FirstName"]);
                    user.LastName = Convert.ToString(dt.Rows[i]["LastName"]);
                    user.Password = Convert.ToString(dt.Rows[i]["Password"]);
                    user.Email = Convert.ToString(dt.Rows[i]["Email"]);
                    user.Fund = Convert.ToDecimal(dt.Rows[i]["Fund"]);
                    
                    user.Status = Convert.ToInt32(dt.Rows[i]["Status"]);
                    user.CreatedOn = Convert.ToDateTime(dt.Rows[i]["CreatedOn"]);
                    listUsers.Add(user);

                }
                if (listUsers.Count > 0)
                {
                    response.statusCode = 200;
                    response.StatusMessage = "Users  details fetched";
                    response.listUsers = listUsers;
                }
                else
                {

                    response.statusCode = 100;
                    response.StatusMessage = "Users details are not available";
                    response.listOrders = null;
                }



            }
            else
            {

                response.statusCode = 100;
                response.StatusMessage = "User  details are not available";
                response.listUsers = null;
            }
            return response;

        }

    }
}
