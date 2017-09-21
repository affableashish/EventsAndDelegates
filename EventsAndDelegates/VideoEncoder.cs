using System;
using System.Threading;

namespace EventsAndDelegates
{
    public class VideoEventArgs : EventArgs
    {
        public Video Vfd { get; set; }
    }
    public class VideoEncoder
    {
        public delegate void VideoEncodedEventHandler(object source, VideoEventArgs e);

        public event VideoEncodedEventHandler VideoEncoded; 
        



        public void Encode(Video vid)
        {
            Console.WriteLine("Video is Encoding");
            Thread.Sleep(300);
            OnVideoEncoded(vid);
            
        }


        protected virtual void OnVideoEncoded(Video vid)
        {
            if (VideoEncoded != null)
                VideoEncoded(this, new VideoEventArgs(){Vfd = vid});
        }
    }
}