using ExoGarage.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExoGarage.InterfaceConsole
{
    internal class ConsoleWriter : IWriter
    {
        void IWriter.Display(string text)
        {
            Console.WriteLine(text);
        }

        void IWriter.DisplayVehicule(Vehicule vehicule)
        {
            Console.WriteLine(vehicule);
        }
    }
}
