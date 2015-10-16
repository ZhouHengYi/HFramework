using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ThoughtWorks.QRCode.Codec;
using ThoughtWorks.QRCode.Codec.Data;

namespace QRCode
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btn_Create_Click(object sender, EventArgs e)
        {
            if (this.txtEncodeData.Text.Trim() == string.Empty)
            {
                MessageBox.Show("数据不能为空。");
            }
            else
            {
                QRCodeEncoder qrCodeEncoder = new QRCodeEncoder();
                switch (this.cboEncoding.Text)
                {
                    case "Byte":
                        qrCodeEncoder.QRCodeEncodeMode = QRCodeEncoder.ENCODE_MODE.BYTE;
                        break;

                    case "AlphaNumeric":
                        qrCodeEncoder.QRCodeEncodeMode = QRCodeEncoder.ENCODE_MODE.ALPHA_NUMERIC;
                        break;

                    case "Numeric":
                        qrCodeEncoder.QRCodeEncodeMode = QRCodeEncoder.ENCODE_MODE.NUMERIC;
                        break;
                }
                try
                {
                    int scale = Convert.ToInt16(this.txtSize.Text);
                    qrCodeEncoder.QRCodeScale = scale;
                }
                catch (Exception)
                {
                    MessageBox.Show("无效的大小!");
                    return;
                }
                try
                {
                    int version = Convert.ToInt16(this.cboVersion.Text);
                    qrCodeEncoder.QRCodeVersion = version;
                }
                catch (Exception)
                {
                    MessageBox.Show("无效的版本!");
                }
                string errorCorrect = this.cboCorrectionLevel.Text;
                if (errorCorrect == "L")
                {
                    qrCodeEncoder.QRCodeErrorCorrect = QRCodeEncoder.ERROR_CORRECTION.L;
                }
                else if (errorCorrect == "M")
                {
                    qrCodeEncoder.QRCodeErrorCorrect = QRCodeEncoder.ERROR_CORRECTION.M;
                }
                else if (errorCorrect == "Q")
                {
                    qrCodeEncoder.QRCodeErrorCorrect = QRCodeEncoder.ERROR_CORRECTION.Q;
                }
                else if (errorCorrect == "H")
                {
                    qrCodeEncoder.QRCodeErrorCorrect = QRCodeEncoder.ERROR_CORRECTION.H;
                }
                string data = this.txtEncodeData.Text;
                Image image = qrCodeEncoder.Encode(data);
                this.picEncode.Image = image;
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            cboEncoding.SelectedIndex = 0;
            cboVersion.SelectedIndex = 0;
            cboCorrectionLevel.SelectedIndex = 0;
        }

        private void btn_Save_Click(object sender, EventArgs e)
        {
            if (this.picEncode.Image != null)
            {
                this.saveFileDialog1.Filter = "JPEG Image File (*.jpg)|*.jpg|GIF Image (*.gif)|*.gif|JPEG Image File (*.jpeg)|*.jpeg|Bitmaps (*.bmp)|*.bmp";
                saveFileDialog1.ShowDialog();
                string url = saveFileDialog1.FileName;
                this.picEncode.Image.Save(url);
            }
            else
            {
                MessageBox.Show("未加密数据!");
            }
        }

        private void btn_Open_Click(object sender, EventArgs e)
        {
            openFileDialog1.ShowDialog();
            string url = openFileDialog1.FileName;
            picDecode.Image = Image.FromFile(url); 
        }

        private void btn_Decode_Click(object sender, EventArgs e)
        {
            if (picDecode.Image != null)
            {
                try
                {
                    string decodedString = new QRCodeDecoder().decode(new QRCodeBitmapImage(new Bitmap(this.picDecode.Image)));
                    this.txtDecodedData.Text = decodedString;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            else
            {
                MessageBox.Show("未加载数据!");
            }
        }

    }
}
