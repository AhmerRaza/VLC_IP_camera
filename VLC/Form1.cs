using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VLC
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void buttonLoad_Click(object sender, EventArgs e)
        {
           // OpenFileDialog diag1 = new OpenFileDialog();
          //  diag1.Filter = "(*.vlc) |*.vlc";
           // if (diag1.ShowDialog() == DialogResult.OK)
           // {



            //•	For H264 Stream 1 rtsp://<IP_Address>:8557/PSIA/Streaming/channels/2?videoCodecType=H.264
            //•	For H264 Stream2  rtsp://<IP_Address>:8556/PSIA/Streaming/channels/2?videoCodecType=H.264
            //•	For MPEG4 Stream1 rtsp://<IP_Address>:8553/PSIA/Streaming/channels/1?videoCodecType=MPEG4
            //•	For MPEG4 Stream2 rtsp://<IP_Address>:8554/PSIA/Streaming/channels/1?videoCodecType=MPEG4
            //•	For JPEG Stream rtsp://<IP_Address>:8555/PSIA/Streaming/channels/0?videoCodecType=MJPEG

            axVLCPlugin21.playlist.items.clear();

            string rtspString = string.Format(@"rtsp://{0}:{1}/PSIA/Streaming/channels/{2}?videoCodecType={3}", 
                                                textBoxIpAddress.Text, 
                                                textBoxPort.Text,
                                                textBoxChannels.Text,
                                                textBoxCodec.Text);
            axVLCPlugin21.playlist.add(rtspString, "aa", null);
            
            //axVLCPlugin21.playlist.add(@"rtsp://10.1.0.126:8557/PSIA/Streaming/channels/2?videoCodecType=H.264","aa",null); //   .add(diag1.FileName, diag1.SafeFileName, null);
               
           // }
        }

        private void buttonStart_Click(object sender, EventArgs e)
        {
            try
            {
                axVLCPlugin21.playlist.play();
                axVLCPlugin21.BringToFront();
               
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }

        }

        private void buttonStop_Click(object sender, EventArgs e)
        {
            axVLCPlugin21.playlist.stop();
        }

        private void buttonPause_Click(object sender, EventArgs e)
        {
            axVLCPlugin21.playlist.togglePause();
            
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.SelectedIndex == 0)
            {
                textBoxPort.Text = "8557";
                textBoxChannels.Text = "2";
                textBoxCodec.Text = "H.264";
            }
            else if(comboBox1.SelectedIndex == 1)
            {
                textBoxPort.Text = "8556";
                textBoxChannels.Text = "2";
                textBoxCodec.Text = "H.264";
            }
            else if (comboBox1.SelectedIndex == 2)
            {
                textBoxPort.Text = "8553";
                textBoxChannels.Text = "1";
                textBoxCodec.Text = "MPEG4";
            }
            else if (comboBox1.SelectedIndex == 3)
            {
                textBoxPort.Text = "8554";
                textBoxChannels.Text = "1";
                textBoxCodec.Text = "MPEG4";
            }
            else if (comboBox1.SelectedIndex == 4)
            {
                textBoxPort.Text = "8555";
                textBoxChannels.Text = "0";
                textBoxCodec.Text = "MJPEG";
            }

        }


    }
}
