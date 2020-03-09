using System;
using System.IO;
using System.Net;
using System.Text;

namespace upload
{
    class Program
    {

        static void FTPUpload()
        {


            // Get the object used to communicate with the server.
            FtpWebRequest request = (FtpWebRequest)WebRequest.Create("ftp://www.contoso.com/test.htm");
            request.Method = WebRequestMethods.Ftp.UploadFile;

            // This example assumes the FTP site uses anonymous logon.
            request.Credentials = new NetworkCredential("anonymous", "janeDoe@contoso.com");

            // Copy the contents of the file to the request stream.
            byte[] fileContents;
            using (StreamReader sourceStream = new StreamReader("testfile.pdf"))
            {
                fileContents = Encoding.UTF8.GetBytes(sourceStream.ReadToEnd());
            }

            request.ContentLength = fileContents.Length;

            using (Stream requestStream = request.GetRequestStream())
            {
                requestStream.Write(fileContents, 0, fileContents.Length);
            }

            using (FtpWebResponse response = (FtpWebResponse)request.GetResponse())
            {
                Console.WriteLine($"Upload File Complete, status {response.StatusDescription}");
            }
        }

            static void CurrentDate()
            {
                DateTime localDate = DateTime.Now;
                DateTime utcDate = DateTime.UtcNow;

                Console.WriteLine("   Local date and time: {0}, {1:G}",
                          localDate.ToString("de-DE"));


            }


        
        static void Main(string[] args)
        {
            Console.WriteLine("Hello !");
            Console.WriteLine("Starting upload !");

            FTPUpload();
            CurrentDate();



        }
    }
}
