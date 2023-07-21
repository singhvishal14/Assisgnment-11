using System;

namespace ConAppIdisposable
{
    internal class Program
    {
        static void Main(string[] args)
        {
            using (LargeDataCollection collection = new LargeDataCollection(new FileHandler[]
            {
                new FileHandler("Document-001"),
                new FileHandler("Document-002")
            }))
            {
                FileHandler file1 = collection.GetElement(0);
                file1.GetFileDetails();

                collection.Add(new FileHandler("Document-003"));

                FileHandler file2 = collection.GetElement(1);
                collection.Remove(file2);

                FileHandler file3 = collection.GetElement(1);
                file3.GetFileDetails();
            }
            Console.ReadKey();
        }
    }
}