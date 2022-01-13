using Cau1.BAL;
using Cau1.BEL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Cau1
{
    public partial class Form1 : Form
    {
        Employee_BAL empBAL = new Employee_BAL();
        Department_BAL dmpBAL = new Department_BAL();
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

            List<Employee_BEL> lstEmp = empBAL.ReadEmployee();
            foreach (Employee_BEL emp in lstEmp)
            {
                dgvEmployee.Rows.Add(emp.IdEmployee, emp.Name, emp.DateBirth, emp.Gender, emp.PlaceBirth, emp.Departments.Name);
            }

            List<Department_BEL> lstDepartment = dmpBAL.ReadDepartmentList();
            foreach (Department_BEL dmp in lstDepartment)
            {
                tbDepartment.Items.Add(dmp);
            }
            tbDepartment.DisplayMember = "Name";

        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            Employee_BEL emp = new Employee_BEL();
            emp.IdEmployee = tbId.Text;
            emp.Name = tbName.Text;
            emp.DateBirth = tbDate.Value;
            if (tbGender.Checked)
            {
                emp.Gender = tbGender.Checked;
            }
            emp.PlaceBirth = tbPlace.Text;
            emp.Departments = (Department_BEL)tbDepartment.SelectedItem;

            empBAL.NewEmployee(emp);

            dgvEmployee.Rows.Add(emp.IdEmployee, emp.Name, emp.DateBirth, emp.Gender, emp.PlaceBirth, emp.Departments.Name);

        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            Employee_BEL emp = new Employee_BEL();
            emp.IdEmployee = tbId.Text;
            emp.Name = tbName.Text;
            emp.DateBirth = DateTime.Parse(tbDate.Text);
            if (tbGender.Checked)
            {
                emp.Gender = true;
            }
            emp.PlaceBirth = tbPlace.Text;
            emp.Departments = (Department_BEL)tbDepartment.SelectedItem;

            empBAL.EditEmployee(emp);

            DataGridViewRow row = dgvEmployee.CurrentRow;
            row.Cells[0].Value = emp.IdEmployee;
            row.Cells[1].Value = emp.Name;
            row.Cells[2].Value = emp.DateBirth;
            row.Cells[3].Value = emp.Gender;
            row.Cells[4].Value = emp.PlaceBirth;
            row.Cells[5].Value = emp.Departments.Name;
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có muốn đóng chương trình không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                this.Close();
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            Employee_BEL emp = new Employee_BEL();
            emp.IdEmployee = tbId.Text;
            emp.Name = tbName.Text;
            emp.DateBirth = DateTime.Parse(tbDate.Text);
            if (tbGender.Checked)
            {
                emp.Gender = true;
            }
            emp.PlaceBirth = tbPlace.Text;
            emp.Departments = (Department_BEL)tbDepartment.SelectedItem;

           

            if (MessageBox.Show("Bạn có muốn Xoá dữ liệu không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                empBAL.DeleteEmployee(emp);

                int idx = dgvEmployee.CurrentCell.RowIndex;
                dgvEmployee.Rows.RemoveAt(idx);
            }



        }

        private void dgvEmployee_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            int idx = e.RowIndex;
            DataGridViewRow row = dgvEmployee.Rows[idx];
            if (row.Cells[0].Value != null)
            {
                tbId.Text = row.Cells[0].Value.ToString();
                tbName.Text = row.Cells[1].Value.ToString();
                tbDate.Text = row.Cells[2].Value.ToString();
                //tbGender.Text = row.Cells[3].Value.ToString();
                if (row.Cells[3].Value.ToString() == "True")
                {
                    tbGender.Checked = true;
                }
                else
                {
                    tbGender.Checked = false;
                }
                tbPlace.Text = row.Cells[4].Value.ToString();
                tbDepartment.Text = row.Cells[5].Value.ToString();
            }

        }       
    }
}
