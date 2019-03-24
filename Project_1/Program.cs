using System;
using System.Diagnostics;

namespace Project_1
{
    class MainClass
    {
        static ulong OpAssignment;
        static ulong OpComparisonLT;
        static ulong OpIncrement;
        static ulong OpComparisonEQ;
        static double ElapsedSeconds;
        static ulong NumberOfTests;


        //1. LinearMaxInstr -----------------------------------------------------------------------------------
        static bool LinearMaxInstr(int[] Vector, int Number)
        {
            OpAssignment = OpComparisonLT = 1;
            for (int i = 0; i < Vector.Length; i++, OpIncrement++)
            {
                OpComparisonEQ++;
                if (i == Number) return true;
                OpComparisonLT++;
            }
            return false;
        }


        //2. LinearMaxTime  -----------------------------------------------------------------------------------
        static bool LinearMaxTime(int[] Vector, int Number)
        {
            long ElapsedTime = 0, MinTime = long.MaxValue, MaxTime = long.MinValue, IterationElapsedTime;
            for (int NumberOfControlTests = 0; NumberOfControlTests < 12; NumberOfControlTests++)
            {
                long StartingTime = Stopwatch.GetTimestamp();

                for (int i = 0; i < Vector.Length; i++)
                {
                    if (i == Number) return true;
                }

                long EndingTime = Stopwatch.GetTimestamp();
                IterationElapsedTime = EndingTime - StartingTime;
                ElapsedTime += IterationElapsedTime;

                if (IterationElapsedTime < MinTime) MinTime = IterationElapsedTime;
                if (IterationElapsedTime > MaxTime) MaxTime = IterationElapsedTime;
            }

            ElapsedTime -= (MinTime + MaxTime);
            ElapsedSeconds = ElapsedTime * (1.0 / (10 * Stopwatch.Frequency));

            return false;
        }




        /*
        static bool LinearMaxTime(int[] Vector, int Number)
        {
            long StartingTime = Stopwatch.GetTimestamp();

            for (int i = 0; i < Vector.Length; i++)
            {
                if (i == Number) return true;
            }

            long EndingTime = Stopwatch.GetTimestamp();
            long ElapsedTime = EndingTime - StartingTime;
            ElapsedSeconds = ElapsedTime * (1.0 / Stopwatch.Frequency);

            return false;
        }*/       

        //3. LinearAvgInstr -----------------------------------------------------------------------------------
        static bool LinearAvgInstr(int[] Vector, int Number)
        {
            OpAssignment++;
            OpComparisonLT++;
            for (int i =0; i < Vector.Length; i++, OpIncrement++)
            {
                OpComparisonEQ++;
                if (i == Number) return true;
                OpComparisonLT++;
            }
            return false;
        }


        //4. LinearAvgTime  -----------------------------------------------------------------------------------
        static bool LinearAvgTime(int[] Vector, int Number)
        {
            long ElapsedTime = 0, MinTime = long.MaxValue, MaxTime = long.MinValue, IterationElapsedTime;
            for (int NumberOfControlTests = 0; NumberOfControlTests < 12; NumberOfControlTests++)
            {
                long StartingTime = Stopwatch.GetTimestamp();

                for (int i = 0; i < Vector.Length; i++)
                {
                    if (i == Number) return true;
                }

                long EndingTime = Stopwatch.GetTimestamp();
                IterationElapsedTime = EndingTime - StartingTime;
                ElapsedTime += IterationElapsedTime;

                if (IterationElapsedTime < MinTime) MinTime = IterationElapsedTime;
                if (IterationElapsedTime > MaxTime) MaxTime = IterationElapsedTime;
            }

            ElapsedTime -= (MinTime + MaxTime);
            ElapsedSeconds += ElapsedTime * (1.0 / (10 * Stopwatch.Frequency));

            return false;
        }


        /*
        static bool LinearAvgTime(int[] Vector, int Number)
        {
            long StartingTime = Stopwatch.GetTimestamp();

            for (int i = 0; i < Vector.Length; i++)
            {
                if (i == Number)
                {
                    return true;
                }

            }

            long EndingTime = Stopwatch.GetTimestamp();
            long ElapsedTime = EndingTime - StartingTime;
            ElapsedSeconds = ElapsedTime * (1.0 / Stopwatch.Frequency);

            return false;
        }
        */


        //5. BinaryMaxInstr -----------------------------------------------------------------------------------
        static bool BinaryMaxInstr(int[] Vector, int Number)
        {
            OpAssignment = 2;
            OpComparisonLT = 1;
            int Left = 0, Right = Vector.Length - 1, Middle;
            while (Left <= Right)
            {
                OpAssignment++;
                Middle = (Left + Right) / 2;

                OpComparisonEQ++;
                if (Vector[Middle] == Number) return true;

                OpComparisonLT++;
                OpAssignment++;
                if (Vector[Middle] > Number) Right = Middle - 1;
                else Left = Middle + 1;

                OpComparisonLT++;
            }
            return false;
        }


        //6. BinaryMaxTime  -----------------------------------------------------------------------------------
        static bool BinaryMaxTime(int[] Vector, int Number)
        {
            long ElapsedTime = 0, MinTime = long.MaxValue, MaxTime = long.MinValue, IterationElapsedTime;
            for (int NumberOfControlTests = 0; NumberOfControlTests < 12; NumberOfControlTests++)
            {
                long StartingTime = Stopwatch.GetTimestamp();

                int Left = 0, Right = Vector.Length - 1, Middle;
                while (Left <= Right)
                {
                    Middle = (Left + Right) / 2;
                    if (Vector[Middle] == Number) return true;
                    if (Vector[Middle] > Number) Right = Middle - 1;
                    else Left = Middle + 1;
                }

                long EndingTime = Stopwatch.GetTimestamp();
                IterationElapsedTime = EndingTime - StartingTime;
                ElapsedTime += IterationElapsedTime;

                if (IterationElapsedTime < MinTime) MinTime = IterationElapsedTime;
                if (IterationElapsedTime > MaxTime) MaxTime = IterationElapsedTime;
            }

            ElapsedTime -= (MinTime + MaxTime);
            ElapsedSeconds = ElapsedTime * (1.0 / (10 * Stopwatch.Frequency));

            return false;
        }


        /*static bool BinaryMaxTime(int[] Vector, int Number)
        {
            long StartingTime = Stopwatch.GetTimestamp();

            int Left = 0, Right = Vector.Length - 1, Middle;
            while (Left <= Right)
            {
                Middle = (Left + Right) / 2;
                if (Vector[Middle] == Number) return true;
                if (Vector[Middle] > Number) Right = Middle - 1;
                else Left = Middle + 1;
            }

            long EndingTime = Stopwatch.GetTimestamp();
            long ElapsedTime = EndingTime - StartingTime;
            ElapsedSeconds = ElapsedTime * (1.0 / Stopwatch.Frequency);

            return false;
        }*/


        //7. BinaryAvgInstr -----------------------------------------------------------------------------------
        static bool BinaryAvgInstr(int[] Vector, int Number)
        {
            OpAssignment += 2;
            OpComparisonLT += 1;
            int Left = 0, Right = Vector.Length - 1, Middle;
            while (Left <= Right)
            {
                OpAssignment++;
                Middle = (Left + Right) / 2;

                OpComparisonEQ++;
                if (Vector[Middle] == Number) return true;

                OpComparisonLT++;
                OpAssignment++;
                if (Vector[Middle] > Number) Right = Middle - 1;
                else Left = Middle + 1;

                OpComparisonLT++;
            }
            return false;
        }


        //8. BinaryAvgTime  -----------------------------------------------------------------------------------
        static bool BinaryAvgTime(int[] Vector, int Number)
        {
            long ElapsedTime = 0, MinTime = long.MaxValue, MaxTime = long.MinValue, IterationElapsedTime;
            for (int NumberOfControlTests = 0; NumberOfControlTests < 12; NumberOfControlTests++)
            {
                long StartingTime = Stopwatch.GetTimestamp();

                int Left = 0, Right = Vector.Length - 1, Middle;
                while (Left <= Right)
                {
                    Middle = (Left + Right) / 2;
                    if (Vector[Middle] == Number) return true;
                    if (Vector[Middle] > Number) Right = Middle - 1;
                    else Left = Middle + 1;
                }

                long EndingTime = Stopwatch.GetTimestamp();
                IterationElapsedTime = EndingTime - StartingTime;
                ElapsedTime += IterationElapsedTime;

                if (IterationElapsedTime < MinTime) MinTime = IterationElapsedTime;
                if (IterationElapsedTime > MaxTime) MaxTime = IterationElapsedTime;
            }

            ElapsedTime -= (MinTime + MaxTime);
            ElapsedSeconds += ElapsedTime * (1.0 / (10 * Stopwatch.Frequency));

            return false;
        }

        /*static bool BinaryAvgTime(int[] Vector, int Number)
        {
            long StartingTime = Stopwatch.GetTimestamp();

            int Left = 0, Right = Vector.Length - 1, Middle;
            while (Left <= Right)
            {
                Middle = (Left + Right) / 2;
                if (Vector[Middle] == Number) return true;
                if (Vector[Middle] > Number) Right = Middle - 1;
                else Left = Middle + 1;
            }

            long EndingTime = Stopwatch.GetTimestamp();
            long ElapsedTime = EndingTime - StartingTime;
            ElapsedSeconds = ElapsedTime * (1.0 / Stopwatch.Frequency);

            return false;
        }*/




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

                if (choice == 1 || choice == 2 || choice == 3 || choice == 4 || choice == 5 || choice == 6 || choice == 7 || choice == 8)
                {
                    switch (choice)
                    {
                        case 1:
                        case 3:
                        case 5:
                        case 7:
                            Console.WriteLine("n\t\t\tOpAssignment\tOpComparisonLT\t\tOpIncrement\t\tOpComparisonEQ");
                            break;

                        case 2:
                        case 4:
                        case 6:
                        case 8:
                            Console.WriteLine("n\t\tElapsedSeconds");
                            break;
                    }


                    for (int i = 0; i < ArraySize.Length; i++)
                    {
                        int[] Vector = new int[ArraySize[i]];
                        for (int j = 0; j < ArraySize[i]; j++)
                        {
                            Vector[j] = j;
                        }

                        OpAssignment = 0;
                        OpComparisonLT = 0;
                        OpIncrement = 0;
                        OpComparisonEQ = 0;
                        ElapsedSeconds = 0;
                        NumberOfTests = 0;

                        switch (choice)
                        {
                            case 1:
                                LinearMaxInstr(Vector, ArraySize[i]);
                                Console.WriteLine("{0}\t\t{1}\t\t{2}\t\t{3}\t\t{4}", Vector.Length, OpAssignment, OpComparisonLT, OpIncrement, OpComparisonEQ);
                                break;

                            case 2:
                                LinearMaxTime(Vector, ArraySize[i]);
                                Console.WriteLine("{0}\t{1}", Vector.Length, ElapsedSeconds);
                                break;

                            case 3:
                                for (int k = 0; k < ArraySize[i]; k+=1000000)
                                {
                                    LinearAvgInstr(Vector, k);
                                    NumberOfTests++;
                                }
                                OpAssignment = OpAssignment / NumberOfTests;
                                OpComparisonLT = OpComparisonLT / NumberOfTests;
                                OpIncrement = OpIncrement / NumberOfTests;
                                OpComparisonEQ = OpComparisonEQ / NumberOfTests;
                                Console.WriteLine("{0}\t\t{1}\t\t{2}\t\t{3}\t\t{4}", Vector.Length, OpAssignment, OpComparisonLT, OpIncrement, OpComparisonEQ);
                                break;

                            case 4:
                                for (int k = 0; k < ArraySize[i]; k += 1000000)
                                {
                                    LinearAvgTime(Vector, k);
                                    NumberOfTests++;
                                }
                                ElapsedSeconds = ElapsedSeconds / NumberOfTests;
                                Console.WriteLine("{0}\t{1}", Vector.Length, ElapsedSeconds);
                                break;

                            case 5:
                                BinaryMaxInstr(Vector, ArraySize[i]);
                                Console.WriteLine("{0}\t\t{1}\t\t{2}\t\t\t\t{3}\t\t{4}", Vector.Length, OpAssignment, OpComparisonLT, OpIncrement, OpComparisonEQ);
                                break;

                            case 6:
                                BinaryMaxTime(Vector, ArraySize[i]);
                                Console.WriteLine("{0}\t{1}", Vector.Length, ElapsedSeconds);
                                break;

                            case 7:
                                for (int k = 0; k < ArraySize[i]; k += 1000000)
                                {
                                    BinaryAvgInstr(Vector, k);
                                    NumberOfTests++;
                                }
                                OpAssignment = OpAssignment / NumberOfTests;
                                OpComparisonLT = OpComparisonLT / NumberOfTests;
                                OpIncrement = OpIncrement / NumberOfTests;
                                OpComparisonEQ = OpComparisonEQ / NumberOfTests;
                                Console.WriteLine("{0}\t\t{1}\t\t{2}\t\t\t\t{3}\t\t{4}", Vector.Length, OpAssignment, OpComparisonLT, OpIncrement, OpComparisonEQ);
                                break;

                            case 8:
                                for (int k = 0; k < ArraySize[i]; k += 1000000)
                                {
                                    BinaryAvgTime(Vector, k);
                                    NumberOfTests++;
                                }
                                ElapsedSeconds = ElapsedSeconds / NumberOfTests;
                                Console.WriteLine("{0}\t{1}", Vector.Length, ElapsedSeconds);
                                break;
                        }
                    }

                    if (choice != 0)
                    {
                        Console.WriteLine("\n\n################################################################################################################");
                        //Console.WriteLine("\nTestowanie zakońćzone, naciśnij dowolny przycisk, by móc ponownie dokonać wyboru");
                        //Console.ReadKey();
                    }
                    //Console.Clear();
                }
                else if (choice == 0)
                {
                    //Console.Clear();
                    Console.WriteLine("Koniec programu");
                }
                else
                {
                    Console.Write("\n\n\n\nDokonałeś złego wyboru, naciśnij dowolny przycisk i spróbuj ponownie\n");
                    //Console.ReadKey();
                    //Console.Clear();
                }
            } while (choice != 0);
        }
    }
}





















/*
public static void Main(string[] args)
{
    int choice = 0;
    int[] ArraySize = new int[10];
    int j = 0;

    for (int i = 26843545; i <= 268435450; i += 26843545)
    {
        ArraySize[j++] = i;
    }

    do
    {
        Console.WriteLine("Jaką oprację chcesz wykonać?\n");
        Console.WriteLine("1. Wyszukiwanie liniowe - pesymistyczne - instrumentacja");
        Console.WriteLine("2. Wyszukiwanie liniowe - pesymistyczne - czas");
        Console.WriteLine("0. Zakończ prorgram\n");
        Console.Write("Twój wybór:");
        choice = int.Parse(Console.ReadLine());
        Console.WriteLine("\n");

        if (choice == 1 || choice == 2 || choice == 3 || choice == 4 || choice == 5 || choice == 6 || choice == 7 || choice == 8)
        {
            switch (choice)
            {
                case 1:
                case 3:
                case 5:
                case 7:
                    Console.WriteLine("n\t\t\tOpAssignment\tOpComparisonLT\t\tOpIncrement\t\tOpComparisonEQ");
                    break;
                case 2:
                case 4:
                case 6:
                case 8:
                    Console.WriteLine("n\t\tElapsedSeconds");
                    break;
            }


            for (int i = 0; i < ArraySize.Length; i++)
            {
                switch (choice)
                {
                    case 1:
                        OpAssignment = 0;
                        OpComparisonLT = 0;
                        OpIncrement = 0;
                        OpComparisonEQ = 0;
                        LinearMaxInstr(ArraySize[i], ArraySize[i]);
                        Console.WriteLine("{0}\t\t{1}\t\t{2}\t\t{3}\t\t{4}", ArraySize[i], OpAssignment, OpComparisonLT, OpIncrement, OpComparisonEQ);
                        break;
                    case 2:
                        ElapsedSeconds = 0;
                        LinearMaxTime(ArraySize[i], ArraySize[i]);
                        Console.WriteLine("{0}\t{1}", ArraySize[i], ElapsedSeconds);
                        break;
                }
            }

            if (choice != 0)
            {
                Console.WriteLine("\n\nTestowanie zakońćzone, naciśnij dowolny przycisk, by móc ponownie dokonać wyboru");
                Console.ReadKey();
            }
            Console.Clear();
        }
        else if (choice == 0)
        {
            Console.Clear();
            Console.WriteLine("Koniec programu");
        }
        else
        {
            Console.Write("Dokonałeś złego wyboru, naciśnij dowolny przycisk i spróbuj ponownie");
            Console.ReadKey();
            Console.Clear();
        }
    } while (choice != 0);
}*/
