using Mapster;
using DataAccessLayer.Dto;
using TerminalApi.ViewModels;
using BuisinessLogicLayer.ViewModels;

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

            TypeAdapterConfig<delivdoc, DelivDoc>
                .NewConfig()
                .Map(d => d.DriverName, s => (s.idcarNavigation != null) ? s.idcarNavigation.comment : "")
                .Map(d => d.CarNumber, s => (s.idcarNavigation != null) ? s.idcarNavigation.name : "");

            TypeAdapterConfig<storagespace, StorageSpace>
                .NewConfig()
                .Map(d => d.StoreName, s => (s.idstoredepartNavigation!=null) ? s.idstoredepartNavigation.name : "")
                .Map(d => d.Parent, s => s.idparentNavigation);

            TypeAdapterConfig<PeopleViewModel, people>
                .NewConfig()
                .Ignore(p=> p.userpassword); 

            TypeAdapterConfig<people, Item<int>>
                .NewConfig()
                .Map(d => d.Name, s => s.Fio);

            TypeAdapterConfig<rotoxhouse, RotoxHouse>
                .NewConfig();

            TypeAdapterConfig<orders, Order>
                .NewConfig()
                .Map(o=>o.State, s => (s.iddocstateNavigation != null) ? s.iddocstateNavigation.name : "");
        }
    }
}