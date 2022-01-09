# Exercice : MyGarage

MyGarage est un exercice que nous avons eu a faire durant la formation de devops.

## Screen 
<img src="<a href="https://zupimages.net/viewer.php?id=22/01/iof9.png"><img src="https://zupimages.net/up/22/01/iof9.png" alt="" /></a>" alt="My cool logo"/>
## Exercice :
Créer une application console (dotnet 5.0 ou dotnet 6.0) qui permet de gérer un garage virtuel.

## Structure
L'application doit au moins posséder le class Garage qui est la classe qui va permettre de gérer son garage. Cette classe ne doit pas contenir d'appels à Console.WriteLine

## Règles
Il est possible d'effectuer les opérations suivantes au sein de l'application :

Ajouter un nouveau véhicule dans le garage  
Enlever un véhicule du garage  
Mettre à jour l'état d'un véhicule  
Lister les véhicules actuellement dans le garage  
Quitter l'application  
Le garage possède les règles suivantes :

Il ne peut pas y avoir plus de 5 véhicules au sein du garage
Le garage peut contenir des véhicules à 2 roues (moto, vélo, trotinette) ou 4 roues (voiture, pot de yaourt)
Il ne peut pas y avoir plus de 2 véhicules à 4 roues dans le garage
Un véhicule possède au moins les caractéristiques suivantes :

Un identifiant unique sous la forme d'un nombre incrémental
Un marque  
Un modèle  
Un kilométrage  
Il est possible d'avoir d'autres attributs qui peuvent être liés au type de véhicule

## Notions attendues
Classes  
Héritage  
Exceptions  
Enums  
Static  
Encapsulation  
(Chaînage de méthodes/constructeurs)  
Interface / classes abstraites  
(Utilisation d'une bibliothèque de classe pour les règles métiers)  
### Optionnels  
Ajouter un système de logs (de base, serilog etc...)
Sauvegarder l'état du garage dans un fichier local afin de sauvegarder son garage entre les démarrages de l'application
