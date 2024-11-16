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
namespace QLGV
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        SqlConnection connection;
        SqlCommand command;
        string str = "Data Source=LAPTOP-2OA5RPHI;Initial Catalog=QLGV;Integrated Security=True;Encrypt=False";
        SqlDataAdapter adapter = new SqlDataAdapter();
        DataTable table = new DataTable();
        void loaddata()
        {
            command = connection.CreateCommand();
            command.CommandText = "SELECT * FROM GiaoVien";
            adapter.SelectCommand = command;
            table.Clear();
            adapter.Fill(table);
            dataGridView1.DataSource = table;
        }
        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            connection = new SqlConnection(str);
            connection.Open();
            loaddata();
        }
        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            string idGV = txtID.Text.Trim();
            string tenTaiKhoan = txtTenTk.Text.Trim();
            string hoTen = txtHoTen.Text.Trim(); 
            string email = txtMail.Text.Trim();
            string khoa = txtKhoa.Text.Trim(); 
            if (string.IsNullOrEmpty(idGV) || string.IsNullOrEmpty(tenTaiKhoan) || string.IsNullOrEmpty(hoTen) ||
                string.IsNullOrEmpty(email) || string.IsNullOrEmpty(khoa))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            string query = "INSERT INTO GiaoVien (MaGV, TenTaiKhoan, HoTen, Email, Khoa) VALUES (@MaGV, @TenTaiKhoan, @HoTen, @Email, @Khoa)";
            command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@MaGV", idGV);
            command.Parameters.AddWithValue("@TenTaiKhoan", tenTaiKhoan);
            command.Parameters.AddWithValue("@HoTen", hoTen);
            command.Parameters.AddWithValue("@Email", email);
            command.Parameters.AddWithValue("@Khoa", khoa);

            try
            {
                command.ExecuteNonQuery();
                loaddata();
                txtTenTk.Clear();
                txtID.Clear();
                txtKhoa.Clear();
                txtMail.Clear();
                txtHoTen.Clear();
                MessageBox.Show("Thêm giáo viên thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi thêm dữ liệu: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            string idGV = txtID.Text.Trim();
            string tenTaiKhoan = txtTenTk.Text.Trim();
            string hoTen = txtHoTen.Text.Trim();
            string email = txtMail.Text.Trim();
            string khoa = txtKhoa.Text.Trim();
            if (string.IsNullOrEmpty(idGV))
            {
                MessageBox.Show("Vui lòng nhập ID giáo viên để sửa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            string query = "UPDATE GiaoVien SET TenTaiKhoan = @TenTaiKhoan, HoTen = @HoTen, Email = @Email, Khoa = @Khoa WHERE MaGV = @MaGV";
            command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@MaGV", idGV);
            command.Parameters.AddWithValue("@TenTaiKhoan", tenTaiKhoan);
            command.Parameters.AddWithValue("@HoTen", hoTen);
            command.Parameters.AddWithValue("@Email", email);
            command.Parameters.AddWithValue("@Khoa", khoa);
            try
            {
                int rowsAffected = command.ExecuteNonQuery();

                if (rowsAffected > 0)
                {
                    loaddata();
                    txtID.Clear();
                    txtTenTk.Clear();
                    txtHoTen.Clear();
                    txtMail.Clear();
                    txtKhoa.Clear();

                    MessageBox.Show("Sửa thông tin giáo viên thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Không tìm thấy giáo viên với ID được cung cấp!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi sửa dữ liệu: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            
            string idGV = txtID.Text.Trim();
            if (string.IsNullOrEmpty(idGV))
            {
                MessageBox.Show("Vui lòng nhập ID giáo viên cần xóa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            string query = "DELETE FROM GiaoVien WHERE MaGV = @MaGV";
            command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@MaGV", idGV);
            try
            {
                int rowsAffected = command.ExecuteNonQuery();

                if (rowsAffected > 0)
                {
                    loaddata();
                    txtID.Clear();
                    txtTenTk.Clear();
                    txtHoTen.Clear();
                    txtMail.Clear();
                    txtKhoa.Clear();
                    MessageBox.Show("Xóa giáo viên thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show(" Không tìm thấy ID trên ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi xóa dữ liệu: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btbTimKiem_Click(object sender, EventArgs e)
        {
            string keyword = txtTimKiem.Text.Trim();
            if (string.IsNullOrEmpty(keyword))
            {
                loaddata();
            }
            else
            {              
                if (string.IsNullOrEmpty(keyword))
                {
                    MessageBox.Show("Vui lòng nhập từ khóa để tìm kiếm!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                string query = "SELECT * FROM GiaoVien WHERE MaGV LIKE @Keyword OR HoTen LIKE @Keyword OR Khoa LIKE @Keyword";
                command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@Keyword", "%" + keyword + "%");

                try
                {
                    DataTable searchTable = new DataTable();
                    adapter.SelectCommand = command;
                    searchTable.Clear();
                    adapter.Fill(searchTable);
                    dataGridView1.DataSource = searchTable;

                    if (searchTable.Rows.Count == 0)
                    {
                        MessageBox.Show("Không tìm thấy kết quả phù hợp!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi tìm kiếm dữ liệu: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {       
                DataGridViewRow row = dataGridView1.Rows[e.RowIndex];
                txtID.Text = row.Cells["MaGV"].Value.ToString();
            }
        }
    }
}
