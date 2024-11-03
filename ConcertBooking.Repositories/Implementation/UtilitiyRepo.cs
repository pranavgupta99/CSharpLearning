using CSharpLearning.ConcertBooking.Repositories;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;

namespace CSharpLearning.ConcertBooking.Repositories
{
    public class UtilitiyRepo : IUtilityRepo
    {
        private IWebHostEnvironment _env;
        private IHttpContextAccessor _contextAccessor;

        public UtilitiyRepo(IWebHostEnvironment env, IHttpContextAccessor contextAccessor)
        {
            _env = env;
            _contextAccessor = contextAccessor;
        }

        public Task DeleteImage(string ContainerName, string dbPath)
        {
            if (string.IsNullOrEmpty(ContainerName))
            {
                return Task.CompletedTask;
            }
            var fileName = Path.GetFileName(dbPath);
            var completePath = Path.Combine(_env.WebRootPath, ContainerName, fileName);
            if (File.Exists(completePath))
            {
                File.Delete(completePath);
            }
            return Task.CompletedTask;
        }

        public async Task<string> EditImage(string ContainerName, IFormFile file, string dbPath)
        {
            await DeleteImage(ContainerName, dbPath);
            return await SaveImage(ContainerName, file);
        }

        //https://localhost:7232/ContainerName/guid
        public async Task<string> SaveImage(string ContainerName, IFormFile file) //A.jpg
        {
            var extension = Path.GetExtension(file.FileName);
            var fileName = $"{Guid.NewGuid()}{extension}";
            string folder = Path.Combine(_env.WebRootPath, ContainerName);
            if (!Directory.Exists(folder))
            {
                Directory.CreateDirectory(folder);
            }
            string filePath = Path.Combine(folder, fileName);

            using (var memoryStreem = new MemoryStream())
            {
                await file.CopyToAsync(memoryStreem);
                var content  = memoryStreem.ToArray();
                await File.WriteAllBytesAsync(filePath, content);

            }

            var basePath = $"{_contextAccessor.HttpContext.Request.Scheme}://{_contextAccessor.HttpContext.Request.Host}";
            var completePath = Path.Combine(basePath, ContainerName, fileName).Replace("\\","/");
            return completePath;
        }
    }
}
