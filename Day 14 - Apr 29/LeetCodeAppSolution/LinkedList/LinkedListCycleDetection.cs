namespace LinkedList
{
    public class LinkedListCycleDetection
    {
        public static ListNode? CreateLinkedList(string[] values, int pos)
        {
            ListNode? dummyHead = new(-1);
            ListNode? current = dummyHead;
            ListNode? cycleStartNode = null;

            for (int i = 0; i < values.Length; i++)
            {
                int val = int.Parse(values[i]);
                current.next = new ListNode(val);
                current = current.next;

                if (i == pos)
                {
                    cycleStartNode = current;
                }
            }

            current.next = cycleStartNode;

            return dummyHead.next;
        }

        public static async Task<bool> HasCycle(ListNode head)
        {
            if (head == null || head.next == null)
                return false;

            ListNode slow = head;
            ListNode fast = head.next;

            while (slow != fast)
            {
                if (fast == null || fast.next == null)
                    return false;

                slow = slow.next!;
                fast = fast.next!.next!;
            }

            await Task.Delay(0);

            return true;
        }
    }
}
