using System.Text;

namespace TestBridge.Constants
{
    public class ApiCallConstants
    {
        public static readonly string baseURL = "https://localhost:44332/";
        //public static readonly string baseURL = "http://localhost:10568";

        public static readonly string UserAccountingRoleIndexURL =
            new StringBuilder().Append(baseURL).Append("UserAccounting/Role/Index").ToString();

        public static readonly string UserAccountingRoleCreateURL =
            new StringBuilder().Append(baseURL).Append("UserAccounting/Role/Create").ToString();

        public static readonly string UserAccountingRoleDeleteURL =
            new StringBuilder().Append(baseURL).Append("UserAccounting/Role/Delete").ToString();

        public static readonly string UserAccountingRoleDeleteByIdURL =
            new StringBuilder().Append(baseURL).Append("UserAccounting/Role/DeleteById").ToString();

        public static readonly string UserAccountingRoleEditURL =
           new StringBuilder().Append(baseURL).Append("UserAccounting/Role/Edit").ToString();
    }
}
