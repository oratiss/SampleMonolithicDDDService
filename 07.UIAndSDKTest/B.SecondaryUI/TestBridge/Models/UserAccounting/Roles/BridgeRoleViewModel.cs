using Utilities;

namespace TestBridge.Models.UserAccounting.Roles
{
    public class BridgeRoleViewModel : BaseViewModel<long>
    {
        public string Title { get; private set; }
        public string SystemDescription { get; private set; }
        public string Description { get; private set; }

        public BridgeRoleViewModel(long id, string title, string systemDescription, string description) : base(id)
        {
            Title = title;
            SystemDescription = systemDescription;
            Description = description;
        }
    }
}
