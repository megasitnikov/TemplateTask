// task2.cpp : Этот файл содержит функцию "main". Здесь начинается и заканчивается выполнение программы.
//

#include <iostream>
#include "BinaryTree.h"
using namespace std;

int main()
{
    int a;
    Tree<int> tree(13);
    tree.Push(3);
    tree.Push(7);
    tree.Push(21);
    tree.Push(18);
    tree.Push(5);
    tree.Push(28);
    tree.Push(41);
    tree.Push(33);
    tree.Print();
    tree.DeleteElement(21);
    tree.Print();
    tree.PrintLeafs();
    tree.ElementSearch(28);
    tree.ElementSearch(69);
}