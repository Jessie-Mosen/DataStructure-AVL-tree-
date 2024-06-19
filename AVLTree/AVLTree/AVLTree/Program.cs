using System;
using System.Diagnostics;
using System.IO;

namespace AVLTree
{
    internal class Program
    {
        public static AVLTree AVLTree = new AVLTree();

        static void Main(string[] args)
        {
            bool exit = false;
            while (!exit)
            {
                string MyFolder = "";
                int FolderOpt = 0;
                int TextFileOpt = 0;
                string filesize = "";

                Console.WriteLine("Press 1: Ordered file");
                Console.WriteLine("Press 2: Random file");
                FolderOpt = int.Parse(Console.ReadLine());

                if (FolderOpt == 1)
                {
                    MyFolder = "../ordered/";

                    Console.WriteLine("***Ordered has been selected***");
                    Console.WriteLine("Choose File size");
                    Console.WriteLine("Press 1 for 1000");
                    Console.WriteLine("Press 2 for 5000");
                    Console.WriteLine("Press 3 for 10000");
                    Console.WriteLine("Press 4 for 15000");
                    Console.WriteLine("Press 5 for 20000");
                    Console.WriteLine("Press 6 for 25000");
                    Console.WriteLine("Press 7 for 30000");
                    Console.WriteLine("Press 8 for 35000");
                    Console.WriteLine("Press 9 for 40000");
                    Console.WriteLine("Press 10 for 45000");
                    Console.WriteLine("Press 11 for 50000");
                }
                else if (FolderOpt == 2)
                {
                    MyFolder = "../random/";

                    Console.WriteLine("***Random has been selected***");
                    Console.WriteLine("Choose File size");
                    Console.WriteLine("Press 1 for 1000");
                    Console.WriteLine("Press 2 for 5000");
                    Console.WriteLine("Press 3 for 10000");
                    Console.WriteLine("Press 4 for 15000");
                    Console.WriteLine("Press 5 for 20000");
                    Console.WriteLine("Press 6 for 25000");
                    Console.WriteLine("Press 7 for 30000");
                    Console.WriteLine("Press 8 for 35000");
                    Console.WriteLine("Press 9 for 40000");
                    Console.WriteLine("Press 10 for 45000");
                    Console.WriteLine("Press 11 for 50000");
                }

                TextFileOpt = int.Parse(Console.ReadLine());
                Console.Clear();

                switch (TextFileOpt)
                {
                    case 1:
                        filesize = "1000";
                        break;
                    case 2:
                        filesize = "5000";
                        break;
                    case 3:
                        filesize = "10000";
                        break;
                    case 4:
                        filesize = "15000";
                        break;
                    case 5:
                        filesize = "20000";
                        break;
                    case 6:
                        filesize = "25000";
                        break;
                    case 7:
                        filesize = "30000";
                        break;
                    case 8:
                        filesize = "35000";
                        break;
                    case 9:
                        filesize = "40000";
                        break;
                    case 10:
                        filesize = "45000";
                        break;
                    case 11:
                        filesize = "50000";
                        break;
                    default:
                        Console.WriteLine("Invalid option. Please select a valid file size.");
                        continue;
                }

                string Myline;
                string MyFile = filesize + "-words.txt";
                string path = Path.Combine(MyFolder, MyFile);
                Stopwatch sw1 = Stopwatch.StartNew();

                using (StreamReader FileContent = new StreamReader(path))
                {
                    while ((Myline = FileContent.ReadLine()) != null)
                    {
                        if (!Myline.Contains("#") && !string.IsNullOrWhiteSpace(Myline))
                        {
                            AVLTree.Add(Myline);
                        }
                    }
                }

                sw1.Stop();
                TimeSpan timeSpan1 = sw1.Elapsed;
                Console.WriteLine("Time taken to insert into the AVL Tree");
                Console.WriteLine("Time: " + timeSpan1.ToString(@"mm\:ss\.fffffff") + "m:ss");
                Console.WriteLine();
                Console.WriteLine($"{filesize}-word.txt from {MyFolder} has been loaded");

                bool back = false;
                while (!back)
                {
                    Console.WriteLine("Press 1: ToPrint Options");
                    Console.WriteLine("Press 2: Find Operation");
                    Console.WriteLine("Press 3: Delete");
                    Console.WriteLine("Press 4: Insert Operation");
                    Console.WriteLine("Press 5: Functionally Test");
                    Console.WriteLine("Press 0: Go Back");
                    int OperationOpt = int.Parse(Console.ReadLine());
                    Console.Clear();

                    switch (OperationOpt)
                    {
                        case 0:
                            back = true;
                            break;

                        case 1:
                            int PrintOpt = 0;
                            Console.WriteLine("Press 1: Pre-Order");
                            Console.WriteLine("Press 2: In-Order");
                            Console.WriteLine("Press 3: Post-Order");
                            PrintOpt = int.Parse(Console.ReadLine());

                            Stopwatch sw = Stopwatch.StartNew();

                            switch (PrintOpt)
                            {
                                case 1:
                                    Console.WriteLine(AVLTree.PreOrder());
                                    Console.WriteLine("Tree depth: " + AVLTree.TreeDepth());
                                    break;
                                case 2:
                                    Console.WriteLine(AVLTree.InOrder());
                                    Console.WriteLine("Tree depth: " + AVLTree.TreeDepth());
                                    break;
                                case 3:
                                    Console.WriteLine(AVLTree.PostOrder());
                                    Console.WriteLine("Tree depth: " + AVLTree.TreeDepth());
                                    break;
                                default:
                                    Console.WriteLine("Error");
                                    break;
                            }

                            sw.Stop();
                            TimeSpan timespan = sw.Elapsed;
                            Console.WriteLine("***Time taken to perform print operation***");
                            Console.WriteLine("Time: " + timespan.ToString(@"mm\:ss\.fffffff") + "m:ss");
                            break;

                        case 2:
                            {
                                Stopwatch sw2 = Stopwatch.StartNew();
                                Console.WriteLine("Enter Word to search: ");
                                string WordToSearch = Console.ReadLine();
                                Console.WriteLine(AVLTree.Find(WordToSearch));
                                sw2.Stop();
                                TimeSpan timespan2 = sw2.Elapsed;
                                Console.WriteLine("***Time taken to perform find operation***");
                                Console.WriteLine("Time: " + timespan2.ToString(@"mm\:ss\.fffffff") + "m:ss");
                            }
                            break;

                        case 3:
                            {
                                Stopwatch sw3 = Stopwatch.StartNew();
                                Console.WriteLine("Enter Word to delete: ");
                                string WordToDelete = Console.ReadLine();
                                Console.WriteLine(AVLTree.Remove(WordToDelete));
                                sw3.Stop();
                                TimeSpan timespan3 = sw3.Elapsed;
                                Console.WriteLine("***Time taken to perform delete operation***");
                                Console.WriteLine("Time: " + timespan3.ToString(@"mm\:ss\.fffffff") + "m:ss");
                            }
                            break;

                        case 4:
                            {
                                Console.WriteLine("Word to be inserted: ");
                                string wordToInsert = Console.ReadLine();
                                Stopwatch sw4 = Stopwatch.StartNew();
                                AVLTree.Add(wordToInsert);
                                sw4.Stop();
                                Console.WriteLine("Word has been inserted");
                                Console.WriteLine($"{wordToInsert} has a length of {wordToInsert.Length}");
                                TimeSpan timespan4 = sw4.Elapsed;
                                Console.WriteLine("***Time taken to perform insert operation***");
                                Console.WriteLine("Time: " + timespan4.ToString(@"mm\:ss\.fffffff") + "m:ss");
                            }
                            break;

                        case 5:
                            {
                                Stopwatch sw5 = Stopwatch.StartNew();
                                Console.WriteLine("Deleting word (zu): ");
                                AVLTree.Remove("zu");
                                Console.WriteLine("Will now find the word (zu)\n");
                                Console.WriteLine(AVLTree.Find("zu"));
                                Console.WriteLine("Inserting words: The, Earth, Movement, AroundTheEarth, Grab, Pull, Enter");

                                AVLTree.Add("The");
                                AVLTree.Add("Earth");
                                AVLTree.Add("Movement");
                                AVLTree.Add("AroundTheEarth");
                                AVLTree.Add("Grab");
                                AVLTree.Add("Pull");
                                AVLTree.Add("Enter");

                                Console.WriteLine("Will now find the word (AroundTheEarth)\n");
                                Console.WriteLine(AVLTree.Find("AroundTheEarth"));

                                sw5.Stop();
                                TimeSpan timeSpan5 = sw5.Elapsed;
                                Console.WriteLine("***Time taken to perform functional test***");
                                Console.WriteLine("Time: " + timeSpan5.ToString(@"mm\:ss\.fffffff") + "m:ss");
                            }
                            break;

                        default:
                            Console.WriteLine("Error");
                            break;
                    }
                }

                Console.WriteLine("Press 1 to continue with file size selection or 0 to exit the program");
                int optContinue = int.Parse(Console.ReadLine());
                if (optContinue == 0)
                {
                    exit = true;
                }
             
               
            }
        }
    }
}
