using ExoGarage.Enum;

namespace ExoGarage.Model
{

    /// <summary>
    /// Definie les informations sur les vehicules
    /// </summary>
    internal class Vehicule
    {
        // Je met le eid et un compteur en static qui sincrement a lajout de vehicule
        private readonly int _id;

        private int _nbRoues;
        private VehiculeState _state;
        private string _brand;
        private string _modele;
        private int _kms;

        public Vehicule(int nbRoues, VehiculeState state, string brand, string modele, int kms)
        {
            _id = IdCounter.New();
            _nbRoues = nbRoues;
            _state = state;
            _brand = string.IsNullOrEmpty(brand) ? throw new ArgumentNullException(nameof(brand)) : brand;
            _modele = string.IsNullOrEmpty(modele) ? throw new ArgumentNullException(nameof(modele)) : modele;
            _kms = kms;
        }

        public int Id
        {
            get { return _id; }
        }
        public int NbRoues
        {
            get { return _id; } 
        }

        public VehiculeState State
        {
            get { return _state; }
            set { _state = value; }
        }

        public string Brand
        {
            get { return _brand; }
            set { _brand = value; }

        }
        public string Modele
        {
            get { return _modele; }
            set { _modele = value; }

        }
        public int Kms
        {
            get { return _kms; }
            set { _kms = value; }

        }

        // Sert a faire afficher la liste des vehicules comme on veux.
        public override string ToString()
        {
            return $"NbRoues: {_nbRoues}" + $", Etat: {_state}" + $", Marque: {_brand}" + $", Modele: {_modele}" + $", Kilometre: {_kms}";
        }
    }
}