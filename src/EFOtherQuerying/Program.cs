using Microsoft.EntityFrameworkCore;

Console.WriteLine("Hello,EntityFrameworkCore!");
#region Context
AppDbContext context = new();
#endregion

#region CountAsync
var countPerson = await context.People.CountAsync();//CountAsync metodu verilənlər bazasında müəyyən bir şərtə uyğun olan qeydlərin sayını hesablamaq üçün istifadə olunur.Geriyə int tipində dəyər qaytarır.
#endregion

#region LongCountAsync
var LongCountPerson = await context.People.LongCountAsync();//LongCountAsync metodu CountAsync metoduna bənzəyir, lakin əgər qeydlərin sayı int tipinin maksimum dəyərindən çoxdursa, bu metod long tipində dəyər qaytarır.
#endregion

#region AnyAsync
var AnyPerson = await context.People.AnyAsync(p => p.Name == "Ravan");//AnyAsync metodu verilənlər bazasında müəyyən bir şərtə uyğun olan ən azı bir qeyd olub olmadığını yoxlamaq üçün istifadə olunur. Geriyə bool tipində dəyər qaytarır.
#endregion

#region MaxAsync
var MaxPerson = await context.People.MaxAsync(p => p.Id);//MaxAsync metodu verilənlər bazasında müəyyən bir xüsusiyyətə (property) görə ən böyük dəyəri tapmaq üçün istifadə olunur. Geriyə həmin xüsusiyyətin tipinə uyğun dəyər qaytarır.
#endregion

#region MinAsync
var MinPerson = await context.People.MinAsync(p => p.Id);//MinAsync metodu MaxAsync metoduna bənzəyir, lakin ən kiçik dəyəri tapmaq üçün istifadə olunur. Geriyə həmin xüsusiyyətin tipinə uyğun dəyər qaytarır.
#endregion

#region Distinct
var DistinctPerson = await context.People.Select(p => p.Name).Distinct().ToListAsync();//Distinct metodu verilənlər bazasında müəyyən bir xüsusiyyətə (property) görə təkrarlanan dəyərləri çıxarmaq üçün istifadə olunur. Geriyə həmin xüsusiyyətin tipinə uyğun dəyərlərin siyahısını qaytarır.
#endregion

#region AllAsync
var AllPerson = await context.People.AllAsync(p => p.Id > 0);//AllAsync metodu verilənlər bazasında müəyyən bir şərtə uyğun olan bütün qeydlərin olub olmadığını yoxlamaq üçün istifadə olunur. Geriyə bool tipində dəyər qaytarır.            
#endregion

#region SumAsync
var SumPerson = await context.People.SumAsync(p => p.Id);//SumAsync metodu verilənlər bazasında müəyyən bir xüsusiyyətə (property) görə bütün dəyərlərin cəmini tapmaq üçün istifadə olunur. Geriyə həmin xüsusiyyətin tipinə uyğun dəyər qaytarır.
#endregion

#region AvarageAsync
var AvaragePerson = await context.People.AverageAsync(p => p.Id);//AverageAsync metodu verilənlər bazasında müəyyən bir xüsusiyyətə (property) görə bütün dəyərlərin orta qiymətini tapmaq üçün istifadə olunur. Geriyə həmin xüsusiyyətin tipinə uyğun dəyər qaytarır.
#endregion

#region ContainsAsync
var ContainsPerson = await context.People.Where(p => p.Name.Contains("R")).ToListAsync();
#endregion

#region StartsWith
var StartsWithPerson = await context.People.Where(p => p.Name.StartsWith("R")).ToListAsync();
#endregion

#region EndsWith
var EndsWithPerson = await context.People.Where(p => p.Name.EndsWith("n")).ToListAsync();
#endregion

#region ToDictionaryAsync
var ToDictionaryPerson = await context.People.ToDictionaryAsync(p => p.Id, p => p.Name);//ToDictionaryAsync metodu verilənlər bazasındakı qeydləri müəyyən bir xüsusiyyətə (property) görə açar (key) və dəyər (value) cütləri şəklində bir lüğət (dictionary) halına gətirmək üçün istifadə olunur. Geriyə Dictionary<TKey, TValue> tipində bir lüğət qaytarır.
#endregion

#region ToArrayAsync
var ToArrayPerson = await context.People.ToArrayAsync();//ToArrayAsync metodu verilənlər bazasındakı qeydləri bir massiv (array) halına gətirmək üçün istifadə olunur. Geriyə T[] tipində bir massiv qaytarır.
#endregion

#region Select
var SelectPerson = await context.People.Select(p => new { p.Id, p.Name }).ToListAsync();//Select metodu verilənlər bazasındakı qeydləri müəyyən bir xüsusiyyətə (property) görə seçmək üçün istifadə olunur. Geriyə həmin xüsusiyyətlərin tipinə uyğun dəyərlərin siyahısını qaytarır.
#endregion


