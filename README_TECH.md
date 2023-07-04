# README_TECH - Jeu de Zombie

## Structure du projet :
- Trois scènes sont utilisées : la scène de jeu, la scène de départ et la scène de fin.
- Les scripts importants sont les suivants :
   - CyberManController : Contrôle le personnage principal.
   - IAZombie : Gère le comportement des zombies en définissant leur cible et en infligeant des dégâts au coffre et au joueur.
   - Pistolet : Gère les dégâts infligés par l'arme du joueur aux zombies, ainsi que les mécanismes de rechargement.
   - ZombieAnim : Gère les animations des zombies.
   - ZombieSpawner : Gère le spawn des zombies.
   - Les scripts de menu pour le jeu.
- Les scripts importants sont attachés aux objets suivants :
   - IAZombie et IAZombie2 : Attachés aux zombies.
   - CyberMan : Attaché au personnage principal.
   - L'arme que le personnage tient.
   - Le coffre à protéger.

## Fonctionnalités implémentées :
- Menu avec options.
- Déplacement du joueur et capacité de tirer.
- Deux types de zombies qui infligent des dégâts au joueur ou au coffre.
- Les zombies se déplace avec de manière optimisé vers la target
- Mécanisme de vagues de zombies.
- Système sonore pour les tirs et le rechargement.
- Animation du joueur et des zombies

Nous avons essayé de documenter le code pour que vous puissiez mieux comprendre ce que nous faisons.
