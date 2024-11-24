using Contracts;
using Entities.Models;
using Services.Contracts;

namespace Services;

internal sealed class GroupService(IRepositoryManager repository) : IGroupService
{
    public IEnumerable<Group> GetAllGroups(bool trackChanges) => repository.Group.GetAllGroups(trackChanges);
}