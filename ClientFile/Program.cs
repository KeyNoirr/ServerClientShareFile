using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClientFile
{
    class Program
    {
        static void Main(string[] args)
        {
            Clients client = new Clients();
            client.Connects();
            string s;
            client.nhan();
            do
            {
                Console.Write("Client: ");
                s = Console.ReadLine();
                client.Gui(s);
                if (s == "text1.txt" || s == "text2.txt" || s == "text3.txt")
                {
                    Console.Write("Nhap duong dan: ");
                    string sf = Console.ReadLine();
                    sf = sf + "\\" + s;
                    client.CreateFIle(sf, client.nhan());
                }
            } while (s != "exit");
        }
    }
}
