using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AppViewYoutube
{
    public partial class FrmPrincipal : Form
    {
        public FrmPrincipal()
        {
            InitializeComponent();
        }

        private void FrmPrincipal_Load(object sender, EventArgs e)
        {
            lvlVideo.View = View.Details;
            lvlVideo.FullRowSelect = true;
            lvlVideo.GridLines = true;

            lvlVideo.Columns.Add("Vídeos", 400, HorizontalAlignment.Left);
            lvlVideo.Columns.Add("Horário", 200, HorizontalAlignment.Right);

            txtUrl.Select();
        }

        private void btnCarregar_Click(object sender, EventArgs e)
        {
            if (txtUrl.Text.Trim().Equals(string.Empty))
            {
                MessageBox.Show("Você deve informar a URL do vídeo!", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            ListViewItem lvi = new ListViewItem(txtUrl.Text.Trim());
            lvi.SubItems.Add(DateTime.Now.ToString("dd/MM/yyyy 'às' HH:mm:ss", new CultureInfo("pt-BR")));
            lvlVideo.Items.Add(lvi);

            string html = "<html><head>";
            html += "<meta content='IE=Edge' http-equiv='X-UA-Compatible'/>";
            html += "<body><center><iframe id='video' src='https://www.youtube.com/embed/{0}?autoplay={1}' width='{2}' height='{3}' frameborder='0' allowfullscreen='true'></iframe></center>";
            html += "</body></html>";

            wbVideo.DocumentText = string.Format(html, txtUrl.Text.Trim().Split('=')[1],chkAutoPlay.Checked ? "1" : "0",wbVideo.Width - 30, wbVideo.Height - 30);
            txtUrl.Text = string.Empty;
            chkAutoPlay.Checked = false;
        }
    }
}
