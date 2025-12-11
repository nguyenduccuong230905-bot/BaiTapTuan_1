using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Text;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab03_02
{
    public partial class FrmSoanThaoVanBan : Form
    {
        private string currentFile = "";

        public FrmSoanThaoVanBan()
        {
            InitializeComponent();
            this.Text = "Soạn Thảo Văn Bản" + DateTime.Now.ToString();
            MessageBox.Show("Đang chạy FrmSoanThaoVanBan");
        }

        private void địnhDạngToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FontDialog fontDlg = new FontDialog();
            fontDlg.ShowColor = true;
            fontDlg.ShowApply = true;
            fontDlg.ShowEffects = true;
            fontDlg.ShowHelp = true;
            if (fontDlg.ShowDialog() != DialogResult.Cancel)
            {
                rtbVanBan.ForeColor = fontDlg.Color;
                rtbVanBan.Font = fontDlg.Font;
            }
        }

        private void cmbLoad_Click()
        {
            int[] sizeValues = new int[] { 8, 9, 10, 11, 12, 14, 16, 18, 20, 22, 24, 26, 28, 36, 48, 72 };
            cmbSize.ComboBox.DataSource = sizeValues;
            cmbSize.SelectedItem = 14;
        }
        private void cmbFont_Click()
        {
            foreach (FontFamily fontFamily in new InstalledFontCollection().Families)
            {
                cmbFont.Items.Add(fontFamily.Name);
            }
            cmbFont.SelectedItem = "Tahoma";
        }

        private void Frm_Load(object sender, EventArgs e)
        {
            cmbFont_Click();
            cmbLoad_Click();
            rtbVanBan.Font = new Font("Tahoma", 14, FontStyle.Regular);

        }

        private void cmbSize_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (int.TryParse(cmbSize.SelectedItem.ToString(), out int newSize))
            {
                rtbVanBan.Font = new Font(rtbVanBan.Font.FontFamily, newSize, rtbVanBan.Font.Style);
            }
        }

        private void cmbFont_SelectedIndexChanged(object sender, EventArgs e)
        {

            if (cmbFont.SelectedItem == null) return;

            rtbVanBan.Font = new Font(
                cmbFont.SelectedItem.ToString(),
                rtbVanBan.Font.Size,
                rtbVanBan.Font.Style
            );
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            rtbVanBan.Clear();
            rtbVanBan.Font = new Font("Tahoma", 14, FontStyle.Regular);
            cmbFont.SelectedItem = "Tahoma";
            cmbSize.SelectedItem = 14;
        }

        private void tạoVănBảnMớiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            rtbVanBan.Clear();
            rtbVanBan.Font = new Font("Tahoma", 14, FontStyle.Regular);
            cmbFont.SelectedItem = "Tahoma";
            cmbSize.SelectedItem = 14;
        }

        private void toolStripButton6_Click(object sender, EventArgs e)
        {
            rtbVanBan.Clear();
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.CheckFileExists = true;
            openFileDialog.CheckPathExists = true;
            openFileDialog.Filter = "Text files (*.txt)|*.txt|RichText files (*.rtf)|*.rtf";
            openFileDialog.Multiselect = false;

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                string selectedFileName = openFileDialog.FileName;
                try
                {
                    if (Path.GetExtension(selectedFileName).Equals(".txt", StringComparison.OrdinalIgnoreCase))
                    {
                        rtbVanBan.LoadFile(selectedFileName, RichTextBoxStreamType.PlainText);
                    }
                    else
                    {
                        rtbVanBan.LoadFile(selectedFileName, RichTextBoxStreamType.RichText);
                    }
                    MessageBox.Show("Tập tin đã được mở thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Đã xảy ra lỗi trong quá trình mở tập tin: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void mởTậpTintToolStripMenuItem_Click(object sender, EventArgs e)
        {
            rtbVanBan.Clear();
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.CheckFileExists = true;
            openFileDialog.CheckPathExists = true;
            openFileDialog.Filter = "Text files (*.txt)|*.txt|RichText files (*.rtf)|*.rtf";
            openFileDialog.Multiselect = false;

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                string selectedFileName = openFileDialog.FileName;
                try
                {
                    if (Path.GetExtension(selectedFileName).Equals(".txt", StringComparison.OrdinalIgnoreCase))
                    {
                        rtbVanBan.LoadFile(selectedFileName, RichTextBoxStreamType.PlainText);
                    }
                    else
                    {
                        rtbVanBan.LoadFile(selectedFileName, RichTextBoxStreamType.RichText);
                    }
                    MessageBox.Show("Tập tin đã được mở thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Đã xảy ra lỗi trong quá trình mở tập tin: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void thoátToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(currentFile))
            {
                SaveFileDialog saveDlg = new SaveFileDialog();
                saveDlg.Filter = "RTF File|*.rtf";
                saveDlg.DefaultExt = "rtf";

                if (saveDlg.ShowDialog() == DialogResult.OK)
                {
                    rtbVanBan.SaveFile(saveDlg.FileName, RichTextBoxStreamType.RichText);
                    currentFile = saveDlg.FileName;
                    MessageBox.Show("Lưu thành công!");
                }
            }
            else
            {
                rtbVanBan.SaveFile(currentFile, RichTextBoxStreamType.RichText);
                MessageBox.Show("Đã lưu!");
            }
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(currentFile))
            {
                SaveFileDialog saveDlg = new SaveFileDialog();
                saveDlg.Filter = "RTF File|*.rtf";
                saveDlg.DefaultExt = "rtf";

                if (saveDlg.ShowDialog() == DialogResult.OK)
                {
                    rtbVanBan.SaveFile(saveDlg.FileName, RichTextBoxStreamType.RichText);
                    currentFile = saveDlg.FileName;
                    MessageBox.Show("Lưu thành công!");
                }
            }
            else
            {
                rtbVanBan.SaveFile(currentFile, RichTextBoxStreamType.RichText);
                MessageBox.Show("Đã lưu!");
            }
        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            if (rtbVanBan.SelectionFont != null)
            {
                Font current = rtbVanBan.SelectionFont;
                FontStyle style = current.Style;
                if (current.Bold)
                    style &= ~FontStyle.Bold;
                else
                    style |= FontStyle.Bold;

                rtbVanBan.SelectionFont =
                    new Font(current.FontFamily, current.Size, style);
            }
        }

        private void toolStripButton4_Click(object sender, EventArgs e)
        {
            if (rtbVanBan.SelectionFont != null)
            {
                Font current = rtbVanBan.SelectionFont;
                FontStyle style = current.Style;

                if (current.Italic)
                    style &= ~FontStyle.Italic;
                else
                    style |= FontStyle.Italic;

                rtbVanBan.SelectionFont =
                    new Font(current.FontFamily, current.Size, style);
            }

        }

        private void toolStripButton5_Click(object sender, EventArgs e)
        {
            if (rtbVanBan.SelectionFont != null)
            {
                Font current = rtbVanBan.SelectionFont;
                FontStyle style = current.Style;

                if (current.Underline)
                    style &= ~FontStyle.Underline;
                else
                    style |= FontStyle.Underline;

                rtbVanBan.SelectionFont =
                    new Font(current.FontFamily, current.Size, style);
            }
        }
    }
}
