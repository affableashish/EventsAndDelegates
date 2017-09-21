using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventsAndDelegates
{
    class Program
    {
        static void Main(string[] args)
        {

            Video vid = new Video(){Title = "Game of Thrones"};
            VideoEncoder vidEnc = new VideoEncoder(); // publisher
            MailService ms = new MailService(); // subscriber
            vidEnc.VideoEncoded += ms.LaundaVideoEncoded;

            vidEnc.Encode(vid);

        }
    }

    class MailService
    {
        public void LaundaVideoEncoded(object source, VideoEventArgs e)
        {
            Console.WriteLine("Sending an E-mail" +" " + e.Vfd.Title);
        }
    }
}
