using GameRecordApplication_v3.Constants;
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
                SeedData.SeedBilliardGameModes(dataContext);
            }
            catch (System.Exception ex)
            {
                LogWriting.WriteDBLog(this.GetType().Name, System.Reflection.MethodBase.GetCurrentMethod().Name, ex, LogFile.DBExceptionLog);
            }
        }
    }
}
