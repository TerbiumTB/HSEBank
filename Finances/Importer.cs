namespace Finances;
using System.Text.Json;

// public class StorageImporter<T> where T: class, IIndexed
// {   
//     // public StorageImporter(string)
//     public IndexedStorage<T>? Import(string path)
//     {
//         FileStream stream = File.OpenRead(path);
//         return JsonSerializer.Deserialize<IndexedStorage<T>>(stream);
//     }
// }

// public class Importer
// {
//     private string Pathname { get; set; }
//     public Importer(string pathname)
//     {
//         Pathname = pathname;
//     }
//
//     public BankAccount? Import(TextReader reader)
//     {
//         // FileStream stream = File.OpenRead(Pathname);
//         return JsonSerializer.Deserialize<BankAccount>(reader.);
//     }
// }