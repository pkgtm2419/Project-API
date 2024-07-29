using WinDLMSClientApp._Models;

namespace WinDLMSClientApp._Helpers.JWT
{
    public interface IJWT
    {
        string GenerateToken(JWTModel body);
    }
}
