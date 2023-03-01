using ims.Common.Utils;

namespace ims.Security.Enums;


public class Operation : Enumeration<Operation>
{
    public const string VIEW = nameof(VIEW);
    public const string CREATE = nameof(CREATE);
    public const string UPDATE = nameof(UPDATE);
    public const string DELETE = nameof(DELETE);
}
