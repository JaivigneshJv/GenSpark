using MinimumDepthOfBinaryTree;
using LinkedList;

namespace LeetCodeApp
{
    public class Program
    {
        public static async Task Main()
        {
            BinaryTree? binaryTree = null;

            while (true)
            {
                Console.Clear();
                Console.WriteLine("Binary Tree Operations:\n");
                Console.WriteLine("-------------------------");
                Console.WriteLine("1. Create a Binary Tree");
                Console.WriteLine("2. Insert Node");
                Console.WriteLine("3. Find Minimum Depth");
                Console.WriteLine("4. View Binary Tree");
                Console.WriteLine("-------------------------");
                Console.WriteLine("5. Excel Column Title");
                Console.WriteLine("-------------------------");
                Console.WriteLine("6. Check Linked List Cycle");
                Console.WriteLine("-------------------------\n");
                Console.WriteLine("7. Exit\n");
                Console.Write("Enter your choice: ");

                if (!int.TryParse(Console.ReadLine(), out int choice))
                {
                    Console.WriteLine("Invalid input. Please enter a number.");
                    continue;
                }

                switch (choice)
                {
                    case 1:
                        Console.Clear();
                        Console.Write("Enter the value of the root node: ");
                        if (!int.TryParse(Console.ReadLine(), out int rootValue))
                        {
                            Console.WriteLine("Invalid input. Please enter a valid integer.");
                            break;
                        }
                        binaryTree = new BinaryTree(rootValue);
                        Console.WriteLine("Binary Tree created successfully.");
                        await ClearConsoleAsync();
                        break;

                    case 2:
                        Console.Clear();
                        if (binaryTree == null)
                        {
                            Console.WriteLine("Binary Tree has not been created yet.");
                            break;
                        }
                        Console.Write("Enter the value of the node to insert: ");
                        if (!int.TryParse(Console.ReadLine(), out int insertValue))
                        {
                            Console.WriteLine("Invalid input. Please enter a valid integer.");
                            break;
                        }
                        binaryTree.Insert(insertValue);
                        Console.WriteLine("Node inserted successfully.");
                        await ClearConsoleAsync();

                        break;

                    case 3:
                        Console.Clear();

                        if (binaryTree == null)
                        {
                            Console.WriteLine("Binary Tree has not been created yet.");
                            break;
                        }
                        int minDepth = await Solution.MinDepth(binaryTree.root);
                        Console.WriteLine($"Minimum depth of the binary tree: {minDepth}");
                        await ClearConsoleAsync();

                        break;

                    case 4:
                        Console.Clear();

                        if (binaryTree == null)
                        {
                            Console.WriteLine("Binary Tree has not been created yet.");
                            break;
                        }
                        Console.WriteLine("Viewing Binary Tree:");
                        binaryTree.ViewTree();
                        await ClearConsoleAsync();

                        break;

                    case 5:
                        Console.Clear();

                        Console.Write("Enter Column Number : ");
                        if (!int.TryParse(Console.ReadLine(), out int column))
                        {
                            Console.WriteLine("Invalid input. Please enter a number.");
                            continue;
                        }
                        Console.WriteLine(ExcelSheet.Excel.ExcelColumnTitle(column));
                        await ClearConsoleAsync();
                        break;

                    case 6:
                        Console.Clear();

                        Console.WriteLine("Enter values for linked list separated by commas: ");
                        string? input = Console.ReadLine();
                        Console.WriteLine("Enter Pos: ");
                        int pos;
                        while (!int.TryParse(Console.ReadLine(), out pos))
                        {
                            Console.WriteLine("Invalid input, please try again...");
                            Console.WriteLine("\nEnter Pos: ");
                        }
                        string[]? values = input?.Split(',');
                        ListNode? linkedListHead = LinkedListCycleDetection.CreateLinkedList(values!, pos);
                        bool hasCycle = await LinkedListCycleDetection.HasCycle(linkedListHead!);
                        Console.WriteLine($"Linked List has cycle: {hasCycle}");
                        await ClearConsoleAsync();
                        break;

                    case 7:
                        Console.Clear();
                        Console.WriteLine("Exiting the program...");
                        await ClearConsoleAsync();

                        return;

                    default:

                        Console.WriteLine("Invalid choice. Please enter a valid option.");
                        await ClearConsoleAsync();

                        break;
                }

                Console.WriteLine();
            }
        }

        public static async Task ClearConsoleAsync()
        {
            Console.WriteLine("Press any key to continue...");
            await Task.Run(() => Console.ReadKey());
            Console.Clear();
        }
    }
}
