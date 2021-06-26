using Microsoft.AspNetCore.Http;

namespace WebMVC.Servicos
{
    public interface IServicoArquivo
    {
        string Upload(IFormFile file);

        string ApagarArquivo(string path);
    }
}