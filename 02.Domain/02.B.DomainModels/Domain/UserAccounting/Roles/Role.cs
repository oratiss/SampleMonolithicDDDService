using System;

using DomainServiceContract.Roles;
using DomainShared.BaseAggregates;
using ExceptionsManagement.DomainExceptions.Roles;
using Utilities.BaseDomain;
using Utilities.BaseEntities;
using Utilities.SharedTools.ExceptionDictionaries;

namespace Domain.UserAccounting.Roles
{
    public class Role : BaseDomainEntity<long>, IAggregateRoot
    {
        public string Title { get; private set; }
        public string SystemDescription { get; private set; }
        public string Description { get; private set; }

        private IDomainRoleExceptionHelper _roleExceptionHelper = new RoleExceptionHelper();

        public event EventHandler<RoleEventArgs> RoleCreated;

        public Role(long id, string title, string systemDescription, string description) : base(id)
        {

            if (title.Length > 100 || string.IsNullOrWhiteSpace(title) || string.IsNullOrEmpty(title))
            {
                _roleExceptionHelper.ThrowExceptionMessage((long)ExceptionCodes.UserAccountingDomainRoleTitle);
            }

            if (systemDescription.Length > 400)
            {
                _roleExceptionHelper.ThrowExceptionMessage((long)ExceptionCodes.UserAccountingDomainRoleSystemDescription);
            }

            if (description.Length > 500 || string.IsNullOrWhiteSpace(description) || string.IsNullOrEmpty(description))
            {
                _roleExceptionHelper.ThrowExceptionMessage((long)ExceptionCodes.UserAccountingDomainRoleDescription);
            }

            Title = title;
            SystemDescription = systemDescription;
            Description = description;

            OnRoleCreated(this);
        }

        protected virtual void OnRoleCreated(Role role)
        {
            if (RoleCreated != null)
            {
                RoleCreated(this, new RoleEventArgs() { Role = role });
            }
        }



    }
}
