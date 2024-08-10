using DataProcessor.FileLocations.FileGroup;

namespace DataProcessor.Components.FileIdentifiers;

public interface IFileLocationVerifier
{
    public abstract IFileGroup GetCorrectFileLocations(IFileGroup expectedFileLocations);
}

public class FileLocationVerifier : IFileLocationVerifier
{
    public IFileGroup GetCorrectFileLocations(IFileGroup expectedFileLocations) 
    {
        // Expected file is there
        if (File.Exists(expectedFileLocations.StartPathFile.GetFileLocation()))
        {
            return expectedFileLocations;
        }
        
        // If version number simply needs incrementing, then do so
        bool fileFound = CheckVersionNumbers(expectedFileLocations);
        if (fileFound)
        {
            // Return the instance with the incremented version number
            return expectedFileLocations;
        }

        // If this is not simply a case of version mismatch, may be a different date
        IFileGroup correctedFileLocations = CheckOtherDates(expectedFileLocations);

        return correctedFileLocations;

    }

    private bool CheckVersionNumbers(IFileGroup expectedFileLocations)
    {
        // Local temp variables
        bool fileFound = false;
        int currentAttempt = 1;
        int maxAttempts = 10;

        // Keep checking for higher version numbers
        while (!fileFound && currentAttempt <= maxAttempts)
        {
            // Increase the version number being checked
            expectedFileLocations.StartPathFile.IncrementVersionNumber();
            fileFound = (File.Exists(expectedFileLocations.StartPathFile.GetFileLocation()));
            currentAttempt++;
        }

        return fileFound;
    }

    private IFileGroup CheckOtherDates(IFileGroup expectedFileLocations)
    {
        // Temp local variables for clarity
        string directoryPath = expectedFileLocations.StartPathFile.FilePath;
        string fileStart = expectedFileLocations.StartPathFile.FileName;

        // Ensure the directory exists
        if (!Directory.Exists(directoryPath))
        {
            throw new ArgumentException($"Directory: {directoryPath} does not exist.");
        }

        // Get all files in the directory
        string[] files = Directory.GetFiles(directoryPath);

        // Use LINQ to filter files that start with the specified prefix
        var matchingFiles = files.Where(file => Path.GetFileName(file).StartsWith(fileStart));

        // Check if any matching files are found
        if (!matchingFiles.Any()) // Early return
        {
            throw new ArgumentException($"There are no files in the folder {directoryPath}, which start like: {fileStart}.");
        }

        // Too many files matching the pattern
        if (matchingFiles.Count() > 1)
        {
            throw new ArgumentException($"There are too many files in the folder {directoryPath}, which start like: {fileStart}, none of which match the expected file date with a version number <= 10.");
        }

        // Split all parts of the file name
        string[] dateAndVersionOnly = matchingFiles.ElementAt(0)
                                                   .Replace(expectedFileLocations.StartPathFile.FileName, "")
                                                   .Replace(expectedFileLocations.StartPathFile.FilePath, "")
                                                   .Replace(expectedFileLocations.StartPathFile.FileExtension,"")
                                                   .Split(' ');

        // Determine which are correct file dates and version number with file
        string versionAsString = dateAndVersionOnly.Where(text => text.StartsWith(expectedFileLocations.StartPathFile.FileVersionText)).ToArray()[0];
        string dateOnly = dateAndVersionOnly.Where(text => !text.StartsWith(expectedFileLocations.StartPathFile.FileVersionText)
                                                        && text.Length > 0).ToArray()[0]; // Get rid of blank string

        // Modification
        expectedFileLocations.StartPathFile.ChangeFileDateText(dateOnly);

        // Capture as text first for exception
        string versionNumberOnlyAsString = versionAsString.Replace(expectedFileLocations.StartPathFile.FileVersionText, "");
        try
        {
            int versionNumberOnly = int.Parse(versionNumberOnlyAsString);
            expectedFileLocations.StartPathFile.SetVersionNumber(versionNumberOnly);
        }
        catch(FormatException)
        {
            throw new FormatException($"{versionNumberOnlyAsString} is not a valid integer.");
        }

        return expectedFileLocations;

    }
}
