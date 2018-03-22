using System;

namespace KneatCodeChallenge.Utilities
{
    class Conversion
    {
        /// <summary>
        /// Calculate the hours during the period
        /// </summary>
        /// <param name="period">Period to be calculated</param>
        /// <returns>Return the quantitative of hours</returns>
        public int CalculateHours(string period)
        {
            switch (period.Split(' ')[1])
            {
                case "year":
                case "years":
                    return (Convert.ToInt32(period.Split(' ')[0]) * 365) * 24;

                case "month":
                case "months":
                    return (Convert.ToInt32(period.Split(' ')[0]) * 30) * 24;

                case "week":
                case "weeks":
                    return (Convert.ToInt32(period.Split(' ')[0]) * 7) * 24;

                case "day":
                case "days":
                    return Convert.ToInt32(period.Split(' ')[0]) * 24;
            }

            return 0;
        }
    }
}
