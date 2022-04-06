using ConsoleApp1;

class MainClass
{
    private static void readJsonFile(Collection l)
        {
            Console.WriteLine("Enter file_name: ");
            var file = Console.ReadLine();
            l.ReadJsonFile(file);
        }
        
        private static void sortElements(Collection l)
        {
            Console.WriteLine("Enter field for which you want to sort: \n");
            l.sortField(Console.ReadLine());
        }
        
        private static void searchElements(Collection l)
        {
            Console.WriteLine("Enter parameter which elements you want to find: \n");
            var res = new Collection(l.search(Console.ReadLine()));
            Console.WriteLine(res);
        }
        
        private static void addElements(Collection l)
        {
            var p = new TaxFree();
            p.InputData();
            l.addElement(p);
        }
        
        private static void writeFile(Collection l)
        {
            Console.WriteLine("Enter file_name: ");
            var file = Console.ReadLine();
            l.WriteJsonFile(file);
        }

        private static void delete(Collection l)
        {
            Console.WriteLine("Enter id to delete: ");
            l.DeleteById(Console.ReadLine());
        }

        private static void edit(Collection l)
        {
            Console.Write("Enter id to edit: ");
            var id = Console.ReadLine();
            Console.Write("Enter atter to edit: ");
            var atter = Console.ReadLine();
            Console.Write("Enter value to change: ");
            var value = Console.ReadLine();
            l.Edit(id, atter, value);
        }

        private static string DisplayHelpMessage()
        {
            string helpMessage =
                "\n  Help menu:" +
                "\n  1 - to read from file"  +
                "\n  2 - to sort elements"  +
                "\n  3 - to search element"  +
                "\n  4 - add Company to collection" +
                "\n  5 - to del element from collection" +
                "\n  6 - to edit element from collection"  +
                "\n  7 - to write collection elements to file " +
                "\n  8 - to print collection" +
                "\n  exit - to exit" + "\n";
            return helpMessage;
        }

        public static void Main(string[] args)
        {
            Collection l = new Collection();
            while (true) 
            {
                Console.WriteLine(DisplayHelpMessage());
                string task = Console.ReadLine();
                switch (task)
                {
                    case "1":
                        readJsonFile(l);
                        break;
                    case "2":
                        sortElements(l);
                        break;
                    case "3":
                        searchElements(l);
                        break;
                    case "4":
                        addElements(l);
                        break;
                    case "5":
                        delete(l);
                        break;
                    case "6":
                        edit(l);
                        break;
                    case "7":
                        writeFile(l);
                        break;
                    case "8":
                        l.ToString();
                        break;
                    case "exit":
                        return;
                    default:
                        Console.WriteLine("error!");
                        continue;
            }
                Console.WriteLine();
            } 
        }
    }

