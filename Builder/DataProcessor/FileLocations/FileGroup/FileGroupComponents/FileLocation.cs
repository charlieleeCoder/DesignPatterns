/*
 * Used by the DataReader, DataWriter and FileArchiver components. 
 * Multiple of these make up a FileGroup, with a record of file locations for the following files:
 * 
 * - Original
 * - Processed (new file written after being processing)
 * - OriginalArchive
 * - ProcessedArchive
 */

namespace DataProcessor.FileLocations.FileGroup.FileGroupComponents;

// Requirements for interface
public interface IFileLocation
{
    public abstract string GetFileLocation();
    public abstract void IncrementVersionNumber();
    public abstract void SetVersionNumber(int versionNumber);
    public abstract void ChangeFileDateText(string formattedDateText);
    public abstract void ChangeFileExtension(string fileExtension);
}

// Base implementation, which is largely consistent
public class FileLocation : IFileLocation
{
    public virtual string FilePath { get; protected set; }    // e.g. C:\\Root\CompanyName\AccountsReport\
    public virtual string FileName { get; protected set; }
    public static string FormattedFileDate { get; protected set; } = string.Empty;
    public virtual string FileVersionText { get; protected set; }    // e.g. "" or "v" or "v." or "version"
    public static int VersionNumber { get; protected set; }    // Change version number for all files if v1 already exists, etc.
    public virtual string AppendedStatus { get; protected set; }    // e.g. " - PROCESSING" or " - ORIGINAL"
    public virtual string FileExtension { get; protected set; }

    // Constructor to initialize
    public FileLocation(string filePath, string fileName, string formattedFileDate, string fileVersionText, int versionNumber, string appendedStatus, string fileExtension)
    {
        FilePath = filePath;
        FileName = fileName;
        FormattedFileDate = formattedFileDate;
        FileVersionText = fileVersionText;
        VersionNumber = versionNumber;
        AppendedStatus = appendedStatus;
        FileExtension = fileExtension;
    }

    // Copy constructor with modified path and status (these are the main differences between each file location)
    public FileLocation(FileLocation otherInstanceToCopy, string modifiedFilePath, string modifiedStatus)
    {
        FilePath = modifiedFilePath;                               // e.g. C:\\Root\CompanyName\AccountsReport\
        FileName = otherInstanceToCopy.FileName;
        FormattedFileDate = FormattedFileDate;
        FileVersionText = otherInstanceToCopy.FileVersionText;     // e.g. "" or " v" or " v." or " version"
        VersionNumber = VersionNumber;
        AppendedStatus = modifiedStatus;                           // e.g. " - PROCESSING" or " - ORIGINAL"
        FileExtension = otherInstanceToCopy.FileExtension;
    }

    // Required method for decoupled components expecting an IFileLocation with a simple way to find the file
    public virtual string GetFileLocation()
    {
        // Example of output: RootEtc\AccountReport 22.05.24 version1.csv
        return $"{FilePath}{FileName} {FormattedFileDate} {FileVersionText}{VersionNumber}{AppendedStatus}{FileExtension}";
    }

    public virtual void ChangeFileDateText(string formattedDateText)
    {
        FormattedFileDate = formattedDateText;
    }

    // Required for when above v1
    public virtual void IncrementVersionNumber()
    {
        VersionNumber++;
    }

    // Required when using file location verifier to find version and date
    public virtual void SetVersionNumber(int versionNumber)
    {
        VersionNumber = versionNumber;
    }

    // If the default of csv is not correct for this company, change to new type
    public virtual void ChangeFileExtension(string fileExtension)
    {
        FileExtension = fileExtension;
    }
}
