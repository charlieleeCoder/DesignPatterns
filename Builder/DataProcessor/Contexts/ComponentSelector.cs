using DataProcessor.Enums;

namespace DataProcessor.Contexts;

public class ComponentSelector
{
    public static IComponentList ReturnComponentsList(Company company)
    {
        return company switch
        {
            Company.MuffinsMuffins => new UnprocessedCSVSentByEmail(),
            Company.NotRealLtd => new ProcessedExcelSentViaSFTP(),
            Company.MadeUpCo => new ProcessedCSVConvertedtoExcelSentViaSFTP(),
            Company.NotGenericCo => new UnprocessedCSVSentByWebDriver(),
            _ => throw new NotImplementedException()
        };
    }
}