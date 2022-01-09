using ExoGarage.Enum;
using ExoGarage.InterfaceConsole;
using ExoGarage.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExoGarage.Program
{
    /// La classe qui gere tous les menus du garage.
    /// Elle recupere les reader/writer pour lire les inputs des utilisateur
    /// ou ecrire dans la console.
    internal class Menu
    {
        private readonly IReader _reader;
        private readonly IWriter _writer;

        private Garage _garage;
        public Menu(IReader reader, IWriter writer, Garage garage)
        {
            _reader = reader;
            _writer = writer;
            _garage = garage;
        }

        /// <summary>
        /// Affiche le main menu et attend un input du l'utilisateur.
        /// </summary>
        internal void ShowMainMenu()
        {
            _writer.Display(
                "\nBienvenue dans mon super Garage !!\n" + Environment.NewLine +
                "1. Liste des véhicules dans le garage." + Environment.NewLine +
                "2. Ajouter un véhicule dans le garage." + Environment.NewLine +
                "3. Editer/Mettre à jour un véhicule." + Environment.NewLine +
                "4. Supprimer un véhicule du garage." + Environment.NewLine +
                "5. Quit()." + Environment.NewLine +
                "6. Enregistrer/Sauvegarder Liste (Optionel)");

            GetMainMenuInput();
        }

        /// <summary>
        /// Recupere ce que le user a tapé sur le main menu.
        /// Puis l'envoi sur le sous menu correspondant ou affiche la liste de vehicules.
        /// </summary>
        internal void GetMainMenuInput()
        {
            var UserInputInt = _reader.ReadId(1, 6);
            switch (UserInputInt)
            {
                case 1:
                    _garage.ShowVehiculeList();
                    break;
                case 2:
                    ShowAddMenu();
                    break;
                case 3:
                    ShowEditMenu();
                    break;
                case 4:
                    ShowDeleteMenu();
                    break;
                case 5:
                    Environment.Exit(0);
                    break;
                case 6:
                    ShowSaveLoadMenu();
                    break;
            }
        }


        /// <summary>
        /// Affiche le menu pour ajouter un vehicule.
        /// Controle que le garage ne soit pas plein.
        /// Controle qu'il n'y ai pas 1 vehicules 4 roues deja present.
        /// Renvoie au garage qui l'ajoute a la liste.
        /// </summary>
        internal void ShowAddMenu()
        {
            // Avant d'ajouter le vehicule, je verif que ya la place dans le garage
            if (_garage.garageIsFull)
            {
                _writer.Display("Le garage est plein !!");
            }
            else
            {
                int vehiculeType = 0;
                // Si ya pas la place pour dautres 4 roues on affiche que loption 2
                if (_garage.GarageMaxCars)
                {
                    _writer.Display("Trop de voiture dans le garage !!");
                    _writer.Display("Ajouter moto ou velo !!");
                    _writer.Display("1. Vélo/Moto - 2 roues.");
                    vehiculeType = _reader.ReadId(1, 1);
                }
                else
                {
                    // J'affiche les 2 types qui seront mes heritages de vehicules
                    //Console.Clear();
                    _writer.Display("\nEntrer le type de vehicule à ajouter:");
                    _writer.Display("1. Vélo/Moto - 2 roues.");
                    _writer.Display("2. Voiture - 4 roues.");
                    vehiculeType = _reader.ReadId(1, 2);
                }

                VehiculeState vehiculeState = _garage.GetVehiculeState();

                // Je recup les autres champs
                _writer.Display("Entrer la Marque :");
                var vehiculeBrand = _reader.ReadText();

                _writer.Display("Entrer le Modele :");
                var vehiculeModel= _reader.ReadText();

                // Je recup les kms en int et relance la demande si user tape un string
                _writer.Display("Entrer le nombre de kilometres du vehicule :");
                int vehiculeKms = _garage.GetvehiculeKms();
                
                switch(vehiculeType)
                {
                    case 1:
                        Vehicule voiture2 = new VehiculeTwoWeels(2, vehiculeState, vehiculeBrand, vehiculeModel, vehiculeKms);
                        // Jenvoie le vehicule dans le garage pour qu'il l'ajoute a la liste des vehicules
                        _garage.AddVehicule(voiture2);
                        break;

                    case 2:
                        Vehicule voiture = new VehiculeFourWeels(4, vehiculeState, vehiculeBrand, vehiculeModel, vehiculeKms);
                        // Jenvoie le vehicule dans le garage pour qu'il l'ajoute a la liste des vehicules
                        _garage.AddVehicule(voiture);
                        break;
                }
                _writer.Display("Le Vehicule à était ajouté avec succes :)");
            }
        }


        /// <summary>
        /// Affiche le menu pour editer un vehicule.
        /// Affiche la liste des vehicules avec un id, recup le input id utilisateur
        /// Le compare aux id de la liste, et si identique l'edit.
        /// </summary>
        internal void ShowEditMenu()
        {
            _writer.Display("Choisir le numero du véhicule à Editer :");
            _garage.ShowVehiculeList();

            int listCount = _garage.GetVehiculeListCount();
            // Recup l'id a editer
            int choiceMenuUpdate = _reader.ReadId(1, listCount);

            foreach (Vehicule vehicule in _garage.VehiculeList)
            {
                // Si lid correspond a un vehicule on recup et edit les champs
                if (vehicule.Id == choiceMenuUpdate)
                {
                    _writer.Display($"\nOk on Edit ce vehicule :");
                    _writer.DisplayVehicule(vehicule);

                    VehiculeState vehiculeState = _garage.GetVehiculeState();

                    // Je recup les autres champs
                    _writer.Display("\nEntrer la Marque du véhicule :");
                    var vehiculeBrand = _reader.ReadText();

                    _writer.Display("Entrer le Modele du véhicule :");
                    var vehiculeModel = _reader.ReadText();

                    _writer.Display("Entrer le nombre de kilometres du vehicule :");
                    // Je recup les kms en int et relance la demande si user tape un string
                    Console.Clear();
                    int vehiculeKms = _garage.GetvehiculeKms();

                    vehicule.State = vehiculeState;
                    vehicule.Brand = vehiculeBrand;
                    vehicule.Modele = vehiculeModel;
                    vehicule.Kms = vehiculeKms;
                    _writer.Display("Véhicule éditer avec succes !");
                }
            }

        }


        /// <summary>
        /// Affiche le menu pour supp un vehicule.
        /// Affiche la liste des vehicules, recup le id user et le renvoi au garage pour le supp
        /// </summary>
        internal void ShowDeleteMenu()
        {
            _writer.Display("Choisir le numero du véhicule à supprimer :");
            _garage.ShowVehiculeList();

            int listCount = _garage.GetVehiculeListCount();
            // Recup l'id a supp
            int choiceMenuSupp = _reader.ReadId(1, listCount);
            // envoi lid a la fonction delete
            _garage.DeleteVehicule(choiceMenuSupp);
        }


        internal void ShowSaveLoadMenu()
        {
            _writer.Display(
                "Vous voulez :" + Environment.NewLine +
                "1. Charger la liste de vehicule." + Environment.NewLine +
                "2. Enregistrer la liste de vehicule."
            );
            int choiceMenuSave = _reader.ReadId(1, 2);
            _garage.SaveAndLoad(choiceMenuSave);
        }
    }
}
