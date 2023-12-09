using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EmployeeApp
{
    public partial class Employees : Form
    {
        Functions Con;

        public Employees()
        {
            InitializeComponent();
            Con = new Functions();
            ShowEmp();
            GetDepartment();
        }
        private void ShowEmp()
        {
            string Query = "select * from EmployeeTbl";
            EmployeeList.DataSource = Con.GetData(Query);
        }
        private void Employees_Load(object sender, EventArgs e)
        {

        }
        private void GetDepartment()
        {
            string Query = "select * from EmployeeTbl";

        }
        private void GetEmployee()
        {
            string Query = "select * from DepartmentTbl";
            depCb.DisplayMember = Con.GetData(Query).Columns["DepName"].ToString();
            depCb.ValueMember = Con.GetData(Query).Columns["DepId"].ToString();
            depCb.DataSource = Con.GetData(Query);
        }
        private void AddBtn_Click(object sender, EventArgs e)
        {
            try
            {
                if (EmpNameTb.Text == "" || GenCb.SelectedIndex == -1 || depCb.SelectedIndex == -1 || DailySalTb.Text == "")
                {
                    MessageBox.Show("Missing Data !!");
                }
                else
                {
                    string Name = EmpNameTb.Text;
                    string Gender = GenCb.SelectedItem.ToString();
                    if (depCb.SelectedValue != null) { 
                        int Dep = Convert.ToInt32(depCb.SelectedValue.ToString());
                    }
                    else
                    {
                        
                        MessageBox.Show("Please select a department.");
                    }
                    string DOB = DOBTb.Value.ToString("yyyy-MM-dd");
                    string JDate = JDateTb.Value.ToString("yyyy-MM-dd"); 
                    int Salary = Convert.ToInt32(DailySalTb.Text);

                    
                    string Query = "INSERT INTO EmployeeTbl VALUES ('{0}', '{1}', {2}, '{3}', '{4}', {5})";
                    Query = string.Format(Query, Name, Gender,  DOB, JDate, Salary);

                  
                    Con.SetData(Query);

                    ShowEmp();
                    MessageBox.Show("Employee Added !!!");

                   
                    EmpNameTb.Text = "";
                    DailySalTb.Text = "";
                    GenCb.SelectedIndex = -1;
                    depCb.SelectedIndex = -1;
                }
            }
            catch (Exception Ex)
            {
                MessageBox.Show(Ex.Message);
            }
        }

        private void Deletebtn_Click(object sender, EventArgs e)
        {

        }

        private void Update_Click(object sender, EventArgs e)
        {

        }
    }

}
