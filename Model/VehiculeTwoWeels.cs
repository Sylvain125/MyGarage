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
        public VehiculeTwoWeels(VehiculeState state, string brand, string modele, int kms) : base(state, brand, modele, kms)
        {
        }
    }
}
