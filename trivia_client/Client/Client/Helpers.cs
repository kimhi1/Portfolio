using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Sockets;
using System.IO;

namespace Client
{
    class Helpers
    {

        public const string CONFIG_FILE_NAME = "config.txt";
        public const char DELIMITER = '=';
        public const int NUM_LINES = 3;

        // get client stream, return message from server at length len
        public static string getMessage(int len, NetworkStream clientStream)
        {
            string message = "";
            byte[] bufferIn = new byte[len];
            int bytesRead = clientStream.Read(bufferIn, 0, len);
            message = new ASCIIEncoding().GetString(bufferIn);
            return message;
        }

        // send message to server
        public static void sendMessage(string message, NetworkStream clientStream)
        {
            try
            {
                byte[] buffer = new ASCIIEncoding().GetBytes(message);
                clientStream.Write(buffer, 0, message.Length);
                clientStream.Flush();
            }
            catch (SocketException err)
            { }
        }

        // return a string with config data: ip, port, encryption
        public static string[] readConfigFile()
        {
            string[] arr = new string[3];
            int i = 0;
            try
            {

                using (StreamReader sr = new StreamReader(CONFIG_FILE_NAME))
                {
                    String line;
                    // Read and display lines from the file until the end of
                    // the file is reached.
                    while ((line = sr.ReadLine()) != null)
                    {
                        arr[i] = line.Split(DELIMITER)[1];
                        i++;
                    }
                }
            }
            catch(Exception e)
            {
                arr = null;
            }

            return arr;
        }

        
    }
}
