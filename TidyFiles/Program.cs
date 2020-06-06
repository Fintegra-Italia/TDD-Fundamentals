using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace TidyFiles
{
    class Program
    {
        static void Main(string[] args)
        {
            Timer ciclo = new Timer(5000);
            ciclo.Enabled = true;
            ciclo.Elapsed += Work;
            string readKeys = "";
            while (readKeys != "ex")
            {
                readKeys = Console.ReadLine();
            }

            void Work(object sender, ElapsedEventArgs e)
            {
                ciclo.Stop();
                //leggi tutti i file che sono in una cartella che ti passo
                //leggi i filtri da applicare ai file  (da un file)
                //filtra la lista dei file in base ai filtri che hai caricato
                //sposta i file che hai trovato nella destinazione associata
                ciclo.Start();
            }
        }
    }
}
