using Microsoft.EntityFrameworkCore;
Console.WriteLine("Hello,EntityFrameworkCore!");

#region Context


AppDbContext context = new();
#endregion

#region ToListAsync
var people = await context.People.ToListAsync();//ToListAsync metodu verilənlər bazasındakı bütün qeydləri siyahı şəklində gətirmək üçün istifadə olunur.
#endregion

#region Where
var filteredPeople= await context.People.Where(context => context.Name == "Ravan").ToListAsync();//Ravan adlı şəxsləri gətirir.Where metodu ilə verilənlər bazasında müəyyən bir şərtə uyğun olan qeydləri seçmək üçün istifadə olunur.
#endregion

#region OrderBy
var OrderByPeople = await context.People.Where(p => p.Id > 5).OrderBy(p => p.Id).ToListAsync();//OrderBy metodu verilənlər bazasından gələn məlumatları müəyyən bir xüsusiyyətə (property) görə artan ardıcıllıqla sıralamaq üçün istifadə olunur.
#endregion

#region ThenBy
var ThenByPeople = await context.People.Where(p => p.Id > 5).OrderBy(p => p.Id).ThenBy(p=>p.Name).ToListAsync();//ThenBy metodu, OrderBy (və ya OrderByDescending) ilə ilkin sıralama aparıldıqdan sonra, eyni dəyərə malik olan elementləri ikinci bir kriteriya üzrə sıralamaq üçün istifadə olunur.
#endregion

#region SingleAsync
var singlePerson = await context.People.SingleAsync(p => p.Id == 1);//SingleAsync metodu verilənlər bazasında yalnız bir qeydin mövcud olduğunu və həmin qeydi gətirmək üçün istifadə olunur. Əgər şərtə uyğun bir neçə və ya heç bir qeyd tapılmazsa, bu metod istisna (exception) atır.
#endregion

#region SingleOrDefaultAsync
var SingleOrDefaultPerson = await context.People.SingleOrDefaultAsync(p=> p.Id == 1);//SingleOrDefaultAsync metodu SingleAsync metoduna bənzəyir, lakin əgər şərtə uyğun heç bir qeyd tapılmazsa, bu metod null dəyərini qaytarır. Əgər bir neçə uyğun qeyd tapılarsa, istisna (exception) atır.
#endregion

#region FirstAsync
var FirstPerson = await context.People.FirstAsync(p => p.Id == 1);//FirstAsync metodu verilənlər bazasında şərtə uyğun olan ilk qeydi gətirmək üçün istifadə olunur. Əgər heç bir uyğun qeyd tapılmazsa, bu metod istisna (exception) atır.
#endregion

#region FirstOrDefaultAsync
var FirstOrDefaultPerson = await context.People.FirstOrDefaultAsync(p => p.Id == 1);//FirstOrDefaultAsync metodu FirstAsync metoduna bənzəyir, lakin əgər şərtə uyğun heç bir qeyd tapılmazsa, bu metod null dəyərini qaytarır.
#endregion

#region FindAsync
var FindPerson = await context.People.FindAsync(1);//FindAsync metodu verilənlər bazasında müəyyən bir əsas açara (primary key) uyğun olan qeydi tapmaq üçün istifadə olunur. Əgər uyğun qeyd tapılmazsa, bu metod null dəyərini qaytarır.
#region Composite Primary Key
var FindCompositePerson = await context.People.FindAsync(1,2);
#endregion
#endregion

#region LastAsync
var LastPerson = await context.People.OrderBy(p => p.Name).LastAsync(p => p.Id == 1);//LastAsync metodu verilənlər bazasında şərtə uyğun olan sonuncu qeydi gətirmək üçün istifadə olunur. Əgər heç bir uyğun qeyd tapılmazsa, bu metod istisna (exception) atır.
#endregion

#region LastOrDefaultAsync
var LastOrDefaultPerson = await context.People.OrderBy(p => p.Name).LastOrDefaultAsync(p => p.Id == 1);//LastOrDefaultAsync metodu LastAsync metoduna bənzəyir, lakin əgər şərtə uyğun heç bir qeyd tapılmazsa, bu metod null dəyərini qaytarır.
#endregion

