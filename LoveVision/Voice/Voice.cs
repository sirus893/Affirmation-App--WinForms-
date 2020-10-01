using NAudio.Wave;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Timers;
using System.Windows.Forms;

namespace LoveVision
{
    public class Voice : IDisposable
    {
        private bool _disposed = false;

        private WaveInEvent _waveSource;
        private WaveFileWriter _waveWriter;

        public event EventHandler RecordingFinished;

        private System.Timers.Timer _timer;

        private ListBox _listBox;

        private const int MaxTimeSpanInSeconds = 10; //1800;
        private const int MaxTimeSpanInMilliseconds = 10000; //1800000;

        private List<string> _recordedFiles;

        public bool Recording { get; set; }

        public Voice(ListBox listBox)
        {
            _listBox = listBox;
        }

        public void Record()
        {
            // We need to check the microphone is working
            // And we should only record x time for messages
            // If the user is going to record a new message it must overrite something.
            if (WaveIn.DeviceCount == 0)
            {
                _listBox.AddItemThreadSafe("Cant find microphone");
                return;
            }

            var timeRecorded = HowMuchTimeRecorded();

            if (timeRecorded.TotalSeconds <= MaxTimeSpanInSeconds - 10)
            {
                _listBox.AddItemThreadSafe($"{MaxTimeSpanInSeconds - timeRecorded.TotalSeconds} seconds left to record.");
                _listBox.AddItemThreadSafe("Say what you want, press but again to stop");

                _timer = new System.Timers.Timer(MaxTimeSpanInMilliseconds - timeRecorded.TotalMilliseconds);
                _timer.AutoReset = false;
                _timer.Elapsed += ForceStop;

                _waveSource = new WaveInEvent
                {
                    WaveFormat = new WaveFormat(44100, 1)
                };

                var fileName = Guid.NewGuid();
                string _tempFilename = Path.GetFullPath(Path.Combine(Directory.GetCurrentDirectory(), $@"..\..\Voice\SavedVoices\{fileName}.wav"));

                _waveSource.DataAvailable += DataAvailable;
                _waveSource.RecordingStopped += RecordingStopped;
                _waveWriter = new WaveFileWriter(_tempFilename, _waveSource.WaveFormat);

                _waveSource.StartRecording();

                _timer.Start();
            }
            else
            {
                _listBox.AddItemThreadSafe("Your out of space");
            }
        }

        public void Playback()
        {
            if (_recordedFiles == null || _recordedFiles.Count == 0)
            {
                _recordedFiles = new List<string>();
                _recordedFiles = GetAllRecordings();
            }

            // Play this first one
            var fileDirToPlayback = _recordedFiles[0];

            _recordedFiles.RemoveAt(0);

            var waveOut = new WaveOutEvent();
            WaveStream fileToPlayback = new WaveFileReader(fileDirToPlayback);

            waveOut.Init(fileToPlayback);
            waveOut.Play();
        }

        private TimeSpan HowMuchTimeRecorded()
        {
            var files = GetAllRecordings();
            TimeSpan time = new TimeSpan();
            foreach (var file in files)
            {
                if (Path.GetExtension(file) == ".wav")
                {
                    time += GetWavFileDuration(file);
                }
            }

            return time;
        }

        private static List<string> GetAllRecordings()
        {
            string directory = Path.GetFullPath(Path.Combine(Directory.GetCurrentDirectory(), @"..\..\Voice\SavedVoices"));

            return Directory.GetFiles(directory).ToList();
        }

        private static TimeSpan GetWavFileDuration(string fileName)
        {
            WaveFileReader wf = new WaveFileReader(fileName);
            return wf.TotalTime;
        }

        private void ForceStop(object sender, ElapsedEventArgs e)
        {
            _listBox.AddItemThreadSafe("You have run out of time.");
            //button.Text = "ffffff";
            StopRecording();
        }

        public void StopRecording()
        {
            /*Stop the timer*/
            _timer?.Stop();

            /*Destroy/Dispose of the timer to free memory*/
            _timer?.Dispose();

            /*Stop the audio recording*/
            if (_waveSource != null)
            {
                _waveSource.StopRecording();
            }
        }

        private void RecordingStopped(object sender, StoppedEventArgs e)
        {
            _waveSource.DataAvailable -= DataAvailable;
            _waveSource.RecordingStopped -= RecordingStopped;
            _waveSource?.Dispose();
            _waveWriter?.Dispose();

            /*Convert the recorded file to MP3*/
            //ConvertWaveToMp3(_tempFilename, _filename);

            /*Send notification that the recording is complete*/
            RecordingFinished?.Invoke(this, null);
        }

        private void DataAvailable(object sender, WaveInEventArgs e)
        {
            if (_waveWriter != null)
            {
                _waveWriter.Write(e.Buffer, 0, e.BytesRecorded);
                _waveWriter.Flush();
            }
        }

        public void Dispose()
        {
            // Dispose of unmanaged resources.
            Dispose(true);
            // Suppress finalization.
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing)
                {
                    // Clear all property values that maybe have been set
                    // when the class was instantiated
                }

                // Indicate that the instance has been disposed.
                _disposed = true;
            }
        }
    }
}