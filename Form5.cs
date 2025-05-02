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
    public partial class Form5 : Form
    {
        SqlConnection con = null;
        public Form5()
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
                int empid = Convert.ToInt32(txtemp.Text);
                DateTime begin = dateTimePicker1.Value;
                DateTime end = dateTimePicker1.Value;
                int leaves = Convert.ToInt32(txtleaves.Text);
                int holiday = Convert.ToInt32(txtholiday.Text);
                Decimal salary = Convert.ToDecimal(txtsalary.Text);
                Decimal allowances = Convert.ToDecimal(txtallowances.Text);
                Decimal otrate = Convert.ToDecimal(txtotrate.Text);
                int othrs = Convert.ToInt32(txtothrs.Text);
                Decimal taxrate = Convert.ToDecimal(txttax.Text);
                Decimal nopay = Convert.ToDecimal(txtno.Text);
                Decimal basepay = Convert.ToDecimal(txtbase.Text);
                Decimal grosspay = Convert.ToDecimal(txtgross.Text);

                cmd.CommandText = "insert into salary2 (emp_id,begin_date,end_date,leaves,holidays,salary,allowances,ot_rate,ot_hours,tax_rate,no_pay,base_pay,gross_pay) values ('" + empid + "','" + begin.ToString("dd/MM/yyyy") + "', '" + end.ToString("dd/MM/yyyy") + "', '" + leaves + "', '" + holiday + "', '" + salary + "', '" + allowances + "', '" + otrate + "', '" + othrs + "', '" + taxrate + "', '" + nopay + "', '" + basepay + "', '" + grosspay + "' )";
                cmd.ExecuteNonQuery();
                con.Close();
                MessageBox.Show("Record has been inserted!");

                txtid.Clear();
                txtemp.Clear();
                txtleaves.Clear();
                txtholiday.Clear();
                txtsalary.Clear();
                txtallowances.Clear();
                txtotrate.Clear();
                txtothrs.Clear();
                txttax.Clear();
                txtno.Clear();
                txtbase.Clear();
                txtgross.Clear();
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
                cmd.CommandText = "select * from salary2";
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

        private void Form5_Load(object sender, EventArgs e)
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

                    int empid = Convert.ToInt32(txtemp.Text);
                    string begin = dateTimePicker1.Text;
                    string end = dateTimePicker2.Text;
                    int leaves = Convert.ToInt32(txtleaves.Text);
                    int holiday = Convert.ToInt32(txtholiday.Text);
                    decimal salary = Convert.ToDecimal(txtsalary.Text);
                    decimal allowances = Convert.ToDecimal(txtallowances.Text);
                    decimal otrate = Convert.ToDecimal(txtotrate.Text);
                    int othrs = Convert.ToInt32(txtothrs.Text);
                    decimal taxrate = Convert.ToDecimal(txttax.Text);
                    decimal nopay = Convert.ToDecimal(txtno.Text);
                    decimal basepay = Convert.ToDecimal(txtbase.Text);
                    decimal grosspay = Convert.ToDecimal(txtgross.Text);

                    cmd.CommandText = "update salary2 set emp_id= '" + empid + "', begin_date='" + begin + "', end_date='" + end + "', leaves='" + leaves + "', holidays='" + holiday + "', salary='" + salary + "', allowances='" + allowances + "', ot_rate='" + otrate + "', ot_hours='" + othrs + "', tax_rate='" + taxrate + "', no_pay='" + nopay + "', base_pay='" + basepay + "', gross_pay='" + grosspay + "', ";
                    //cmd.Parameters.Add(new OleDbParameter { Value = name });
                    //cmd.Parameters.Add(new OleDbParameter { Value = address });
                    //cmd.Parameters.Add(new OleDbParameter { Value = tp });
                    //cmd.Parameters.Add(new OleDbParameter { Value = id });
                    cmd.ExecuteNonQuery();

                    con.Close();

                    MessageBox.Show("Record has been Updated!");
                    txtid.Clear();
                    txtemp.Clear();
                    txtleaves.Clear();
                    txtholiday.Clear();
                    txtsalary.Clear();
                    txtallowances.Clear();
                    txtotrate.Clear();
                    txtothrs.Clear();
                    txttax.Clear();
                    txtno.Clear();
                    txtbase.Clear();
                    txtgross.Clear();

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

                    int salid = Convert.ToInt32(txtid.Text);

                    cmd.CommandText = "delete from salary2 where sal_id = '" + salid + "' ";
                    // cmd.Parameters.Add(new OleDbParameter { Value = id });


                    cmd.ExecuteNonQuery();

                    con.Close();

                    MessageBox.Show("Record has been deleted!");
                    txtid.Clear();
                    txtemp.Clear();
                    txtleaves.Clear();
                    txtholiday.Clear();
                    txtsalary.Clear();
                    txtallowances.Clear();
                    txtotrate.Clear();
                    txtothrs.Clear();
                    txttax.Clear();
                    txtno.Clear();
                    txtbase.Clear();
                    txtgross.Clear();

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

                string salid = dataGridView1.Rows[e.RowIndex].Cells["sal_id"].FormattedValue.ToString();
                string empid = dataGridView1.Rows[e.RowIndex].Cells["emp_id"].FormattedValue.ToString();
                string begin = dataGridView1.Rows[e.RowIndex].Cells["begin_date"].FormattedValue.ToString();
                string end = dataGridView1.Rows[e.RowIndex].Cells["end_date"].FormattedValue.ToString();
                string leaves = dataGridView1.Rows[e.RowIndex].Cells["leaves"].FormattedValue.ToString();
                string holiday = dataGridView1.Rows[e.RowIndex].Cells["holidays"].FormattedValue.ToString();
                string salary = dataGridView1.Rows[e.RowIndex].Cells["salary"].FormattedValue.ToString();
                string allowances = dataGridView1.Rows[e.RowIndex].Cells["allowances"].FormattedValue.ToString();
                string otrate = dataGridView1.Rows[e.RowIndex].Cells["ot_rate"].FormattedValue.ToString();
                string othrs = dataGridView1.Rows[e.RowIndex].Cells["ot_hours"].FormattedValue.ToString();
                string taxrate = dataGridView1.Rows[e.RowIndex].Cells["tax_rate"].FormattedValue.ToString();
                string nopay = dataGridView1.Rows[e.RowIndex].Cells["no_pay"].FormattedValue.ToString();
                string basepay = dataGridView1.Rows[e.RowIndex].Cells["base_pay"].FormattedValue.ToString();
                string grosspay = dataGridView1.Rows[e.RowIndex].Cells["gross_pay"].FormattedValue.ToString();

                txtid.Text = salid;
                txtemp.Text = empid;
                dateTimePicker1.Text = begin;
                dateTimePicker2.Text = end;
                txtleaves.Text = leaves;
                txtholiday.Text = holiday;
                txtsalary.Text = salary;
                txtallowances.Text = allowances;
                txtotrate.Text = otrate;
                txtothrs.Text = othrs;
                txttax.Text = taxrate;
                txtno.Text = nopay;
                txtbase.Text = basepay;
                txtgross.Text = grosspay;
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            try
            {
                con.Open();
                SqlCommand cmd = con.CreateCommand();
                cmd.CommandType = CommandType.Text;

                Decimal Monthly_Salary = Convert.ToDecimal(txtsalary.Text);
                Decimal Overtime_Rate = Convert.ToDecimal(txtotrate.Text);
                Decimal OT_Hours = Convert.ToDecimal(txtothrs.Text);
                Decimal Allowances = Convert.ToDecimal(txtallowances.Text);

                int Absent_Days = Convert.ToInt32(txtleaves.Text);
                int Date_Range = Convert.ToInt32(txtleaves.Text);
                Decimal Tax_Rate = Convert.ToDecimal(txttax.Text);


                Decimal Base_Pay = Monthly_Salary + Allowances + (Overtime_Rate * OT_Hours);
                Decimal No_Pay = (Monthly_Salary / Date_Range) * Absent_Days;
                Decimal Gross_Pay = Base_Pay - (No_Pay + Base_Pay * Tax_Rate);


                txtno.Text = No_Pay.ToString();
                txtgross.Text = Gross_Pay.ToString();
                txtbase.Text = Base_Pay.ToString();

                con.Close();
                MessageBox.Show("Salary Calculated!", "Grifindo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error" + ex);
            }
        }
    }
    
}
