using Emgu.CV;
using System;
using System.Drawing;
using System.Linq;

namespace LoveVision
{
    public class FaceDetection : IDisposable
    {
        private bool _disposed = false;
        private CascadeClassifier _faceDetector;

        public FaceDetection()
        {
            // Load cascade files
            _faceDetector = new CascadeClassifier("FaceDetection/haarcascade_frontalface_default.xml");
        }

        public bool DetectFace(Mat frame)
        {
            using (frame)
            {
                return _faceDetector.DetectMultiScale(frame, 1.1, 10, new Size(20, 20), Size.Empty).Length > 0;
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
                    _faceDetector.Dispose();
                }

                // Indicate that the instance has been disposed.
                _disposed = true;
            }
        }
    }
}