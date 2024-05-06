public class SimpleDataArchiver: IDataArchiver 
{
    public void ArchiveFiles(string filePath) {
        Console.WriteLine(filePath);
    }
}