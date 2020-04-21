using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace okul_bilgi_sistemi
{
    class baglanti
    {
        SqlConnection bag = new SqlConnection("Data Source=DESKTOP-323TRBO\\SQLEXPRESS;Initial Catalog=okul;Integrated Security=True");
        
    }
}
