using Microsoft.AspNetCore.Http;

namespace WebMVC.Servicos
{
    public interface IServicosDeArquivos
    {
        string Upload(IFormFile file);

        string ExcluirArquivoDoDisco(string path);
    }
}