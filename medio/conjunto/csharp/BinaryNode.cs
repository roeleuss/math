
public class BinaryNode {

    public BinaryNode Parent { get; set; }
    public BinarySide Side { get; set; }
    public int Element { get; set; }
    public BinaryNode Greater { get; set; }
    public BinaryNode Less { get; set; }

    public BinaryNode(int element, BinaryNode parent = null) 
    {
        Side = BinarySide.NONE;
        Element = element;
        Parent = parent;
    }

    public int Count() 
    {
        int less = Less?.Count() ?? 0;
        int greater = Greater?.Count() ?? 0;
        return 1 + less + greater;
    }

    public BinaryNode Max() 
    {
        BinaryNode node = this;
        while (node.Greater != null) 
        {
            node = node.Greater;
        }
        return node;
    }

    public BinaryNode Min() 
    {
        BinaryNode node = this;
        while (node.Less != null) 
        {
            node = node.Less;
        }
        return node;
    }
}
    