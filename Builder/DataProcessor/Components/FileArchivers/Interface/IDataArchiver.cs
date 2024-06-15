namespace Archiver;
public interface IFileArchiver 
{
    public void ArchiveFiles(string startFilePath, string archiveFilePath);
}