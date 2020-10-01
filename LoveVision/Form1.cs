using Emgu.CV;
using System;
using System.Threading;
using System.Windows.Forms;

namespace LoveVision
{
    public partial class Form1 : Form
    {
        private System.Threading.Timer _timer;
        private VideoCapture _videoCapture;
        private bool _captureInProgress;
        private bool _autoDetect;
        private int seconds = 5 * 1000;
        private CameraCapture _cameraCapture;
        private Voice _recordVoice;

        public Form1()
        {
            InitializeComponent();
            CvInvoke.UseOpenCL = false;

            listBox1.Items.Add("Program Loaded.");
        }

        private void Start_btn_Click(object sender, EventArgs e)
        {
            try
            {
                if (!_captureInProgress)
                {
                    listBox1.Items.Add("Started to capture image");

                    _videoCapture = new VideoCapture();
                    _cameraCapture = new CameraCapture(listBox1, _videoCapture);

                    _videoCapture.Start();
                    _timer = new System.Threading.Timer((eg) =>
                    {
                        _cameraCapture.ProcessFrameEverySecond();
                    }, null, 0, seconds);

                    _captureInProgress = !_captureInProgress;
                }
            }
            catch (NullReferenceException excpt)
            {
                MessageBox.Show(excpt.Message);
            }
        }

        private void Stop_btn_Click(object sender, EventArgs e)
        {
            try
            {
                if (_captureInProgress)
                {
                    _videoCapture.Stop();
                    _timer.Change(Timeout.Infinite, Timeout.Infinite);
                    listBox1.Items.Add("Stopped capturing image");

                    _videoCapture.Dispose();
                    _cameraCapture.Dispose();
                    _timer.Dispose();
                    _captureInProgress = !_captureInProgress;
                }
            }
            catch (NullReferenceException excpt)
            {
                MessageBox.Show(excpt.Message);
                _captureInProgress = !_captureInProgress;
            }
        }

        private void AutoDetect_btn_Click(object sender, EventArgs e)
        {
            if (_captureInProgress)
            {
                _autoDetect = !_autoDetect;
                if (_cameraCapture != null)
                {
                    _cameraCapture.AutoDetect = _autoDetect;
                }

                if (_autoDetect)
                {
                    listBox1.Items.Add("Auto detect On");
                }
                else
                {
                    listBox1.Items.Add("Auto detect Off");
                }
            }
        }

        private void record_btn_Click(object sender, EventArgs e)
        {
            // Forcefully turn off auto detect on CameraCapture
            if (_captureInProgress)
            {
                _cameraCapture.AutoDetect = false;
            }

            if (record_btn.Text == "Start Recording")
            {
                record_btn.Text = "Stop Recording";
                _recordVoice = new Voice(listBox1);
                _recordVoice.Record();
            }
            else
            {
                record_btn.Text = "Start Recording";
                _recordVoice.StopRecording();
                _recordVoice.Dispose();
            }
        }

        private bool buttonUp;
        private DateTime sw;
        private const int holdButtonDuration = 2;

        private void playback_btn_MouseDown(object sender, MouseEventArgs e)
        {
            buttonUp = false;
            sw = DateTime.Now;
            while (e.Button == MouseButtons.Left && e.Clicks == 1 && (buttonUp == false && (DateTime.Now - sw).TotalSeconds < holdButtonDuration))
                Application.DoEvents();
            if ((DateTime.Now - sw).TotalSeconds < holdButtonDuration)
                Test_ShortClick();
            else
                Test_LongClick();
        }

        private void playback_btn_MouseUp(object sender, MouseEventArgs e)
        {
            buttonUp = true;
        }

        private void Test_LongClick()
        {
            listBox1.Items.Add("long");
        }

        private void Test_ShortClick()
        {
            listBox1.Items.Add("short");
            _recordVoice = new Voice(listBox1);
            _recordVoice.Playback();
        }
    }
}