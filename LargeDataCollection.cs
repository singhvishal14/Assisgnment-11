
using System;
using System.Collections.Generic;

namespace ConAppIdisposable
{
    internal class LargeDataCollection : IDisposable
    {
        private List<FileHandler> data;

        public LargeDataCollection(IEnumerable<FileHandler> initialData)
        {
            data = new List<FileHandler>(initialData);
        }

        public void Add(FileHandler item)
        {
            data.Add(item);
        }

        public bool Remove(FileHandler item)
        {
            return data.Remove(item);
        }

        public FileHandler GetElement(int index)
        {
            if (index >= 0 && index < data.Count)
            {
                return data[index];
            }
            throw new IndexOutOfRangeException("Index out of range.");
        }

        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!disposed)
            {
                if (disposing)
                {
                    // Release managed resources here (if any)
                    foreach (var item in data)
                    {
                        item.Dispose();
                    }
                }

                // Release unmanaged resources here (if any)
                data.Clear();
                data = null;

                disposed = true;
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}