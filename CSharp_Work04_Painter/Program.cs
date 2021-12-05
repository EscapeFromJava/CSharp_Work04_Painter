using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Painter
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = @"INPUT.txt";
            string ss = File.ReadAllText(input);
            string[] words = ss.Split(' ', '\n','\r');
            int[] newWords = new int[words.Length];

            for (int i = 0, j = 0; i < words.Length; i++)
            {
                int number;
                bool flag = int.TryParse(words[i], out number);
                    if (flag)
                    {
                        newWords[j] = number;
                        j++;
                        flag = false;
                    }
            }
            int size1 = newWords[0];
            int size2 = newWords[1];
            int x1, x2, y1, y2;
            int[,] arr = new int[size1, size2];
            int num = newWords[2];
            int value = 3;
            while (num != 0)
            {
                x1 = newWords[value];
                y1 = newWords[value + 1];
                x2 = newWords[value + 2];
                y2 = newWords[value + 3];
                for (int j = x1; j < x2; j++)
                {
                    for (int k = y1; k < y2; k++)
                    {
                        arr[j, k] = 1;
                    }
                }
                value += 4;
                num--;
            }
            
            int count = 0;
            for (int i = 0; i < size1; i++)
            {
                for (int j = 0; j < size2; j++)
                {
                    if (arr[i, j] == 0)
                        count++;
                }
            }
            string result = count.ToString();
            string output = @"OUTPUT.txt";
            File.WriteAllText(output, result);
        }
    }
}
