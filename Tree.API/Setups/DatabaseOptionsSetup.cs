using Microsoft.Extensions.Options;

using Tree.Persistence.Options;

namespace Tree.API.Setups;

public class DatabaseOptionsSetup : IConfigureOptions<DatabaseOptions> {
    private const string DatabaseSectionName = "Database";
    private const string ConnectionStringName = "Application";
    private readonly IConfiguration _configuration;
    public DatabaseOptionsSetup(IConfiguration configuration) {
        _configuration = configuration;
    }
    public void Configure(DatabaseOptions options) {
        options.ConnectionString = _configuration.GetConnectionString(ConnectionStringName)!;

        _configuration.GetSection(DatabaseSectionName).Bind(options);
    }
}
