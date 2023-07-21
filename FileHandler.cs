
using System;

namespace ConAppIdisposable
{
    public class FileHandler : IDisposable
    {
        LargeDataCollection fileObject = null;
        static int totalFiles = 0;
        bool disposedvalue;

        public FileHandler(string fileName)
        {
            if (fileObject == null)
            {
                totalFiles++;
                fileObject = new LargeDataCollection(new FileHandler[] { this }); // Add this line
            }
            Console.WriteLine("File Created");
            Console.WriteLine("Number of files are: " + totalFiles);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedvalue)
            {
                if (disposing)
                {
                    totalFiles = 0;
                }
            }
            Console.WriteLine("File {0} has been disposed", fileObject.GetElement(0).ToString()); // Add this line
            fileObject = null;
            disposedvalue = true;
        }

        public void Dispose()
        {
            Dispose(disposing: true);
            GC.SuppressFinalize(this);
        }

        public void GetFileDetails()
        {
            Console.WriteLine(fileObject.GetElement(0).ToString() + " file has been created Successfully"); // Add this line
        }

        ~FileHandler()
        {
            Dispose(false);
        }
    }
}