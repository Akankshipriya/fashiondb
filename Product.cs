using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace fashion
{
    public class Product : IMethods
    {
        SqlConnection con = new SqlConnection(@"server = BHAVNAWKS651\SQLEXPRESS; database=fashion;Integrated Security = true;");
        SqlCommand sqlCommand;
        CCProduct productDetails = new CCProduct();


        public string Add(CCProduct products)
        {
            Console.WriteLine("Enter following information to add new product:");
            Console.WriteLine("Enter product name");
            products.pName = Console.ReadLine();
            Console.WriteLine("Enter product price");
            products.price = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter category id");
            products.cId = int.Parse(Console.ReadLine());

            //connection starts
            con.Open();
            SqlCommand cmd = new SqlCommand("insert into product values('" + products.pName + "'," + products.price + "," + products.cId + ")", con);
            cmd.ExecuteNonQuery();
            Console.WriteLine("inserted succefully");
            con.Close();

            //connection close
            return "";
        }
        public void AllProducts(string role)
        {
            // role =Console.ReadLine();

            if (role == "product")
            {
                Console.WriteLine("Enter ur choice");
                Console.WriteLine("1:Add product");
                Console.WriteLine("2:Delete product");
                Console.WriteLine("3:Display product");
                Console.WriteLine("4:Update product");
                Console.WriteLine("5:Search product with category name");
                Console.WriteLine("6:exit");
                int choice = int.Parse(Console.ReadLine());
                switch (choice)
                {
                    case 1:
                        Console.WriteLine("Enter following information to add new Category:");

                        //function delegates
                        Func<CCProduct, string> productfunc = new Func<CCProduct, string>(AddProduct);
                        productfunc(productDetails);
                        break;
                    case 2:
                        Console.WriteLine("Enter categoryId which you want to delete:");
                        int cid = int.Parse(Console.ReadLine());

                        //Action delegates
                        Action<int> action = new Action<int>(DeleteProduct);
                        DeleteProduct(cid);
                        break;
                    case 3:
                        Display();
                        break;
                    case 4:
                        Console.WriteLine("Enter categoryId which you want to Update:");
                        int id = int.Parse(Console.ReadLine());
                        Update(id);
                        break;
                    case 5:
                        Console.WriteLine("Using predict delegate enter product name ");

                        //predicate delegates prints true or false;
                        Predicate<string> predicate = new Predicate<string>(Search);
                        string name = Console.ReadLine();
                        predicate(name);
                        break;
                    case 6:
                        Console.WriteLine("");
                        break;
                    default:
                        Console.WriteLine("Invalid option");
                        break;
                }
            }
        }


        public void Delete(int pid)
        {
            sqlCommand = new SqlCommand("delete from product where pid=" + pid + "", con);
            con.Open();
            sqlCommand.ExecuteNonQuery();
            Console.WriteLine("category with id:" + pid + "\n" + "Deleted successfully");
            con.Open();

        }

        public void Display()
        {
            con.Open();
            sqlCommand = new SqlCommand("select  p.pid,p.pname,p.price,c.cname from product as p left join category as c  on p.cid = c.cid ", con);
            SqlDataReader sdr = sqlCommand.ExecuteReader();
            while (sdr.Read())
            {
                Console.WriteLine("Product Id:" + sdr.GetValue(0) + "\n" + "product name:" + sdr.GetValue(1) + "product price" + sdr.GetValue(2) + "\n" + "category name" + sdr.GetValue(3));

            }
            con.Close();
        }

        public int Update(int pid)
        {
            int result = 0;

            try
            {
                Console.WriteLine("Enter following information to update new product:");
                Console.WriteLine("Enter product name");
                productDetails.pName = Console.ReadLine();
                Console.WriteLine("Enter product price");
                productDetails.price = int.Parse(Console.ReadLine());
                Console.WriteLine("Enter category id");
                productDetails.cId = int.Parse(Console.ReadLine());
                con.Open();
                SqlCommand cmd = new SqlCommand("update product set pname='" + productDetails.pname + "' where pid=" + pid + "", con);
                cmd.ExecuteNonQuery();
                con.Close();
                Console.WriteLine("product with id:" + pid + "\n" + "updated successfully");
            }
            catch (Exception)
            {
                Console.WriteLine("Update Failed");
            }
            return result;
        }

        //searching a row with name 
        public bool Search(string name)
        {
            var ProList = new List<CCProduct>();
            con.Open();
            sqlCommand = new SqlCommand("select * from product where pname Like  '%" + name + "%'  ", con);
            SqlDataReader sdr = sqlCommand.ExecuteReader();

            while (sdr.Read())
            {
                Console.WriteLine("product Id:" + sdr.GetValue(0) + "\n" + "product Name:" + sdr.GetValue(1) + "\n" + "product price:" + sdr.GetValue(2) + "\n" + "category name:" + sdr.GetValue(3));
                return true;
            }
            return false;

            con.Close();
        }
    }
}
