#pragma once
#include <iostream>
using namespace std;


template<typename T>
class Queue
{
public:
    int n = 0, save, s;
    T* value;
    int N;
    Queue(int N)
    {
        value = new T[N];
        this->N = N;
    }
    void push(T number) // Вставка чисел в очередь
    {
        if (n == N)
        {
            cout << endl << "Error. The queue is full. Failed to add: " << number << endl;
        }
        else
        {
            value[n] = number;
            n++;
            cout << "A number was added to the queue: " << number << endl;
        }
    }
    void pop() // Удаление первого числа в очереди
    {
        s = value[0];
        for (int i = 0; i < n; i++)
        {
            value[i] = value[i + 1];

        }
        n--;
        cout << "Deleting the first number in the queue: " << s << endl;
    }

    void pop_back() // Удаление последнего числа в очереди
    {
        s = value[n - 1];
        for (int z = 0; z < n; z++)
        {
            for (int j = 0; j < n; j++)
            {
                save = value[j];
                value[j] = value[j + 1];
                value[j + 1] = save;
            }
        }
        for (int i = 0; i < n; i++)
        {
            value[i] = value[i + 1];
        }
        n--;
        cout << "Deleting the last number in the queue: " << s << endl;
    }
    void Print() // Вывод очереди
    {
        for (int i = 0; i < n; i++)
        {
            cout << value[i] << "  ";
        }
        cout << endl << endl;
    }
    void MergingQueues(Queue num) // Объединение очередей    
    {
        T* arr = new T[N];
        for (int i = 0; i < n; i++)
        {
            arr[i] = value[i];
        }
        int x = n;
        n = n + num.n;
        N = N + num.N;
        value = new T[N];
        int j = 0;
        for (int i = x; i < n; i++)
        {
            value[i] = num.value[j];
            j++;
        }
        for (int i = 0; i < x; i++)
        {
            value[i] = arr[i];
        }
    }
};