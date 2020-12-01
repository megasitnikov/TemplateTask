#pragma once
#include <iostream>
using namespace std;

template<typename T>
class Tree
{
public:
    Tree()
    {
        Push(1);
    }
    Tree(T n)
    {
        Push(n);
    }
    void Push(T n) // Добавление элемента в дерево
    {
        push(n, &tree);
    }
    void Print() // Вывод элементов дерева
    {
        cout << "Tree" << endl;
        print(tree, 0);
        cout << endl;
    }
    void DeleteElement(T n) // Удаление элементов из дерева
    {
        cout << "Element " << n << " deleted" << endl;
        DeleteNode(tree, n);
        cout << endl;
    }
    void PrintLeafs() // Вывод листьев дерева
    {
        cout << "Leaves " << endl;
        PrintLeaf(tree);
        cout << endl;
    }
    void ElementSearch(T n) // Поиск элемента в дереве
    {
        if (Search(tree, n)) cout << "Element " << n << " found" << endl;
        else cout << "Element " << n << " not found" << endl;
    }

private:

    struct node
    {
        T info;
        node* l, * r;
    };

    node* tree = NULL;

    void push(T a, node** t)
    {
        if ((*t) == NULL)
        {
            (*t) = new node;
            (*t)->info = a;
            (*t)->l = (*t)->r = NULL;
            return;
        }
        if (a > (*t)->info) push(a, &(*t)->r);
        else push(a, &(*t)->l);
    }
    void print(node* t, int u)
    {
        if (t == NULL) return;
        else
        {
            print(t->l, ++u);
            for (int i = 0; i < u; ++i) cout << "[]";
            cout << t->info << endl;
            u--;
        }
        print(t->r, ++u);
    }
    node* DeleteNode(node* value, T val)
    {
        if (value == NULL) return value;
        if (val == value->info)
        {
            node* tmp;
            if (value->r == NULL) tmp = value->l;
            else
            {
                node* ptr = value->r;
                if (ptr->l == NULL)
                {
                    ptr->l = value->l;
                    tmp = ptr;
                }
                else
                {
                    node* pmin = ptr->l;
                    while (pmin->l != NULL)
                    {
                        ptr = pmin;
                        pmin = ptr->l;
                    }
                    ptr->l = pmin->r;
                    pmin->l = value->l;
                    pmin->r = value->r;
                    tmp = pmin;
                }
            }
            delete value;
            return tmp;
        }
        else if (val < value->info) value->l = DeleteNode(value->l, val);
        else value->r = DeleteNode(value->r, val);
        return value;
    }
    void PrintLeaf(node* t)
    {
        if ((t->l == nullptr) && (t->r == nullptr)) cout << t->info << "\n";
        else
        {
            if (t->l) PrintLeaf(t->l);
            if (t->r) PrintLeaf(t->r);
        }
    }
    bool Search(node* r, T d)
    {
        if (r == NULL) return false;
        if (r->info == d) return true;
        if (d <= r->info)
        {
            if (r->l != NULL)  return Search(r->l, d);
            else return false;
        }
        else
        {
            if (r->r) return Search(r->r, d);
            else return false;
        }
    }
};