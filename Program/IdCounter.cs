

/// <summary>
/// Sert a incrementer le id tout seul :)
/// </summary>
internal static class IdCounter
{
    private static int _idcounter = 0;

    public static int New()
    {
        return System.Threading.Interlocked.Increment(ref _idcounter);
    }
}