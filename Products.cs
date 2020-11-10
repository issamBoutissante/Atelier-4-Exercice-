using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Atelier_4_Excercice_1
{
    public partial class Products : Form
    {
        public Products(Func<string,IEnumerable<SqlDataReader>> GetData)
        {
            InitializeComponent();
            foreach (SqlDataReader reader in GetData("select * from products"))
            {
                Products_dataGridView.Rows.Add(reader.GetInt32(0).ToString(), reader.GetSqlString(1),
                    reader.GetSqlMoney(5).ToString(),reader.GetInt16(6).ToString());
            }
        }
    }
}
