using Emgu.CV;
using System;
using System.Windows.Forms;

namespace LoveVision
{
    public class CameraCapture : IDisposable
    {
        private VideoCapture _videoCapture;
        private HandlePhrases _handlePhrases = new HandlePhrases();

        private ListBox _listBox;

        public bool AutoDetect { get; set; }
        private bool _disposed = false;

        public CameraCapture(ListBox listBox, VideoCapture videoCapture)
        {
            _listBox = listBox;
            _videoCapture = videoCapture;
        }

        public void ProcessFrameEverySecond()
        {
            using (var frame = new Mat())
            {
                _videoCapture.Retrieve(frame, 0);

                if (AutoDetect)
                {
                    using (FaceDetection faceDetector = new FaceDetection())
                    {
                        var foundFace = faceDetector.DetectFace(frame);
                        if (foundFace)
                        {
                            _listBox.AddItemThreadSafe(_handlePhrases.GetSaying());
                        }
                        else
                        {
                            _listBox.AddItemThreadSafe("I didn't find you!!");
                        }
                    }
                }
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
                    _videoCapture.Dispose();
                    _videoCapture = null;
                    _handlePhrases = null;
                    _listBox = null;
                }

                if (!AutoDetect)
                {
                    _handlePhrases = null;
                }

                // Indicate that the instance has been disposed.
                _disposed = true;
            }
        }
    }
}