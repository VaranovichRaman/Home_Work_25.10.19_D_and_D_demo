using D_and_D_demo.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace D_and_D_demo.Actions
{
    class CreatureFromFileReader
    {
        public List<Creature> CreateCreatureList()
        {
            List<Creature> creatureList = new List<Creature>();
            string[] separators = { "***" };
            var value = File.ReadAllLines("../../CreatureList.txt", Encoding.Default);
            foreach (var item in value)
            {
                Creature creature = new Creature(); creature.CreatureArmor = new ArmorClass();
                creature.CreatureAttackMod = new AttackMod();
                creature.CreatureWeapon = new Weapon();
                creature.CreatureWeapon.Demage = new DemageDice();
                creature.CreatureWeapon.Demage.NumberOfDices = new DiceCount();
                creature.CreatureWeapon.Demage.SizeOfDice = new DiceSize();
                string[] words = item.Split(separators, StringSplitOptions.RemoveEmptyEntries);
                creature.CreatureName = words[0];
                creature.CreatureArmor = (ArmorClass)int.Parse(words[1]);
                creature.CreatureAttackMod = (AttackMod)int.Parse(words[2]);
                creature.CreatureHitPoints = int.Parse(words[3]);
                creature.CreatureLevel = int.Parse(words[4]);
                creature.CreatureWeapon.WeaponName = words[5];
                creature.CreatureWeapon.DemageMod = int.Parse(words[6]);
                creature.CreatureWeapon.Demage.NumberOfDices = (DiceCount)int.Parse(words[7]);
                creature.CreatureWeapon.Demage.SizeOfDice = (DiceSize)int.Parse(words[8]);
                creatureList.Add(creature);
            }
            return creatureList;
        }    
    }
}
