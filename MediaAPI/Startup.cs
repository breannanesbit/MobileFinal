using Azure.Storage.Blobs;
using MediaAPI.services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace MediaAPI
{
    public class Startup
    {
        public IConfiguration configRoot
        {
            get;
        }
        public Startup(IConfiguration configuration)
        {
            configRoot = configuration;
        }
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddRazorPages();
            services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen();
            var blobstring = configRoot.GetConnectionString("blobString");
            var database = configRoot.GetConnectionString("database");
            services.AddDbContext<MultiMediaAppContext>(options => options.UseNpgsql(database));
            services.AddScoped<IDatabaseService, DatabaseService>();
            services.AddScoped<MultiMediaAppContext>();

            services.AddSingleton(x => new BlobServiceClient(blobstring));
            BlobServiceClient blobServiceClient = new(blobstring);

        }
        public void Configure(WebApplication app, IWebHostEnvironment env)
        {
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseRouting();
            app.UseAuthorization();
            app.MapRazorPages();
            app.Run();
        }
    }
}
