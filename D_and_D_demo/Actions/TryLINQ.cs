using D_and_D_demo.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace D_and_D_demo.Actions
{
    public class TryLINQ
    {
        CreatureFromFileReader reader = new CreatureFromFileReader();
        public void ShowCreaturesNames()
        {
            Console.Write($"List of creatures: ");
            foreach (var creature in reader.CreateCreatureList().Select(x => new { Name = x.CreatureName}))
            {
                Console.Write($"{creature.Name}, ");
            }
        }
        public void MaxArmorClass()
        {
            var armorSort = reader.CreateCreatureList().OrderBy(x => x.CreatureArmor).Max(x => x.CreatureArmor);
            Console.WriteLine($"\n\nMax armor class from all creatures: {armorSort}.");
        }

        public void SortByClaws()
        {
            Console.WriteLine($"\nList of creutures, who using claws:\n");
            var clawsSort = reader.CreateCreatureList().Where(x => x.CreatureWeapon.WeaponName == "Claws");
            foreach (var creatureName in clawsSort)
            {
                Console.WriteLine($"{creatureName.CreatureName};");
            }
        }
        public void CreatureSearch()
        {
            Console.WriteLine($"\nThe first creature who has 3-d level is:\n");
            var firstCreature = reader.CreateCreatureList().First(x => x.CreatureLevel < 4 && x.CreatureLevel > 2);
            Console.WriteLine($"{firstCreature.CreatureName}.");
        }
        public void ShowCreatureDemage()
        {
            Console.WriteLine($"\n-------Creatures and their demage-------\n");
            foreach (var demage in reader.CreateCreatureList().Select(x => new { Name = x.CreatureName, NumberOfDices = ((int)(DiceCount)Enum.Parse(typeof(DiceCount), x.CreatureWeapon.Demage.NumberOfDices.ToString())).ToString(),
                SizeOfDice = x.CreatureWeapon.Demage.SizeOfDice.ToString(), Mod = x.CreatureWeapon.DemageMod}))
            {
                Console.WriteLine($"{demage.Name} ---- {demage.NumberOfDices}{demage.SizeOfDice} + {demage.Mod}");
            }
        }
        public void MaxDemage()
        {
            var maxDemage = reader.CreateCreatureList().Select(x => new {NumberOfDices =(int)(DiceCount)Enum.Parse(typeof(DiceCount), x.CreatureWeapon.Demage.NumberOfDices.ToString()),
                SizeOfDice = ((int)(DiceSize)Enum.Parse(typeof(DiceSize), x.CreatureWeapon.Demage.SizeOfDice.ToString())), Mod = x.CreatureWeapon.DemageMod}).Max(m => (m.NumberOfDices*m.SizeOfDice + m.Mod)); 
           
            Console.WriteLine($"\n\nMax demage from all creatures: {maxDemage}.");
        }
    }
}
