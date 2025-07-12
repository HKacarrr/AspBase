using Repositories.Config.Context;
using Repositories.Models.Product;

namespace Repositories.Config;

public class RepositoryManager
{
    public RepositoryManager(RepositoryContext context, ProductRepository productRepository)
    {
        _context = context;
        _productRepository = productRepository;
    }

    private readonly RepositoryContext _context;

    private readonly ProductRepository _productRepository;

    public ProductRepository ProductRepository => _productRepository;
}