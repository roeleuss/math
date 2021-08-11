using System;

public class BinarySet
{
    BinaryNode root;

    public void Add(BinaryNode nodeToAdd) 
    {
        if (root == null) 
        {
            root = nodeToAdd;
            return;
        }

        BinaryNode node = root;

        while (node != null)
        {
            if (node.Element == nodeToAdd.Element) return;
            
            if (nodeToAdd.Element < node.Element) 
            {
                if (node.Less == null) 
                {
                    nodeToAdd.Parent = node;
                    nodeToAdd.Side = BinarySide.LEFT;
                    node.Less = nodeToAdd;
                    return;
                } 
                else 
                {
                    node = node.Less;
                }
            } 
            else 
            {
                if (node.Greater == null) 
                {
                    nodeToAdd.Parent = node;
                    nodeToAdd.Side = BinarySide.RIGHT;
                    node.Greater = nodeToAdd;
                    return;
                } 
                else 
                {
                    node = node.Greater;
                }
            } 
        }
    }

    public BinaryNode Find(int elementToSearch) 
    {
        BinaryNode node = root;

        while (node != null)
        {
            if (node.Element == elementToSearch) return node;
            node = elementToSearch < node.Element ? node.Less : node.Greater;
        }

        return null;
    }

    public bool Contains(int element) 
    {
        return Find(element) != null;
    }

    public int Count() 
    {
        if (root == null) return 0;
        return root.Count();
    }

    public void Remove(int element) 
    {
        BinaryNode node = Find(element);
        if (node == null)  return;

        if (node.Side == BinarySide.LEFT) 
        {
            if (node.Less != null)
            {
                node.Parent.Less = node.Less;
                node.Less.Parent = node.Parent;

                if (node.Greater != null)
                {
                    BinaryNode max = node.Less.Max();
                    max.Greater = node.Greater;
                    max.Greater.Parent = max;
                }
            }
            else if (node.Greater != null)
            {
                node.Parent.Less = node.Greater;
                node.Parent.Less.Side = BinarySide.LEFT;
                node.Greater.Parent = node.Parent;
            }
            else
            {
                node.Parent.Less = null;
            }
        }
        else if (node.Side == BinarySide.RIGHT) 
        {
            if (node.Greater != null)
            {
                node.Parent.Greater = node.Greater;
                node.Greater.Parent = node.Parent;

                if (node.Less != null)
                {
                    BinaryNode min = node.Greater.Min();
                    min.Less = node.Less;
                    min.Less.Parent = min;
                }
            }
            else if (node.Less != null)
            {
                node.Parent.Greater = node.Less;
                node.Parent.Greater.Side = BinarySide.RIGHT;
                node.Less.Parent = node.Parent;
            }
            else
            {
                node.Parent.Greater = null;
            }
        }
        else 
        {
            if (node.Greater != null) 
            {
                node.Greater.Parent = null;
                node.Greater.Side = BinarySide.NONE;

                if (node.Less != null) 
                {
                    BinaryNode min = node.Greater.Min();
                    min.Less = node.Less;
                    node.Less.Parent = min;
                }
                root = node.Greater;
            }
            else if (node.Less != null) 
            {
                node.Less.Parent = null;
                node.Less.Side = BinarySide.NONE;
                root = node.Less;
            }   
            else
            {
                root = null;
            }
        }

        node.Parent = null;
        node.Side = BinarySide.NONE;
    }
}