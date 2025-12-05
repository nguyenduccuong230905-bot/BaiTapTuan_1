using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace baitapvenhabuoi3_nhanvien
{
    public partial class dgvNhanVien : Form
    {
        public string MSNV
        {
            get { return txtMSNV.Text.Trim(); }
            set { txtMSNV.Text = value; }
        }

        public string TenNV
        {
            get { return txtTenNV.Text.Trim(); }
            set { txtTenNV.Text = value; }
        }

        public string LuongCB
        {
            get { return txtLuong.Text.Trim(); }
            set { txtLuong.Text = value; }
        }

        public dgvNhanVien()
        {
            InitializeComponent();
        }

        private void dgvNhanVien_Load(object sender, EventArgs e)
        {
            // Có thể dùng để thiết lập mặc định hoặc kiểm tra dữ liệu
        }

        private void btnDongy_Click(object sender, EventArgs e)
        {
            // Kiểm tra dữ liệu trước khi đóng form
            if (string.IsNullOrEmpty(MSNV) || string.IsNullOrEmpty(TenNV) || string.IsNullOrEmpty(LuongCB))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin nhân viên!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Kiểm tra lương có phải là số
            if (!decimal.TryParse(LuongCB, out _))
            {
                MessageBox.Show("Lương căn bản phải là số!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void btnBoqua_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        // Các sự kiện không cần xử lý có thể để trống hoặc xóa nếu không dùng
        private void label1_Click(object sender, EventArgs e) { }
        private void label2_Click(object sender, EventArgs e) { }
        private void label3_Click(object sender, EventArgs e) { }
        private void textMSNV_TextChanged(object sender, EventArgs e) { }
        private void txtTenNV_TextChanged(object sender, EventArgs e) { }
        private void textBox3_TextChanged(object sender, EventArgs e) { }
    }
}
