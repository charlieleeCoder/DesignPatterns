
namespace DataProcessor.Enums
{
    // Define valid companies
    public enum Company
    {
        MadeUpCo,
        NotRealLtd,
        MuffinsMuffins,
        NotGenericCo
    }

    // Provide name lookup
    public static class CompanyDictionary
    {
        public static readonly Dictionary<Company, string> CompanyLookup = new()
        {
            { Company.MadeUpCo,         "MadeUpCo" },
            { Company.NotRealLtd,       "NotRealLtd" },
            { Company.MuffinsMuffins,   "MuffinsMuffins" },
            { Company.NotGenericCo,     "NotGenericCo" }
        };
    }

}
