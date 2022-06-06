using GameRecordApplication_v3.DataAccessLayer;
using GameRecordApplication_v3.Seeding;
using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(GameRecordApplication_v3.Startup))]
namespace GameRecordApplication_v3
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);

            try
            {
                var dataContext = new DataContext();

                SeedData.SeedPlayers(dataContext);
                SeedData.SeedBilliardGameTypes(dataContext);
            }
            catch (System.Exception ex)
            {
                throw;
            }
        }
    }
}
