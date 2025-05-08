using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IFTR.DAL.Users
{
    public class UserDataAccess
    {
        public static string ConnectionString = "Data Source=SQL8002.site4now.net;Initial Catalog=db_a88aaa_iftrdev001;User Id=db_a88aaa_iftrdev001_admin;Password=Network1@";

        public static Users GetUserDetails(string emailAddress, string password)
        {

            var _obj = new Users();
            try
            {
                using (SqlConnection con = new SqlConnection(ConnectionString))
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("usp_Get_UserDetails", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("@EmailAddress", emailAddress.ToLower()));
                    cmd.Parameters.Add(new SqlParameter("@Password", password.ToLower()));
                    SqlDataReader dr = cmd.ExecuteReader();
                    if (dr.HasRows)
                    {
                        if (dr.Read())
                        {
                            _obj.UserName = Convert.ToString(dr["UserName"]);
                            _obj.EmailAddress = Convert.ToString(dr["EmailAddress"]);
                            _obj.Password = Convert.ToString(dr["Password"]);
                            _obj.UserType = Convert.ToString(dr["UserType"]);
                            _obj.IsActive = Convert.ToBoolean(dr["IsActive"]);
                        }
                    }
                    dr.Close();
                    con.Close();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {

            }
            return _obj;
        }

        public static DataTable GetAllUsers()
        {
            DataTable dt = new DataTable();
            try
            {
                using (SqlConnection con = new SqlConnection(ConnectionString))
                {
                    con.Open();

                    SqlCommand cmd = new SqlCommand("usp_Get_AllUsers", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    da.Fill(dt);
                    con.Close();
                }
                return dt;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (!Object.ReferenceEquals(null, dt))
                    dt.Dispose();

            }
        }
        public static DataTable GetAllUserTypes()
        {
            DataTable dt = new DataTable();
            try
            {
                using (SqlConnection con = new SqlConnection(ConnectionString))
                {
                    con.Open();

                    SqlCommand cmd = new SqlCommand("usp_Get_AllUserTypes", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    da.Fill(dt);
                    con.Close();
                }
                return dt;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (!Object.ReferenceEquals(null, dt))
                    dt.Dispose();

            }
        }
    }
}
