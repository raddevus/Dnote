using System.Threading;
using System.Threading.Tasks;
using System.IO;
using Interfaces;
using Models;

namespace Repos;

public class EntrySqliteRepo: IPersistable{
   public bool Save(Entry entry){
      return true;
   }

   public bool Read(){
      return true;
   }
      public async Task<bool> SaveAsync(string documentKey, Stream contentStream, CancellationToken cancellationToken = default){
      return true;
   }

}
