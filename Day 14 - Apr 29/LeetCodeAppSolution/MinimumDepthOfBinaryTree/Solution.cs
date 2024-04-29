namespace MinimumDepthOfBinaryTree
{
    public class Solution
    {
        public static async Task<int> MinDepth(TreeNode? root)
        {
            if (root == null)
            {
                return 0;
            }
            if (root.left == null && root.right == null)
            {
                return 1;
            }
            if (root.left == null)
            {
                return await MinDepth(root.right) + 1;
            }
            if (root.right == null)
            {
                return await MinDepth(root.left) + 1;
            }
            var leftDepth = MinDepth(root.left);
            var rightDepth = MinDepth(root.right);
            await Task.WhenAll(leftDepth, rightDepth);
            return Math.Min(leftDepth.Result, rightDepth.Result) + 1;
        }
    }
}
