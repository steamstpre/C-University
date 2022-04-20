namespace ConsoleApp1;

public class Validation
{
    public static string setComapnyName(string companyName)
    {
        List<string> symbols = new List<string>()
            {"#", "!", "$", "%", "^", "&", "*", "(", "_", ")", "+", "1", "2", "3", "4", "5", "6", "7", "8", "9", "0"};

        foreach (var value in symbols)
        {
            if (companyName.Contains(value))
            {
                throw new InvalidDataException("not correct company name");
            }
        }

        return companyName;
    }

    public static int setVatRate(int vatRate)
    {
        if (vatRate <= 1 || vatRate >= 40)
        {
            throw new InvalidDataException("wrong vat rate");
        }

        return vatRate;
    }

    public static DateTime setDateOfPurchase(DateTime dateTime)
    {
        DateTime wrongData = new DateTime(2022, 6, 12);
        if (dateTime > wrongData)
        {
            throw new InvalidDataException("wrong data purchase");
        }

        return dateTime;
    }

    public static string setVatCode(string vatCode)
    {
        char[] vatCodeArr = vatCode.ToCharArray();
        if (vatCodeArr.Length == 12 && vatCodeArr[0] == 'V' && vatCodeArr[1] == 'A' && vatCodeArr[2] == '-' &&
            vatCodeArr[6] == '-' && vatCodeArr[7] == '-')
        {
            foreach (var item in vatCodeArr)
            {
                if (item == vatCodeArr[3] || item == vatCodeArr[4] || item == vatCodeArr[5] || item == vatCodeArr[7] ||
                    item == vatCodeArr[8] || item == vatCodeArr[10] || item == vatCodeArr[11] || item == vatCodeArr[12])
                {
                    try
                    {
                        int checkNum;
                        checkNum = (int) item;
                    }
                    catch (Exception e)
                    {
                        throw new InvalidDataException("wrong data purchase");
                    }
                }
            }
        }

        return vatCode;
    }

    public static string setCountry(string CountryInput)
    {
        if (CountryInput == "Italy" || CountryInput == "France" || CountryInput == "Ukraine")
        {
            return CountryInput;
        }
        else
        {
            throw new InvalidDataException("wrong country");
        }
    }

    public static DateTime setDataOfRefistrationTax(DateTime dateTime, DateTime dateOfPurcase)
    {
        DateTime wrongData = new DateTime(2022, 6, 12);
        if (dateTime > wrongData && dateTime < dateOfPurcase)
        {
            throw new InvalidDataException("wrong data purchase");
        }

        return dateTime;
    }

    public static T ParseEnum<T>(string value)
    {
        return (T) Enum.Parse(typeof(T), value, true);
    }

    public static List<TaxFree> searchValidation(List<TaxFree> list)
    {
        if (list.Count == 0)
        {
            throw new InvalidDataException("empty list");
        }

        return list;
    }
}