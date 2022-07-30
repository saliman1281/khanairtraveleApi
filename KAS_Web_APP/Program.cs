using DBCore;
using Services.CommonService;
using Services.CustomerService;
using Services.DealerService.DealerInfoService;
using Services.TicketService.TicketInfoService;
using Services.TicketService.TicketInstalmentService;
using Services.VisaService.VisaInformationService;
using Services.VisaService.VisaInstalmentService;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddScoped<ICustomerService, CustomerService>();
builder.Services.AddScoped<IDBConnection, DBConnection>();
builder.Services.AddScoped<IListConverter, ListConverter>();
builder.Services.AddScoped<ITicketInfoService, TicketInfoService>();
builder.Services.AddScoped<ITicketInstalmentService, TicketInstalmentService>();
builder.Services.AddScoped<IVisaInfoService, VisaInfoService>();
builder.Services.AddScoped<IVisaInstalmentService, VisaInstalmentService>();
builder.Services.AddScoped<IDealerInfoService, DealerInfoService>();
builder.Services.AddScoped<ICommonService, CommonService>();
builder.Services.AddMvc();
builder.Services.AddControllers();
builder.Services.AddControllers();
builder.Services.AddCors(options =>
{
    options.AddPolicy("CorsPolicy",
        builder => builder.AllowAnyOrigin()
        .AllowAnyMethod()
        .AllowAnyHeader());
});

var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseCors("CorsPolicy");

app.UseRouting();
app.UseAuthorization();
app.UseEndpoints(endpoints =>
{
    endpoints.MapControllers();
});
app.Run();
