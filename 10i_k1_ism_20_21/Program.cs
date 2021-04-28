using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _10i_k1_ism_20_21
{
    class Program
    {
        static bool NagyobbEAMasik(string egyikIP, string masikIP)
        {
            string egyik = egyikIP.Split(';')[1];
            string masik = masikIP.Split(';')[1];

            if (int.Parse(egyik.Split('.')[0]) > int.Parse(masik.Split('.')[0]))
            {
                return false;
            }
            else if (int.Parse(egyik.Split('.')[0]) < int.Parse(masik.Split('.')[0]))
            {
                return true;
            }
            else if (int.Parse(egyik.Split('.')[1]) > int.Parse(masik.Split('.')[1]))
            {
                return false;
            }
            else if (int.Parse(egyik.Split('.')[1]) < int.Parse(masik.Split('.')[1]))
            {
                return true;
            }
            else if (int.Parse(egyik.Split('.')[2]) > int.Parse(masik.Split('.')[2]))
            {
                return false;
            }
            else if (int.Parse(egyik.Split('.')[2]) < int.Parse(masik.Split('.')[2]))
            {
                return true;
            }
            else if (int.Parse(egyik.Split('.')[3]) > int.Parse(masik.Split('.')[3]))
            {
                return false;
            }
            else if (int.Parse(egyik.Split('.')[3]) < int.Parse(masik.Split('.')[3]))
            {
                return true;
            }
            else
            {
                return false;
            }

        }

        static void Main(string[] args)
        {
            StreamReader sr = new StreamReader("csudh.txt");
            StreamWriter sw = new StreamWriter("csudh.html");
            string sor;
            string[] sorok = new string[10000];

            int db = 0;
            sr.ReadLine();
            while ((sor = sr.ReadLine()) != null)
            {
                sorok[db] = sor;
                db++;
            }

            string[] pontJo = new string[db];
            for (int i = 0; i < pontJo.Length; i++)
            {
                pontJo[i] = sorok[i];
            }
            sorok = pontJo;

            //int db = 0;
            //while (db < sorok.Length && sorok[db] != null)
            //{
            //    db++;
            //}

            for (int i = 0; i < sorok.Length; i++)
            {
                int legkisebb = i;
                for (int j = i + 1; j < sorok.Length; j++)
                {
                    if (NagyobbEAMasik(sorok[j], sorok[legkisebb]))
                    {
                        legkisebb = j;
                    }
                }

                if (i != legkisebb)
                {
                    string seged = sorok[i];
                    sorok[i] = sorok[legkisebb];
                    sorok[legkisebb] = seged;
                }
            }

            sw.WriteLine("<html><head></head><body>");
            sw.WriteLine("<table>");
            sw.WriteLine("<tr><th>Ssz</th><th>Host doaminneve</th><th>Host IP címe</th>");
            for (int i = 1; i <= 5; i++)
            {
                sw.WriteLine($"<th>{i}. szint</th>");
            }
            sw.WriteLine("</tr>");

            for (int i = 0; i < sorok.Length; i++)
            { 
                sw.WriteLine("<tr>");
                sw.WriteLine($"<th>{i + 1}.</th>");

                string[] adatok = sorok[i].Split(';');
                sw.WriteLine($"<td>{adatok[0]}</td>");
                sw.WriteLine($"<td>{adatok[1]}</td>");

                string[] dnsParts = adatok[0].Split('.');
                for (int k = 0; k < 5; k++)
                {
                    int idx = dnsParts.Length - 1 - k;
                    if (idx >= 0) {
                        sw.WriteLine($"<td>{dnsParts[idx]}</td>");
                    }
                    else
                    {
                        sw.WriteLine("<td>nincs</td>");
                    }
                }

                sw.WriteLine("</tr>");
            }
            sw.WriteLine("</table>");
            sw.WriteLine("</body></html>");

            sw.Close();
            sr.Close();
        }
    }
}
