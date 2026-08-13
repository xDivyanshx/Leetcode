public class Solution
{
    // 1. Define what we need to know about every chunk of the string
    class Node
    {
        public int Max;       // Longest repeating sequence anywhere in this chunk
        public int PrefLen;   // Length of repeating chars at the start
        public char PrefChar; // The actual character at the start
        public int SuffLen;   // Length of repeating chars at the end
        public char SuffChar; // The actual character at the end
        public int Size;      // Total size of this chunk
    }

    Node[] tree;

    public int[] LongestRepeating(string s, string queryCharacters, int[] queryIndices)
    {
        int n = s.Length;
        // A Segment Tree array typically needs 4 * N space to hold all nodes safely
        tree = new Node[4 * n];
        for (int i = 0; i < tree.Length; i++)
            tree[i] = new Node();

        // Build the initial tree from the starting string
        Build(s, 0, 0, n - 1);

        int k = queryIndices.Length;
        int[] result = new int[k];

        // Process each query
        for (int i = 0; i < k; i++)
        {
            Update(0, 0, n - 1, queryIndices[i], queryCharacters[i]);
            // After updating, the root node (tree[0]) always holds the global Max
            result[i] = tree[0].Max;
        }

        return result;
    }

    // Recursively splits the string down to single characters, then merges back up
    private void Build(string s, int nodeIndex, int start, int end)
    {
        // Base Case: We are down to a single character
        if (start == end)
        {
            tree[nodeIndex].Max = 1;
            tree[nodeIndex].PrefLen = 1;
            tree[nodeIndex].SuffLen = 1;
            tree[nodeIndex].PrefChar = s[start];
            tree[nodeIndex].SuffChar = s[start];
            tree[nodeIndex].Size = 1;
            return;
        }

        int mid = start + (end - start) / 2;
        int leftChild = 2 * nodeIndex + 1;
        int rightChild = 2 * nodeIndex + 2;

        // Build the left and right halves
        Build(s, leftChild, start, mid);
        Build(s, rightChild, mid + 1, end);

        // Merge them to calculate this node's properties
        Merge(tree[nodeIndex], tree[leftChild], tree[rightChild]);
    }

    // Recursively finds the specific character to update, changes it, and merges back up
    private void Update(int nodeIndex, int start, int end, int targetIdx, char newChar)
    {
        // Base Case: We found the exact character to update
        if (start == end)
        {
            tree[nodeIndex].PrefChar = newChar;
            tree[nodeIndex].SuffChar = newChar;
            return;
        }

        int mid = start + (end - start) / 2;
        int leftChild = 2 * nodeIndex + 1;
        int rightChild = 2 * nodeIndex + 2;

        // Go left or right depending on where the target index lives
        if (targetIdx <= mid)
            Update(leftChild, start, mid, targetIdx, newChar);
        else
            Update(rightChild, mid + 1, end, targetIdx, newChar);

        // After the child updates, merge the changes back into this parent
        Merge(tree[nodeIndex], tree[leftChild], tree[rightChild]);
    }

    // THE CORE LOGIC: How two chunks combine into one bigger chunk
    private void Merge(Node parent, Node left, Node right)
    {
        parent.Size = left.Size + right.Size;

        // 1. Calculate Prefix
        parent.PrefChar = left.PrefChar;
        parent.PrefLen = left.PrefLen;
        // If the entire left chunk is identical AND it matches the right's prefix, it extends!
        if (left.PrefLen == left.Size && left.PrefChar == right.PrefChar)
        {
            parent.PrefLen += right.PrefLen;
        }

        // 2. Calculate Suffix
        parent.SuffChar = right.SuffChar;
        parent.SuffLen = right.SuffLen;
        // If the entire right chunk is identical AND it matches the left's suffix, it extends!
        if (right.SuffLen == right.Size && right.SuffChar == left.SuffChar)
        {
            parent.SuffLen += left.SuffLen;
        }

        // 3. Calculate Overall Max
        // Start by assuming the max is whatever the biggest chunk was on the left or right
        parent.Max = Math.Max(left.Max, right.Max);

        // Check the boundary! If the left suffix and right prefix connect, they might form a new max
        if (left.SuffChar == right.PrefChar)
        {
            parent.Max = Math.Max(parent.Max, left.SuffLen + right.PrefLen);
        }
    }
}