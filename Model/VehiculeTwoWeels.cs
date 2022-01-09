using ExoGarage.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExoGarage.Model
{
    internal class VehiculeTwoWeels : Vehicule
    {
        public VehiculeTwoWeels(int nbRoues,VehiculeState state, string brand, string modele, int kms) : base(nbRoues, state, brand, modele, kms)
        {
        }
    }
}
