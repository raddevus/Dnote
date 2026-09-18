using Models;

namespace Dnote.Tests;

public class EntryTests 
{
    [Fact]
    public void Test1()
    {
      Entry e = new(DateTime.Now.ToString(),"test data");
    }
}
