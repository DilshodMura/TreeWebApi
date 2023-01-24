using Newtonsoft.Json.Converters;
using System.Text.Json.Serialization;

namespace Domain.Enums
{
    /// <summary>
    /// Main tree types which are available for users.
    /// </summary>
    [Flags]
    public enum TreeTypes
    {
        Apple = 1,
        Cherry = 2
    }
}
