using System.IO;
using Interfaces;
using Models;

namespace Repos;

public class EntryFileRepo: IPersistable{

    public bool Save(Entry entry){
        try{
            Directory.CreateDirectory(entry.EntryFolder);
            var targetFile = Path.Combine(entry.EntryFolder,entry.EntryFile);
            File.Delete(targetFile);
            File.AppendAllText(targetFile,entry.Data);
        }
        catch{
            return false;
        }
        return true;
    }

   public bool Read(){
      return true;
   }
}
