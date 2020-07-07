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
            Console.Write("2.Feladat: Kérem adja meg egy város kódját:");
            string varos = Console.ReadLine();
            string ido = null;
            for (int i = n-1; i>-1;i--)
            {
                if (varos == adatok[i].telepules)
                {
                    ido = adatok[i].ido;
                    Console.WriteLine("{0}:{1}-kor volt az utolsó mérés",ido.Substring(0,2),ido.Substring(2,2));
                    break;
                }
            }

            //3.feladat
            int max = adatok[0].fok;
            int min = adatok[0].fok;
            int h = 0;
            int g = 0;
            for (int i = 1; i<n;i++)
            {
                if (max < adatok[i].fok)
                {
                    max = adatok[i].fok;
                    h = i;
                }           
            }

            for (int i = 1; i < n; i++)
            {
                if (min > adatok[i].fok)
                {
                    min = adatok[i].fok;
                    g = i;
                }
            }
            Console.WriteLine("A legmagasabb hőmérséklet: {0} {1}:{2} {3} fok",adatok[h].telepules, adatok[h].ido.Substring(0,2), adatok[h].ido.Substring(2, 2), adatok[h].fok);                                
            Console.WriteLine("A legalacsonyabb hőmérséklet: {0} {1}:{2} {3} fok", adatok[g].telepules, adatok[g].ido.Substring(0, 2), adatok[g].ido.Substring(2, 2), adatok[g].fok);

            //4.feladat
            int u = 0;
            for (int i =0;i <n;i++)
            {
                if (adatok[i].szelirany == "00000")
                {
                    Console.WriteLine(adatok[i].telepules+" " + adatok[i].ido.Substring(0,2)+":"+ adatok[i].ido.Substring(2,2));
                    u++;
                }
                
            }
            if (u ==0)
            {
                Console.WriteLine("Nem volt szélcsend a a mérések idején.");
            }
            
            Console.ReadKey();
        }
    }
}
