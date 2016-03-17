namespace Flags.Desktop.Infrastructure.Extensions
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public static class Extensions
    {
        private static Random RandomGenerator { get; set; } = new Random();

        // Simple unbiased Fisher-Yates shuffle
        public static void Shuffle<T>(this IList<T> items)
        {
            int itemsCount = items.Count;

            while (itemsCount > 1)
            {
                itemsCount--;
                var swapPosition = RandomGenerator.Next(itemsCount + 1);
                T value = items[swapPosition];
                items[swapPosition] = items[itemsCount];
                items[itemsCount] = value;
            }
        }
    }
}
