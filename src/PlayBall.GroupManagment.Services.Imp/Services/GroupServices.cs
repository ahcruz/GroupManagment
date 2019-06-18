using PlayBall.GroupManagment.Services.Models;
using PlayBall.GroupManagment.Services.Services;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PlayBall.GroupManagment.Services.Imp.Services
{
    public class GroupServices : IGroupServices
    {
        private List<Group> _groups = new List<Group>();
        private long currentId = 0;

        public Group Create(Group model)
        {
            model.Id = ++currentId;
            _groups.Add(model);

            return model;
        }

        public IReadOnlyCollection<Group> GetAll()
        {
            return _groups.AsReadOnly();
        }

        public Group GetById(long id)
        {
            var group = _groups.SingleOrDefault(x => x.Id == id);

            return group;
        }

        public Group Update(Group model)
        {
            var group = _groups.SingleOrDefault(x => x.Id == model.Id);

            if (group == null)
            {
                return null;
            }

            group.Name = model.Name;

            return model;
        }
    }
}
