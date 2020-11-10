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
    public partial class Employes : Form
    {
        public Employes(Func<string, IEnumerable<SqlDataReader>> GetData)
        {
            InitializeComponent();
            foreach (SqlDataReader reader in GetData("select * from employees"))
            {
                Employes_dataGridView.Rows.Add(reader.GetInt32(0).ToString(), reader.GetSqlString(1),
                    reader.GetSqlString(2), reader.GetSqlString(3), reader.GetSqlString(8), reader.GetSqlString(11));
            }
        }
    }
}
