using VisualisationOfLeeAlgoritm;

namespace VisualisationOfLeeAlgoritm
{
    class Program
    {
        static void Main(string[] args)
        {
            var rand = new Random();
            const int heigth = 10;
            const int width = 18;
            while (true)
            {
                int[,] my = new int[heigth, width];
                for (int i = 0; i < heigth; i++)
                {
                    for (int j = 0; j < width; j++)
                    {

                        if (rand.Next(100) > 70)
                            my[i, j] = (int)Constant.Barrier;
                        else
                            my[i, j] = (int)Constant.EmptySpace;
                    }
                }
                var random = new Random(unchecked((int)DateTime.Now.Millisecond));
                my[random.Next(heigth), random.Next(width)] = (int)Constant.StartPosition;
                my[random.Next(heigth), random.Next(width)] = (int)Constant.Destination;
                Print(my);

                var li = new LeeAlgorithm(my);
                Console.WriteLine(li.PathFound);
                if (li.PathFound)
                {
                    foreach (var item in li.Path)
                    {
                        if (item == li.Path.Last())
                            my[item.Item1, item.Item2] = (int)Constant.StartPosition;
                        else if (item == li.Path.First())
                            my[item.Item1, item.Item2] = (int)Constant.Destination;
                        else
                            my[item.Item1, item.Item2] = (int)Constant.Path;
                    }
                    Print(li.ArrayGraph);
                    Console.WriteLine("Длина " + li.LengthPath);
                }
                else
                    Console.WriteLine("Путь не найден");
                Console.ReadLine();
            }
        }

        private static void Print(int[,] array)
        {
            Console.WriteLine("***");
            string msg = string.Empty;
            int x = array.GetLength(0);
            int y = array.GetLength(1);
            for (int i = 0; i < x; i++)
            {
                for (int j = 0; j < y; j++)
                {
                    switch (array[i, j])
                    {
                        case (int)Constant.Path: msg = string.Format("{0,3}", "+"); Console.ForegroundColor = ConsoleColor.Yellow; break;
                        case (int)Constant.StartPosition: msg = string.Format("{0,3}", "s"); Console.ForegroundColor = ConsoleColor.Green; break;
                        case (int)Constant.Destination: msg = string.Format("{0,3}", "d"); Console.ForegroundColor = ConsoleColor.Red; break;
                        case (int)Constant.EmptySpace: msg = string.Format("{0,3}", "'"); Console.ForegroundColor = ConsoleColor.DarkBlue; break;
                        case (int)Constant.Barrier: msg = string.Format("{0,3}", "*"); Console.ForegroundColor = ConsoleColor.Blue; break;
                        case 1: 
                        case 2:
                        case 3:
                        case 4:
                        case 5:
                        case 6:
                        case 7:
                        case 8:
                        case 9:
                        case 10:
                        case 11:
                        case 12:
                        case 13:
                        case 14:
                        case 15:
                        case 16:
                        case 17:
                        case 18:
                        case 19:
                        case 20:
                            msg = string.Format("{0,3}", array[i, j]); Console.ForegroundColor = ConsoleColor.DarkGray; break;
                        default:
                            break;
                    }
                    Console.Write(msg);
                    Console.ResetColor();
                }
                Console.WriteLine();
            }
            Console.WriteLine(msg);
        }

    }
}