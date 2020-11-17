using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mystruct
{
    public class MyCollection<T>: IEnumerable<T>, IEnumerator<T>, IDisposable
    {
        private int index=-1;
        private T[] arr = new T[0];
        public T Current { get { return arr[index]; } }

        object IEnumerator.Current { get { return arr[index]; } }

        public void Dispose()
        {
            index = -1;
        }

        public IEnumerator<T> GetEnumerator()
        {
           return this;
        }

        public bool MoveNext()
        {
            index++;
           
            return index < arr.Length;
        }

        public void Reset()
        {
            throw new NotImplementedException();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this;
        }
        public void Add(T obj)
        {
            T[] arr2 = new T[arr.Length + 1];
            for(int i=0;i<arr.Length;i++)
            {
                arr2[i] = arr[i];
            }
            arr2[arr.Length] = obj;
            arr = arr2;
        }
        public void Remove(T obj)
        {
            T[] arr2 = new T[arr.Length - 1];
            int k=0;
            for (int i = 0; i < arr.Length; i++)
            {
                if (arr[i].Equals(obj)) { continue; }
                arr2[k++] = arr[i];
            }
            arr = arr2;
        }
        public void RemoveAt(int j)
        {
            T[] arr2 = new T[arr.Length - 1];
            int k = 0;
            for (int i = 0; i < arr.Length; i++)
            {
                if (i==j) { continue; }
                arr2[k++] = arr[i];
            }
            arr = arr2;
        }
        public void RemoveAll()
        {
            Array.Clear(arr, 0, arr.Length);
        }
        public T Find(int j)
        {
            for (int i = 0; i < arr.Length; i++)
            {
                if (i == j) { return arr[i]; }
            }
            return default(T);
        }
       public int FindIndex(T obj)
        {
            for (int i = 0; i < arr.Length; i++)
            {
                if (arr[i].Equals(obj)) { return i; }
            }
           return -1; 
        }
        public void Insert(int after,T obj)
        {
            T[] arr2 = new T[arr.Length + 1];
            int k = 0;
            for (int i = 0; i < arr.Length; i++)
            {
                if (i == after) { arr2[k++] = arr[i]; arr[k++] = obj; }
                else { arr2[k++] = arr[i]; }

            }
        }
    }
}
