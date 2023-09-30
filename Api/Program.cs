using Api.Utils;
using Application.CategoryService.GetCategories;
using infrastructure;
using Microsoft.EntityFrameworkCore;
using Repository.Database;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(); 

builder.Services.AddAutoMapper(typeof(ShopMapper));

//builder.Services.AddIdentityService(builder.Configuration);

builder.Services.AddDbContext<SqlServer>(optionsAction: options => {
    options.UseSqlServer(connectionString: builder.Configuration.GetConnectionString("SqlServer"));
});

  
//

builder.Services.AddTransient<IGetCategoriesService<GetCategoriesResponse, GetCategoriesRequest>, GetCategoriesService>();

//

 
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}



app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
