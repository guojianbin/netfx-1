using System.Collections.Generic;

namespace LianZhao
{
    public static class ArrayExtensions
    {
        public static IEnumerable<T[]> ToEnumerable<T>(this T[,] array)
        {
            var rowCount = array.GetLength(0);
            var lengthPerRow = array.GetLength(1);
            for (var i = 0; i < rowCount; i++)
            {
                var row = new T[lengthPerRow];
                for (var j = 0; j < lengthPerRow; j++)
                {
                    row[j] = array[i, j];
                }

                yield return row;
            }
        }
    }
}