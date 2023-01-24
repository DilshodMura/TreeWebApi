
namespace Domain.Enums
{
    /// <summary>
    /// Tree sorts which are available for each tree type.
    /// </summary>
    [Flags]
    public enum TreeSorts
    {
        Golden = 1,
        Semerenko = 2,
        Frosty = 4,
        Oakland = 8,
    }
}
