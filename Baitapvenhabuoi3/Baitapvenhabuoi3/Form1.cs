using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Baitapvenhabuoi3
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // Khởi tạo cột cho DataGridView
            dgvListView.ColumnCount = 3;
            dgvListView.Columns[0].Name = "MSNV";
            dgvListView.Columns[1].Name = "Tên NV";
            dgvListView.Columns[2].Name = "Lương CB";
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            // Mở form nhập nhân viên
            baitapvenhabuoi3_nhanvien.dgvNhanVien f = new baitapvenhabuoi3_nhanvien.dgvNhanVien();
            if (f.ShowDialog() == DialogResult.OK)
            {
                dgvListView.Rows.Add(f.MSNV, f.TenNV, f.LuongCB);
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (dgvListView.SelectedRows.Count > 0)
            {
                DataGridViewRow row = dgvListView.SelectedRows[0];
                baitapvenhabuoi3_nhanvien.dgvNhanVien f = new baitapvenhabuoi3_nhanvien.dgvNhanVien();

                // Gán dữ liệu hiện tại vào form nhập
                f.MSNV = row.Cells[0].Value.ToString();
                f.TenNV = row.Cells[1].Value.ToString();
                f.LuongCB = row.Cells[2].Value.ToString();

                if (f.ShowDialog() == DialogResult.OK)
                {
                    row.Cells[0].Value = f.MSNV;
                    row.Cells[1].Value = f.TenNV;
                    row.Cells[2].Value = f.LuongCB;
                }
            }
            else
            {
                MessageBox.Show("Vui lòng chọn một nhân viên để sửa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (dgvListView.SelectedRows.Count > 0)
            {
                DialogResult dr = MessageBox.Show("Bạn có chắc muốn xóa nhân viên này?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dr == DialogResult.Yes)
                {
                    dgvListView.Rows.RemoveAt(dgvListView.SelectedRows[0].Index);
                }
            }
            else
            {
                MessageBox.Show("Vui lòng chọn một nhân viên để xóa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnDong_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
