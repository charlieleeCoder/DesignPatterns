namespace DataProcessor.FileLocations;

internal class PathInfo(string path, string fileName, string date, int versionNumber)
{
    public string Path              { get; set; }
    public string FileName          { get; set; }
    public string Date              { get; set; }

    // Version number validation
    private string _versionText { get; set; } = "v"; // Most common
    private Type VersionType { get; set; } = typeof(int);
    private int _VersionNumberInt;   
    private float _VersionNumberFloat;
    private string _VersionNumberString;

    // Return version number, whether in v0.5, or v1, or version 1.0, etc.
    public string VersionNumber     {

        // Different backing variables for different formats
        get 
        {
            if (VersionType == typeof(int))
            {
                return $"{_versionText}{_VersionNumberInt}";
            }
            else if (VersionType == typeof(float))
            {
                return $"{_versionText}{_VersionNumberFloat}";
            }
            else if (VersionType == typeof(string))
            {
                return $"{_versionText}{_VersionNumberString}";
            }
            else
            {
                throw new NotImplementedException("Invalid version type.");
            }
        }
        set
        {
            if (int.TryParse(value, out int _Version))
            {
                _VersionNumberInt = _Version;
            }
            else
            {
                throw new ArgumentException
            }
        }    
    }

}
