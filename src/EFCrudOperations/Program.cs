using Microsoft.EntityFrameworkCore;


Console.WriteLine("Hello,EntityFrameworkCore!");


#region Context
AppDbContext context = new();
#endregion

#region Add

Person person = new()
{
    Name = "Ravan",
    Surname = "Alasgarov",
    Address = "Baku"
};

//await context.AddAsync(person);
Console.WriteLine(context.Entry(person).State);//Detached
await context.People.AddAsync(person);
Console.WriteLine(context.Entry(person).State);//Added
await context.SaveChangesAsync();//yaddaşda etdiyiniz dəyişiklikləri (yeni qeyd, yeniləmə və ya silmə) izləyərək onları daimi hala gətirmək üçün verilənlər bazasına (database) əks etdirən əməliyyatdır.
Console.WriteLine(context.Entry(person).State);//Unchanged
#endregion

#region AddRange
Person person1 = new()
{
    Name = "Polad",
    Surname = "Mirzayev",
    Address = "Baku"
};
Person person2 = new()
{
    Name = "Muxtar",
    Surname = "Babazada",
    Address = "Baku"
};

await context.People.AddRangeAsync(person1, person2);
await context.SaveChangesAsync();

#endregion

#region Update
var personToUpdate = await context.People.FirstOrDefaultAsync(p => p.Id == 3);
personToUpdate.Name = "Mukhtar";
await context.SaveChangesAsync();
#endregion

#region EFCore Update

var personToUpdate2 = new Person
{
    Id = 2,
    Name = "Polad",
    Surname = "Mirzayav",
    Address = "Baku"
};
context.People.Update(personToUpdate2);
await context.SaveChangesAsync();
#endregion

#region Remove
var personRemove = context.People.FirstOrDefault(p => p.Id == 3);
context.People.Remove(personRemove);
await context.SaveChangesAsync();
#endregion

#region Remove with EntityState
Person personRemoveEntityState = new() { Id = 2 };
context.Entry(personRemoveEntityState).State = EntityState.Deleted;
await context.SaveChangesAsync();
#endregion

#region RemoveRange
var people = context.People.Where(p => p.Id > 3).ToList();
context.People.RemoveRange(people);
await context.SaveChangesAsync();
#endregion

#region DbContext
public class AppDbContext : DbContext
{
    public DbSet<Person> People { get; set; }
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer("Server=Revan;Database=EFCoreDb;Trusted_Connection=True;TrustServerCertificate=True;");
    }
}
#endregion

#region Entity
public class Person
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Surname { get; set; }
    public string Address { get; set; }
}
#endregion


















