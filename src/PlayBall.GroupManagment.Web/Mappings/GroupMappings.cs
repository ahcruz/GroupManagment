using PlayBall.GroupManagment.Services.Models;
using PlayBall.GroupManagment.Web.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace PlayBall.GroupManagment.Web.Mappings
{
    public static class GroupMappings
    {        
        public static GroupsViewModel ToViewModel(this Group model)
        {
            return model != null ? new GroupsViewModel { Id = model.Id, Name = model.Name } : null;
        }

        public static Group ToModel(this GroupsViewModel model)
        {
            return model != null ? new Group { Id = model.Id, Name = model.Name } : null;
        }

        public static IReadOnlyCollection<GroupsViewModel> ToViewModel(this IReadOnlyCollection<Group> models)
        {
            if (models.Count == 0)
            {
                return Array.Empty<GroupsViewModel>();
            }

            var groups = new GroupsViewModel[models.ToArray().Length];
            var i = 0;

            foreach (var model in models)
            {
                var group = new GroupsViewModel
                {
                    Id = model.Id,
                    Name = model.Name
                };

                groups[i] = group;
                ++i;
            }

            return new ReadOnlyCollection<GroupsViewModel>(groups);
        }
    }
}
