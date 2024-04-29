namespace ExcelSheet
{
    public class Excel
    {
        public static string ExcelColumnTitle(int columnNumber)
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            string result = "";
            while (columnNumber > 0)
            {
                columnNumber--;
                var remainder = columnNumber % 26;
                result = chars[remainder] + result;
                columnNumber /= 26;
            }
            return result;
        }
    }
}
