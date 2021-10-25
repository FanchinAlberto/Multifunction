using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using LibVLCSharp.Shared;
using System.Media;


namespace Multifunction
{
    public partial class Multifunction : Form
    {

        public LibVLC _libVLC;
        public MediaPlayer _mp;
        public Media media;


        public LibVLC _libVLC2;
        public MediaPlayer _mp2;
        public Media media2;

        public LibVLC _libVLC3;
        public MediaPlayer _mp3;
        public Media media3;


        public bool isFullscreen = false;
        public bool isPlaying = false;
        public Size oldVideoSize;
        public Size oldFormSize;
        public Point oldVideoLocation;
        public OpenFileDialog ofd = new OpenFileDialog();
        public OpenFileDialog ofd2 = new OpenFileDialog();


        public Multifunction()
        {
            InitializeComponent();
            Core.Initialize();
            this.KeyPreview = true;
            this.KeyDown += new KeyEventHandler(ShortcutEvent);
            oldVideoSize = videoView1.Size;
            oldFormSize = this.Size;
            oldVideoLocation = videoView1.Location;
            _libVLC = new LibVLC();
            _mp = new MediaPlayer(_libVLC);
            videoView1.MediaPlayer = _mp;
            _mp.Volume = 25;
            trackBar1.Value = _mp.Volume;
            lblVolume.Text = Convert.ToString(trackBar1.Value) + "%";

            _libVLC2 = new LibVLC();
            _mp2 = new MediaPlayer(_libVLC2);
            videoView2.MediaPlayer = _mp2;
            _mp2.Volume = 0;

            _libVLC3 = new LibVLC();
            _mp3 = new MediaPlayer(_libVLC3);
            videoView3.MediaPlayer = _mp3;
            _mp3.Volume = 25;
            trackBar2.Value = _mp3.Volume;
            lblVolume2.Text = Convert.ToString(trackBar2.Value) + "%";

        }

        public void ShortcutEvent(object sender, KeyEventArgs e)
        {

           
             
            

            if (e.KeyCode == Keys.Escape && isFullscreen) // implemento il tasto esc per uscire dal fullscreen
            {
                this.FormBorderStyle = FormBorderStyle.Sizable; 
                this.WindowState = FormWindowState.Normal; // torno alla dimensione precedente
                this.Size = oldFormSize;
                
                videoView1.Size = oldVideoSize; 
                videoView1.Location = oldVideoLocation; 
                isFullscreen = false;
            }

            if (isPlaying) 
            {
                if (e.KeyCode == Keys.Space) //Implemento la possibilita di stoppare e riprendere la riproduzione con la spacebar
                {
                    if (_mp.State == VLCState.Playing) // se sta riproducendo
                    {
                        _mp.Pause(); // mette in pausa
                    }
                    else // se non sta riproducendo
                    {
                        _mp.Play(); // riparte
                    }
                }

                if (e.KeyCode == Keys.J) // implemnto il time-skip con i tasti J e L, lo skip risulta l'1% del video (skip avanti)
                {
                    _mp.Position -= 0.01f;
                }
                if (e.KeyCode == Keys.L) // (skip indietro)
                {
                    _mp.Position += 0.01f;
                }

                

            }

            if (_mp3.IsPlaying)
            {
                if (e.KeyCode == Keys.Space) //Implemento la possibilita di stoppare e riprendere la riproduzione con la spacebar
                {
                    if (_mp3.State == VLCState.Playing) // se sta riproducendo
                    {
                        _mp3.Pause(); // mette in pausa
                    }
                    else // se non sta riproducendo
                    {
                        _mp3.Play(); // riparte
                    }
                }

                if (e.KeyCode == Keys.J) // implemnto il time-skip con i tasti J e L, lo skip risulta l'1% del video (skip avanti)
                {
                    _mp3.Position -= 0.01f;
                }
                if (e.KeyCode == Keys.L) // (skip indietro)
                {
                    _mp3.Position += 0.01f;
                }



            }



        }
        private void Multifunction_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            tabControl.SelectedIndex = 2;
        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            tabControl.SelectedIndex = 1;
        }

        private void btnChrono_Click(object sender, EventArgs e)
        {
            tabControl.SelectedIndex = 3;
        }

        private void btnPlayMusic_Click(object sender, EventArgs e)
        {
             // apro un openfiledialog in modo che l'utente possa scegliere il file da riprodurre
            
            
                
            
            ofd.ShowDialog();


        }

        private void tabMusic_Click(object sender, EventArgs e)
        {

        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            panelBack1.BackColor = Color.FromArgb(238, 248, 244);
            pnlMenuLaterale.BackColor = Color.FromArgb(238, 248, 244);
            pnlBack2.BackColor = Color.FromArgb(238, 248, 244);
            pnlBack4.BackColor = Color.FromArgb(238, 248, 244);
            pnlBack5.BackColor = Color.FromArgb(238, 248, 244);
            tabHome.BackColor = Color.FromArgb(203,203,203);
            tabMusic.BackColor = Color.FromArgb(203, 203, 203);
            tabVideo.BackColor = Color.FromArgb(203, 203, 203);
            tabChrono.BackColor = Color.FromArgb(203, 203, 203);
            button1.BackColor = Color.FromArgb(203, 203, 203);
            button2.BackColor = Color.FromArgb(203, 203, 203);
            btnChrono.BackColor = Color.FromArgb(203, 203, 203);
            btnHistory.BackColor = Color.FromArgb(203, 203, 203);
            btnTheme.BackColor = Color.FromArgb(203, 203, 203);
            btnNero.BackColor = Color.FromArgb(203, 203, 203);
            btnBianco.BackColor = Color.FromArgb(203, 203, 203);
            btnRosa.BackColor = Color.FromArgb(203, 203, 203);
            lblProject.ForeColor = Color.FromArgb(41, 181, 158);
            lblTitle1.ForeColor = Color.FromArgb(41, 181, 158);
            lblTitle2.ForeColor = Color.FromArgb(41, 181, 158);
            ptbLogo.Image = Properties.Resources.logo3;
            pnlLogo.BackgroundImage = Properties.Resources.logo3;
            this.BackColor = Color.FromArgb(238, 248, 244);
            tabControl.BackColor = Color.FromArgb(238, 248, 244);
        }

        private void btnTheme_Click(object sender, EventArgs e)
        {
            btnNero.Visible = true;
            btnBianco.Visible = true;
            btnRosa.Visible = true;
        }

        private void btnRosa_Click(object sender, EventArgs e)
        {
            panelBack1.BackColor = Color.FromArgb(59, 2, 31);
            pnlMenuLaterale.BackColor = Color.FromArgb(59,2,31);
            pnlBack2.BackColor = Color.FromArgb(59,2,31);
            pnlBack4.BackColor = Color.FromArgb(59,2,31);
            pnlBack5.BackColor = Color.FromArgb(59,2,31);
            tabHome.BackColor = Color.FromArgb(158, 73, 116);
            tabMusic.BackColor = Color.FromArgb( 158,73,116);
            tabVideo.BackColor = Color.FromArgb( 158,73,116);
            tabChrono.BackColor = Color.FromArgb( 158,73,116);
            button1.BackColor = Color.FromArgb( 158,73,116);
            button2.BackColor = Color.FromArgb( 158,73,116);
            btnChrono.BackColor = Color.FromArgb( 158,73,116);
            btnHistory.BackColor = Color.FromArgb( 158,73,116);
            btnTheme.BackColor = Color.FromArgb( 158,73,116);
            btnNero.BackColor = Color.FromArgb( 158,73,116);
            btnBianco.BackColor = Color.FromArgb( 158,73,116);
            btnRosa.BackColor = Color.FromArgb( 158,73,116);
            lblProject.ForeColor = Color.FromArgb(0,0,0);
            lblTitle1.ForeColor = Color.FromArgb(0,0,0);
            lblTitle2.ForeColor = Color.FromArgb(0,0,0);
            ptbLogo.Image = Properties.Resources.logo2;
            pnlLogo.BackgroundImage = Properties.Resources.logo2;
            this.BackColor = Color.FromArgb(59,2,31);
            tabControl.BackColor = Color.FromArgb(59,2,31);
        }

        private void btnNero_Click(object sender, EventArgs e)
        {
            panelBack1.BackColor = Color.FromArgb(11, 7, 17);
            pnlMenuLaterale.BackColor = Color.FromArgb(11,7,17);
            pnlBack2.BackColor = Color.FromArgb(11,7,17);
            pnlBack4.BackColor = Color.FromArgb(11,7,17);
            pnlBack5.BackColor = Color.FromArgb(11,7,17);
            tabHome.BackColor = Color.FromArgb(52, 52, 52);
            tabMusic.BackColor = Color.FromArgb(52,52,52);
            tabVideo.BackColor = Color.FromArgb(52,52,52);
            tabChrono.BackColor = Color.FromArgb(52,52,52);
            button1.BackColor = Color.FromArgb(52,52,52);
            button2.BackColor = Color.FromArgb(52,52,52);
            btnChrono.BackColor = Color.FromArgb(52,52,52);
            btnHistory.BackColor = Color.FromArgb(52,52,52);
            btnTheme.BackColor = Color.FromArgb(52,52,52);
            btnNero.BackColor = Color.FromArgb(52,52,52);
            btnBianco.BackColor = Color.FromArgb(52,52,52);
            btnRosa.BackColor = Color.FromArgb(52,52,52);
            lblProject.ForeColor = Color.FromArgb(214, 74, 97);
            lblTitle1.ForeColor = Color.FromArgb(214, 74, 97);
            lblTitle2.ForeColor = Color.FromArgb(214, 74, 97);
            ptbLogo.Image = Properties.Resources.logo;
            pnlLogo.BackgroundImage = Properties.Resources.logo;
            this.BackColor = Color.FromArgb(11,7,17);
            tabControl.BackColor = Color.FromArgb(11,7,17);
        }

        private void menuStrip1_ItemClicked_1(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void btnScegliFile_Click(object sender, ToolStripItemClickedEventArgs e)
        {
           
        }

        public void PlayFile(string file)
        {
            _mp.Play(new Media(_libVLC, file));
            isPlaying = true;
        }
        public void PlayFile2(string file)
        {
            _mp3.Play(new Media(_libVLC3, file));
            
        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            _mp.Volume = trackBar1.Value;
            lblVolume.Text = Convert.ToString(trackBar1.Value) + "%";
        }

        private void btnPsPl_Click(object sender, EventArgs e)
        {
            if (_mp.State == VLCState.Playing) // if is playing
            {
                _mp.Pause(); // pause
                this.timer1.Stop();
            }
            else // it's not playing?
            {
                _mp.Play(); // play
                this.timer1.Start();
            }

            
        }

        private void btnFullScreen_Click(object sender, EventArgs e)
        {
            videoView1.Size = this.Size; //setto il video alla stessa size del form
            videoView1.Location = new Point(0, 0); // rimuovo l'offset del video
            this.FormBorderStyle = FormBorderStyle.None; // rimuovo i bordi
            this.WindowState = FormWindowState.Maximized; // metto il form in fullscreen
            isFullscreen = true;
        }

        private void btnBck_Click(object sender, EventArgs e)
        {
            _mp.Position -= 0.05f;
        }

        private void btnFwd_Click(object sender, EventArgs e)
        {
            _mp.Position += 0.05f;
            
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if(progressBar1.Value > 100)
            {
                progressBar1.Value += 1;

            }
            else
            {
                timer1.Stop();
            }
        }

        private void btnRiproduci_Click(object sender, EventArgs e)
        {
            PlayFile(ofd.FileName);
            timer1.Start();
            progressBar1.Maximum = (int)_mp.Length / 1000;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            ofd2.ShowDialog();
        }

        private void btnRiproduci2_Click(object sender, EventArgs e)
        {
            PlayFile2(ofd2.FileName);

        }

        private void btnPsPl2_Click(object sender, EventArgs e)
        {
            if (_mp3.State == VLCState.Playing) // if is playing
            {
                _mp3.Pause(); // pause
                this.timer1.Stop();
            }
            else // it's not playing?
            {
                _mp3.Play(); // play
                this.timer1.Start();
            }
        }

        private void trackBar2_Scroll(object sender, EventArgs e)
        {
            _mp3.Volume = trackBar2.Value;
            lblVolume2.Text = Convert.ToString(trackBar2.Value) + "%";
        }
    }
}
