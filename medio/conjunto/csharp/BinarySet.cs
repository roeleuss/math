using System;

public class BinarySet
{
    BinaryNode root;

    public void Add(int newElement) 
    {
        if (root == null) 
        {
            root = new BinaryNode(newElement);
            return;
        }

        BinaryNode node = root;

        while (node != null)
        {
            if (node.Element == newElement) return;
            
            if (newElement < node.Element) 
            {
                if (node.Less == null) 
                {
                    var nodeToAdd = new BinaryNode(newElement);
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
                    var nodeToAdd = new BinaryNode(newElement);
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
        BinaryNode nodeToRemove = Find(element);
        if (nodeToRemove == null) return;

        BinaryNode nodeToReplace = null;
        if (nodeToRemove.Less != null)  
        {
            nodeToReplace = nodeToRemove.Less.Max();
        } 
        else if (nodeToRemove.Greater != null) 
        {
            nodeToReplace = nodeToRemove.Greater.Min();
        }

        if (nodeToReplace != null) 
        {
            switch (nodeToReplace.Side)
            {
            case BinarySide.RIGHT:
                nodeToReplace.Parent.Greater = null;
                break;
            case BinarySide.LEFT:
                nodeToReplace.Parent.Less = null;
                break;
            }

            if (nodeToRemove.Less != null && nodeToRemove.Less.Element != nodeToReplace.Element) 
            {
                nodeToReplace.Less = nodeToRemove.Less;
                nodeToReplace.Less.Parent = nodeToReplace;
            }
            else 
            {
                nodeToReplace.Less = null;
            }

            if (nodeToRemove.Greater != null && nodeToRemove.Greater.Element != nodeToReplace.Element) 
            {
                nodeToReplace.Greater = nodeToRemove.Greater;
                nodeToReplace.Greater.Parent = nodeToReplace;
            }
            else 
            {
                nodeToReplace.Greater = null;
            }

            nodeToReplace.Parent = nodeToRemove.Parent;
            nodeToReplace.Side = nodeToRemove.Side;
        }

        switch (nodeToRemove.Side)
        {
        case BinarySide.RIGHT:
            nodeToRemove.Parent.Greater = nodeToReplace;
            break;
        case BinarySide.LEFT:
            nodeToRemove.Parent.Less = nodeToReplace;
            break;
        case BinarySide.NONE:
            root = nodeToReplace;
            break;
        }
    }
}