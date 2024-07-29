namespace WinDLMSClientApp._Helpers.Hashing
{
    public interface IHashing
    {
        string HashValue(string value);
        bool VerifyHash(string hash, string value);
    }
}
