namespace RestAPIexample.DB;

public record Product
{
    public int Id { get; set; }
    public string ? Name { get; set; }
}

public class ProductDB
{
    private static List<Product> _Products = new List<Product>()
   {
     new Product{ Id=1, Name="First product" },
     new Product{ Id=2, Name="Second product"},
     new Product{ Id=3, Name="Third product"}
   };

    public static List<Product> GetProducts()
    {
        return _Products;
    }

    public static Product ? GetProduct(int id)
    {
        return _Products.SingleOrDefault(Product => Product.Id == id);
    }

    public static Product CreateProduct(Product Product)
    {
        _Products.Add(Product);
        return Product;
    }

    public static Product UpdateProduct(Product update)
    {
        _Products = _Products.Select(Product =>
        {
            if (Product.Id == update.Id)
            {
                Product.Name = update.Name;
            }
            return Product;
        }).ToList();
        return update;
    }

    public static void RemoveProduct(int id)
    {
        _Products = _Products.FindAll(Product => Product.Id != id).ToList();
    }
}