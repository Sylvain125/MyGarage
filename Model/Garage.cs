using ExoGarage.Enum;
using ExoGarage.InterfaceConsole;
using ExoGarage.Program;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExoGarage.Model
{
    /// <summary>
    /// Le Garage, contient les reader/writer et la liste des vehicules.
    /// Il fixe toutes les "limites" du garage => Max 5 véhicules, Max 2 vehicules à 4 roues.
    /// Le garage gere les ajout/edit/delete/voir sur la liste.
    /// </summary>
    internal class Garage
    {
        private readonly IReader _reader;
        private readonly IWriter _writer;
        private List<Vehicule> _vehiculeList = new List<Vehicule>();

        public List<Vehicule> VehiculeList
        {
            get => _vehiculeList;
        }

        /// Quand on lance un Garage, on creer des vehicules et les ajoutent a la liste de vehicule.
        public Garage(IReader reader, IWriter writer)
        {
            _reader = reader;
            _reader.Writer = writer;
            _writer = writer;

            Vehicule vehicule1 = new VehiculeTwoWeels(VehiculeState.Bon, "Peugot", "103", 120788);
            Vehicule vehicule2 = new VehiculeFourWeels(VehiculeState.Moyen, "Citroen", "C3", 62000);
            Vehicule vehicule3 = new VehiculeFourWeels(VehiculeState.Moyen, "Peugot", "206", 62000);
            _vehiculeList.Add(vehicule1);
            _vehiculeList.Add(vehicule2);
            _vehiculeList.Add(vehicule3);
        }

        /// Pour "fixer les limites" du garage, si 5 vehicules = plus de place dans le garage.
        internal bool garageIsFull
        {
            get => VehiculeList.Count == 5 ? true : false;
        }

        /// Pour "fixer les limites" du garage,
        /// si 2 vehicules 4 roues = plus de place pour d'autre vehicule 4 roues.
        internal bool GarageMaxCars
        {
            get => NumberMaxCar() == 2 ? true : false;
        }

        /// Compte le nombre de vehicules 4 roues present dans la liste
        internal int NumberMaxCar()
        {
            int vehiculecount = 0;
            foreach (var vehicule in _vehiculeList)
            {
                // Le Gettype sert à comparer 2 types de class, ici si c'est 4 roues ou 2 roues
                if (vehicule.GetType() == typeof(VehiculeFourWeels))
                {
                    vehiculecount++;
                }
            }

            //TODO: tu peux utiliser linq 
            //_vehiculeslist.OfType<VehiculeFourWeels>().Count();
            
            // je renvoi le nb de 4roues trouvés
            return vehiculecount;
        }


        /// Renvoie l'etat du vehicule, tant que le user a pas input un int de la liste tourne en boucle
        internal VehiculeState GetVehiculeState()
        {
            bool WeContinue = true;
            do
            {
                _writer.Display("Quel est son etat ?");
                _writer.Display("1 - Bon");
                _writer.Display("2 - Moyen");
                _writer.Display("3 - Mauvais");

                var vehiculeState = Console.ReadLine();
                int numberState;

                bool succes = int.TryParse(vehiculeState, out numberState);
                if (succes)
                {
                    WeContinue = false;
                }
                else
                {
                    // je sais pas si on a le droit de clean la console mais cest plus propre.
                    Console.Clear();
                    _writer.Display("Entrée des chiffres pas des lettres !!");
                    GetVehiculeState();
                }
                VehiculeState state = (VehiculeState)numberState;
                return state;

            } while (WeContinue);
        }


        /// Sert a récuperer les kms que l'utilisateur à taper
        internal int GetvehiculeKms()
        {
            bool WeContinue = true;
            do
            {
                _writer.Display("Entrer les kms :");
                var vehiculeKm = Console.ReadLine();
                int numberkms;
                bool succes = int.TryParse(vehiculeKm, out numberkms);
                if (succes)
                {
                    WeContinue = false;
                }
                else
                {
                    /// La aussi le clean
                    Console.Clear();
                    _writer.Display("Entrée des chiffres pas des lettres!!");
                    GetvehiculeKms();
                }
                return numberkms;
            }
            while (WeContinue);
        }


        /// Renvoie le nombre de vehicules dans la liste.
        public int GetVehiculeListCount()
        {
            return VehiculeList.Count();
        }


        /// Affiche les vehicules present dans la liste selon si 2 roues ou 4 roues.
        public void ShowVehiculeList()
        {
            int i = 0;
            _writer.Display("\nListe des véhicules 2 roues présent dans le garage:");
            foreach (var vehicule in _vehiculeList)
            {
                if (vehicule.GetType() == typeof(VehiculeTwoWeels))
                {
                    i++;
                    _reader.Writer.Display(i.ToString() + ". " + vehicule);
                }
            }

            _writer.Display("Liste des véhicules 4 roues présent dans le garage:");
            foreach (Vehicule vehicule in _vehiculeList)
            {
                if (vehicule.GetType() == typeof(VehiculeFourWeels))
                {
                    i++;
                    _reader.Writer.Display(i.ToString() + ". " + vehicule);
                }

            }


        }


        /// Ajoute un vehicule à la liste
        internal void AddVehicule(Vehicule vehicule)
        {
            //TODO: gestion d'exception
            if (vehicule == null)
            {
                throw new ArgumentNullException();
            }
            _vehiculeList.Add(vehicule);
        }


        /// Supprime un vehicule de la liste selon l'id que l'utilisateur à entrée.
        internal void DeleteVehicule(int inputuser)
        {
            try
            {
                _vehiculeList.RemoveAt(inputuser - 1);
            }
            catch (System.ArgumentOutOfRangeException ex)
            {
                _writer.Display("Pas dans la liste");
            }
        }
    }
}
