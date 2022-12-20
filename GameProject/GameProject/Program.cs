using System;
using System.Numerics;
using System.Reflection;
using System.Runtime.CompilerServices;

namespace GameProject
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var gamePlayers = new string[2] { "张三", "李四" };
            var goods = new int[3] { 3, 5, 7 };
            Console.WriteLine($"--------------游戏开始------------");
            var s = PlayGame(gamePlayers, goods);
            Console.WriteLine($"-------------游戏结束,{s}赢了!---------------");
            Console.WriteLine("输入任意字符结束");
            Console.Read();
        }

        /// <summary>
        /// 游戏规则
        /// </summary>
        /// <param name="gamePlayers">玩家</param>
        /// <param name="goods">物品摆放情况</param>
        /// <returns></returns>
        private static string PlayGame(string[] gamePlayers, int[] goods)
        {
            var index = 0;
            do
            {
                Console.WriteLine("--------------当前物品摆放情况---------------");
                PrintPlacement(goods);

                var length = gamePlayers.Length;
                Console.WriteLine($"--------------请{gamePlayers[index % length]}进行选择-------------");
                Console.WriteLine("选择行数：");
                var rowIndexStr = Console.ReadLine();
                if (!int.TryParse(rowIndexStr, out int rowIndex))
                {
                    Console.WriteLine("输入错误,请重新输入！");
                    continue;
                }
                else if (rowIndex > goods.Length)
                {
                    Console.WriteLine($"输入错误,行数不能超过{goods.Length},请重新输入！");
                    continue;
                }
                else if (goods[rowIndex - 1] <= 0)
                {
                    Console.WriteLine($"第{rowIndex}行已被拿完,请重新选择！");
                    continue;
                }
                Console.WriteLine("选择根数：");
                var countStr = Console.ReadLine();
                if (!int.TryParse(countStr, out int count))
                {
                    Console.WriteLine("输入错误,请重新输入！");
                    continue;
                }
                else if (count > goods[rowIndex - 1])
                {
                    Console.WriteLine($"第{rowIndex}行只剩{goods[rowIndex - 1]}根,请重新选择！");
                    continue;
                }
                goods[rowIndex - 1] -= count;
                if (goods.Sum() <= 0)
                {
                    return gamePlayers[index % length];
                }
                index++;

            } while (true);
        }

        /// <summary>
        /// 打印当前物品摆放情况
        /// </summary>
        /// <param name="goods"></param>
        private static void PrintPlacement(int[] goods)
        {
            for (var index = 0; index < goods.Length; index++)
            {
                Console.WriteLine($"第{index + 1}行：{goods[index]}");
            }
        }
    }
}