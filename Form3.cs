using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Xml.Linq;

namespace Grifindo_Toys
{
    public partial class Form3 : Form
    {
        SqlConnection con = null;
        public Form3()
        {
            con = new SqlConnection("Data Source=DESKTOP-7LQQUCN;Initial Catalog=gtr;Integrated Security=True;");
            InitializeComponent();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Form2 form = new Form2();
            form.Show();
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {

                con.Open();
                //label4.Text = "Connection Successfull!";
                SqlCommand cmd = con.CreateCommand();
                cmd.CommandType = CommandType.Text;
                string name = txtname.Text;
                decimal salary = Convert.ToDecimal(txtsal.Text);
                decimal otrate = Convert.ToDecimal(txtot.Text);
                decimal allowances = Convert.ToDecimal(txtallow.Text);

                cmd.CommandText = "insert into employee (emp_name,salary,ot_rate,allowances) values ('" + name + "', '" + salary + "', '" + otrate + "', '" + allowances + "' )";
                cmd.ExecuteNonQuery();
                con.Close();
                MessageBox.Show("Record has been inserted!");

                txtid.Clear();
                txtname.Clear();
                txtsal.Clear();
                txtot.Clear();
                txtallow.Clear();
                loadtable();


            }
            catch (Exception ex)
            {
                MessageBox.Show("Error" + ex);
            }
        }

        private void loadtable()
        {
            try
            {

                con.Open();
                // label3.Text = "Connection Successfull!";

                SqlCommand cmd = con.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "select * from Employee";
                cmd.ExecuteNonQuery();
                DataTable dt = new DataTable();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);
                dataGridView1.DataSource = dt;

                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error" + ex);
            }
        }

        private void Form3_Load(object sender, EventArgs e)
        {
            loadtable();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                if (MessageBox.Show("Are you sure to Update?", "Update Record", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    con.Open();

                    //  label3.Text = "Connection Successfull!";
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;

                    int id = Convert.ToInt32(txtid.Text);
                    string name = txtname.Text;
                    decimal salary = Convert.ToDecimal(txtsal.Text);
                    decimal otrate = Convert.ToDecimal(txtot.Text);
                    decimal allowances = Convert.ToDecimal(txtallow.Text);

                    cmd.CommandText = "update employee set emp_name= '" + name + "', salary='" + salary + "', ot_rate='" + otrate + "', allowances='" + allowances + "' ";
                    //cmd.Parameters.Add(new OleDbParameter { Value = name });
                    //cmd.Parameters.Add(new OleDbParameter { Value = address });
                    //cmd.Parameters.Add(new OleDbParameter { Value = tp });
                    //cmd.Parameters.Add(new OleDbParameter { Value = id });
                    cmd.ExecuteNonQuery();

                    con.Close();

                    MessageBox.Show("Record has been Updated!");
                    txtid.Clear();
                    txtname.Clear();
                    txtsal.Clear();
                    txtot.Clear();
                    txtallow.Clear();

                    loadtable();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error" + ex);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {

                if (MessageBox.Show("Are you sure to delete?", "Delete Record", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    con.Open();
                    //   label3.Text = "Connection Successfull!";
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;

                    int emp_id = Convert.ToInt32(txtid.Text);

                    cmd.CommandText = "delete from employee Where emp_id= '" + emp_id + "' ";
                    // cmd.Parameters.Add(new OleDbParameter { Value = id });


                    cmd.ExecuteNonQuery();

                    con.Close();

                    MessageBox.Show("Record has been deleted!");
                    txtid.Clear();
                    txtname.Clear();
                    txtsal.Clear();
                    txtot.Clear();
                    txtallow.Clear();

                    loadtable();
                }


            }
            catch (Exception ex)
            {
                MessageBox.Show("Error" + ex);
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0 &&
    dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value != null)
            {
                dataGridView1.CurrentRow.Selected = true;

                string empId = dataGridView1.Rows[e.RowIndex].Cells["emp_id"].FormattedValue.ToString();
                string empName = dataGridView1.Rows[e.RowIndex].Cells["emp_name"].FormattedValue.ToString();
                string salary = dataGridView1.Rows[e.RowIndex].Cells["salary"].FormattedValue.ToString();
                string otRate = dataGridView1.Rows[e.RowIndex].Cells["ot_rate"].FormattedValue.ToString();
                string allowances = dataGridView1.Rows[e.RowIndex].Cells["allowances"].FormattedValue.ToString();

                txtid.Text = empId;
                txtname.Text = empName;
                txtsal.Text = salary;
                txtot.Text = otRate;
                txtallow.Text = allowances;
            }

        }
    }
}
