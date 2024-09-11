using System.IdentityModel.Tokens.Jwt;
using System.Text;
using Microsoft.IdentityModel.Tokens;

public class CustomJwtMiddleware
{
    private readonly RequestDelegate _next;
    private readonly string _secretKey;

    public CustomJwtMiddleware(RequestDelegate next, string secretKey)
    {
        _next = next;
        _secretKey = secretKey;
    }

    public async Task Invoke(HttpContext context)
    {
        if (context.Request.Headers.ContainsKey("Authorization"))
        {
            var authHeader = context.Request.Headers["Authorization"].ToString();
            var token = authHeader;

            // Loại bỏ tiền tố Bearer nếu có
            if (authHeader.StartsWith("Bearer "))
            {
                token = authHeader.Substring(7).Trim();
            }

            // Xác thực token
            if (!string.IsNullOrWhiteSpace(token))
            {
                var handler = new JwtSecurityTokenHandler();
                try
                {
                    var validationParameters = new TokenValidationParameters
                    {
                        ValidateIssuer = true,
                        ValidateAudience = true,
                        ValidateLifetime = true,
                        ValidateIssuerSigningKey = true,
                        ValidIssuer = "toandev",
                        ValidAudience = "toan",
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(_secretKey))
                    };

                    var principal = handler.ValidateToken(token, validationParameters, out _);
                    context.User = principal;
                }
                catch (Exception)
                {
                    // Token không hợp lệ
                }
            }
        }

        await _next(context);
    }
}
