using System;
using Interfaces;
using Models;

public class EntryService{
   IPersistable EntryRepo;

   public EntryService(IPersistable entryRepo){
      if (entryRepo == null){ throw new ArgumentNullException("EntryRepo");
      }
      EntryRepo = entryRepo;
      
   }

   public bool Save(Entry entry){
      return EntryRepo.Save(entry);
   }
}
