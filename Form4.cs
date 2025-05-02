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
    public partial class Form4 : Form
    {
        SqlConnection con = null;
        public Form4()
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
            this.Hide();
            Form2 form = new Form2();
            form.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {

                con.Open();
                //label4.Text = "Connection Successfull!";
                SqlCommand cmd = con.CreateCommand();
                cmd.CommandType = CommandType.Text;
                DateTime begin = dateTimePicker1.Value;
                DateTime end = dateTimePicker2.Value;
                int leaves = Convert.ToInt32(txtleaves.Text);
                decimal tax = Convert.ToDecimal(txttax.Text);

                cmd.CommandText = "insert into setting1 (begin_date,end_date,leaves,tax_rate) values ('" + begin.ToString("dd/MM/yyyy") + "', '" + end.ToString("dd/MM/yyyy") + "', '" + leaves + "', '" + tax + "')";
                cmd.ExecuteNonQuery();
                con.Close();
                MessageBox.Show("Record has been inserted!");

                txtid.Clear();
                txtleaves.Clear();
                txttax.Clear();
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
                cmd.CommandText = "select * from setting1";
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

        private void Form4_Load(object sender, EventArgs e)
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

                    DateTime begin = dateTimePicker1.Value;
                    DateTime end = dateTimePicker2.Value;
                    int leaves = Convert.ToInt32(txtleaves.Text);
                    decimal tax = Convert.ToDecimal(txttax.Text);

                    cmd.CommandText = "update setting1 set begin_date= '" + begin + "', end_date='" + end + "', leaves='" + leaves + "', tax_rate='" + tax + "' ";
                    //cmd.Parameters.Add(new OleDbParameter { Value = name });
                    //cmd.Parameters.Add(new OleDbParameter { Value = address });
                    //cmd.Parameters.Add(new OleDbParameter { Value = tp });
                    //cmd.Parameters.Add(new OleDbParameter { Value = id });
                    cmd.ExecuteNonQuery();

                    con.Close();

                    MessageBox.Show("Record has been Updated!");
                    txtid.Clear();
                    txtleaves.Clear();
                    txttax.Clear();

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

                    int set_id = Convert.ToInt32(txtid.Text);

                    cmd.CommandText = "delete from setting1 Where set_id= '" + set_id + "' ";
                    // cmd.Parameters.Add(new OleDbParameter { Value = id });


                    cmd.ExecuteNonQuery();

                    con.Close();

                    MessageBox.Show("Record has been deleted!");
                    txtid.Clear();
                    txtleaves.Clear();
                    txttax.Clear();

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

                string setid = dataGridView1.Rows[e.RowIndex].Cells["set_id"].FormattedValue.ToString();
                string begin = dataGridView1.Rows[e.RowIndex].Cells["begin_date"].FormattedValue.ToString();
                string end = dataGridView1.Rows[e.RowIndex].Cells["end_date"].FormattedValue.ToString();
                string leaves = dataGridView1.Rows[e.RowIndex].Cells["leaves"].FormattedValue.ToString();
                string tax = dataGridView1.Rows[e.RowIndex].Cells["tax_rate"].FormattedValue.ToString();

                txtid.Text = setid;
                dateTimePicker1.Text = begin;
                dateTimePicker2.Text = end;
                txtleaves.Text = leaves;
                txttax.Text = tax;
            }
        }
    }
}
