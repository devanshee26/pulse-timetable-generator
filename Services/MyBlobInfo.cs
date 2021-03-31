using System.IO;

namespace Pulse.Services
{
    public class MyBlobInfo
    {
        public string contentType;
        public Stream content;
        public MyBlobInfo(Stream content, string contentType)
        {
            this.content = content;
            this.contentType = contentType;          
        }
    }
}