using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExoGarage.InterfaceConsole
{
    internal interface IReader
    {
        public IWriter Writer { get; set; }
        /// <summary>
        /// Reads a text input from the user. 
        /// </summary>
        internal string ReadText();
        /// <summary>
        /// Reads a number input from the user. You can set allowed values.
        /// </summary>
        internal int ReadId(int lowerBound = 0, int higherBound = 0);
    }
}
