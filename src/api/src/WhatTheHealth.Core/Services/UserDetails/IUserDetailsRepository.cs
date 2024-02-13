using UserDetailsEntity = WhatTheHealth.Domain.Entities.UserDetails;
using WhatTheHealth.Core.Exceptions;

namespace WhatTheHealth.Core.Services.UserDetails;


public interface IUserDetailsRepository
{
    /// <summary>
    /// Creates the given <see cref="UserDetails"/>, returning the same item with the id field containing the id of the newly created item.
    /// </summary>
    /// <param name="userDetails"></param>
    /// <returns>The created <see cref="UserDetails"/></returns>
    Task<UserDetailsEntity> Create(UserDetailsEntity userDetails);
    
    /// <summary>
    /// Retrieves all stored instances of <see cref="UserDetails"/>.
    /// </summary>
    /// <returns>A list containing all <see cref="UserDetails"/>s</returns>
    IEnumerable<UserDetailsEntity> GetAll();

    /// <summary>
    /// Retrieves the <see cref="UserDetails"/> with the given id.
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    /// <exception cref="DbNotFoundException">Throws <see cref="DbNotFoundException"/> if no record could be found</exception>
    Task<UserDetailsEntity> GetById(string id);

    /// <summary>
    /// Updates the given <see cref="UserDetails"/>.
    /// </summary>
    /// <param name="userDetails"></param>
    /// <returns>The updated <see cref="UserDetails"/></returns>
    /// <exception cref="DbEditException">Throws <see cref="DbEditException"/> if the record could not be deleted</exception>
    Task<UserDetailsEntity> Update(UserDetailsEntity userDetails);

    /// <summary>
    /// Deletes the given <see cref="UserDetails"/>.
    /// </summary>
    /// <param name="userDetails"></param>
    /// <returns></returns>
    /// <exception cref="DbDeleteException">Throws <see cref="DbDeleteException"/> if no record could be deleted</exception>

    Task Delete(UserDetailsEntity userDetails);

    /// <summary>
    /// Deletes the <see cref="UserDetails"/> with the given id.
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    /// <exception cref="DbDeleteException">Throws <see cref="DbDeleteException"/> if no record could be deleted</exception>
    Task DeleteById(string id);
}
