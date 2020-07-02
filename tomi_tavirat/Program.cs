using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace tomi_tavirat
{
    class Program
    {
        struct Adat
        {
            public string telepules;
            public string ido;
            public string szelirany;
            public int fok;
        }
        static void Main(string[] args)
        {
            Adat[] adatok = new Adat[500];
            StreamReader olvas = new StreamReader(@"C:\Users\Rendszergazda\Desktop\2020_majus\tavirathu13.txt");
            int n = 0;
            while (!olvas.EndOfStream)
            {
                string sor = olvas.ReadLine();
                string[] db = sor.Split();
                adatok[n].telepules = db[0];
                adatok[n].ido = db[1];
                adatok[n].szelirany = db[2];
                adatok[n].fok = int.Parse(db[3]);
                n++;
            }
            olvas.Close();
            Console.WriteLine("1.Feladat: Beolvasás kész!");
            Console.WriteLine("Kérem adja meg egy város kódját:");
            string varos = Console.ReadLine();
            
            Console.ReadKey();
        }
    }
}
