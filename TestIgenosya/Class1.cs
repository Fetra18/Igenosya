using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestIgenosya
{
    public class Class1
    {
        public void TestConnexion()
        {

           string connString= @"data source=(localdb)\v11.0;initial catalog=Igenosya;integrated security=True;MultipleActiveResultSets=True;App=EntityFramework";
            SqlConnection conn = new SqlConnection(connString);
            
            try {
                conn.Open();
                Console.WriteLine("Connexion Succesfully");
                Console.ReadKey();
            }
            catch(Exception)
            {
                Console.WriteLine("Connexion failed");
            }
           

        }
    }
}
