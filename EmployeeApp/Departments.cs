﻿using System;
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
    public partial class Departments : Form


    {
        Functions Con;
        public Departments()
        {
            InitializeComponent();
            Con = new Functions();
            ShowDepartments();
        }
        private void ShowDepartments()
        {
            string Query = "select * from DepartmentTbl";
            DepList.DataSource = Con.GetData(Query);
        }
        private void AddBtn_Click(object sender, EventArgs e)
        {
            try
            {
                if (DepNameTb.Text == "")
                {
                    MessageBox.Show("Missing Data !!");
                }
                else
                {
                    string Dep = DepNameTb.Text;
                    string Query = "insert into DepartmentTbl values ('{0}')";
                    Query = string.Format(Query, DepNameTb.Text);
                    Con.SetData(Query);
                    ShowDepartments();
                    MessageBox.Show("Department Added !!!");
                    DepNameTb.Text = "";
                }
            }
            catch (Exception Ex)
            {

                MessageBox.Show(Ex.Message);
            }
        }
        int key = 0;
        private int index;
        private void DepList_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != -1)
            {
                DataGridViewRow row = DepList.Rows[e.RowIndex];
                DepNameTb.Text = row.Cells[1].Value.ToString();

            }

        }

        private void EditBtn_Click(object sender, EventArgs e)
        {
            try
            {
                if (DepNameTb.Text == "")
                {
                    MessageBox.Show("Missing Data !!");
                }
                else
                {
                    string Dep = DepNameTb.Text;
                    string Query = "Update into DepartmentTbl set DepName  = '{0}'Where DepId  = {1}";
                    Query = string.Format(Query, DepNameTb.Text,key);
                    Con.SetData(Query);
                    ShowDepartments();
                    MessageBox.Show("Department Updated !!");
                    DepNameTb.Text = "";
                }
            }
            catch (Exception Ex)
            {

                MessageBox.Show(Ex.Message);
            }
        }

        private void DepNameTb_TextChanged(object sender, EventArgs e)
        {

        }

        private void DeleteBtn_Click(object sender, EventArgs e)
        {
            try
            {
                if (DepNameTb.Text == "")
                {
                    MessageBox.Show("Missing Data !!");
                }
                else
                {
                    string Dep = DepNameTb.Text;
                    string Query = "Delete into DepartmentTbl Where DepId  = {0}";
                    Query = string.Format(Query, key);
                    Con.SetData(Query);
                    ShowDepartments();
                    MessageBox.Show("Department Deleted !!");
                    DepNameTb.Text = "";
                }
            }
            catch (Exception Ex)
            {

                MessageBox.Show(Ex.Message);
            }

        }

        private void EmpLbl_Click(object sender, EventArgs e)
        {
            Employees Obj = new Employees();  
            Obj.Show();
            this.Hide();
        }
    }
}
