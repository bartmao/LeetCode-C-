using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Web;

using Elem = System.Tuple<TreeNode, string>;
public class TreeNode
{
    public int val;
    public TreeNode left;
    public TreeNode right;
    public TreeNode(int x) { val = x; }
    public TreeNode() { }
}

namespace LeetCode_CSharp
{
    class Program
    {
        static void Main(string[] args)
        {
            //    var r = new object[] { 1,2,2,null,3,3 };
            //    var root = TreeNodeConvert(r);
            //    L2RTraverse(root, n =>
            //    {
            //        if (n.left == null && n.right != null) n.left = new TreeNode(int.MinValue);
            //        else if (n.left != null && n.right == null) n.right = new TreeNode(int.MinValue);
            //    });

            //    L2RTraverse(root);
            //    Console.WriteLine("**********");
            //    R2LTraverse(root);
            // 1, 2, 3, null, null, 4, null, null, 5
            //1,2,3,#,#,4,#,#,5

            PlusOne(new int[] { 9, 8, 2, 1, 3, 3, 1, 8, 1, 4, 4, 7, 2, 7, 2, 0, 5, 6, 8, 9, 7, 7, 4, 3 });
            Console.WriteLine();
        }


        #region Collapse

        public static int RemoveElement(int[] nums, int val)
        {
            if (nums.Length == 0) return 0;
            int i = 0, j = nums.Length - 1;
            while (i < j)
            {
                while (i < j && nums[i] != val) ++i;
                while (i < j && nums[j] == val) --j;
                if (nums[i] == val && nums[j] != val)
                    Swap(nums, i, j);
            }

            return nums[i] == val ? i : i + 1;
        }

        public static IList<IList<int>> LevelOrderBottom(TreeNode root)
        {
            var m = new List<IList<int>>();
            if (root == null) return m;

            var s = new Stack<int>();
            var s1 = new Queue<TreeNode>();
            s1.Enqueue(root);
            s1.Enqueue(null);
            s.Push(root.val);
            s.Push(int.MinValue);

            while (s1.Count != 0)
            {
                var item = s1.Dequeue();
                if (item == null)
                {
                    if (s1.Count == 0) break;
                    else
                    {
                        s.Push(int.MinValue);
                        s1.Enqueue(null);
                        continue;
                    }
                }
                if (item.right != null)
                {
                    s1.Enqueue(item.right);
                    s.Push(item.right.val);
                }
                if (item.left != null)
                {
                    s1.Enqueue(item.left);
                    s.Push(item.left.val);
                }
            }

            var m1 = new List<int>();
            while (s.Count != 0)
            {
                var i = s.Pop();
                if (i != int.MinValue)
                    m1.Add(i);
                else if (m1.Count != 0)
                {
                    m.Add(m1);
                    m1 = new List<int>();
                }
            }

            if (m1.Count != 0)
                m.Add(m1);

            return m;
        }

        /// <summary>
        /// Given a sorted array, remove the duplicates in place such that each element appear only once and return the new length.
        /// Do not allocate extra space for another array, you must do this in place with constant memory.
        /// For example,
        /// Given input array nums = [1,1,2],
        /// Your function should return length = 2, with the first two elements of nums being 1 and 2 respectively. It doesn't matter what you leave beyond the new length.
        /// Subscribe to see which companies asked this question
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public static int RemoveDuplicates(int[] nums)
        {
            if (nums.Length == 0) return 0;

            var i = 1;
            var p = nums[0];
            var markArr = new bool[nums.Length];
            markArr[0] = false;

            while (i < nums.Length)
            {
                if (nums[i] == p)
                    markArr[i] = true;
                p = nums[i++];
            }

            i = 1;
            var m = 1;
            while (i < markArr.Length)
            {
                if (!markArr[i])
                    nums[m++] = nums[i];
                ++i;
            }

            return m;
        }

        public static bool IsSymmetric(TreeNode root)
        {
            if (root == null) return true;
            return IsSymmetricSubTree(root.left, root.right);
        }

        public static bool IsSymmetricSubTree(TreeNode left, TreeNode right)
        {
            if (left == null && right == null) return true;
            if (left == null || right == null) return false;
            return left.val == right.val && IsSymmetricSubTree(left.left, right.right)
                && IsSymmetricSubTree(left.right, right.left);
        }

        public static bool IsPowerOfTwo(int n)
        {
            if (n == 0) return false;

            while (true)
            {
                if ((n & 1) == 1) break;
                n = n >> 1;
            }

            return n == 1;
        }

        public static ListNode MergeTwoLists(ListNode l1, ListNode l2)
        {
            ListNode p = l1.val > l2.val ? l2 : l1;
            var head = p;
            var m = l1.next;
            var n = l2.next;
            while (m != null && n != null)
            {
                ListNode q;
                if (m.val > n.val)
                {
                    q = n;
                    n = n.next;
                }
                else
                {
                    q = m;
                    m = m.next;
                }

                p.next = q;
                p = p.next;
            }

            if (m == null)
                p.next = n;
            else
                p.next = m;

            return head;

        }

        public static bool IsBalanced(TreeNode root)
        {
            return false;
        }

        public static int LengthOfLastWord(string s)
        {
            s = s.Trim();
            var len = s.Length;
            var wordLen = 0;
            var curPos = len - 1;
            while (curPos > -1 && s[curPos] != ' ')
            {
                ++wordLen;
                --curPos;
            }
            return wordLen;
        }

        public static int LengthOfLastWord1(string s)
        {
            var len = s.Length;
            var wordLen = 0;
            var curPos = len - 1;
            var flag = false;

            while (curPos > -1)
            {
                if (s[curPos] != ' ')
                {
                    if (!flag) flag = true;
                    ++wordLen;
                }
                else if (flag)
                    break;

                --curPos;
            }
            return wordLen;
        }

        public static bool IsUgly(int num)
        {
            if (num == 1) return true;
            if (num <= 0) return false;
            while (num % 5 == 0) num /= 5;
            while (num % 3 == 0) num /= 3;
            while (num % 2 == 0) num /= 2;
            return num == 1 ? true : false;
        }




        //public static IList<string> BinaryTreePaths(TreeNode root)
        //{
        //    var s = new Stack<TreeNode>();
        //    if (root != null) 
        //    {
        //        s.Push(root);

        //        while (s.Count != 0) 
        //        {
        //            var p = s.Peek();
        //            if (p.left == null && p.right == null)
        //            {
        //                // Output
        //                s.Pop();
        //            }
        //            else if (p.left != null) 
        //            {

        //            }

        //        }
        //    }
        //}

        static List<string> tens = new List<string>() { "I", "II", "III", "IV", "V", "VI", "VII", "VIII", "IX", "X" };
        static List<char> symbols = new List<char>() { 'I', 'V', 'X', 'L', 'C', 'D', 'M' };
        public static int RomanToInt(string s)
        {
            int index = -1; ;
            int val = 0;
            var sLen = s.Length;
            for (int i = 0; i < sLen; ++i)
            {
                char c = s[i];
                char p = '\0';
                if (i != sLen - 1) p = s[i + 1];
                index = symbols.IndexOf(c);

                if ((p == 'V' || p == 'X') && c == 'I') val -= 1;
                else if ((p == 'L' || p == 'C') && c == 'X') val -= 10;
                else if ((p == 'D' || p == 'M') && c == 'C') val -= 100;
                else val += index % 2 == 0 ? (int)Math.Pow(10, index / 2) : (int)Math.Pow(10, index / 2) * 5;
            }

            return val;
        }

        public static int RomanToInt1(string s)
        {
            int index = -1;
            if ((index = tens.IndexOf(s)) != -1) return index + 1;
            int val = 0;
            char p = '\0';
            char q = '\0';
            var sLen = s.Length;
            for (int i = 0; i < sLen; ++i)
            {
                p = s[i];
            }

            return val;
        }

        public static void Rotate(int[] nums, int k)
        {
            var m = k - 1;
            if (m < 0 || m > nums.Length - 1) m = nums.Length - 1;
            RotateInternal(nums, 0, nums.Length - 1);
            RotateInternal(nums, 0, m);
            RotateInternal(nums, m + 1, nums.Length - 1);
        }

        private static void RotateInternal(int[] nums, int p, int q)
        {
            while (p < q)
            {
                int k = nums[p];
                nums[p] = nums[q];
                nums[q] = k;
                ++p; --q;
            }
        }

        public static int MaxDepth(TreeNode root)
        {
            if (root == null) return 0;
            int l = MaxDepth(root.left);
            int r = MaxDepth(root.right);
            return 1 + Math.Max(l, r);
        }


        public class ListNode
        {
            public int val;
            public ListNode next;
            public ListNode(int x) { val = x; }
        }

        public static void MoveZeroes(int[] nums)
        {
            int p = 0;
            int q;
            while (p < nums.Length && nums[p] != 0) ++p;
            q = p + 1;
            while (q < nums.Length)
            {
                if (nums[q] != 0)
                {
                    nums[p++] = nums[q];
                    nums[q] = 0;
                }

                ++q;
            }

            for (int v = p; v < nums.Length; ++v)
                nums[v] = 0;
        }

        public static Queue<TreeNode> queue;

        public static bool IsSameTree(TreeNode p, TreeNode q)
        {
            if (p == null && q == null) return true;
            else if (p == null || q == null || p.val != q.val) return false;
            else return IsSameTree(p.left, q.left) && IsSameTree(p.right, q.right);
        }

        public TreeNode InvertTree(TreeNode root)
        {
            if (root != null)
            {
                var t = root.left;
                if (t != null)
                    root.left = root.right;
                if (root.right != null)
                    root.right = t;
                InvertTree(root.left);
                InvertTree(root.right);
            }

            return root;
        }

        public TreeNode LowestCommonAncestor(TreeNode root, TreeNode p, TreeNode q)
        {
            var node = root;
            while (node != null)
            {
                if (node.val > Math.Max(p.val, q.val)) node = node.left;
                else if (node.val < Math.Min(p.val, q.val)) node = node.right;
                else break;
            }

            return node;
        }

        public static int HammingWeight(uint n)
        {
            if (n == 0) return 0;
            uint x = 0x1;
            int count = 0;
            while (x != 0)
            {
                if ((x & n) != 0) count++;
                x *= 2;
            }
            return count;
        }
        public bool ContainsDuplicate(int[] nums)
        {
            if (nums.Length < 2) return false;
            QuickSort(nums, 0, nums.Length - 1);
            for (int i = 0; i < nums.Length - 1; ++i)
                if (nums[i] == nums[i + 1]) return true;
            return false;
        }

        private static void QuickSort(int[] nums, int p, int q)
        {
            if (p < q)
            {
                var m = Partition(nums, p, q);

                QuickSort(nums, p, m - 1);
                QuickSort(nums, m + 1, q);
            }
        }

        private static int Partition(int[] nums, int p, int q)
        {
            var m = (p + q) / 2;
            var pivot = nums[m];
            var x = p;
            var y = q;

            while (nums[x] < pivot) ++x;
            while (y >= x)
            {
                if (nums[y] <= pivot) Swap(nums, x++, y);
                y--;
            }

            return x;
        }

        private static void Swap(int[] nums, int p, int q)
        {
            var t = nums[p];
            nums[p] = nums[q];
            nums[q] = t;
        }

        public static int TitleToNumber(string s)
        {
            int k = 0;
            int m = 0;
            for (int i = s.Length - 1; i >= 0; i--)
            {
                k += ((int)s[i] - 64) * (int)Math.Pow(26, m++);
            }
            return k;
        }

        public static int MajorityElement(int[] nums)
        {
            var dict = new Dictionary<int, int>();
            var n = nums.Length / 2;
            for (var i = 0; i < nums.Length; ++i)
            {
                if (!dict.ContainsKey(nums[i]))
                    dict.Add(nums[i], 1);
                else
                    dict[nums[i]] = ++dict[nums[i]];
                if (dict[nums[i]] > n) return nums[i];
            }

            return 0;
        }

        public static bool IsAnagram(string s, string t)
        {
            if (s.Length != t.Length) return false;
            int[] alphabet = new int[26];
            for (int i = 0; i < 26; i++)
            {
                alphabet[i] = 0;
            }
            for (int i = 0; i < s.Length; i++)
            {
                alphabet[s[i] - 'a']++;
            }
            for (int i = 0; i < t.Length; i++)
            {
                alphabet[t[i] - 'a']--;
                if (alphabet[t[i] - 'a'] < 0) return false;
            }
            return true;
        }

        public static ListNode DeleteDuplicates(ListNode head)
        {
            if (head == null || head.next == null) return head;

            var h = head;
            var p = head;
            while (p.next != null)
            {
                if (p.val == p.next.val)
                    p.next = p.next.next;
                else p = p.next;
            }

            return h;
        }

        public static int ClimbStairs(int n)
        {
            if (n == 1) return 1;
            else if (n == 2) return 2;
            else
            {
                var p1 = 1;
                var p2 = 2;
                var s = 0;
                while (n-- > 2)
                {
                    s = p1 + p2;
                    p1 = p2;
                    p2 = s;
                }

                return s;
            }
        }

        public static ListNode ReverseList(ListNode head)
        {
            if (head == null || head.next == null) return head;
            var p = head;
            ListNode q = null;

            while (p != null)
            {
                var m = p.next;
                p.next = q;
                q = p;
                p = m;
            }

            return q;
        }

        public class Queue
        {
            private Stack<int> stack = new Stack<int>();
            private Stack<int> stack1 = new Stack<int>();

            // Push element x to the back of queue.
            public void Push(int x)
            {
                stack.Push(x);
            }

            // Removes the element from front of queue.
            public void Pop()
            {
                while (stack.Count != 0)
                {
                    stack1.Push(stack.Pop());
                }
                if (stack1.Count != 0) stack1.Pop();
                while (stack1.Count != 0)
                {
                    stack.Push(stack1.Pop());
                }
            }

            // Get the front element.
            public int Peek()
            {
                while (stack.Count != 0)
                {
                    stack1.Push(stack.Pop());
                }
                var p = stack1.Peek();
                while (stack1.Count != 0)
                {
                    stack.Push(stack1.Pop());
                }

                return p;
            }

            // Return whether the queue is empty.
            public bool Empty()
            {
                return stack.Count == 0;
            }
        }

        public static void GetHappyNumbers()
        {
            var d = new Dictionary<int, bool>();
            d.Add(1, true);

            var l = new List<int>();
            for (int m = 10; m < 100; ++m)
            {
                if (IsHappy(m)) l.Add(m);
            }

            l.ForEach(i => Console.WriteLine(i));
        }

        static Dictionary<int, int> a = new Dictionary<int, int>();
        static Program()
        {
            a.Add(1, 1);
            a.Add(7, 1);
        }
        public static bool IsHappy(int n)
        {
            if (n == 1) return true;
            if (a.ContainsKey(n)) return true;

            var s = new Stack<int>();
            var i = n;
            while (i >= 10)
            {
                s.Push(i);
                i = CalSum(i);
            }
            if (i == 1)
            {
                s.Pop();
                while (s.Count != 0 && !a.ContainsKey(s.Peek())) a.Add(s.Pop(), 1);
            }

            return i == 1;
        }

        private static int CalSum(int i)
        {
            int s = 0;
            while (i != 0)
            {
                var k = i % 10;
                s += (int)Math.Pow(k, 2);
                i = i / 10;
            }

            return s;
        }
        #endregion

        /// <summary>
        /// Given a non-negative number represented as an array of digits, plus one to the number.
        /// The digits are stored such that the most significant digit is at the head of the list.
        /// </summary>
        /// <param name="digits"></param>
        /// <returns></returns>
        public static int[] PlusOne(int[] digits)
        {
            int p = digits.Length - 1;

            while (p >= 0)
            {

                if (digits[p] < 9)
                    digits[p] += 1;
                else digits[p] = 0;

                if (digits[p] != 0) return digits;

                --p;
            }

            var newArr = new int[digits.Length+1];
            newArr[0] = 1;
            for(var k=0;k<digits.Length;++k)
                newArr[k+1]=digits[k];

            return newArr;
        }

        public static TreeNode TreeNodeConvert(object[] arr)
        {
            if (arr == null || arr.Length == 0) return null;

            int p = 0;
            var root = new TreeNode((int)arr[p]);
            var q = new Queue<TreeNode>();
            q.Enqueue(root);

            while (q.Count != 0 && ++p < arr.Length)
            {
                var cur = q.Dequeue();
                if (arr[p] != null)
                {
                    var l = new TreeNode((int)arr[p]);
                    cur.left = l;
                    q.Enqueue(l);
                }
                ++p;
                if (p < arr.Length && arr[p] != null)
                {
                    var r = new TreeNode((int)arr[p]);
                    cur.right = r;
                    q.Enqueue(r);
                }
            }

            return root;
        }

        public static void L2RTraverse(TreeNode node, Action<TreeNode> action = null)
        {
            if (node == null) return;
            L2RTraverse(node.left, action);
            if (action == null) Console.WriteLine(node.val);
            else action(node);
            L2RTraverse(node.right, action);
        }

        public static void R2LTraverse(TreeNode node, Action<TreeNode> action = null)
        {
            if (node == null) return;
            R2LTraverse(node.right, action);
            if (action == null) Console.WriteLine(node.val);
            else action(node);
            R2LTraverse(node.left, action);
        }
    }
}