#include <iostream>
#include "BinarySet.h"

using namespace std;

void BinarySet::addElement(int newElement) 
{
    if (root == nullptr) 
    {
        root = new Node();
        root->element = newElement;
        root->side = NONE;
        root->greater = nullptr;
        root->less = nullptr;
    } 
    else 
    {
        auto node = root;
        while (node != nullptr) 
        {
            if (newElement == node->element) break;

            if (newElement < node->element) 
            {
                if (node->less == nullptr) 
                {
                    node->less = new Node();
                    node->less->element = newElement;
                    node->less->side = LEFT;
                    node->less->parent = node;
                    node->less->greater = nullptr;
                    node->less->less = nullptr;
                } 
                else 
                {
                    node = node->less;
                }
            } 
            else 
            {
                if (node->greater == nullptr) 
                {
                    node->greater = new Node();
                    node->greater->element = newElement;
                    node->greater->side = RIGHT;
                    node->greater->parent = node;
                    node->greater->greater = nullptr;
                    node->greater->less = nullptr;
                }
                else 
                {
                    node = node->greater;
                }
            }
        }          
    }
}

bool BinarySet::contains(int element) 
{
    return find(element);
}

Node* BinarySet::find(int element) 
{
    auto node = root;
    while (node != nullptr) 
    {
        if (node->element == element) 
        {
            return node;
        }
        node = (element < node->element) ? node->less : node->greater;
    }
    return nullptr;
}

Node* BinarySet::max(Node *node) 
{
    if (node == nullptr) return nullptr;
    while (node->greater != nullptr) 
    {
        node = node->greater;
    }
    return node;
}

Node* BinarySet::min(Node *node) 
{
    if (node == nullptr) return nullptr;
    while (node->less != nullptr) 
    {
        node = node->less;
    }
    return node;
}

void BinarySet::removeElement(int elementToRemove) 
{
    auto nodeToRemove = find(elementToRemove);
    
    if (nodeToRemove == nullptr) return;

    Node *toReplace = nullptr;
    
    if (nodeToRemove->less != nullptr)  
    {
        toReplace = max(nodeToRemove->less);
    } 
    else if (nodeToRemove->greater != nullptr) 
    {
        toReplace = min(nodeToRemove->greater);
    }
    
    if (toReplace != nullptr) 
    {
        switch (toReplace->side)
        {
        case RIGHT:
            toReplace->parent->greater = nullptr;
            break;
        case LEFT:
            toReplace->parent->less = nullptr;
            break;
        }

        if (nodeToRemove->less != nullptr && nodeToRemove->less->element != toReplace->element) 
        {
            toReplace->less = nodeToRemove->less;
            toReplace->less->parent = toReplace;
        }
        else 
        {
            toReplace->less = nullptr;
        }

        if (nodeToRemove->greater != nullptr && nodeToRemove->greater->element != toReplace->element) 
        {
            toReplace->greater = nodeToRemove->greater;
            toReplace->greater->parent = toReplace;
        }
        else 
        {
            toReplace->greater = nullptr;
        }

        toReplace->parent = nodeToRemove->parent;
        toReplace->side = nodeToRemove->side;
    }

    switch (nodeToRemove->side)
    {
    case RIGHT:
        nodeToRemove->parent->greater = toReplace;
        break;
    case LEFT:
        nodeToRemove->parent->less = toReplace;
        break;
    case NONE:
        root = toReplace;
        break;
    }

    delete nodeToRemove;
}

int BinarySet::count() {
    return count(root);
}

int BinarySet::count(Node* node) {
    int greater = node->greater == nullptr ? 0 : count(node->greater);
    int less = node->less == nullptr ? 0 : count(node->less);
    return 1 + greater + less;
}

void BinarySet::print() {
    print(root);
    cout << endl;
}

void BinarySet::print(Node* node) {
    cout << node->element << ":" << node->side << ", ";
    if (node->less != nullptr) print(node->less);
    if (node->greater != nullptr) print(node->greater);
}