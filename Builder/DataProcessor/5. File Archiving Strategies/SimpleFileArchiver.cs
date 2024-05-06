namespace Archiver;
public class SimpleFileArchiver: IFileArchiver 
{
    public void ArchiveFiles(string filePath) {
        Console.WriteLine(filePath);
    }
}