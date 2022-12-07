using System.Data.SqlClient;
namespace CRUDWithAdoNet.Models
{
    public class CustomerDAL
    {
        public class CustomersDAL
        {
            private readonly IConfiguration configuration;
            SqlConnection con;
            SqlDataReader dr;
            SqlCommand cmd;
            public CustomersDAL(IConfiguration configuration)
            {
                this.configuration = configuration;
                con = new SqlConnection(this.configuration.GetConnectionString("defaultConnection"));
            }

            public IEnumerable<customers> GetAllCustomers()
            {

                List<customers> custlist = new List<customers>();
                string qry = "select * from Customers";
                cmd = new SqlCommand(qry, con);
                con.Open();
                dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        customers c = new customers();
                        c.id = Convert.ToInt32(dr["id"]);
                        c.name = dr["name"].ToString();
                        c.contact = dr["contact"].ToString();
                        c.email = dr["email"].ToString();
                        c.password = dr["password"].ToString();
                        custlist.Add(c);
                    }
                }
                con.Close();
                return custlist;
            }
            public customers GetCustomerById(int id)
            {
                customers c = new customers();
                string qry = "select * from customers where id=@id";
                cmd = new SqlCommand(qry, con);
                cmd.Parameters.AddWithValue("@id", Convert.ToInt32(id));
                con.Open();
                dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {


                        c.name = dr["name"].ToString();
                        c.contact = dr["contact"].ToString();
                        c.email = dr["email"].ToString();
                        c.password = dr["password"].ToString();




                    }
                }

                con.Close();
                return c;

            }
            public int AddCustomer(customers customers)
            {
                string qry = "insert into customers values(@name,@email,@Contact,@password)";
                cmd = new SqlCommand(qry, con);
                cmd.Parameters.AddWithValue("@name", customers.name);
                cmd.Parameters.AddWithValue("@email", customers.email);
                cmd.Parameters.AddWithValue("@contact", customers.contact);
                cmd.Parameters.AddWithValue("@password", customers.password);
                con.Open();
                int result = cmd.ExecuteNonQuery();
                con.Close();
                return result;
            }

            public int UpdateCustomer(customers customers)
            {
                string qry = "update customers set name=@name,email=@email,contact=@contact,password=@password where id=@id";
                cmd = new SqlCommand(qry, con);
                cmd.Parameters.AddWithValue("@name", customers.name);
                cmd.Parameters.AddWithValue("@email", customers.email);
                cmd.Parameters.AddWithValue("@contact", customers.contact);
                cmd.Parameters.AddWithValue("@password", customers.password);

                cmd.Parameters.AddWithValue("@id", Convert.ToInt32(customers.id));
                con.Open();
                int result = cmd.ExecuteNonQuery();
                con.Close();
                return result;
            }
            public int DeleteCustomer(int id)
            {
                string qry = "delete from customers where id=@id";
                cmd = new SqlCommand(qry, con);
                cmd.Parameters.AddWithValue("@id", Convert.ToInt32(id));
                con.Open();
                int result = cmd.ExecuteNonQuery();
                con.Close();
                return result;



            }
        }

    }
}

