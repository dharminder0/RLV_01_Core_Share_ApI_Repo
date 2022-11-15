//var builder = WebApplication.CreateBuilder(args);

//// Add services to the container.

//builder.Services.AddControllers();
//// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
//builder.Services.AddEndpointsApiExplorer();
//builder.Services.AddSwaggerGen();

//var app = builder.Build();

//// Configure the HTTP request pipeline.
//if (app.Environment.IsDevelopment()) {
//    app.UseSwagger();
//    app.UseSwaggerUI();
//}

//app.UseHttpsRedirection();

//app.UseAuthorization();

//app.MapControllers();

//app.Run();




using Core.Web.Api;

//var builder = WebApplication.CreateBuilder(args);
var builder = WebApplication.CreateBuilder(new WebApplicationOptions {
    Args = args,
    //ApplicationName = typeof(Program).Assembly.FullName,
    //ContentRootPath = Directory.GetCurrentDirectory(),
    //EnvironmentName = Environments.Staging,
    //WebRootPath = "customwwwroot"
});


var startup = new Startup(builder.Configuration);
startup.ConfigureServices(builder.Services); // calling ConfigureServices method
var app = builder.Build();
startup.Configure(app, builder.Environment);
app.Run();



// Reference path : https://learn.microsoft.com/en-us/aspnet/core/migration/50-to-60-samples?view=aspnetcore-6.0
