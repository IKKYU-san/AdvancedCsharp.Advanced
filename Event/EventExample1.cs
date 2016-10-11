
namespace AdvancedCsharp.Advanced.Event
{
    using System.IO;
    using System;

    public class EventExample1
    {

        public void Run()
        {
            var watchingPath = @"C:\TMP";
            var watcher = new FileSystemWatcher(); // FileSystemWatcher är "publisher"
            watcher.Path = watchingPath;
            // watcher.Filter = "*.txt";
            watcher.EnableRaisingEvents = true; // I annat fall så körs inga events

            // "Changed" är ett exempel på ett "event"
            watcher.Changed += FileChanged;
            watcher.Deleted += FileDeleted;
            watcher.Deleted += Apa;
            watcher.Renamed += FileRenamed;
            watcher.Created += FileCreated;

            Console.WriteLine($"Jag vakar över vad som händer på {watchingPath}");
            Console.ReadKey();
        }

        private void Apa(object sender, FileSystemEventArgs e)
        {
            Console.WriteLine("APA!");
        }

        private void FileCreated(object sender, FileSystemEventArgs e)
        {
            Console.WriteLine($"Filen {e.Name} skapades");
        }

        private void FileRenamed(object sender, RenamedEventArgs e)
        {
            Console.WriteLine($"Filen {e.Name} fick nytt namn");
        }

        private void FileDeleted(object sender, FileSystemEventArgs e)
        {
            Console.WriteLine($"Filen {e.Name} togs bort");
        }

        private void FileChanged(object sender, FileSystemEventArgs e)
        {
            Console.WriteLine($"Filen {e.Name} ändrades");
        }
    }
}
