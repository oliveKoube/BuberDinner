using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;

namespace BuberDinner.Infrastructure.Authentification;

public class JwtOptionSetup : IConfigureOptions<JwtSettings>
{
    private readonly IConfiguration _configuration;

    public JwtOptionSetup(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    public void Configure(JwtSettings options)
    {
        _configuration.GetSection(JwtSettings.SectionName).Bind(options);
    }
}
