## Présentation du projet Fantastic3D.
<a href="https://zupimages.net/viewer.php?id=22/02/3ak5.png"><img src="https://zupimages.net/up/22/02/3ak5.png" alt="" /></a>
Fantastic3d, c'est un site de téléchargement et/ou de mise en vente de ressources 3D pour les particuliers et les proffesionels.
Il s'adresse principalement aux infographistes 3D mais aussi aux développeurs de jeux vidéo et toutes personnes étant amenée à apprendre, utiliser ou créer une scène en 3D.

## Caractéristiques :
Le projet répond à plusieurs besoins utilisateurs :
- Sur la conception de leur modèles 3D.
- Sur la création de scènes 3D.
- Aux développeurs pour les intégrer dans leur environnement .
- Pour un débutant qui aurai besoin d'un modèle pour apprendre à modéliser en 3D.

Il permet aussi aux membres du site qui souhaitent monétiser leurs créations 3D, de les mettre en vente sur notre site et ainsi gagner de l'argent à travers leurs créations.
Les membres disposent d’une page de portfolio présentant leurs créations et proposant de les contacter.
Sous réserve de validation des modèles par les administrateurs.
Une commission est reversée au site lors de la vente de leurs modèles. 

## Fonctionnement :
Le site dispose d'un système de connexion des utilisateurs, la connexion à son compte est impérative pour tout téléchargement de modèles 3D.
De plus, les utilisateurs peuvent s’abonner au site en mode premium.
Ce qui leur donne accès au téléchargement de certains modèles (les modèles les plus aboutis, ceux qui sont libres de droits, etc.)
Les utilisateurs ont aussi une wishlist : un simple clic sur l’icône correspondante, permet l'ajout a la wishlist, consultable depuis leurs profils.

Les utilisateurs peuvent déposer des avis avec une note sur 5 étoiles et un commentaire facultatif. 
Ces avis ne sont publiés en ligne qu’après validation d’un administrateur.

Le site se présente sous la forme d’un catalogue, il permet de rechercher des modèles 3D selon différents critères :
- Catégories.
- Type de modèle.
- Thématiques.
- Style graphique (cartoon, réaliste, low-poly).
- Format de fichier.
- Directement par recherche texte.

Les pages de modèles sont gérées par les administrateurs, via un client lourd dédié.
Les informations sont présentées de manière claire, car ce sont des informations cruciales pour ceux qui souhaitent les télécharger.
Les pages des modèles indiquent les différentes informations : 
- Le nom
- Le descriptif
- Le visuel
- Le format
- Ce qui est inclus (animation ? textures? ) 
- La licence attachée au modèle.

Le site est géré via un client lourd en C#, il permet de consulter les statistiques d’achat et de téléchargement des modèles 3D.
Les administrateurs peuvent directement ajouter des modèles 3D, valider les modèles envoyées par les utilisateurs ainsi que les avis et commentaires.
Les fiches « modèles 3D » sont éditables pour ajouter les informations des fiches modèles.

Le site est conçu de manière évolutive, il permet en outre d’ajouter d’autres types de ressources que des modèles 3D. 
Par exemple des sons, des sprites 2D, etc.

## Composants du projet :

- Application Console pour la gestion des tags :

<a href="https://ibb.co/hBZ8PKz"><img src="https://i.ibb.co/hBZ8PKz/Projet-App-Console.png" alt="Projet-App-Console" ></a>

- Le clients lourd WPF :

<a href="https://ibb.co/sWW5WDG"><img src="https://i.ibb.co/sWW5WDG/Projet-WPF.png" alt="Projet-WPF"></a>
<a href="https://ibb.co/Xst0LcF"><img src="https://i.ibb.co/Xst0LcF/Projet-Wpf-Reader.png" alt="Projet-Wpf-Reader" ></a>

- Service WCF :

