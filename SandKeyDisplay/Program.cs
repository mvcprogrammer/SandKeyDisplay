using FluentEmail.MailKitSmtp;
using SandKeyDisplay.Settings;

var builder = WebApplication.CreateBuilder(args);

//var environment = builder.Environment.EnvironmentName.ToLower();
builder.Configuration.AddSystemsManager("/production/sandkeydisplay", TimeSpan.FromSeconds(90));

// Add services to the container.
builder.Services.AddControllersWithViews();

// not in appsettings - stored in aws vault
builder.Services.Configure<StellarSettings>(builder.Configuration.GetSection("StellarSettings"));
builder.Services.Configure<MailgunSettings>(builder.Configuration.GetSection("MailgunSettings"));

builder.Services
    .AddFluentEmail("info.request@sandkeyhomesandcondos.com")
    .AddMailKitSender(new SmtpClientOptions
    {
        Server = "smtp.mailgun.org",
        Port = 587,
        Password = builder.Configuration["MailgunSettings:Password"],
        UseSsl = false,
        User = builder.Configuration["MailgunSettings:User"],
        RequiresAuthentication = true
    });

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.MapControllers();
app.UseAuthorization();
app.Run();