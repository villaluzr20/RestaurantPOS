using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using Microsoft.IdentityModel.Tokens;

public class TokenService
{
    private readonly string secretKey = "RestaurantPOS";

    public string GenerateToken(User user)
    {
        var securityKey = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes(secretKey));
        var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

        var claims = new[]
        {
            new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
            new Claim(ClaimTypes.Email, user.Email),
            new Claim(ClaimTypes.Role, user.Role)
        };

        var token = new JwtSecurityToken(
            issuer: "https://localhost:5001",
            audience: "https://localhost:5001",
            claims: claims,
            expires: DateTime.Now.AddMinutes(60),
            signingCredentials: credentials
        );

        var tokenHandler = new JwtSecurityTokenHandler();
        var stringToken = tokenHandler.WriteToken(token);
        var newSecretKey = "1VRaJ9U6oUDX2SN5QbKG6QCkrNnJ9Dy3DXepz5FrxIEDatXq200ScbKiWSm7q7IPrAKyAL8yh7q0iV63S4d9FdsfbavNBquzUowTI7UveKgsrdAcpm3oV9ZY55s+2KfBmGcLFlwejilcw0GPUktYp9Jqrez/T5VKUiuRv0o8UPONmwS5rCGDSVcRfcDWe+QE";

        return stringToken;
    }
}