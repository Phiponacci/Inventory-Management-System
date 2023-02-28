using Ardalis.SmartEnum;
using ims.Common.Utils;
using System.Collections;
using System.Reflection;

namespace ims.Security.Enums;


public class Operation : Enumeration<Operation>
{
    public const string VIEW = nameof(VIEW);
    public const string CREATE = nameof(CREATE);
    public const string UPDATE = nameof(UPDATE);
    public const string DELETE = nameof(DELETE);
}
