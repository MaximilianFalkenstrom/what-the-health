using UserDetailsEntity = WhatTheHealth.Domain.Entities.UserDetails;

namespace WhatTheHealth.Core.Services.UserDetails;

public interface IUserDetailsService
{
    Task<UserDetailsEntity> Create(UserDetailsEntity userSettings);

    IEnumerable<UserDetailsEntity> GetAll();

    Task<UserDetailsEntity> GetById(string id);

    Task<UserDetailsEntity> Edit(UserDetailsEntity userSettings);

    Task RemoveById(string id);
}
