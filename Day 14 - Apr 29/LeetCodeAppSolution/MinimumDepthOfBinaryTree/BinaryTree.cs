namespace MinimumDepthOfBinaryTree
{
    public class BinaryTree
    {
        public TreeNode? root;

        public BinaryTree(int rootValue)
        {
            root = new TreeNode(rootValue);
        }

        public void Insert(int value)
        {
            if (root == null)
            {
                root = new TreeNode(value);
                return;
            }

            Queue<TreeNode> queue = new();
            queue.Enqueue(root);

            while (queue.Count > 0)
            {
                TreeNode node = queue.Dequeue();

                if (node.left != null)
                {
                    queue.Enqueue(node.left);
                }
                else
                {
                    node.left = new TreeNode(value);
                    return;
                }

                if (node.right != null)
                {
                    queue.Enqueue(node.right);
                }
                else
                {
                    node.right = new TreeNode(value);
                    return;
                }
            }
        }



        public void InOrderTraversal()
        {
            InOrderRecursive(root);
        }

        private static void InOrderRecursive(TreeNode? node)
        {
            if (node == null)
            {
                return;
            }

            InOrderRecursive(node.left);
            Console.Write(node.val + " ");
            InOrderRecursive(node.right);
        }

        public void PreOrderTraversal()
        {
            PreOrderRecursive(root);
        }

        private static void PreOrderRecursive(TreeNode? node)
        {
            if (node == null)
            {
                return;
            }

            Console.Write(node.val + " ");
            PreOrderRecursive(node.left);
            PreOrderRecursive(node.right);
        }

        public void PostOrderTraversal()
        {
            PostOrderRecursive(root);
        }

        private static void PostOrderRecursive(TreeNode? node)
        {
            if (node == null)
            {
                return;
            }

            PostOrderRecursive(node.left);
            PostOrderRecursive(node.right);
            Console.Write(node.val + " ");
        }

        public void ViewTree()
        {
            if (root == null)
            {
                Console.WriteLine("Binary Tree is empty.");
                return;
            }

            Queue<TreeNode> queue = new();
            queue.Enqueue(root);

            while (queue.Count > 0)
            {
                int levelSize = queue.Count;
                for (int i = 0; i < levelSize; i++)
                {
                    TreeNode current = queue.Dequeue();
                    Console.Write(current.val + " ");

                    if (current.left != null)
                    {
                        queue.Enqueue(current.left);
                    }
                    if (current.right != null)
                    {
                        queue.Enqueue(current.right);
                    }
                }
                Console.WriteLine();
            }
        }
    }
}
