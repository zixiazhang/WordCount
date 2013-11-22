using System;

namespace WordCount
{
    public static class Extensions
    {
        public static void DisposeIfNotNull(this IDisposable item)
        {
            if (item != null)
            {
                item.Dispose();
            }
        }
    }
}