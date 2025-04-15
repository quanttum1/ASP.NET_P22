namespace WebSmonder.Interfaces;

public interface IImageService
{
    Task<string> SaveImageAsync(IFormFile file);
}
