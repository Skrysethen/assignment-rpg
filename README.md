# assignment-rpg
This is an assignment from Noroff to make a basic back-end for a simple RPG. Possible to make a hero (Mage, Warrior, Rogue, Ranger) and weapon items and armor items.
This is a blank program so feel free to try and make a basic gameloop. 

## Installation
Clone the repo and open the solution in Visual Studio.

## Features 
### Creating a Hero with only passing your name.
Ex: RogueHero rogue = new RogueHero("NameHere");

### LevelUp your hero
Ex: rogue.LevelUp();

### Creating WeaponItems or ArmorItems.
For weapons you pass trough Name, Level Requirement, Slot type, Weapon type and Damage.
Ex: WeaponItem fancySword = new WeaponItem("Big pointy thingy", 1, Slot.Weapon, WeaponType.Sword, 1); 

For armor you pass trough Name, Level Requirement, Slot type, Armor type and a Hero attribute
Ex: ArmorItem fancyRobe = new ArmorItem("Gray Robe", 1, Slot.Body, ArmorType.Cloth, new HeroAttribute{Str = 0, Dex = 0, Intelligence = 5});

### Equipping items
Ex: rogue.Equip(fancySword);

### Hero Damage
This calculates the damage of the Hero, each subclass has its own damage modifier, for rogue this is Dex. 
Ex: rogue.Damage();

### Print out simple char sheet
Prints out a simple character sheet
Ex: rogue.ToString(); 

## Contributions
Solo project
