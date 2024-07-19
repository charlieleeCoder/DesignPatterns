﻿namespace DataProcessor.FileLocations;

// Requirements for interface
public interface IFileLocation
{
    public abstract string GetFileLocation();
    public abstract string GetFileStartsLike();
    public abstract void IncrementVersionNumber();
    public abstract void ChangeFileExtension(string fileExtension);
}

// Base implementation, which is largely consistent
public class FileLocation : IFileLocation
{
    public virtual string FilePath              { get; protected set; }    // e.g. C:\\Root\CompanyName\AccountsReport\
    public virtual string FileName              { get; protected set; }
    public virtual string FormattedFileDate     { get; protected set; }
    public virtual string FileVersionText       { get; protected set; }    // e.g. "" or " v" or " v." or " version"
    public static int VersionNumber             { get; protected set; }    // Change version number for all files if v1 already exists, etc.
    public virtual string AppendedStatus        { get; protected set; }    // e.g. " - PROCESSING" or " - ORIGINAL"
    public virtual string FileExtension         { get; protected set; }

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
        this.FilePath = modifiedFilePath;                               // e.g. C:\\Root\CompanyName\AccountsReport\
        this.FileName = otherInstanceToCopy.FileName;
        this.FormattedFileDate = otherInstanceToCopy.FormattedFileDate;
        this.FileVersionText = otherInstanceToCopy.FileVersionText;     // e.g. "" or " v" or " v." or " version"
        VersionNumber = FileLocation.VersionNumber;
        this.AppendedStatus = modifiedStatus;                           // e.g. " - PROCESSING" or " - ORIGINAL"
        this.FileExtension = otherInstanceToCopy.FileExtension;
    }

    // Required method for decoupled components expecting an IFileLocation with a simple way to find the file
    public virtual string GetFileLocation()
    {
        // Example of output: RootEtc\AccountReport 22.05.24 version1.csv
        return $"{FilePath}{FileName} {FormattedFileDate}{FileVersionText}{VersionNumber}{FileExtension}";
    }

    public virtual string GetFileStartsLike() 
    {
        return $"{FilePath}{FileName}";
    }

    // Required for when above v1
    public virtual void IncrementVersionNumber()
    {
        VersionNumber++;
    }

    // If the default of csv is not correct for this company, change to new type
    public virtual void ChangeFileExtension(string fileExtension) 
    {
        this.FileExtension = fileExtension;
    }
}
