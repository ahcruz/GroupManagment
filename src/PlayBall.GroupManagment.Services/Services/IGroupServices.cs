using PlayBall.GroupManagment.Services.Models;
using System.Collections.Generic;

namespace PlayBall.GroupManagment.Services.Services
{
    public interface IGroupServices
    {
        IReadOnlyCollection<Group> GetAll();
        Group GetById(long id);
        Group Update(Group model);
        Group Create(Group model);
    }
}
