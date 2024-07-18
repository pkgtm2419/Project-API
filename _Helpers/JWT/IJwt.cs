using ProjectAPI.SchemaModel;

namespace ProjectAPI._Helpers.JWT
{
    public interface IJwt
    {
        string GenerateToken(JWTModel body);
    }
}
