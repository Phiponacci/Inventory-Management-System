using ims.Common.Utils;

namespace ims.Security.Enums;


public class Role : Enumeration<Operation>
{
    public const string Admin = nameof(Admin);
    public const string Accountant = nameof(Accountant);
    public const string Driver = nameof(Driver);
}
