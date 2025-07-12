using Repositories.Models.Category;

namespace Services.Category;

using AutoMapper;
using Entities.DTO.Category;
using Repositories;

public class CategoryService : AbstractService<Entities.Models.Category.Category>
{
    public CategoryService(CategoryRepository repository, IMapper mapper) : base(repository, mapper)
    {
    }


    public async Task<IEnumerable<CategoryDto>> CategoryList()
    {
        var categories = await Repository.FindAllAsync();
        return Mapper.Map<IEnumerable<CategoryDto>>(categories);
    }


    public async Task<CreateCategoryDto> CreateCategory(CreateCategoryDto createCategoryDto)
    {
        var category = Mapper.Map<Entities.Models.Category.Category>(createCategoryDto);
        await Repository.AddAsync(category);
        Repository.SaveAsync();

        return Mapper.Map<CreateCategoryDto>(category);
    }


    public async Task<CategoryDto> GetCategoryById(Guid id)
    {
        var category = await CheckCategory(id);
        return Mapper.Map<CategoryDto>(category);
    }


    public async Task<CategoryDto> UpdateCategory(Guid id, CreateCategoryDto createCategoryDto)
    {
        var updatingCategory = await CheckCategory(id);

        Mapper.Map(createCategoryDto, updatingCategory);
        Repository.Update(updatingCategory);
        Repository.SaveAsync();

        return Mapper.Map<CategoryDto>(updatingCategory);
    }


    public async Task DeleteCategory(Guid id)
    {
        var category = await CheckCategory(id);
        Repository.Delete(category);
        Repository.SaveAsync();
    }


    private async Task<Entities.Models.Category.Category> CheckCategory(Guid id)
    {
        var category = await Repository.FindOneByAsync(c => c.Id.Equals(id));
        if (category is null)
            throw new Exception("Category not found");

        return category;
    }
}