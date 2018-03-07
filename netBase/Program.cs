

using System;
using System.Collections.Generic;

namespace HashSearch.CSharp
{
    class Program
    {
        //初始化哈希表
        static int hashLength = 7;
        static int[] hashTable = new int[hashLength];

        //原始数据
        static List<int> list = new List<int>() { 13, 29, 27, 28, 26, 30, 38 };

        static void Main(string[] args)
        {
            Console.WriteLine("********************哈希查找(C#版)********************\n");

            //创建哈希表
            for (int i = 0; i < list.Count; i++)
            {
                Insert(hashTable, list[i]);
            }
            Console.WriteLine("展示哈希表中的数据：{0}", String.Join(",", hashTable));

            while (true)
            {
                //哈希表查找
                Console.Write("请输入要查找的数据:");
                int data = int.Parse(Console.ReadLine());
                var result = Search(hashTable, data);
                if (result == -1) Console.WriteLine("对不起，没有找到!");
                else Console.WriteLine("数据的位置是：{0}", result);
            }
        }

        /// <summary>
        /// 哈希表插入
        /// </summary>
        /// <param name="hashTable">哈希表</param>
        /// <param name="data">待插入值</param>
        public static void Insert(int[] hashTable, int data)
        {
            //哈希函数,除留余数法
            int hashAddress = Hash(hashTable, data);

            //如果不为0，则说明发生冲突
            while (hashTable[hashAddress] != 0)
            {
                //利用开放定址的线性探测法解决冲突
                hashAddress = (++hashAddress) % hashTable.Length;
            }

            //将待插入值存入字典中
            hashTable[hashAddress] = data;
        }

        /// <summary>
        /// 哈希表查找
        /// </summary>
        /// <param name="hashTable">哈希表</param>
        /// <param name="data">待查找的值</param>
        /// <returns></returns>
        public static int Search(int[] hashTable, int data)
        {
            //哈希函数,除留余数法
            int hashAddress = Hash(hashTable, data);

            //冲突发生
            while (hashTable[hashAddress] != data)
            {
                //利用开放定址的线性探测法解决冲突
                hashAddress = (++hashAddress) % hashTable.Length;

                //查找到了开放单元或者循环回到原点，表示查找失败
                if (hashTable[hashAddress] == 0 || hashAddress == Hash(hashTable, data)) return -1;
            }
            //查找成功,返回值的下标
            return hashAddress;
        }

        /// <summary>
        /// 哈希函数(除留余数法)
        /// </summary>
        /// <param name="hashTable">待操作哈希表</param>
        /// <param name="data"></param>
        /// <returns>返回数据的位置</returns>
        public static int Hash(int[] hashTable, int data)
        {
            return data % hashTable.Length;
        }
    }
}
