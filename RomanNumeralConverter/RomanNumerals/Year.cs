using System.Text;

namespace RomanNumerals
{
    public class Year
    {
        public int AsInt { get; }
        public int OnesPlace { get; set; }
        public int TensPlace { get; set; }
        public int HundredsPlace { get; set; }
        public int ThousandsPlace { get; set; }
        public string AsString { get; }

        public Year(int yearAsInt)
        {
            AsInt = yearAsInt;
            OnesPlace = yearAsInt % 10;
            TensPlace = ((yearAsInt / 10) % 10) * 10;
            HundredsPlace = ((yearAsInt / 100) % 10) * 100;
            ThousandsPlace = ((yearAsInt / 1000) % 10) * 1000;
            AsString = ConvertToRomanNumerals(OnesPlace, TensPlace, HundredsPlace, ThousandsPlace);
        }
        public Year(string yearAsString)
        {
            AsInt = ConvertToYYYY(yearAsString);
            AsString = yearAsString;
        }

        internal static string ConvertToRomanNumerals(int onesPlace, int tensPlace, int hundredsPlace, int thousandsPlace)
        {
            StringBuilder sb = new StringBuilder(15);

            string thousandsPlaceString = GetThousands(thousandsPlace);
            sb.Append(thousandsPlaceString);
            string hundredsPlaceString = GetHundreds(hundredsPlace);
            sb.Append(hundredsPlaceString);
            string tensPlaceString = GetTens(tensPlace);
            sb.Append(tensPlaceString);
            string onesPlaceString = GetOnes(onesPlace);
            sb.Append(onesPlaceString);

            return sb.ToString();
        }
        static string GetThousands(int thousandsFromObject)
        {
            return thousandsFromObject switch
            {
                0 => "",
                1000 => "M",
                2000 => "MM",
                3000 => "MMM",
                _ => "O",
            };
        }
        static string GetHundreds(int hundredsFromObject)
        {
            return hundredsFromObject switch
            {
                0 => "",
                100 => "C",
                200 => "CC",
                300 => "CCC",
                400 => "CD",
                500 => "D",
                600 => "DC",
                700 => "DCC",
                800 => "DCCC",
                900 => "CM",
                _ => "O",
            };
        }
        static string GetTens(int tensFromObject)
        {
            return tensFromObject switch
            {
                0 => "",
                10 => "X",
                20 => "XX",
                30 => "XXX",
                40 => "XL",
                50 => "L",
                60 => "LX",
                70 => "LXX",
                80 => "LXXX",
                90 => "XC",
                _ => "O",
            };
        }
        static string GetOnes(int onesFromObject)
        {
            return onesFromObject switch
            {
                0 => "",
                1 => "I",
                2 => "II",
                3 => "III",
                4 => "IV",
                5 => "V",
                6 => "VI",
                7 => "VII",
                8 => "VIII",
                9 => "IX",
                _ => "O",
            };
        }
        //
        //
        internal static int ConvertToYYYY(string yearAsString)
        {
            int testAsInt = 0;

            foreach (char i in yearAsString)
            {
                testAsInt += Convert2(i);
            }
            if (yearAsString.Contains("IV") || yearAsString.Contains("IX"))
                testAsInt -= 2;

            if (yearAsString.Contains("XL") || yearAsString.Contains("XC"))
                testAsInt -= 20;

            if (yearAsString.Contains("CD") || yearAsString.Contains("CM"))
                testAsInt -= 200;

            return testAsInt;
        }
        internal static int Convert2(char testAsInt)
        {
            return testAsInt switch
            {
                'M' => 1000,
                'D' => 500,
                'C' => 100,
                'L' => 50,
                'X' => 10,
                'V' => 5,
                'I' => 1,
                _ => 0,
            };
        }
    }
}
