using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Atelier_4_Excercice_1
{
    public partial class Form1 : Form
    {
        Products products;
        Employes employes;
        Customers customers;

        static string connection_string = ConfigurationManager.ConnectionStrings["mon_connection"].ConnectionString;
        SqlConnection connection;
        SqlCommand command;
        SqlDataReader reader;
        Func<string,IEnumerable<SqlDataReader>> GetData;
        public Form1()
        {
            InitializeComponent();
            GetData = OnGetDataHandler;
            IsMdiContainer = true;
        }
        IEnumerable<SqlDataReader> OnGetDataHandler(string requete)
        {
            try
            {
                connection = new SqlConnection(connection_string);
                command = new SqlCommand(requete, connection);
                connection.Open();
                reader = command.ExecuteReader();

            }
            catch(SqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
            while (reader.Read())
            {
                yield return reader;
            }
            reader.Close();
            connection.Close();
        }
        private void employesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            employes = new Employes(GetData);
            Afficher_form(employes);
        }       
        private void productsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            products = new Products(GetData);
            Afficher_form(products);
        }

        private void customersToolStripMenuItem_Click(object sender, EventArgs e)
        {
            customers = new Customers(GetData);
            Afficher_form(customers);
        }
        void Afficher_form(Form form)
        {
            if (this.ActiveMdiChild != null) this.ActiveMdiChild.Close();
            form.MdiParent = this;
            form.Dock = DockStyle.Fill;
            form.Show();
        }
    }
}
