using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assigments_01
{
    public class Item
    {
        public int StatBonus; // 점수 증가
        public int Price; // 가격
        public string Name; // 이름
        public string Stat; // 특징
        public string Description; // 설명
        public bool isEquip;
        public int AtDf; // 방어력: 0, 공격력: 1

        public Item(string name, string stat, int statBonus, string description, int atdf)
        {
            Name = name;
            Stat = stat;
            StatBonus = statBonus;
            Description = description;
            AtDf = atdf;
        }

        public Item( bool isequip, string name, string stat, int statBonus,  string description, int atdf)
        {
            isEquip = isequip;
            Name = name;
            Stat = stat;
            StatBonus = statBonus;
            Description = description;
            AtDf = atdf;
        }
    }
}
