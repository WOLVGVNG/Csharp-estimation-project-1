using System;
using System.Diagnostics;

namespace Project_1
{
    class MainClass
    {
        static ulong NumberOfOperations;
        static double ElapsedSeconds;
        static ulong NumberOfTests;

        static bool LinearSearchInstr(int[] Vector, int Number)
        {
            for (int i = 0; i < Vector.Length; i++)
            {
                NumberOfOperations++;
                if (i == Number) return true;
            }
            return false;
        }

        static bool LinearSearchTime(int[] Vector, int Number)
        {
            for (int i = 0; i < Vector.Length; i++)
            {
                if (i == Number) return true;
            }
            return false;
        }

        static bool BinarySearchInstr(int[] Vector, int Number)
        {
            int Left = 0, Right = Vector.Length - 1, Middle;
            while (Left <= Right)
            {
                Middle = (Left + Right) / 2;

                NumberOfOperations++;
                if (Vector[Middle] == Number)return true;

                if (Vector[Middle] > Number) Right = Middle - 1;
                else Left = Middle + 1;

            }
            return false;
        }

        static bool BinarySearchTime(int [] Vector, int Number)
        {
            int Left = 0, Right = Vector.Length - 1, Middle;
            while (Left <= Right)
            {
                Middle = (Left + Right) / 2;

                if (Vector[Middle] == Number) return true;

                if (Vector[Middle] > Number) Right = Middle - 1;
                else Left = Middle + 1;

            }
            return false;
        }

        //1. LinearMaxInstr -----------------------------------------------------------------------------------
        static void LinearMaxInstr(int[] Vector)
        {
            LinearSearchInstr(Vector, Vector.Length - 1);
        }

        //2. LinearMaxTime  -----------------------------------------------------------------------------------
        static void LinearMaxTime(int[] Vector)
        {
            long ElapsedTime = 0, MinTime = long.MaxValue, MaxTime = long.MinValue, IterationElapsedTime;
            for (int NumberOfControlTests = 0; NumberOfControlTests < 12; NumberOfControlTests++)
            {
                long StartingTime = Stopwatch.GetTimestamp();
                LinearSearchTime(Vector, Vector.Length - 1);
                long EndingTime = Stopwatch.GetTimestamp();

                IterationElapsedTime = EndingTime - StartingTime;
                ElapsedTime += IterationElapsedTime;

                if (IterationElapsedTime < MinTime) MinTime = IterationElapsedTime;
                if (IterationElapsedTime > MaxTime) MaxTime = IterationElapsedTime;
            }

            ElapsedTime -= (MinTime + MaxTime);
            ElapsedSeconds = ElapsedTime * (1.0 / (10 * Stopwatch.Frequency));
        }
 
        //3. LinearAvgInstr -----------------------------------------------------------------------------------
        static void LinearAvgInstr(int[] Vector)
        {
            for (int k = 0; k < Vector.Length; k += 1000000)
            {
                NumberOfTests++;
                LinearSearchInstr(Vector, k);
            }
            NumberOfOperations = (NumberOfOperations / NumberOfTests);
        }

        //4. LinearAvgTime  -----------------------------------------------------------------------------------
        static void LinearAvgTime(int[] Vector)
        {
            for (int k = 0; k < Vector.Length; k += 1000000)
            {
                NumberOfTests++;
                long ElapsedTime = 0, MinTime = long.MaxValue, MaxTime = long.MinValue, IterationElapsedTime;

                for (int NumberOfControlTests = 0; NumberOfControlTests < 12; NumberOfControlTests++)
                {
                    long StartingTime = Stopwatch.GetTimestamp();

                    LinearSearchTime(Vector, k);

                    long EndingTime = Stopwatch.GetTimestamp();
                    IterationElapsedTime = EndingTime - StartingTime;
                    ElapsedTime += IterationElapsedTime;

                    if (IterationElapsedTime < MinTime) MinTime = IterationElapsedTime;
                    if (IterationElapsedTime > MaxTime) MaxTime = IterationElapsedTime;
                }

                ElapsedTime -= (MinTime + MaxTime);
                ElapsedSeconds += ElapsedTime * (1.0 / (10 * Stopwatch.Frequency));
            }
            ElapsedSeconds = (ElapsedSeconds / NumberOfTests);
        }

        //5. BinaryMaxInstr -----------------------------------------------------------------------------------
        static void BinaryMaxInstr(int[] Vector)
        {
            BinarySearchInstr(Vector, Vector.Length - 1);
        }

        //6. BinaryMaxTime  -----------------------------------------------------------------------------------
        static void BinaryMaxTime(int[] Vector)
        {
            long ElapsedTime = 0, MinTime = long.MaxValue, MaxTime = long.MinValue, IterationElapsedTime;
            for (int NumberOfControlTests = 0; NumberOfControlTests < 12; NumberOfControlTests++)
            {
                long StartingTime = Stopwatch.GetTimestamp();

                BinarySearchTime(Vector, Vector.Length - 1);

                long EndingTime = Stopwatch.GetTimestamp();
                IterationElapsedTime = EndingTime - StartingTime;
                ElapsedTime += IterationElapsedTime;

                if (IterationElapsedTime < MinTime) MinTime = IterationElapsedTime;
                if (IterationElapsedTime > MaxTime) MaxTime = IterationElapsedTime;
            }

            ElapsedTime -= (MinTime + MaxTime);
            ElapsedSeconds = ElapsedTime * (1.0 / (10 * Stopwatch.Frequency));
        }

        //7. BinaryAvgInstr -----------------------------------------------------------------------------------
        static void BinaryAvgInstr(int[] Vector)
        {
            for (int k = 0; k < Vector.Length; k += 1000000)
            {
                NumberOfTests++;
                BinarySearchInstr(Vector, k);
            }
            NumberOfOperations = (NumberOfOperations / NumberOfTests);
        }

        //8. BinaryAvgTime  -----------------------------------------------------------------------------------
        static void BinaryAvgTime(int[] Vector)
        {
            for (int k = 0; k < Vector.Length; k += 1000000)
            {
                NumberOfTests++;
                long ElapsedTime = 0, MinTime = long.MaxValue, MaxTime = long.MinValue, IterationElapsedTime;

                for (int NumberOfControlTests = 0; NumberOfControlTests < 12; NumberOfControlTests++)
                {
                    long StartingTime = Stopwatch.GetTimestamp();

                    BinarySearchTime(Vector, k);

                    long EndingTime = Stopwatch.GetTimestamp();
                    IterationElapsedTime = EndingTime - StartingTime;
                    ElapsedTime += IterationElapsedTime;

                    if (IterationElapsedTime < MinTime) MinTime = IterationElapsedTime;
                    if (IterationElapsedTime > MaxTime) MaxTime = IterationElapsedTime;
                }

                ElapsedTime -= (MinTime + MaxTime);
                ElapsedSeconds += ElapsedTime * (1.0 / (10 * Stopwatch.Frequency));
            }
            ElapsedSeconds = (ElapsedSeconds / NumberOfTests);
        }

        //------- MAIN -----------------------------------------------------------------------
        public static void Main(string[] args)
        {
            int choice = 0;
            int[] ArraySize = new int[10];
            ArraySize[0] = 26843545;

            for (int i = 1; i < ArraySize.Length; i++)
            {
                ArraySize[i] = ArraySize[i-1] + 26843545;
            }

            do
            {
                Console.WriteLine("Jaką oprację chcesz wykonać?\n");
                Console.WriteLine("1. Wyszukiwanie liniowe - pesymistyczne - instrumentacja");
                Console.WriteLine("2. Wyszukiwanie liniowe - pesymistyczne - czas\n");
                Console.WriteLine("3. Wyszukiwanie liniowe - średnie - instrumentacja");
                Console.WriteLine("4. Wyszukiwanie liniowe - średnie - czas\n");
                Console.WriteLine("5. Wyszukiwanie binarne - pesymistyczne - instrumentacja");
                Console.WriteLine("6. Wyszukiwanie binarne - pesymistyczne - czas\n");
                Console.WriteLine("7. Wyszukiwanie binarne - średnie - instrumentacja");
                Console.WriteLine("8. Wyszukiwanie binarne - średnie - czas\n");
                Console.WriteLine("0. Zakończ prorgram\n");
                Console.Write("Twój wybór:");
                choice = int.Parse(Console.ReadLine());
                Console.WriteLine("\n\n");

                if (choice == 1
                    || choice == 2
                    || choice == 3
                    || choice == 4
                    || choice == 5
                    || choice == 6
                    || choice == 7
                    || choice == 8)
                {
                    switch (choice)
                    {
                        case 1:
                        case 3:
                        case 5:
                        case 7:
                            Console.WriteLine("n\t\t\tOperations");
                            break;

                        case 2:
                        case 4:
                        case 6:
                        case 8:
                            Console.WriteLine("n\t\tElapsed seconds");
                            break;
                    }


                    for (int i = 0; i < ArraySize.Length; i++)
                    {
                        int[] Vector = new int[ArraySize[i]];
                        for (int j = 0; j < ArraySize[i]; j++)
                        {
                            Vector[j] = j;
                        }

                        NumberOfOperations = 0;
                        ElapsedSeconds = 0;
                        NumberOfTests = 0;

                        // ----- MIEJSCE WYWYOŁYWANIA FUNKCJI ------------------------------------------------------------
                        switch (choice)
                        {
                            case 1:
                                LinearMaxInstr(Vector);
                                Console.WriteLine("{0}\t\t{1}", Vector.Length, NumberOfOperations);
                                break;

                            case 2:
                                LinearMaxTime(Vector);
                                Console.WriteLine("{0}\t{1}", Vector.Length, ElapsedSeconds.ToString("F4"));
                                break;

                            case 3:
                                LinearAvgInstr(Vector);
                                Console.WriteLine("{0}\t\t{1}", Vector.Length, NumberOfOperations);
                                break;

                            case 4:
                                LinearAvgTime(Vector);
                                Console.WriteLine("{0}\t{1}", Vector.Length, ElapsedSeconds.ToString("F4"));
                                break;

                            case 5:
                                BinaryMaxInstr(Vector);
                                Console.WriteLine("{0}\t\t{1}", Vector.Length, NumberOfOperations);
                                break;

                            case 6:
                                BinaryMaxTime(Vector);
                                Console.WriteLine("{0}\t{1}", Vector.Length, ElapsedSeconds.ToString("F4"));
                                break;

                            case 7:
                                BinaryAvgInstr(Vector);
                                Console.WriteLine("{0}\t\t{1}", Vector.Length, NumberOfOperations);
                                break;

                            case 8:
                                BinaryAvgTime(Vector);
                                Console.WriteLine("{0}\t{1}", Vector.Length, ElapsedSeconds.ToString("F4"));
                                break;
                        }
                    }

                    if (choice != 0)
                    {
                        Console.WriteLine("\n\n################################################################################################################");
                    }
                }
                else if (choice == 0)
                {
                    Console.WriteLine("Koniec programu");
                }
                else
                {
                    Console.Write("\n\n\n\nDokonałeś złego wyboru, naciśnij dowolny przycisk i spróbuj ponownie\n");
                }
            } while (choice != 0);
        }
    }
}