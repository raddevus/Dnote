using System.Threading;
using System.Threading.Tasks;
using System.IO;

using Interfaces;
using Models;

public class PersistFileService : IPersistable
{
    public async Task<bool> SaveAsync(string documentKey, Stream contentStream, CancellationToken cancellationToken = default)
    {
        // FileMode.Create creates a new file or overwrites an existing file cleanly
        await using var fileStream = new FileStream(
            documentKey, 
            FileMode.Create, 
            FileAccess.Write, 
            FileShare.None, 
            bufferSize: 4096, 
            useAsync: true);

        contentStream.Position = 0; // Ensure stream is at the beginning before copying
        await contentStream.CopyToAsync(fileStream, cancellationToken);
        return true;
    }

    public bool Read(){
       return true;
    }

    public bool Save(Entry entry){
       return true;
    }
}
