using ExoGarage.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExoGarage.InterfaceConsole
{
    internal interface IWriter
    {
        internal void Display(string text);
        /// <summary>
        /// Displays an object of the Tag type
        /// </summary>
        internal void DisplayVehicule(Vehicule vehicule);
    }
}
