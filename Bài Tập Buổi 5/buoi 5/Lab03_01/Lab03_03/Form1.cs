using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab03_03
{
    public partial class QuanLySinhVienForm : Form
    {
        // Giả định bạn có một đối tượng List<SinhVien> để quản lý dữ liệu
        // private List<SinhVien> dsSinhVien = new List<SinhVien>(); 

        public QuanLySinhVienForm()
        {
            // TODO: Khởi tạo DataGridView và tải dữ liệu ban đầu
        }

        // Xử lý sự kiện khi nhấn Menu "Thêm mới" (hoặc ToolStrip Button)
        private void themMoiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Khởi tạo Form Thêm Sinh viên
            ThêmSinhVienForm addStudentForm = new ThêmSinhVienForm();

            // Bước 3: Gán hàm xử lý (handler) vào delegate của Form con
            // Gán phương thức addStudentForm_OnAddStudent vào delegate OnAddStudent
            addStudentForm.OnAddStudent = new ThêmSinhVienForm.OnAddStudentDelegate(addStudentForm_OnAddStudent);

            // Hiển thị Form Thêm Sinh viên
            addStudentForm.ShowDialog();
        }

        // Hàm xử lý (handler) được gọi bởi delegate (OnAddStudent.Invoke) của Form con
        // Phương thức này sẽ nhận dữ liệu từ Form con và thực hiện logic thêm vào Form cha
        private void addStudentForm_OnAddStudent(string maSV, string hoTen, string tenKhoa, string faculty)
        {
            try
            {
                MessageBox.Show("Đã thêm sinh viên " + hoTen + " thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error Message: " + ex.Message, "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
