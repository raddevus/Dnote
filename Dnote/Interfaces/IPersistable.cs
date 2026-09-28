using Models;
using System.IO;
using System.Threading;
using System.Threading.Tasks;

namespace Interfaces;

public interface IPersistable{
   public bool Save(Entry entry);
   public bool Read();
   public Task<bool> SaveAsync(string documentKey, Stream contentStream, CancellationToken cancellationToken = default);
}
