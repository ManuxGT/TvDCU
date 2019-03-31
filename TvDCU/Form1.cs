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
        public string btnCanal; //variable para los botones
        //Registro del canal anterior registrado
        public string canalAnteriorNombre; 
        public string canalAnteriorNum;
        public string canalAnteriorURL;


        public Form1()
        {
            InitializeComponent();
            InicializarCanales();
    
        }

       
        //Cambia el canal hacia atras
        private void pictureBox1_Click(object sender, EventArgs e)
        {
            //almacena el canal anterior 
            canalAnteriorNum = NumCanal.Text;
            canalAnteriorNombre = NombreCanal.Text;
            canalAnteriorURL = Player.URL;
            /*if (state)
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
            }*/
            if (state)
            {
                if (Canal + 1 != CanalesURL.Count)
                {
                    Canal--;
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
            Canales.Add("ARAGON TV");
            CanalesURL.Add("http://aragontv.stream.flumotion.com/aragontv/hls-live/main.m3u8");
            Canales.Add("TELEMEDELLIN");
            CanalesURL.Add("http://level3itvo.cdnar.net/itvmedia/14/1/channel_000.m3u8");
            Canales.Add("BLOOMBERG HD");
            CanalesURL.Add("https://bblive-liveproduseast.hs.llnwd.net/btv/desktop/us_live.m3u8");
            Canales.Add("Cartoon Network");
            CanalesURL.Add("http://161.0.157.9/PLTV/88888888/224/3221226843/index.m3u8");
            Canales.Add("History Lab");
            CanalesURL.Add("http://wma10.fluidstream.net/HistoryLab/livestream/playlist.m3u8");
        }

        //boton de encender
        private void pictureBox5_Click(object sender, EventArgs e)
        {
            if (state)
            {
                state = false;
                Player.URL = "";
                NumCanal.Text = "";
                NombreCanal.Text = "";
            }
            else
            {
                state = true;
                Player.URL =CanalesURL[Canal];
                Player.Ctlcontrols.play();
                NumCanal.Text = "Canal " + Canal;
                NombreCanal.Text = Canales[Canal];


                canalAnteriorNum = NumCanal.Text;
                canalAnteriorNombre = NombreCanal.Text;
                canalAnteriorURL = Player.URL;
            }
        }
        //Cambia el canal hacia adelante
        private void pictureBox8_Click(object sender, EventArgs e)
        {
            canalAnteriorNum = NumCanal.Text;
            canalAnteriorNombre = NombreCanal.Text;
            canalAnteriorURL = Player.URL;
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


        /*
        Estos son los botones los cuales nos permiten cambiar de canal
        Cada uno tiene un string que corresponde a su numero y luego se presionara 
        un boton "GO" para ver si ese canal existe entre los disponibles 
        */

        private void pictureBox9_Click(object sender, EventArgs e)
        {
            if (state)
            {
                btnCanal += "0";
                NumCanal.Text = "Canal " + btnCanal;
                verificador(btnCanal);
            }

        }

        private void pictureBox10_Click(object sender, EventArgs e)
        {
            if (state)
            {
                btnCanal += "1";
                NumCanal.Text = "Canal " + btnCanal;
                verificador(btnCanal);
            }

        }

        private void pictureBox11_Click(object sender, EventArgs e)
        {
            if (state)
            {
                btnCanal += "2";
                NumCanal.Text = "Canal " + btnCanal;
                verificador(btnCanal);
            }
        }

        private void pictureBox12_Click(object sender, EventArgs e)
        {
            if (state)
            {
                btnCanal += "3";
                NumCanal.Text = "Canal " + btnCanal;
                verificador(btnCanal);
            }
        }


        private void pictureBox13_Click_1(object sender, EventArgs e)
        {
            if (state)
            {
                btnCanal += "4";
                NumCanal.Text = "Canal " + btnCanal;
                verificador(btnCanal);
            }
        }

        private void pictureBox14_Click_1(object sender, EventArgs e)
        {
            if (state)
            {
                btnCanal += "5";
                NumCanal.Text = "Canal " + btnCanal;
                verificador(btnCanal);
            }
        }

        private void pictureBox15_Click_1(object sender, EventArgs e)
        {
            if (state)
            {
                btnCanal += "6";
                NumCanal.Text = "Canal " + btnCanal;
                verificador(btnCanal);
            }
        }

        private void pictureBox16_Click_1(object sender, EventArgs e)
        {
            if (state)
            {
                btnCanal += "7";
                NumCanal.Text = "Canal " + btnCanal;
                verificador(btnCanal);
            }
        }

        private void pictureBox19_Click(object sender, EventArgs e)
        {
            if (state)
            {
                btnCanal += "8";
                NumCanal.Text = "Canal " + btnCanal;
                verificador(btnCanal);
            }
        }
        private void pictureBox20_Click(object sender, EventArgs e)
        {
            if (state)
            {
                btnCanal += "9";
                NumCanal.Text = "Canal " + btnCanal;
                verificador(btnCanal);
            }
        }


        //verifica que el canal ingresado no tenga mas de 3 digitos y si los tiene activa la clase buscar canal
        public void verificador(string i)
        {
            if (i.Length > 2)
            {
                BuscarCanal();
            }
        }

        public void BuscarCanal()
        {
            //canalAnteriorNum = NumCanal.Text;
            canalAnteriorNombre = NombreCanal.Text;
            canalAnteriorURL = Player.URL;
            int canal = Convert.ToInt32(btnCanal);
            bool existe = false;
            for (int i = 0; i < CanalesURL.Count; i++)
            {
                //si existe algun canal en la lista que corresponda con el canal registrado
                if (i == canal)
                {
                    existe = true;
                }
            }
            if (existe)
            {
                Player.URL = CanalesURL[canal];
                NumCanal.Text = "Canal " + canal;
                NombreCanal.Text = Canales[canal];
            }
            else
            {
                NumCanal.Text = "Canal " + canal;
                NombreCanal.Text = "No disponible";
            }
            btnCanal = "";
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        //boton go
        private void pictureBox17_Click_1(object sender, EventArgs e)
        {
            BuscarCanal();
        }

        //boton para volver atras
        private void pictureBox18_Click(object sender, EventArgs e)
        {
            Canal -= 1;            
            NumCanal.Text = canalAnteriorNum;
            NombreCanal.Text = canalAnteriorNombre;
            Player.URL = canalAnteriorURL;

        }
    }
}
