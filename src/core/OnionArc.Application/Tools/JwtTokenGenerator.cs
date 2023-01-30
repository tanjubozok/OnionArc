using Microsoft.IdentityModel.Tokens;
using OnionArc.Application.Dtos.Jwt;
using OnionArc.Application.Dtos.UserDtos;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace OnionArc.Application.Tools;

public class JwtTokenGenerator
{
    public static TokenResponseDto GenerateToken(CheckUserResponseDto dto)
    {
        List<Claim> claims = new()
        {
            new Claim(ClaimTypes.NameIdentifier, dto.Id.ToString())
        };
        if (dto.Role is not null)
            claims.Add(new Claim(ClaimTypes.Role, dto.Role));
        if (dto.Username is not null)
            claims.Add(new Claim("Username", dto.Username));

        SymmetricSecurityKey key = new(Encoding.UTF8.GetBytes(JwtTokenDefault.Key));
        SigningCredentials signingCredentials = new(key, SecurityAlgorithms.HmacSha256);

        var expiresDate = DateTime.UtcNow.AddDays(JwtTokenDefault.Expire);

        JwtSecurityToken jwtSecurityToken = new(
            issuer: JwtTokenDefault.ValidIssuer,
            audience: JwtTokenDefault.ValidAudience,
            claims: claims,
            notBefore: DateTime.UtcNow,
            expires: expiresDate,
            signingCredentials: signingCredentials
            );

        JwtSecurityTokenHandler tokenHandler = new();
        return new TokenResponseDto(tokenHandler.WriteToken(jwtSecurityToken), expiresDate);
    }
}
