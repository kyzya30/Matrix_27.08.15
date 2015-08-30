using System;
using System.Threading;

namespace Matrix_27._08._15
{
    
    internal class Program
    {
        private ParameterizedThreadStart pts = new ParameterizedThreadStart(Matrix.WorkingThread);
        private static void Main(string[] args)
        {
            Console.Title = "MATRIX";
            Console.SetWindowSize(53, 32);
            Console.CursorVisible = false;
            Console.SetWindowPosition(0, 1);
            Thread[] poolOfThreads = new Thread[51];
            for (int i = 1; i < 51; i++)
            {
                poolOfThreads[i] = new Thread(new ParameterizedThreadStart(Matrix.WorkingThread));
                poolOfThreads[i].Start(i);
            }
        }
    }
    class Matrix
    {
        static Random r = new Random();
        public static void WorkingThread(Object o)
        {
            
            string s = "LOKER";
            int column = (int)o;
            char[] first;

            while (true)
            {
                Thread.Sleep(r.Next(4000));
                Console.CursorTop = 1;
                char[] temp = new char[r.Next(3, 6)];//Array

                for (int row = 1; row < 40; row++)//Position of Console.Write()
                {
                    for (int i = 0; i < temp.Length; i++)//Generate new char to array
                    {
                        temp[i] = (char)r.Next(0x0030, 0x0122);

                    }
                    first = temp;
                    Thread.Sleep(100);

                    lock (s)
                    {
                        for (int i = 0; i < first.Length - 1; i++)
                        {
                            if (i == 0)
                            {
                                if (row >= 29)
                                {
                                }
                                else
                                {
                                    Console.ForegroundColor = ConsoleColor.White;
                                    Console.SetCursorPosition(column, row);
                                    Console.Write(first[i]);
                                }
                            }

                            if (i == 1)
                            {
                                if (row - i <= 0 || row - first.Length >= 29)
                                {
                                }
                                else
                                {
                                    Console.ForegroundColor = ConsoleColor.Green;
                                    Console.SetCursorPosition(column, row - i);
                                    Console.Write(first[i]);
                                }
                            }

                            if (i >= 2)
                            {
                                if (row - i <= 0 || row - first.Length >= 29)
                                {
                                }
                                else
                                {
                                    Console.ForegroundColor = ConsoleColor.DarkGreen;
                                    Console.SetCursorPosition(column, row - i);
                                    Console.Write(first[i]);
                                }
                            }

                            if (row - first.Length <= 0 || row - first.Length >= 33)
                            {
                            }
                            else
                            {
                                Console.SetCursorPosition(column, row - first.Length);
                                Console.Write(" ");
                            }
                        }
                    }
                }
            }
        }
    }
}
