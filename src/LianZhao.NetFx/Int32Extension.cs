namespace LianZhao
{
    public static class Int32Extension
    {
        public static bool IsDivisibleBy(this int value, int divisor)
        {
            return value % divisor == 0;
        }
    }
}