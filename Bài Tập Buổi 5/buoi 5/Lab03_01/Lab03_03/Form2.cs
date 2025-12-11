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
    public partial class ThêmSinhVienForm : Form
    {
        // Bước 1: Khai báo Delegate
        // Định nghĩa delegate để thông báo việc thêm sinh viên hoàn tất
        public delegate void OnAddStudentDelegate(string maSV, string hoTen, string tenKhoa, string faculty);

        // Khai báo Event (dựa trên delegate)
        public OnAddStudentDelegate OnAddStudent;

        public ThêmSinhVienForm()
        {
            InitializeComponent();
        }

        // ... Các trường dữ liệu, ComboBox, v.v.

        // Xử lý sự kiện khi nhấn nút "Thêm"
        private void btnThem_Click(object sender, EventArgs e)
        {
            try
            {
                // Lấy dữ liệu từ các controls
                string maSV = txtMSSV.Text;
                string hoTen = txtTenSV.Text;
                string tenKhoa = cmbKhoa.Text; // Giả sử cboKhoa là ComboBox

                // TODO: Bổ sung logic kiểm tra dữ liệu hợp lệ và bắt buộc

                // Bước 2: Gọi delegate (Invoke) để thông báo cho Form cha
                // Kiểm tra xem delegate đã được gán hàm xử lý chưa (khác null)
                if (OnAddStudent != null)
                {
                    // Thêm dữ liệu mẫu vào delegate (bạn cần thay đổi theo cấu trúc dữ liệu của mình)
                    OnAddStudent.Invoke(maSV, hoTen, tenKhoa, "Faculty_Example");
                }

                // Đóng Form sau khi thêm thành công (hoặc tùy thuộc yêu cầu)
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
