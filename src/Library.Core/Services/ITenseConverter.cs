namespace Library.Core
{
    public interface ITenseConverter
    {
        string Convert(string value, bool pastTense = true);
    }
}
