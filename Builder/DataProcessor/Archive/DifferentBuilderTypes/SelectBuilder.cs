public class SelectBuilder 
{
    private string _colour;
    private IDataBuilder? _builder;

    public SelectBuilder(string colour)
    {
        _colour = colour;
    }

    public IDataBuilder ReturnBuilder()
    {

        _builder = _colour switch 
        {
            "red" => new RedDataBuilder(),
            "blue" => new BlueDataBuilder(),
            "yellow" => new YellowDataBuilder(),
            "green" => new GreenDataBuilder(),
            _ => throw new NotSupportedException()
        };

        return _builder;
    }
};