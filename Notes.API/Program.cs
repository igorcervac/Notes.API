using Microsoft.EntityFrameworkCore;
using Notes.API.Models;

namespace Notes.API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var uiUrl = Environment.GetEnvironmentVariable("NotesUI");

            builder.Services.AddCors(opts => opts.AddDefaultPolicy
                (
                    p =>
                    {
                        p.WithOrigins(uiUrl);
                        p.AllowAnyMethod();
                        p.AllowAnyHeader();
                    }
                )
            );

            var connectionString = Environment.GetEnvironmentVariable("SQLAZURECONNSTR_NotesDB");
            builder.Services.AddDbContext<Subscription1DbContext>(opts => opts.UseSqlServer(connectionString));

            var inMemoryString = Environment.GetEnvironmentVariable("NotesInMemory");
            bool inMemory = false;
            bool.TryParse(inMemoryString, out inMemory);

            if (inMemory)
            {
                builder.Services.AddScoped<IGenericRepository<Note>, InMemoryGenericRepository<Note>>();
            }
            else
            {
                builder.Services.AddScoped<IGenericRepository<Note>, NoteRepository>();
            }

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();
            app.UseCors();

            app.MapControllers();

            app.Run();
        }
    }
}
