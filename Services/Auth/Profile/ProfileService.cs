using AutoMapper;
using Entities.DTO.Auth.Profile;
using Entities.Models.Auth;
using Repositories;

namespace Services.Auth.Profile;

public class ProfileService : AbstractService<Entities.Models.Auth.Profile>
{
    public ProfileService(IBaseRepository<Entities.Models.Auth.Profile> repository, IMapper mapper) : base(repository, mapper)
    {
    }


    public async Task<ProfileRegistrationDto> Create(ProfileRegistrationDto profileRegistrationDto, User user)
    {
        var profile = Mapper.Map<Entities.Models.Auth.Profile>(profileRegistrationDto);
        
        profile.UserId = user.Id;
        profile.FullName = profileRegistrationDto.Name + " " + profileRegistrationDto.Surname;
        
       await Repository.AddAsync(profile);
       Repository.SaveAsync();

       return Mapper.Map<ProfileRegistrationDto>(profile);
    }
}