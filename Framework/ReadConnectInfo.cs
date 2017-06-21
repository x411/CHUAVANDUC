using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.InteropServices;
using System.IO;

namespace Framework
{
    public class ReadConnectInfo
    {
        [DllImport("kernel32")]
        private static extern int GetPrivateProfileString(string section, string key, string def, StringBuilder retVal, int size, string filePath);
        public string mStrServerName;
        public string mStrPassword;
        public string mStrUserName;
        public string mStrDatabaseName;
        public string mStrAttachDBFilename;

        public ReadConnectInfo()
        {
        }

        public void TextFileReading(string pFilePathFull)
        {
            if (!File.Exists(pFilePathFull))
            {
                return;
            }
            try
            {
                StringBuilder strBuilder = new StringBuilder(255);
                int i = GetPrivateProfileString("ConfigConnectDB", "ServerName", "", strBuilder, 255, pFilePathFull);
                mStrServerName = strBuilder.ToString().Trim();

                i = GetPrivateProfileString("ConfigConnectDB", "Password", "", strBuilder, 255, pFilePathFull);
                mStrPassword = strBuilder.ToString().Trim();

                i = GetPrivateProfileString("ConfigConnectDB", "UserName", "", strBuilder, 255, pFilePathFull);
                mStrUserName = strBuilder.ToString().Trim();

                i = GetPrivateProfileString("ConfigConnectDB", "DatabaseName", "", strBuilder, 255, pFilePathFull);
                mStrDatabaseName = strBuilder.ToString().Trim();

                i = GetPrivateProfileString("ConfigConnectDB", "AttachDBFilename", "", strBuilder, 255, pFilePathFull);
                mStrAttachDBFilename = strBuilder.ToString().Trim();
                
            }
            catch
            {
                Console.WriteLine("Error occur while reading file!  ");
            }
        }

    }
}
