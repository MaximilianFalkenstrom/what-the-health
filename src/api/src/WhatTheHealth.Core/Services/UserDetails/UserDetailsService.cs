using UserDetailsEntity = WhatTheHealth.Domain.Entities.UserDetails;

namespace WhatTheHealth.Core.Services.UserDetails;



public class UserDetailsService : IUserDetailsService
{
    private readonly IUserDetailsRepository _userDetailsRepository;

    public UserDetailsService(IUserDetailsRepository userDetailsRepository)
    {
        _userDetailsRepository = userDetailsRepository;
    }

    public async Task<UserDetailsEntity> Create(UserDetailsEntity userDetails)
    {
        return await _userDetailsRepository.Create(userDetails);
    }

    public async Task<UserDetailsEntity> Edit(UserDetailsEntity userDetails)
    {
        return await _userDetailsRepository.Update(userDetails);
    }

    public IEnumerable<UserDetailsEntity> GetAll() 
    {
        var userDetails = _userDetailsRepository.GetAll();

        return userDetails;
    }

    public async Task<UserDetailsEntity> GetById(string id)
    {
        return await _userDetailsRepository.GetById(id);
    }

    public async Task RemoveById(string id)
    {
        await _userDetailsRepository.DeleteById(id);
    }
}
