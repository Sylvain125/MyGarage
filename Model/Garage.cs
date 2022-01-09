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

            Vehicule vehicule1 = new VehiculeTwoWeels(2, VehiculeState.Bon, "Peugot", "103", 120788);
            Vehicule vehicule2 = new VehiculeFourWeels(4, VehiculeState.Moyen, "Citroen", "C3", 62000);
            Vehicule vehicule3 = new VehiculeFourWeels(4, VehiculeState.Moyen, "Peugot", "206", 62000);
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

                var vehiculeState = _reader.ReadText();
                int numberState;

                bool succes = int.TryParse(vehiculeState, out numberState);
                if (succes)
                {
                    WeContinue = false;
                }
                else
                {
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
                var vehiculeKm = _reader.ReadText();
                int numberkms;
                bool succes = int.TryParse(vehiculeKm, out numberkms);
                if (succes)
                {
                    WeContinue = false;
                }
                else
                {
                    _writer.Display("Entrée des chiffres pas des lettres!!");
                    GetvehiculeKms();
                }
                return numberkms;
            }
            while (WeContinue);
        }


        /// Renvoie le nombre de vehicules dans la liste.
        internal int GetVehiculeListCount()
        {
            return VehiculeList.Count();
        }


        /// Affiche les vehicules present dans la liste selon si 2 roues ou 4 roues.
        internal void ShowVehiculeList()
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
            catch (System.ArgumentOutOfRangeException)
            {
                _writer.Display("Pas dans la liste");
            }
        }


        // Sauvegarde la liste de vehicule dans un .txt sur le bureau
        internal void SaveAndLoad(int inputUser)
        {
            switch(inputUser)
            {
               // Charger liste vehicule
                case 1:
                    // On commenc epar clean la liste.
                    _vehiculeList.Clear();
                    //Pour souligner le texte dans la console et reset ensuite
                    const string UNDERLINE = "\x1B[4m";
                    const string RESET = "\x1B[0m";
                    _writer.Display("Entrer votre nom de Pc.\n" +
                        "Exemple : " +
                        "C:\\Users\\" +
                        UNDERLINE +
                        "aerox3" +
                        RESET +
                        "\\Desktop\\file.txt");

                    // recup le chemin via le user name du pc
                    var UserNameInputSave = _reader.ReadText();
                    string savedFile = @"C:\Users\" + UserNameInputSave + "\\Desktop\\file.txt";
                    try
                    {
                        //Créez une instance de StreamReader pour lire à partir d'un fichier
                        using (StreamReader sr = new StreamReader(savedFile))
                        {
                            string line;
                            // Lire les lignes du fichier jusqu'à la fin.
                            while ((line = sr.ReadLine()) != null)
                            {   
                                // Pour chaques lignes, je decoupe avec le ", "
                                var newsList = new List<string>();
                                string[] word = line.Split(", ");
                                foreach (string word2 in word)
                                {
                                    // une fois séparer, je trouve la valeur du champ en decoupant une 2eme fois
                                    string[] word3 = word2.Split(": ");
                                    newsList.Add(word3[1]);
                                }

                                // Je recup toutes les valeur des champs
                                int recupNbRoues = Int32.Parse(newsList[0]);

                                VehiculeState vehiculeState = 0;
                                if (newsList[1] == "Bon")
                                {
                                    int number1 = 1;
                                    vehiculeState = (VehiculeState)number1;
                                }
                                if (newsList[1] == "Moyen")
                                {
                                    int number1 = 2;
                                    vehiculeState = (VehiculeState)number1;
                                }
                                if (newsList[1] == "Mauvais")
                                {
                                    int number1 = 3;
                                    vehiculeState = (VehiculeState)number1;
                                }

                                string brand = newsList[2];
                                string model = newsList[3];
                                int newskms = Int32.Parse(newsList[4]);

                                // Si ya 2 roues, je fait un vehicule 2 roues avec les Infos correspondantes
                                if (recupNbRoues == 2)
                                {
                                    Vehicule voiture2 = new VehiculeTwoWeels(2, vehiculeState, brand, model, newskms);
                                    _vehiculeList.Add(voiture2);
                                }

                                // Si cest un vehicule 4 roues.
                                if (recupNbRoues == 4)
                                {
                                    Vehicule voiture2 = new VehiculeFourWeels(4, vehiculeState, brand, model, newskms);
                                    _vehiculeList.Add(voiture2);
                                }
                            }
                        }
                    }
                    catch (Exception e)
                    {
                        _writer.Display("Le fichier n'a pas pu être lu.");
                        _writer.Display(e.Message);
                    }
                    break;

                // Enregistrer la liste de vehicule
                case 2:
                    try
                    {
                        _writer.Display("Entrer votre nom de Pc.\n" +
                            "Exemple : " +
                            "C:\\Users\\" +
                            UNDERLINE +
                            "aerox3" +
                            RESET +
                            "\\Desktop\\file.txt");

                        var UserNameInput = _reader.ReadText();
                        string fileName = @"C:\Users\" + UserNameInput + "\\Desktop\\file.txt";

                        // Si le fichier existe on le delete et en fait un nouveau
                        if (File.Exists(fileName))
                        {
                            File.Delete(fileName);
                        }
                        else
                        {
                            // Creer le fichier .txt
                            using (FileStream fileStr = File.Create(fileName))
                            {
                                // Pour chaques vehicule de la liste 
                                foreach (var voiture in VehiculeList)
                                {
                                    // Ajouter du texte au fichier  
                                    Byte[] text = new UTF8Encoding(true).GetBytes(voiture.ToString() + "\n");
                                    fileStr.Write(text, 0, text.Length);
                                }
                            }
                            // Ouvre le flux, on save le fichier en gros
                            using (StreamReader sr = File.OpenText(fileName))
                            {
                                string s = "";
                                while ((s = sr.ReadLine()) != null)
                                {
                                    _writer.Display(s);
                                }
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        _writer.Display(ex.Message);
                    }
                    break;
            }
        }
    }
}
