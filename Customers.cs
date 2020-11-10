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
    public partial class Customers : Form
    {
        public Customers(Func<string,IEnumerable<SqlDataReader>> GetData)
        {
            InitializeComponent();
            foreach(var reader in GetData("select * from Customers"))
            {
                Customers_dataGridView.Rows.Add(reader.GetSqlString(0),reader.GetSqlString(1)
                    ,reader.GetSqlString(2),reader.GetSqlString(5),reader.GetSqlString(8));
            }
        }
    }
}
