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
}
