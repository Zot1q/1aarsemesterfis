using Renci.SshNet;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1AarsProjekt.ExternalConnections
/// <Author>
/// Thomas
/// </Author>
/// <summary>
/// This class is used to handle the traffic between the Linux server, and the computer. 
/// </summary>
{
    class ServerAccessLayer
    {
        public static void DownloadFiles()
        {
            string remoteDirectory = "/home/indbakke/";
            string localDirectory = Directory.GetCurrentDirectory() + @"\DownloadedCSVFiles\";
            Directory.CreateDirectory(localDirectory);

            using (var sftp = new SftpClient(@"10.152.120.37", "echo", "ec.12ho."))
            {
                sftp.Connect();
                var files = sftp.ListDirectory(remoteDirectory);

                foreach (var file in files)
                {
                    if (!file.Name.StartsWith("."))
                    {
                        using (Stream file1 = File.OpenWrite(localDirectory + file.Name))
                        {
                            sftp.DownloadFile(remoteDirectory + file.Name, file1);
                        }
                    }
                }
            }
        }

        public static void UploadFiles()
        {
            string remoteDirectory = "/home/echo/test/";
            string localDirectory = Directory.GetCurrentDirectory() + @"\CSVFilesToUpload\";
            Directory.CreateDirectory(localDirectory);


            using (var sftp = new SftpClient(@"10.152.120.37", "echo", "ec.12ho."))
            {
                sftp.Connect();
                //sftp.CreateDirectory(remoteDirectory);//Create folder if necessary else skip
                var files = Directory.GetFiles(localDirectory);

                foreach (var file in files)
                {
                    string remoteFileName = file;

                    using (Stream file1 = new FileStream(file, FileMode.Open))
                    {
                        remoteFileName = remoteFileName.Substring(remoteFileName.Length - 27);//Take out the filename

                        sftp.UploadFile(file1, remoteDirectory + remoteFileName, null);
                    }
                }
            }
        }
    }
}
