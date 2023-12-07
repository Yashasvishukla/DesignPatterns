namespace Union_Find_Distinct_Join;

public class DistinctSet
{
    private readonly IList<int> _parent = new List<int>();
    private readonly IList<int> _size = new List<int>();

    public DistinctSet(int n)
    {
        // Do the initialization
        for (int i = 0; i <= n; i++)
        {
            // Each node by default will be parent of itself
            _parent.Add(i);
            
            // Each node by default contains single node
            _size.Add(1);
        }
    }
    public int FindParent(int node)
    {
        if (_parent[node] == node) return node;
        var topParentNode = FindParent(_parent[node]);
            
        /* Path compression technique
            With the help of path compression
            we won't have to compute the top parent node every time
            once we reach to parent node we will update the top parent node to all the nodes
         */
        _parent[node] = topParentNode;
            
        // returning the top parent node to all the in path nodes.
        return topParentNode;
    }


    public void UnionBySize(int u, int v)
    {
        int topParentU = FindParent(u);
        int topParentV = FindParent(v);

        if (topParentU == topParentV) return;

        /*
         * Based on the size of both the components we will add the components
         *
         *  We always try to add the smaller component to large component reason being
         *  The number of traversal to reach the end node in the large component still remains the same in such manner
         *  The traversal of the small component get impacted by small factor
         *
         *  Refer TUF video for more clarification
         */
        if (_size[topParentU] < _size[topParentV])
        {
            _parent[topParentU] = topParentV;
            _size[topParentV] += _size[topParentU];
        }
        else
        {
            _parent[topParentV] = topParentU;
            _size[topParentU] += _size[topParentV];
        }
    }
    
}