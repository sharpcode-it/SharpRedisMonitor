// (c) 2020 Francesco Del Re <francesco.delre.87@gmail.com>
// This code is licensed under MIT license (see LICENSE.txt for details)
namespace CoreRedisStats.Utility
{
    public static class Utility
    {
        public static double GetPercentage(string percentage, bool divide = false, bool multiple = false)
        {
            if (string.IsNullOrEmpty(percentage))
                return 0;

            // remove % char from oroginal string
            percentage = percentage.Replace("%", string.Empty);
            if (double.TryParse(percentage, out var perc))
            {
                if (divide)
                    return perc / 100;
                if (multiple)
                    return perc * 100;
                return perc;
            }

            return 0;
        }
    }
}
