using System.Collections.Generic;

namespace Assigments_01
{
    class Program
    {
        public static Character player;
        private static List<Item> itemList = new List<Item>();

        static void Main(string[] args)
        {
            GameDataSetting();
            
            DisplayGameIntro();

        }

        static void GameDataSetting()
        {
            // 캐릭터 정보 세팅
            player = new Character("John", "전사", 1, 10, 5, 100, 1500); // 이름, 직업, 레벨, 공격력, 방어력, 생명력, 골드

            // 아이템 정보 세팅
            itemList.Add(new Item(true, "무쇠갑옷", "방어력", 5, "무쇠로 만들어져 튼튼한 갑옷입니다.",0));
            itemList.Add(new Item(false, "낡은 검", "공격력", 2, "쉽게 볼 수 있는 낡은 검 입니다.",1));
            itemList.Add(new Item(false, "신성한 활", "공격력", 3, "신성한 힘을 담아 원거리에서 정확한 공격을 수행하는 활입니다.", 1));
            itemList.Add(new Item(false, "마력 방어 망토", "방어력", 4, "마법 방어에 특화되어 있어 저항력을 부여하는 망토입니다.", 0));
        }


        // 입력가능 여부 및 입력값 리턴
        static int CheckValidInput(int min, int max)
        {
            while (true)
            {
                string input = Console.ReadLine();

                bool parseSuccess = int.TryParse(input, out var ret);
                if (parseSuccess)
                {
                    if (ret >= min && ret <= max)
                        return ret;
                }

                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("잘못된 입력입니다.");
            }
        }

        // 1. 시작 화면
        public static void DisplayGameIntro()
        {
            Console.Clear();

            Console.WriteLine();
            Console.WriteLine("♣ 스파르타 마을에 오신 여러분 환영합니다. ♣");
            Console.WriteLine("이곳에서 던전으로 들어가기 전 활동을 할 수 있습니다.");
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("1. 상태 보기 \n2. 인벤토리");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine();
            Console.WriteLine("원하시는 행동을 입력해주세요.");
            Console.Write(">> ");

            int input = CheckValidInput(1, 2);
            switch (input)
            {
                case 1:
                    PlayerState(); // 플레이어 상태 보기
                    break;
                case 2:
                    EquipManagment1(); // 인벤토리
                    break;
            }

        }

        // 2. 플레이어 상태 보기
        public static void PlayerState()
        {
            Console.Clear();

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("상태 보기");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("캐릭터의 정보가 표시됩니다.");
            Console.WriteLine("");
            Console.WriteLine("-----------------------------");
            Console.WriteLine($"Lv. {player.Level}");
            Console.WriteLine($"{player.Name}({player.Job})");
            Console.WriteLine($"공격력 : {player.Atk}");
            Console.WriteLine($"방어력 : {player.Def}");
            Console.WriteLine($"체력 : {player.Hp}");
            Console.WriteLine($"Gold : {player.Gold} G");
            Console.WriteLine("-----------------------------");
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("0. 나가기");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine();
            Console.WriteLine("원하시는 행동을 입력해주세요.");
            Console.Write(">> ");

            int input = CheckValidInput(0, 0);
            switch (input)
            {
                case 0:
                    DisplayGameIntro();
                    break;
            }
        }

        

        // 3. 인벤토리
        static void EquipManagment1()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("인벤토리 - 장착 관리");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("보유 중인 아이템 관리할 수 있습니다.");
            Console.WriteLine();
            Console.WriteLine("---------------------------------------[아이템 목록]----------------------------------------");
            Console.WriteLine();

            string e;
            foreach (var item in Program.itemList)
            {
                e = item.isEquip ? "[E]" : "[X]";
                Console.WriteLine($"- {e} {item.Name,-10}|{item.Stat,-5} +{item.StatBonus,-4}|{item.Description,-30}");
            }
            Console.WriteLine();
            Console.WriteLine("--------------------------------------------------------------------------------------------");

            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("1. 장착 관리 \n2. 아이템 정렬 \n0. 나가기");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine();
            Console.WriteLine("원하시는 행동을 입력해주세요.");
            Console.Write(">> ");

            int input = Program.CheckValidInput(0, 2);
            switch (input)
            {
                case 0:
                    DisplayGameIntro();
                    break;
                case 1:
                    EquipManagment2();
                    break;
                case 2:
                    InventoryArray1();
                    break;
            }
        }

        static void EquipManagment2() // 현재의 장착상태를 보여줌
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("인벤토리 - 장착 관리");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("보유 중인 아이템 관리할 수 있습니다.");
            Console.WriteLine();
            Console.WriteLine("---------------------------------------[아이템 목록]----------------------------------------");
            Console.WriteLine();

            int i = 0;
            string e;
            foreach (var item in itemList)
            {
                e = item.isEquip ? "[E]" : "[X]";

                i++; // 목록 앞 숫자
                Console.WriteLine($"- {i} {e} {item.Name,-10}|{item.Stat,-5} +{item.StatBonus,-4}|{item.Description,-30}");
                
            }
            Console.WriteLine();
            Console.WriteLine("--------------------------------------------------------------------------------------------");

            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("0. 나가기");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine();
            Console.WriteLine("아이템을 장착하고 싶다면 아이템 앞 번호를 입력해주세요. \n화면에서 나가려면 0번을 입력해주세요.");
            Console.Write(">> ");

            EquipManagment3();
            
        }

        static void EquipManagment3() // 장착상태를 변경하고 플레이어 상태를 수정함
        {
            int input = Program.CheckValidInput(0, itemList.Count);
            if (input == 0) // 0.나가기
            {
                DisplayGameIntro(); // 시작 화면
            }
            else if (itemList[input - 1].isEquip == true) // 1. 아이템[E] = true
            {
                // 장착상태를 변경 E -> X
                itemList[input - 1].isEquip = false; // 1. 아이템[E] = true -> false(장착 해제)

                // 플레이어 상태를 수정(Atk, Def 값 수정)
                if (itemList[input - 1].AtDf == 1) // 장착 해제
                { 
                    player.Atk = player.Atk - itemList[input - 1].StatBonus; 
                }
                else if((itemList[input - 1].AtDf == 0))
                { 
                    player.Def = player.Def - itemList[input - 1].StatBonus; 
                }
            }
            else // 1. 아이템[X] = false
            {
                // 장착상태를 변경 X -> E
                itemList[input - 1].isEquip = true; // 1. 아이템[X] = false -> true(장착 실행)

                if (itemList[input - 1].AtDf == 1) // 장착 실행
                { 
                    player.Atk = player.Atk + itemList[input - 1].StatBonus; 
                }
                else if ((itemList[input - 1].AtDf == 0))
                { 
                    player.Def = player.Def + itemList[input - 1].StatBonus; 
                }
            }

            EquipManagment2();
            
        }

        // 아이템 정렬
        static void InventoryArray1() 
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("인벤토리 - 아이템 정렬");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("보유 중인 아이템 관리할 수 있습니다.");
            Console.WriteLine();
            Console.WriteLine("---------------------------------------[아이템 목록]----------------------------------------");
            Console.WriteLine();

            int i = 0;
            string e;

            foreach (var item in itemList)
            {
                e = item.isEquip ? "[E]" : "[X]";

                i++; // 목록 앞 숫자
                Console.WriteLine($"- {i} {e} {item.Name,-10}|{item.Stat,-5} +{item.StatBonus,-4}|{item.Description,-30}");

            }
            Console.WriteLine();
            Console.WriteLine("--------------------------------------------------------------------------------------------");

            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("1. 이름\n2. 장착순\n3. 공격력\n4. 방어력 \n0. 나가기");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine();
            Console.WriteLine("원하시는 행동을 입력해주세요.");
            Console.Write(">> ");

            int input = Program.CheckValidInput(0, 4);
            switch (input)
            {
                case 0: // 나가기
                    DisplayGameIntro();
                    break;

                case 1: // 이름 정렬
                    itemList = itemList.OrderByDescending(x => x.Name.Length).ToList();
                    InventoryArray1();
                    break;

                case 2: // 장착순
                    itemList = itemList.OrderByDescending(x => x.isEquip).ToList();
                    InventoryArray1();
                    break;
                case 3: // 공격력
                    itemList = itemList.OrderByDescending(x => x.Stat == "공격력").ToList();
                    InventoryArray1();
                    break;
                case 4: // 방어력
                    itemList = itemList.OrderByDescending(x => x.Stat == "방어력").ToList();
                    InventoryArray1();
                    break;

            }
        }


    }
}