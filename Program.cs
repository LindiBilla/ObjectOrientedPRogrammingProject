using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Collections;
namespace assignment1
{
    class Program
    {
        static void Main(string[] args)
        {
            // You must replace this with the class you create
            // that uses a doubly linked list:
           
            MyDeque L = new MyDeque();

            //The code below "ReadALLLines" reads from a directory from my computer
            //please change the directory below and put yours instead, after you have download integers.txt at your computer


            string[] list = File.ReadAllLines(@"C:\Users\arlin\Documents\GitHub\BLG252E_2020Spring\assignment1\integers.txt");

            for(int i = 0; i < list.Length; i++)
            {
                L.Push(int.Parse(list[i]));
            }

            foreach(var item in L)
            {
                Console.WriteLine(item);
            }

        }
    }
}