using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BTN1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private Form currentFormChild;
        private void OpenChildForm(Form childForm)
        {
            if (currentFormChild != null)
            {
                currentFormChild.Close();
            }
            currentFormChild = childForm;
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;
            panel_body.Controls.Add(childForm);
            panel_body.Tag = childForm;
            childForm.BringToFront();
            childForm.Show();
        }
        private void panel_body_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (currentFormChild != null)
            {
                currentFormChild.Close();
            }
            lblHT.Text = "Home";
        }

        private void btnDeThi_Click(object sender, EventArgs e)
        {
            OpenChildForm(new DeThi());
            lblHT.Text= "Đề Thi"; 
        }

        private void btnKND_Click(object sender, EventArgs e)
        {
            OpenChildForm(new KhoND());
            lblHT.Text = "Kho nội dung";
        }

        private void btnNH_Click(object sender, EventArgs e)
        {
            OpenChildForm(new NHCauHoi());
            lblHT.Text = "Ngân Hàng Câu Hỏi";
        }

        private void btnQLGV_Click(object sender, EventArgs e)
        {
            OpenChildForm(new QLGiaoVien());
            lblHT.Text = "Quản Lý Giáo Viên";
        }

        private void button8_Click(object sender, EventArgs e)
        {
            OpenChildForm(new DeThi());
            lblHT.Text = "Đề Thi";
        }

        private void button9_Click(object sender, EventArgs e)
        {
            OpenChildForm(new KhoND());
            lblHT.Text = "Kho nội dung";
        }

        private void button10_Click(object sender, EventArgs e)
        {
            OpenChildForm(new NHCauHoi());
            lblHT.Text = "Ngân Hàng Câu Hỏi";
        }

        private void button11_Click(object sender, EventArgs e)
        {
            OpenChildForm(new QLGiaoVien());
            lblHT.Text = "Quản Lý Giáo Viên";
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            if (currentFormChild != null)
            {
                currentFormChild.Close();
            }
            lblHT.Text = "Home";
        }

        private void button3_Click(object sender, EventArgs e)
        {
            contextMenuStrip1.Show(btnSettings, new Point(0, btnSettings.Height));
        }

        private void thôngTinGiáoViênToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ThongTinGV form = new ThongTinGV(); 
            form.Show();
        }

        private void đăngXuấtToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Bạn có chắc muốn đăng xuất?", "Đăng xuất", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                this.Close();
            }
        }
    }
}
