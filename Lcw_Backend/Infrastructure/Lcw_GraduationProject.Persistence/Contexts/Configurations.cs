using Microsoft.Extensions.Configuration;

namespace Lcw_GraduationProject.Persistence.Contexts
{
    public static class Configurations
    {
        public static string ConnectionString 
        { 
            get
            {
                ConfigurationManager configurationManager = new();
                configurationManager.SetBasePath(Path.Combine(Directory.GetCurrentDirectory(), "../../Presentation/Lcw_GraduationProject.API"));
                configurationManager.AddJsonFile("appsettings.json");
                //return configurationManager.GetConnectionString("PostgreSQL");
                return configurationManager.GetConnectionString("MsSQL");
            }
        }
    }
}
