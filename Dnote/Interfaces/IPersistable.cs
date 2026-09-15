using Models;

namespace Interfaces;

public interface IPersistable{
   public bool Save(Entry entry);
   public bool Read();
}
