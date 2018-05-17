using Renci.SshNet;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1AarsProjekt.Model.ExternalConnections
{
    class ServerAccessLayer
    {
        public static void DownloadFiles()
        {
            string remoteDirectory = "/home/indbakke/";
            string localDirectory = @"C:\Test\csv\";

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
    }
}
