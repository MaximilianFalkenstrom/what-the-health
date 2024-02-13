using WhatTheHealth.Domain.Entities;
using WhatTheHealth.Core.Exceptions;

namespace WhatTheHealth.Core.Services.UserSettings;

public interface IUserSettingRepository
{
    /// <summary>
    /// Creates the given <see cref="UserSetting"/>, returning the same item with the id field containing the id of the newly created item.
    /// </summary>
    /// <param name="userSetting"></param>
    /// <returns>The created <see cref="UserSetting"/></returns>
    Task<UserSetting> Create(UserSetting userSetting);
    
    /// <summary>
    /// Retrieves all stored instances of <see cref="UserSetting"/>.
    /// </summary>
    /// <returns>A list containing all <see cref="UserSetting"/>s</returns>
    IEnumerable<UserSetting> GetAll();

    /// <summary>
    /// Retrieves the <see cref="UserSetting"/> with the given id.
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    /// <exception cref="DbNotFoundException">Throws <see cref="DbNotFoundException"/> if no record could be found</exception>
    Task<UserSetting> GetById(string id);

    /// <summary>
    /// Updates the given <see cref="UserSetting"/>.
    /// </summary>
    /// <param name="userSetting"></param>
    /// <returns>The updated <see cref="UserSetting"/></returns>
    /// <exception cref="DbEditException">Throws <see cref="DbEditException"/> if the record could not be deleted</exception>
    Task<UserSetting> Update(UserSetting userSetting);

    /// <summary>
    /// Deletes the given <see cref="UserSetting"/>.
    /// </summary>
    /// <param name="userSetting"></param>
    /// <returns></returns>
    /// <exception cref="DbDeleteException">Throws <see cref="DbDeleteException"/> if no record could be deleted</exception>

    Task Delete(UserSetting userSetting);

    /// <summary>
    /// Deletes the <see cref="UserSetting"/> with the given id.
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    /// <exception cref="DbDeleteException">Throws <see cref="DbDeleteException"/> if no record could be deleted</exception>
    Task DeleteById(string id);
}
