using Darius_PetDesk.Data.Interfaces;
using Darius_PetDesk.Data;
using Darius_PetDesk.Interfaces;
using Darius_PetDesk.Services;
using Microsoft.OpenApi.Models;
using Darius_PetDesk.Models;

var MyAllowSpecificOrigins = "_myAllowSpecificOrigins";
var builder = WebApplication.CreateBuilder(args);
var contact = new OpenApiContact()
{
    Name = "Darius Castillo",
    Email = "darius.castillo@azurewebservices.com",
    Url = new Uri("http://www.fakeurl.com")
};

var license = new OpenApiLicense()
{
    Name = "Fake License",
    Url = new Uri("http://www.fakeurl.com")
};
var info = new OpenApiInfo()
{
    Version = "v1",
    Title = "PetDesk Minimal API",
    Description = "",
    TermsOfService = new Uri("http://www.fakeurl.com"),
    Contact = contact,
    License = license
};
// Add services to the container.


builder.Services.AddSingleton<IAppointment, AppointmentService>();
builder.Services.AddSingleton<IAppointmentContext, AppointmentContext>();
builder.Services.AddHttpClient("AppointmentContext");
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddCors(options =>
{
    options.AddPolicy(name: MyAllowSpecificOrigins,
                      policy =>
                      {
                          policy.WithOrigins("https://localhost:44411/")
                                .AllowAnyHeader()
                                .AllowAnyMethod()
                                .SetIsOriginAllowed(origin => true);
                      });
});
builder.Services.AddSwaggerGen(o =>
{
    o.SwaggerDoc("v1", info);
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json",
        "Darius Castillo PetDesk Appointment API");
    });
}
else
{
    app.UseDefaultFiles();
    app.UseStaticFiles();
    app.MapFallbackToFile("index.html");
}
app.UseCors();
app.UseHttpsRedirection();

app.MapGet("/appointment/Root", async (IAppointment service, CancellationToken cToken) =>
{
    var resp = await service.AppointmentList(cToken);
    return resp;
})
    .Produces<Root[]>(StatusCodes.Status200OK)
    .Produces(StatusCodes.Status404NotFound)
    .WithTags("Root")
    .RequireCors(MyAllowSpecificOrigins);

app.Run();
