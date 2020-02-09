namespace DcmParserLib
{
    public interface IDcmJsonParser<out T> where T : class
    {
        T Parse(object jo);
    }
}