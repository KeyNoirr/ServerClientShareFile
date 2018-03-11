using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace ClientFile
{
    class Clients
    {
        IPEndPoint ipCli;
        Socket client;
        public Clients()
        {
            ipCli = new IPEndPoint(IPAddress.Loopback, 1512);
            client = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
        }
        public void Connects()
        {
            try
            {
                client.Connect(ipCli);
                nhan();
            }
            catch
            { System.Console.WriteLine("loi"); }
        }
        public string nhan()
        {
            string nhan = "";
            try
            {
                byte[] sNhan = new byte[1024];
                int rec = client.Receive(sNhan);
                nhan = Encoding.ASCII.GetString(sNhan, 0, rec);
                System.Console.WriteLine(nhan);
            }
            catch
            {
                Console.WriteLine("Loi");
            }
            return nhan;
        }
        public void Gui(string s)
        {
            byte[] sGui = new byte[1024];
            sGui = Encoding.ASCII.GetBytes(s);
            client.Send(sGui);
        }
        public void CreateFIle(string pathfile, string data)
        {
            string path = pathfile;
            if (!File.Exists(path))
            {

                try
                {
                    using (StreamWriter sw = File.CreateText(path))
                    {
                        sw.WriteLine(data);
                    }
                    Console.WriteLine("Thanh cong");
                }
                catch
                {
                    Console.WriteLine("Loi duong dan: ");
                }
            }
            else
            {
                Console.WriteLine("File da ton tai!");
            }
        }
    }
}
