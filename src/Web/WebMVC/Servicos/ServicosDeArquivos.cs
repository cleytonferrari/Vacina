using System;
using System.IO;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;

namespace WebMVC.Servicos
{
    public class ServicosDeArquivos : IServicosDeArquivos
    {
        private readonly IWebHostEnvironment env;

        public ServicosDeArquivos(IWebHostEnvironment env)
        {
            this.env = env;
        }

        public string ExcluirArquivoDoDisco(string path)
        {
            if (File.Exists(path))
            {
                File.Delete(path);
            }
            return path;
        }

        public string Upload(IFormFile file)
        {
            var diretorioUpload = "CSV/";
            var pathUpload = Path.Combine(env.WebRootPath, diretorioUpload);

            if (!Directory.Exists(pathUpload))
                Directory.CreateDirectory(pathUpload);

            var fileName = Guid.NewGuid() + Path.GetExtension(file.FileName);
            var filePath = Path.Combine(pathUpload, fileName);

            using (var strem = File.Create(filePath))
            {
                file.CopyTo(strem);
            }
            return filePath;
        }
    }
}
