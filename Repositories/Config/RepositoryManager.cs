using Repositories.Config.Context;
using Repositories.Models.Auth;
using Repositories.Models.Category;
using Repositories.Models.Product;

namespace Repositories.Config;

public class RepositoryManager
{
    public RepositoryManager(
        RepositoryContext context, 
        ProductRepository productRepository,
        CategoryRepository categoryRepository,
        UserRepository userRepository,
        ProfileRepository profileRepository
    )
    {
        _context = context;
        _productRepository = productRepository;
        _categoryRepository = categoryRepository;
        _userRepository = userRepository;
        _profileRepository = profileRepository;
    }

    private readonly RepositoryContext _context;

    private readonly ProductRepository _productRepository;
    
    private readonly CategoryRepository _categoryRepository;
    
    private readonly UserRepository _userRepository;
    
    private readonly ProfileRepository _profileRepository;

    public ProductRepository ProductRepository => _productRepository;
    
    public CategoryRepository CategoryRepository => _categoryRepository;
    
    public UserRepository UserRepository => _userRepository;
    
    public ProfileRepository ProfileRepository => _profileRepository;
}