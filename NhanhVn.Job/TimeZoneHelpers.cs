namespace EntityFrameworkWithPostgresPOC
{
    internal static class TimeZoneHelpers
    {

        public static TimeZoneInfo GetVietnamTimeZone()
        {
            TimeZoneInfo vietnamZone;
            try
            {
                vietnamZone = TimeZoneInfo.FindSystemTimeZoneById("SE Asia Standard Time");
            }
            catch (TimeZoneNotFoundException)
            {
                vietnamZone = TimeZoneInfo.FindSystemTimeZoneById("Asia/Ho_Chi_Minh");
            }

            return vietnamZone;
        }
    }
}