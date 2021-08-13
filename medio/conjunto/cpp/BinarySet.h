#pragma once

enum Side { NONE, LEFT, RIGHT };

struct Node 
{
    Node *parent;
    Side side;
    int element;
    Node *greater;
    Node *less;
};

class BinarySet 
{
private:
    Node *root = nullptr;
    int count(Node *node);
    void print(Node *node);

public:
    void addElement(int newElement);
    void removeElement(int elementToRemove);
    bool contains(int element);
    Node* find(int element);
    Node* max(Node *node);
    Node* min(Node *node);
    int count();
    void print();
};
