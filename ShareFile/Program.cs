using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShareFile
{
    class Program
    {
        static void Main(string[] args)
        {
            Servers ser = new Servers();
            ser.listen();
            ser.accept();
            ser.Nhanfile();
        }
    }
}
