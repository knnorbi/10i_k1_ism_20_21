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
        static void Main(string[] args)
        {
            StreamReader sr = new StreamReader("csudh.txt");
            StreamWriter sw = new StreamWriter("csudh.html");

            int sorsz = 1;
            string sor;
            sw.WriteLine("<html><head></head><body>");
            sw.WriteLine("<table>");
            sw.WriteLine("<tr><th>Ssz</th><th>Host doaminneve</th><th>Host IP címe</th>");
            for (int i = 1; i <= 5; i++)
            {
                sw.WriteLine($"<th>{i}. szint</th>");
            }
            sw.WriteLine("</tr>");
            sr.ReadLine();
            while ((sor = sr.ReadLine()) != null)
            {
                sw.WriteLine("<tr>");
                sw.WriteLine($"<th>{sorsz}.</th>");
                sorsz++;

                string[] adatok = sor.Split(';');
                sw.WriteLine($"<td>{adatok[0]}</td>");
                sw.WriteLine($"<td>{adatok[1]}</td>");

                string[] dnsParts = adatok[0].Split('.');
                for (int i = 0; i < 5; i++)
                {
                    int idx = dnsParts.Length - 1 - i;
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
