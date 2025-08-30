using Services.Auth;
using Services.Auth.Profile;
using Services.Category;
using Services.Product;
using Services.Workspace;

namespace Services.Config;

public class ServiceManager
{
    private readonly ProductService _productService;
    private readonly CategoryService _categoryService;
    private readonly AuthenticationService _authenticationService;
    private readonly ProfileService _profileService;
    private readonly WorkspaceService _workspaceService;

    public ServiceManager(ProductService productService, CategoryService categoryService, AuthenticationService authenticationService, ProfileService profileService, WorkspaceService workspaceService)
    {
        _productService = productService;
        _categoryService = categoryService;
        _authenticationService = authenticationService;
        _profileService = profileService;
        _workspaceService = workspaceService;
    }

    public ProductService ProductService => _productService;
    
    public CategoryService CategoryService => _categoryService;
    
    public AuthenticationService AuthenticationService => _authenticationService;
    
    public ProfileService ProfileService => _profileService;
    
    public WorkspaceService WorkspaceService => _workspaceService;
}