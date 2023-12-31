﻿using System.Collections.Generic;
using System.Numerics;

namespace Assigments_01
{
    class Program
    {
        public static Character player;
        private static List<Item> itemList = new List<Item>();
        private static List<StoreItems> storeList = new List<StoreItems>();


        static void Main(string[] args)
        {
            GameDataSetting();
            DisplayGameIntro(); // 시작 화면

        }

        // ★ 게임 세팅
        static void GameDataSetting()
        {
            // ◆ 캐릭터 정보 세팅
            player = new Character("John", "전사", 1, 0, 5, 100, 1500); // 이름, 직업, 레벨, 공격력, 방어력, 생명력, 골드

            // ◆ 아이템 정보 세팅
            itemList.Add(new Item(true, "무쇠갑옷", "방어력", 5, "무쇠로 만들어져 튼튼한 갑옷입니다.", 0, 300, true));
            itemList.Add(new Item(false, "낡은 검", "공격력", 2, "쉽게 볼 수 있는 낡은 검 입니다.", 1, 200, true));
            itemList.Add(new Item(false, "신성한 활", "공격력", 3, "신성한 힘을 담아 원거리에서 정확한 공격을 수행하는 활입니다.", 1, 400, true));
            itemList.Add(new Item(false, "마력 방어 망토", "방어력", 4, "마법 방어에 특화되어 있어 저항력을 부여하는 망토입니다.", 0, 300, true));

            // ◆ 상점 아이템 정보 세팅
            // 기본 아이템
            storeList.Add(new StoreItems(true, "무쇠갑옷", "방어력", 5, "무쇠로 만들어져 튼튼한 갑옷입니다.", 0, 300, true));
            storeList.Add(new StoreItems(false, "낡은 검", "공격력", 2, "쉽게 볼 수 있는 낡은 검 입니다.", 1, 200, true));
            storeList.Add(new StoreItems(false, "신성한 활", "공격력", 3, "신성한 힘을 담아 원거리에서 정확한 공격을 수행하는 활입니다.", 1, 400, true));
            storeList.Add(new StoreItems(false, "마력 방어 망토", "방어력", 4, "마법 방어에 특화되어 있어 저항력을 부여하는 망토입니다.", 0, 300, true));

            // 상점 아이템
            storeList.Add(new StoreItems(false, "미스릴 방패", "방어력", 6, "가벼우면서도 튼튼한 미스릴로 만든 매우 높은 방어력을 제공하는 방패입니다.", 0, 700, false));
            storeList.Add(new StoreItems(false, "용의 뿔 투구", "방어력", 2, "용의 뿔을 소재로 견고하게 만든 투구입니다.", 0, 200, false));
            storeList.Add(new StoreItems(false, "번개 가죽 장갑", "공격력", 4, "가볍고 신속한 움직임을 위한 손보호구로 민첩성을 높여주는 장갑입니다.", 1, 600, false));
            storeList.Add(new StoreItems(false, "불타는 도끼", "공격력", 8, "불꽃으로 베어내며 화염 공격을 가하는 도끼입니다.", 1, 1500, false));
        }


        // ★ 입력가능 여부 및 입력값 리턴
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

        // ★ 1. 시작 화면
        public static void DisplayGameIntro()
        {
            Console.Clear();

            Console.WriteLine();
            Console.WriteLine("♣ 스파르타 마을에 오신 여러분 환영합니다. ♣");
            Console.WriteLine("이곳에서 던전으로 들어가기 전 활동을 할 수 있습니다.");
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("1. 상태 보기 \n2. 인벤토리 \n3. 상점");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine();
            Console.WriteLine("원하시는 행동을 입력해주세요.");
            Console.Write(">> ");

            int input = CheckValidInput(1, 3);
            switch (input)
            {
                case 1:
                    PlayerState(); // 플레이어 상태 보기
                    break;
                case 2:
                    Inventory(); // 인벤토리
                    break;
                case 3:
                    Store(); // 상점
                    break;
            }

        }

        // ★ 2. 플레이어 상태 보기
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
                    DisplayGameIntro(); // 시작화면
                    break;
            }
        }



        // ★ 3. 인벤토리
        static void Inventory()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("인벤토리");
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
                    DisplayGameIntro(); // 시작화면
                    break;
                case 1:
                    EquipManagment1(); // 장착 관리
                    break;
                case 2:
                    InventoryArray(); // 문자열 정렬
                    break;
            }
        }

        // ★ 장착 관리
        static void EquipManagment1() // 현재의 장착상태를 보여줌
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

            EquipManagment2();

        }

        static void EquipManagment2() // 장착상태를 변경하고 플레이어 상태를 수정함
        {
            int input = Program.CheckValidInput(0, itemList.Count);
            if (input == 0) // 0.나가기
            {
                Inventory(); // 인벤토리 화면
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
                else if ((itemList[input - 1].AtDf == 0))
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

            EquipManagment1();

        }

        // ★ 아이템 정렬
        static void InventoryArray()
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
                    Inventory(); // 인벤토리 화면
                    break;

                case 1: // 이름 정렬
                    itemList = itemList.OrderByDescending(x => x.Name.Length).ToList();
                    InventoryArray();
                    break;

                case 2: // 장착순
                    itemList = itemList.OrderByDescending(x => x.isEquip).ToList();
                    InventoryArray();
                    break;
                case 3: // 공격력
                    itemList = itemList.OrderByDescending(x => x.Stat == "공격력").ToList();
                    InventoryArray();
                    break;
                case 4: // 방어력
                    itemList = itemList.OrderByDescending(x => x.Stat == "방어력").ToList();
                    InventoryArray();
                    break;
            }
        }

        // ★ 4. 상점
        static void Store()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("상점");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("필요한 아이템을 얻을 수 있는 상점입니다.");
            Console.WriteLine();
            Console.WriteLine("[보유 골드]");
            Console.WriteLine($"{player.Gold} G");
            Console.WriteLine();
            Console.WriteLine("---------------------------------------[아이템 목록]----------------------------------------");
            Console.WriteLine();

            int i = 0;
            string c;
            foreach (var items in storeList)
            {
                bool isInInventory = itemList.Any(item => item.Name == items.Name && item.Stat == items.Stat && item.StatBonus == items.StatBonus);
                c = isInInventory ? "구매완료" : $"{items.Price} G";
                i++; // 목록 앞 숫자
                Console.WriteLine($"- {items.Name,-10}|{items.Stat,-5} +{items.StatBonus,-4}|{items.Description,-35}|{c}");
            }
            Console.WriteLine();
            Console.WriteLine("--------------------------------------------------------------------------------------------");

            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("1. 아이템 구매 \n2. 아이템 판매 \n0. 나가기");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine();
            Console.WriteLine("원하시는 행동을 입력해주세요.");
            Console.Write(">> ");

            int input = Program.CheckValidInput(0, 2);
            switch (input)
            {
                case 0: // 나가기
                    DisplayGameIntro(); // 시작 화면
                    break;
                case 1:
                    Buy(); // 아이템 구매
                    Store();
                    break;
                case 2:
                    Sale(); // 아이템 판매
                    Store();
                    break;
            }
        }

        // 아이템 구매
        static void Buy()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("상점 - 아이템 구매");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("필요한 아이템을 얻을 수 있는 상점입니다.");
            Console.WriteLine();
            Console.WriteLine("[보유 골드]");
            Console.WriteLine($"{player.Gold} G");
            Console.WriteLine();
            Console.WriteLine("---------------------------------------[아이템 목록]----------------------------------------");
            Console.WriteLine();

            int i = 0;
            string c;
            foreach (var items in storeList)
            {
                bool isInInventory = itemList.Any(item => item.Name == items.Name && item.Stat == items.Stat && item.StatBonus == items.StatBonus);
                c = isInInventory ?  "구매완료" : $"{items.Price} G";
                i++; // 목록 앞 숫자
                Console.WriteLine($"- {i} {items.Name,-10}|{items.Stat,-5} +{items.StatBonus,-4}|{items.Description,-35}|{c}");
            }
            Console.WriteLine();
            Console.WriteLine("--------------------------------------------------------------------------------------------");

            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("0. 나가기");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine();

            while (true)
            {
                Console.WriteLine("원하시는 행동을 입력해주세요.");
                Console.Write(">> ");
                int input = Program.CheckValidInput(0, storeList.Count);
                if (input == 0)
                {
                    Store(); // 상점
                    break;
                }
                else
                {
                    StoreItems purchaseditem = (StoreItems)storeList[input - 1];

                    if (purchaseditem.isMyItem == true) // 구매했나요? ->  예
                    {
                        Console.ForegroundColor = ConsoleColor.Blue;
                        Console.WriteLine("이미 구매한 아이템입니다.");
                        Console.ForegroundColor = ConsoleColor.White;
                    }
                    else
                    {
                        // 플레이어 골드로 구매가 가능한지
                        if (player.Gold >= purchaseditem.Price) // 구매 가능(플레이어 돈 > 제품 돈)
                        {
                            player.Gold -= purchaseditem.Price; // 상점에서 아이템 구매 -> 플레이어 돈 차감
                            purchaseditem.isMyItem = true;
                            Program.itemList.Add(purchaseditem); // 새로운 아이템을 플레이어의 itemList에 추가(구매한 상점 아이템 -> 인벤토리 리스트)
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.WriteLine($"구매 완료되었습니다. 남은 골드는 {player.Gold}G입니다.");
                            Console.ForegroundColor = ConsoleColor.White;
                        }
                        else // 구매 불가능(플레이어 돈 < 제품 돈)
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("골드가 부족합니다.");
                            Console.ForegroundColor = ConsoleColor.White;
                        }
                    }
                }
            }


        }

        static void Sale()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("상점 - 아이템 판매");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("필요한 아이템을 얻을 수 있는 상점입니다.");
            Console.WriteLine();
            Console.WriteLine("[보유 골드]");
            Console.WriteLine($"{player.Gold} G");
            Console.WriteLine();
            Console.WriteLine("---------------------------------------[아이템 목록]----------------------------------------");
            Console.WriteLine();

            int i = 0;
            string e;
            string c;
            foreach (var item in itemList)
            {
                //e = item.isEquip ? "[E]" : "[X]"; 
                c = item.isMyItem ? "구매완료" : $"{item.Price} G";
                i++; // 목록 앞 숫자
                Console.WriteLine($"- {i} {item.Name,-10}|{item.Stat,-5} +{item.StatBonus,-4}|{item.Description,-30}|{c}");

            }
            Console.WriteLine();
            Console.WriteLine("--------------------------------------------------------------------------------------------");

            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("0. 나가기");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine();
            Console.WriteLine("원하시는 행동을 입력해주세요.");
            Console.Write(">> ");

            int input = Program.CheckValidInput(0, itemList.Count);

            if (input == 0)
            {
                Store(); // 상점
            }
            else
            {
                if (itemList[input - 1].isMyItem) // 내 아이템 O
                {
                    itemList[input - 1].isMyItem = false; // 내 아이템 X
                    
                    
                    if (itemList[input - 1].AtDf == 0 && itemList[input - 1].isEquip == true) // 방어력 아이템이고, 아이템 장착 시
                    {
                        player.Def -= itemList[input - 1].StatBonus; // 플레이어 방어력 감소
                    }
                    else if (itemList[input - 1].AtDf == 1 && itemList[input - 1].isEquip == true) // 공격력 아이템이고, 아이템 장착 시
                    {
                        player.Atk -= itemList[input - 1].StatBonus; // 플레이어 공격력 감소
                    }
                    itemList[input - 1].isEquip = false; // 장착 해제
                    itemList.RemoveAt(input - 1);

                    // 아이템 85% 가격으로 판매 -> 플레이어 골드 증가 
                    int SellingPrice = (int)(storeList[input - 1].Price * 0.85);
                    player.Gold += SellingPrice;
                }
            }
        }
    }
}


