using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TvDCU
{
    public partial class Form1 : Form
    {
        public List<string> CanalesURL = new List<string>();
        public List<string> Canales = new List<string>();
        public int Canal = 0;
        public bool state = false;
        public Form1()
        {
            InitializeComponent();
            InicializarCanales();
    
        }

       

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            if (state)
            {
                if (Canal != 0)
                {
                    Canal--;
                    Player.URL = CanalesURL[Canal];
                }
                else if (Canal == 0)
                {
                    Canal = CanalesURL.Count - 1;
                    Player.URL = CanalesURL[Canal];
                    NumCanal.Text = "Canal " + Canal;
                    NombreCanal.Text = Canales[Canal];
                }
            }
            
        }

        public void InicializarCanales()
        {
            Canales.Add("Real Madrid TV");
            CanalesURL.Add("http://rmtv24hweblive-lh.akamaihd.net/i/rmtv24hwebes_1@300661/master.m3u8");
            Canales.Add("Paramount Channel");
            CanalesURL.Add("http://paramount.live.flumotion.com/live/playlist.m3u8");
            Canales.Add("TeleRD");
            CanalesURL.Add(" http://k4.usastreams.com/Telesistemas/Telesistemas/playlist.m3u8");
            Canales.Add("Unknown");
            CanalesURL.Add("http://play.streaminghd.cl/luis251/luis251/playlist.m3u8");
            Canales.Add("Color visión");
            CanalesURL.Add("http://ss2.domint.net:2138/cvh_str/colorvisionhd/playlist.m3u8");
            Canales.Add("Fox Cinema");
            CanalesURL.Add("http://161.0.157.7/PLTV/88888888/224/3221226793/03.m3u8");
            Canales.Add("Teleformula");
            CanalesURL.Add("http://wms30.tecnoxia.com/radiof/abr_radioftele/playlist.m3u8");
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            if (state)
            {
                state = false;
                Player.URL = "";
            }
            else
            {
                state = true;
                Player.URL =CanalesURL[Canal];
                Player.Ctlcontrols.play();
                NumCanal.Text = "Canal " + Canal;
                NombreCanal.Text = Canales[Canal];
            }
        }

        private void pictureBox8_Click(object sender, EventArgs e)
        {
            if (state)
            {
                if (Canal + 1 != CanalesURL.Count)
                {
                    Canal++;
                    Player.URL = CanalesURL[Canal];
                    NumCanal.Text = "Canal " + Canal;
                    NombreCanal.Text = Canales[Canal];
                }
                else if (Canal + 1 == CanalesURL.Count)
                {
                    Canal = 0;
                    Player.URL = CanalesURL[Canal];
                    NumCanal.Text = "Canal " + Canal;
                    NombreCanal.Text = Canales[Canal];
                }
            }
            
        }

        private void ValorCambiado(object sender, EventArgs e)
        {
    
            Player.settings.volume = RangeBar.Value;
        }

        private void Scrolleado(object sender, EventArgs e)
        {
            
            Player.settings.volume = RangeBar.Value;
        }

        private void pictureBox7_Click(object sender, EventArgs e)
        {
            if (state)
            {
                RangeBar.Value = 0;
            }
            
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            if (state)
            {
                if (RangeBar.Value + 5 <= 100)
                {
                    RangeBar.Value += 5;
                }
            }
           
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            if(state){
                if (RangeBar.Value - 5 >= 0)
                {
                    RangeBar.Value -= 5;
                }
            }
            
        }
    }
}
