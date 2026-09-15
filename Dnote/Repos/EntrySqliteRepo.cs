using Interfaces;

namespace Repos;

public class EntrySqliteRepo: IPersistable{
   public bool Save(){
      return true;
   }

   public bool Read(){
      return true;
   }
}
