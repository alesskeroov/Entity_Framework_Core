using Microsoft.EntityFrameworkCore;


Console.WriteLine("Hello,EntityFrameworkCore!");

#region Context
AppDbContext context = new();
#endregion

#region Change Tracking
//Change Tracking, Entity Framework Core-un bazadan oxunan obyektlərin vəziyyətini izləyərək, SaveChanges() çağırılan zaman edilən dəyişiklikləri (əlavə, dəyişiklik və ya silinmə) avtomatik olaraq müvafiq SQL sorğularına çevirməsidir. Bu mexanizm sizə SQL yazmadan sadəcə C# obyektləri üzərində dəyişiklik edərək bazanı yeniləməyə imkan verir.
#endregion

#region Change Tracker 
var People = await context.People.ToListAsync();//Bu əməliyyat bazadan bütün People qeydlərini oxuyur və onları yaddaşa yükləyir. Bu zaman, ChangeTracker bu obyektlərin vəziyyətini izləməyə başlayır. Hər bir obyektin vəziyyəti "Unchanged" olaraq təyin edilir, çünki onlar bazadan oxunmuş və heç bir dəyişiklik edilməmişdir.
People[1].Name = "Mukhtar";//Bu sətrdə, People siyahısındakı ikinci obyektin (index 1) Name xüsusiyyəti "Mukhtar" olaraq dəyişdirilir. Bu zaman, ChangeTracker bu obyektin vəziyyətini "Modified" olaraq təyin edir, çünki onun bir xüsusiyyəti dəyişdirilmişdir.

var changeTracker = context.ChangeTracker.Entries();//ChangeTracker, Entity Framework Core-un obyektlərin vəziyyətini izləmək üçün istifadə etdiyi bir xüsusiyyətdir. Bu xüsusiyyət vasitəsilə, hansı obyektlərin əlavə edildiyini, dəyişdirildiyini və ya silindiyini görə bilərsiniz. ChangeTracker, SaveChanges() çağırıldığında edilən dəyişiklikləri SQL sorğularına çevirmək üçün istifadə olunur.

await context.SaveChangesAsync();//Bu əməliyyat, yaddaşda edilən dəyişiklikləri (bu halda, People[1] obyektinin Name xüsusiyyətinin dəyişdirilməsi) bazaya əks etdirir. SaveChangesAsync() çağırıldığında, ChangeTracker bu obyektin vəziyyətini "Unchanged" olaraq təyin edir, çünki dəyişikliklər artıq bazaya tətbiq edilmişdir.
#endregion

#region Detect Changes
var DetectPerson = await context.People.FirstOrDefaultAsync(p => p.Id == 1);
DetectPerson.Name = "Filyar";


context.ChangeTracker.DetectChanges();//DetectChanges() metodu, Entity Framework Core-un Change Tracker mexanizminin obyektlərin vəziyyətini yenidən yoxlamasını təmin edir. Bu metod çağırıldığında, Change Tracker yaddaşdakı obyektlərin vəziyyətini yenidən qiymətləndirir və hansı obyektlərin əlavə edildiyini, dəyişdirildiyini və ya silindiyini müəyyən edir. Bu metod adətən SaveChanges() çağırılmadan əvvəl avtomatik olaraq çağırılır, lakin bəzi hallarda əl ilə çağırmaq lazım ola bilər.


await context.SaveChangesAsync();//Bu əməliyyat, yaddaşda edilən dəyişiklikləri (bu halda, DetectPerson obyektinin Name xüsusiyyətinin dəyişdirilməsi) bazaya əks etdirir. SaveChangesAsync() çağırıldığında, ChangeTracker bu obyektin vəziyyətini "Unchanged" olaraq təyin edir, çünki dəyişikliklər artıq bazaya tətbiq edilmişdir.

#endregion

#region Entries
var EntriesPeople = await context.People.ToListAsync();
EntriesPeople.FirstOrDefault(p => p.Id == 1).Name = "Ravan";

context.ChangeTracker.Entries().ToList().ForEach(e =>
{
    if (e.State == EntityState.Unchanged)
    {
        //....
    }
    else if (e.State == EntityState.Added)
    {
        //....
    }
    else if (e.State == EntityState.Modified)
    {
        //....
    }
    else if (e.State == EntityState.Deleted)
    {
        //....
    }
    else if (e.State == EntityState.Detached)
    {
        //....
    }
});
//Entries() metodu, Entity Framework Core-un Change Tracker mexanizminin izlədiyi obyektlərin vəziyyətini göstərən bir siyahı (list) qaytarır. Bu metod çağırıldığında, Change Tracker yaddaşdakı obyektlərin vəziyyətini qiymətləndirir və hər bir obyektin əlavə edildiyini, dəyişdirildiyini və ya silindiyini müəyyən edir. Entries() metodu, SaveChanges() çağırılmadan əvvəl avtomatik olaraq çağırılır, lakin bəzi hallarda əl ilə çağırmaq lazım ola bilər.



#endregion

#region Entity States
#region Detached
Person Person = new();
Console.WriteLine(context.Entry(Person).State);//Detached

#endregion

#region Added
Person person = new()
{
    Name = "Ayla",
    Surname = "Quliyeva",
    Address = "Baku"
};
Console.WriteLine(context.Entry(person).State);//Detached
await context.People.AddAsync(person);
Console.WriteLine(context.Entry(person).State);//Added
await context.SaveChangesAsync();

#endregion

#region Unchanged
//var UnchangedPerson = await context.People.ToListAsync();
//var data = context.ChangeTracker.Entries();
#endregion

#region Modified
var ModifiedPerson = await context.People.FirstOrDefaultAsync(p => p.Id == 1);
Console.WriteLine(context.Entry(ModifiedPerson).State);//Unchanged
ModifiedPerson.Surname = "Alasgarli";
Console.WriteLine(context.Entry(ModifiedPerson).State);//Modified
await context.SaveChangesAsync();
Console.WriteLine(context.Entry(ModifiedPerson).State);//Unchanged

#endregion

#region Deleted
var DeletedPerson = await context.People.FirstOrDefaultAsync(p => p.Id == 1);
context.People.Remove(DeletedPerson);
Console.WriteLine(context.Entry(DeletedPerson).State);//Deleted
context.SaveChanges();

#endregion

#endregion

Console.WriteLine("BreakPoint!");

