using Loto300WebAPI.Storage;
using Microsoft.EntityFrameworkCore;

namespace Loto300WebAPI.Extension
{
    public static class DatabaseRegistration
    {
        public static IServiceCollection RegisterDatabase(this IServiceCollection serviceCollection, string connectionString)
        {
            serviceCollection.AddDbContext<LottoDbContext>(action =>
            {
                action.UseSqlServer(connectionString);
            });

            return serviceCollection;
        }
    }
}
