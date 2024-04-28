using BuisinessLogicLayer.Enum;
using BuisinessLogicLayer.Services;
using BuisinessLogicLayer.Services.Domain;
using BuisinessLogicLayer.ViewModels;
using DataAccessLayer;
using DataAccessLayer.Dto;
using DataAccessLayer.Ef;
using Mapster;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Moq;
using TerminalApi;

namespace Terminal.Tests
{
    [TestClass]
    public class ApiTests
    {
        ServiceProvider serviceProvider;
        public ApiTests()
        {
            var services = new ServiceCollection();
            services
                .AddScoped<IUserService, UserService>()
                .AddScoped<IGenUoW, EfUnit>()
                .AddScoped<IPeoplesService, PeoplesService>()
                .AddScoped<ITerminalService, TerminalService>()
                .AddScoped<IRotoxHouseService, RotoxHouseService>()
                .AddScoped<IDelivDocService, DelivDocService>()
                .AddScoped<IStorageSpaceService, StorageSpaceService>()
            .AddDbContext<WdContext>(options =>
            {
                options.UseSqlServer("Password=ggdhHGHGKdgett3563@#;User ID=windraw-dbo;Initial Catalog=ecad_copy;Data Source=sql-wd-01.corp.lan;");
            });
            serviceProvider = services.BuildServiceProvider();
            MapsterConfig.AddMaps();
        }

        [TestMethod]
        public void RollBackOrderTest()
        {
            IRotoxHouseService rotoxHouseService = serviceProvider.GetService<IRotoxHouseService>();
            rotoxhouse rh = rotoxHouseService.Scan("10000007157").Adapt<rotoxhouse>();
            rotoxhouse rh2 = rotoxHouseService.Scan("10000007228").Adapt<rotoxhouse>();
            rotoxHouseService.Delete(rh);
            rotoxHouseService.Delete(rh2);
            rotoxhouse rhRem = rotoxHouseService.Scan("10000007157", false).Adapt<rotoxhouse>();
            rotoxhouse rhRem2 = rotoxHouseService.Scan("10000007228", false).Adapt<rotoxhouse>();
            rotoxHouseService.Delete(rhRem);
            rotoxHouseService.Delete(rhRem2);

            IGenUoW unit = serviceProvider.GetService<IGenUoW>();
            orders o = unit.RepOrder.Get(o => o.idorder == 6852);
            o.iddocstate = 3;
            unit.RepOrder.Update(o);
        }

        [TestMethod("Сканирование на склад ГП")]
        public void ScanningOnGpStoreTest()
        {
            IRotoxHouseService rotoxHouseService = serviceProvider.GetService<IRotoxHouseService>();

            rotoxhouse rh = rotoxHouseService.Scan("10000007157").Adapt<rotoxhouse>();
            rotoxhouse rh2 = rotoxHouseService.Scan("10000007228").Adapt<rotoxhouse>();
            rotoxHouseService.ScanCell("77770010010", new List<rotoxhouse>() { rh, rh2 });

            List<RotoxHouse> items = rotoxHouseService.GetByStorageSpace("77770010010");
            Assert.IsTrue(items.Any(i => i.State == 1));

            AssertOrderState((int)DocStateEnum.OnGpStorage);
        }

        [TestMethod("Отгрузка со склада ГП")]
        public void PickUpFromGpStoreTest()
        {
            IRotoxHouseService rotoxHouseService = serviceProvider.GetService<IRotoxHouseService>();

            rotoxHouseService.ClearCell("77770010010");

            AssertOrderState((int)DocStateEnum.LeftGpStorage);
        }

        [TestMethod("Сканирование на удаленный склад")]
        public void ScanningOnRemoteStoreTest()
        {
            IRotoxHouseService rotoxHouseService = serviceProvider.GetService<IRotoxHouseService>();

            rotoxhouse rh = rotoxHouseService.Scan("10000007157",false).Adapt<rotoxhouse>();
            rotoxhouse rh2 = rotoxHouseService.Scan("10000007228", false).Adapt<rotoxhouse>();
            rotoxHouseService.ScanCellRemoteStore("77770010010", new List<rotoxhouse>() { rh, rh2 });

            List<RotoxHouse> items = rotoxHouseService.GetByStorageSpace("77770010010", false);
            Assert.IsTrue(items.Any(i => i.State == 1));

            AssertOrderState((int)DocStateEnum.OnRemoteStorage);
        }

        [TestMethod("Отгрузка с удаленного склада")]
        public void PickUpFromRemoteStoreTest()
        {
            IRotoxHouseService rotoxHouseService = serviceProvider.GetService<IRotoxHouseService>();

            rotoxHouseService.ClearCell("77770010010");

            AssertOrderState((int)DocStateEnum.LeftRemoteStorage);
        }

        private void AssertOrderState(int idDocState)
        {
            IGenUoW unit = serviceProvider.GetService<IGenUoW>();
            orders o = unit.RepOrder.Get(o => o.idorder == 6852);
            Assert.IsTrue(o.iddocstate == idDocState);
        }
    }
}