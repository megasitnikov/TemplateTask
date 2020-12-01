using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task2
{
    public unsafe class Tree<T> where T : IComparable
    {
        class Trees
        {
            public T data;
            public int height;
            public Trees left, right;
            public Trees(T data)
            {
                this.data = data;
                this.height = 1;
                this.left = null;
                this.right = null;
            }

            public int Balance()
            {
                int leftHeight, rightHeight;
                if (this.left != null) leftHeight = this.left.height;
                else leftHeight = 0;
                if (this.right != null) rightHeight = this.right.height;
                else rightHeight = 0;
                return rightHeight - leftHeight;
            }

            public void MakeHeight()
            {
                int leftHeight, rightHeight;
                if (this.left != null) leftHeight = this.left.height;
                else leftHeight = 0;
                if (this.right != null) rightHeight = this.right.height;
                else rightHeight = 0;
                this.height = Math.Max(leftHeight, rightHeight) + 1;
            }
        }
        Trees root;
        int count;
        bool change;
        public Tree()
        {
            this.root = null;
            this.change = false;
            this.count = 0;
        }
        public Tree(T data)
        {
            this.root = new Trees(data);
            this.change = false;
            this.count = 1;
        }
        void TurnLeft(ref Trees index)
        {
            Trees temp = index.left;
            index.left = temp.right;
            temp.right = index;
            index.MakeHeight();
            temp.MakeHeight();
            index = temp;
        }
        void TurnRight(ref Trees index)
        {
            Trees temp;
            temp = index.right;
            index.right = temp.left;
            temp.left = index;
            index.MakeHeight();
            temp.MakeHeight();
            index = temp;
        }

        void Ballance(ref Trees index)
        {
            int oldHeight = index.height;
            index.MakeHeight();
            int balance = index.Balance();
            if (balance > 1)
            {
                if (index.right.Balance() < 0) this.TurnLeft(ref index.right);
                this.TurnRight(ref index);
                if (index.height == oldHeight) this.change = false;
            }
            else if (balance < -1)
            {
                if (index.left.Balance() > 0) this.TurnRight(ref index.left);
                this.TurnLeft(ref index);
                if (index.height == oldHeight) this.change = false;
            }
        }
        void push(ref Trees index, T data)
        {
            if (index == null)
            {
                this.change = true;
                index = new Trees(data);
            }
            else
            {
                if (data.CompareTo(index.data) == -1)
                {
                    this.push(ref index.left, data);
                    if (this.change) this.Ballance(ref index);
                }
                else
                {
                    this.push(ref index.right, data);
                    if (this.change) this.Ballance(ref index);
                }
            }
        }

        void FindToDelete(ref Trees replaceable, Trees index, ref Trees temp)
        {
            if (replaceable.right != null)
            {
                this.FindToDelete(ref replaceable.right, index, ref temp);
                this.Ballance(ref replaceable);
            }
            else
            {
                temp = replaceable;
                index.data = replaceable.data;
                replaceable = replaceable.left;
            }
        }

        void DeleteNode(ref Trees index, T data)
        {
            if (index != null)
            {
                if (data.CompareTo(index.data) == -1)
                {
                    this.DeleteNode(ref index.left, data);
                    this.Ballance(ref index);
                }
                else if (data.CompareTo(index.data) == 1)
                {
                    this.DeleteNode(ref index.right, data);
                    this.Ballance(ref index);
                }
                else
                {
                    Trees temp = index;
                    if (index.right == null) index = index.left;
                    else if (index.left == null) index = index.right;
                    else this.FindToDelete(ref index.left, index, ref temp);
                }
            }
        }

        void PLeaf(Trees treeIndex, T[] array, ref int arrayIndex)
        {
            if (treeIndex.left != null) PLeaf(treeIndex.left, array, ref arrayIndex);
            array[arrayIndex] = treeIndex.data;
            arrayIndex++;
            if (treeIndex.right != null) PLeaf(treeIndex.right, array, ref arrayIndex);
        }

        bool Search(Trees index, T data)
        {
            if (index != null)
            {
                if (data.CompareTo(index.data) == 0) return true;
                else if (data.CompareTo(index.data) == -1) return this.Search(index.left, data);
                else if (data.CompareTo(index.data) == 1) return this.Search(index.right, data);
            }
            return false;
        }

        public void Push(T data)
        {
            this.push(ref this.root, data);
            this.count++;
            Console.WriteLine("Element " + data + " was added");

        }
        public void DeleteElement(T data)
        {
            this.DeleteNode(ref this.root, data);
            this.count--;
            Console.WriteLine("Element " + data + " deleted");
            Console.WriteLine();
        }

        bool _contains(Trees pointer, T data)
        {
            if (pointer != null)
            {
                if (data.CompareTo(pointer.data) == -1) return this._contains(pointer.left, data);
                else if (data.CompareTo(pointer.data) == 1) return this._contains(pointer.right, data);
                else return true;
            }
            return false;
        }

        public bool ElementSearch(T data)
        {
            return this._contains(this.root, data);
        }
        public int getCount()
        {
            return this.count;
        }

        public T[] Leaves()
        {
            T[] array = new T[this.count];
            int arrayIndex = 0;
            PLeaf(this.root, array, ref arrayIndex);
            return array;
        }
    }
}