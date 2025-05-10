namespace WebSmonder.Models.Product;

public class ProductListViewModel
{
    //Відображення списку даних
    public List<ProductItemViewModel> Products { get; set; } = new();
    //Модель для пошуку
    public ProductSearchViewModel Search { get; set; } = new();
}
