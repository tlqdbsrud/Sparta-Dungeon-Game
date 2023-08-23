using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assigments_01
{
    public class Character
    {
        public string Name { get; } // 이름 
        public string Job { get; } // 직업
        public int Level { get; set; } // 레벨
        public int Atk { get; set; } // 공격력
        public int Def { get; set; } // 방어력
        public int Hp { get; set; } // 생명력
        public int Gold { get; set; } // 돈

        public Character(string name, string job, int level, int atk, int def, int hp, int gold)
        {
            Name = name;
            Job = job;
            Level = level;
            Atk = atk;
            Def = def;
            Hp = hp;
            Gold = gold;
        }
    }
}
