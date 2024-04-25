using Mapster;
using DataAccessLayer.Dto;
using TerminalApi.ViewModels;

namespace TerminalApi
{
    public static class MapsterConfig
    {
        public static void AddMaps()
        {
            TypeAdapterConfig.GlobalSettings.Default.PreserveReference(true);
            TypeAdapterConfig.GlobalSettings.Default.NameMatchingStrategy(NameMatchingStrategy.IgnoreCase);

            TypeAdapterConfig<people, PeopleViewModel>
                .NewConfig();

            TypeAdapterConfig<PeopleViewModel, people>
                .NewConfig()
                .Ignore(p=> p.userpassword); 


        }
    }
}