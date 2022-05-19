using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GameHocTuVung
{
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();
        }

        Dictionary<string, string> dic = null;
        Random rd = new Random();
        int n; //lưu vị trí random;
        int count; // lưu số lượng từ trong file text;
        int SoCauDung; //lưu số câu làm đúng trong lượt chơi;
        List<string> dsNN = null;
        List<string> dsTV = null;
        List<Button> btnNN = null;
        List<Button> btnTV = null;
        int NN;
        int TV;
        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void lblNgoaiNgu_Click(object sender, EventArgs e)
        {

        }

        private void btnPath_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog()==DialogResult.OK)
            {
                txtPath.Text = openFileDialog1.FileName;
            }
            dic = new FileFactory().ReadTextData(txtPath.Text);
            count = dic.Count();
            lblSoTuDung.Text = "Đọc được " + dic.Count + " từ vựng từ file text.";
            ChoiGameNhapNghia();
        }

        private void ChoiGameNhapNghia()
        {
            if(dic.Count==0)
            {
                lblThongBao.Text = "Bạn đã chiến thắng!";
                lblThongBao.BackColor = Color.LightGreen;
            }
            else
            {
                n = rd.Next(dic.Count);
                lblNgoaiNgu.Text = dic.ElementAt(n).Key;
                txtNghiaTiengViet.Focus();
            }
        }

        private void btnChoiGameNhapNghia_Click(object sender, EventArgs e)
        {
        }

        private void btnXacNhan_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtNghiaTiengViet.Text == "")
                {
                    return;
                }
                if (txtNghiaTiengViet.Text == dic.ElementAt(n).Value)
                {
                    lblThongBao.Text = dic.ElementAt(n).Key + " - " + dic.ElementAt(n).Value + " là chính xác.";
                    dic.Remove(dic.ElementAt(n).Key);
                    lblSoTuDung.Text = (count - dic.Count) + "/" + count;
                    txtNghiaTiengViet.Text = "";
                    ChoiGameNhapNghia();
                }
                else
                {
                    lblThongBao.Text = "Đáp án bạn nhập chưa chính xác. Hãy thử lại.";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }          
        }

        private void btnChoiLai_Click(object sender, EventArgs e)
        {
            dic.Clear();
            dic = new FileFactory().ReadTextData(txtPath.Text);
            count = dic.Count();
            lblSoTuDung.Text = "Đọc được " + dic.Count + " từ vựng từ file text.";
            lblThongBao.Text = "...";
            ChoiGameNhapNghia();
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            this.KeyPreview = true;
            this.KeyDown += Form1_KeyDown;
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnXacNhan.PerformClick();
            }
        }

        private void btnOpen_Click(object sender, EventArgs e)
        {           
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                txtPath2.Text = openFileDialog1.FileName;
            }
            dic = new FileFactory().ReadTextData(txtPath2.Text);
            count = dic.Count();
            lblSoCauDungNT.Text = "Đọc được " + dic.Count + " từ vựng từ file text.";
            if (dic.Count>0) ChoiGameNoiTu();
        }

        private void ChoiGameNoiTu()
        {
            HienThiLenButtonNgoaiNgu();
            HienThiLenButtonTiengViet();
        }

        private void HienThiLenButtonTiengViet()
        {
            flpTiengViet.Controls.Clear();
            dsTV = dic.Values.ToList();
            while(dsTV.Count>5)
            {
                dsTV.RemoveAt(dsTV.Count - 1);
            }
            btnTV = new List<Button>();
            for(int i =0; i<5;i++)
            {
                if (dsTV.Count == 0) break;
                int m = rd.Next(dsTV.Count);
                Button btn2 = new Button();
                btn2.Width = 250;
                btn2.Height = 70;
                btn2.Text = dsTV[m];
                btn2.Tag = i + "";
                flpTiengViet.Controls.Add(btn2);
                btnTV.Add(btn2);
                btn2.Click += Btn2_Click;
                dsTV.RemoveAt(m);
            }
        }

        private void Btn2_Click(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            btnDapAn.Text = btnDapAn.Text + " - " +  btn.Text;
            string tag = btn.Tag as string;
            TV = int.Parse(tag);
            KiemTraDapAn();
        }

        private void HienThiLenButtonNgoaiNgu()
        {
            flpNgoaiNgu.Controls.Clear();
            dsNN = dic.Keys.ToList();
            while(dsNN.Count>5)
            {
                dsNN.RemoveAt(dsNN.Count - 1);
            }
            btnNN = new List<Button>();
            for(int i=0; i<5;i++)
            {
                if (dsNN.Count == 0) break;
                int m = rd.Next(dsNN.Count);
                Button btn = new Button();
                btn.Width = 250;
                btn.Height = 70;
                btn.Text = dsNN[m];
                btn.Tag = i + "";
                flpNgoaiNgu.Controls.Add(btn);
                btnNN.Add(btn);
                btn.Click += Btn_Click;
                dsNN.RemoveAt(m);
            }
        }

        private void Btn_Click(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            string tag = btn.Tag as string;
            NN = int.Parse(tag);
            btnDapAn.Text = btn.Text;
        }

        private void btnNN1_Click(object sender, EventArgs e)
        {
        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void lblSoCauDungNT_Click(object sender, EventArgs e)
        {

        }

        private void btnNN2_Click(object sender, EventArgs e)
        {

        }

        private void btnNN3_Click(object sender, EventArgs e)
        {
        }

        private void splitContainer3_Panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnNN4_Click(object sender, EventArgs e)
        {
        }

        private void btnNN5_Click(object sender, EventArgs e)
        {
        }

        private void btnTV1_Click(object sender, EventArgs e)
        {
        }

        private void KiemTraDapAn()
        {
            string[] DapAn = btnDapAn.Text.Split('-');
            if (dic[DapAn[0].Trim()] == DapAn[1].Trim())
            {
                SoCauDung++;
                if (SoCauDung > 0 && SoCauDung % 5 == 0)
                {
                    for (int i =0; i<5;i++)
                    {
                        dic.Remove(dic.ElementAt(0).Key);
                    }
                    HienThiLenButtonNgoaiNgu();
                    HienThiLenButtonTiengViet();
                    return;
                }
                btnNN[NN].Text = "";
                btnNN[NN].BackColor = Color.WhiteSmoke;
                btnTV[TV].Text = "";
                btnTV[TV].BackColor = Color.WhiteSmoke;
                
                if(SoCauDung==count)
                {
                    lblSoCauDungNT.Text = "Bạn đã chiến thắng!";
                    lblSoCauDungNT.BackColor = Color.LightGreen;
                    flpNgoaiNgu.Controls.Clear();
                    flpTiengViet.Controls.Clear();
                    return;
                }
                lblSoCauDungNT.Text = SoCauDung + "/" + count;             
            }
        }

        private void btnTV2_Click(object sender, EventArgs e)
        {

        }

        private void btnTV3_Click(object sender, EventArgs e)
        {

        }

        private void btnTV4_Click(object sender, EventArgs e)
        {

        }

        private void btnTV5_Click(object sender, EventArgs e)
        {

        }

        private void lblDapAn_Click(object sender, EventArgs e)
        {
        }

        private void btnDapAn_Click(object sender, EventArgs e)
        {
            btnDapAn.Text = "";
        }

        private void btnChoiLaiNN_Click(object sender, EventArgs e)
        {
            dic = new FileFactory().ReadTextData(txtPath2.Text);
            count = dic.Count();
            lblSoCauDungNT.Text = "Đọc được " + dic.Count + " từ vựng từ file text.";
            if (dic.Count > 0) ChoiGameNoiTu();
        }
    }
}
