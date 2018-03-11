using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace ShareFile
{
    class Servers
    {
        string[] strfile;
        IPEndPoint ipSer;
        public IPEndPoint IPSer
        {
            get { return ipSer; }
        }
        Socket sServer;
        Socket client;
        public Socket SServer
        {
            get { return sServer; }
        }

        public Servers()
        {
            sServer = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            ipSer = new IPEndPoint(IPAddress.Loopback, 1512);
            sServer.Bind(ipSer);
        }
        public void listen()
        {
            sServer.Listen(4);
            System.Console.WriteLine("Dang doi ket noi tu clients");
        }
        public void accept()
        {
            client = sServer.Accept();
            System.Console.WriteLine("Dang ket noi voi : {0}", client.RemoteEndPoint.ToString());
            string s = "Hello clients!";
            gui(s);
            Connectfile();
        }
        public void Nhanfile()
        {
            try
            {
                bool check = true;
                while (check)
                {
                    byte[] nhan = new byte[1024];
                    int rec = client.Receive(nhan);
                    string sNhan = Encoding.ASCII.GetString(nhan, 0, rec);
                    switch (sNhan)
                    {
                        case "exit":
                            {
                                check = false;
                                client.Close();
                                sServer.Close();
                            }
                            break;

                        case "text1.txt":
                            {
                                gui(readfile("text1.txt"));
                            }
                            break;
                        case "text2.txt":
                            {
                                gui(readfile("text2.txt"));
                            }
                            break;
                        case "text3.txt":
                            {
                                gui(readfile("text3.txt"));
                            }
                            break;
                        default:
                            {
                                Console.WriteLine("From client: " + sNhan);
                            }
                            break;
                    }

                }
            }
            catch
            { Console.WriteLine("Loi!"); }
        }
        public void gui(string s)
        {
            byte[] gui = Encoding.ASCII.GetBytes(s);
            client.Send(gui);
        }
        public void Connectfile()
        {
            DirectoryInfo d = new DirectoryInfo(@"file\");
            FileInfo[] Files = d.GetFiles("*.txt");
            strfile = new string[Files.Length];
            for (int i = 0; i < Files.Length; i++)
            {
                strfile[i] = Files[i].ToString();
            }
            string mess = string.Join(" | ", strfile);
            mess = "Cac file co the download: " + mess;
            gui(mess);
        }
        public string readfile(string namefile)
        {
            string file = @"file\" + namefile;
            string line = "";
            try
            {   
                using (StreamReader sr = new StreamReader(file))
                {
                    line = sr.ReadToEnd();
                    Console.WriteLine(line);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Loi khong the doc file:");
                Console.WriteLine(e.Message);
            }
            return line;
        }
    }
}
