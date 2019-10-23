using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace D_and_D_demo.Model
{
    class Creature
    {
        public string CreatureName { get; set; }
        public Weapon CreatureWeapon { get; set; }
        public ArmorClass CreatureArmor { get; set; }
        public AttackMod CreatureAttackMod { get; set; }
        public int CreatureHitPoints { get; set; }
        public int CreatureLevel { get; set; }
    }
}
