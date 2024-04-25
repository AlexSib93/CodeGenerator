using BuisinessLogicLayer.Services;
using Mapster;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DataAccessLayer.Dto;
using BuisinessLogicLayer.ViewModels;
using TerminalApi.ViewModels;
using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;

namespace TerminalApi
{    
    [Route("api/[controller]")]
    [ApiController]
    public class RotoxHouseController : ControllerBase
    {
        private IUserService _userService { get; set; }
        private IRotoxHouseService _rotoxHouseService { get; set; }
        private IDelivDocService _delivDocService { get; set; }
        private IStorageSpaceService _storageSpaceService { get; set; }
        private IOrderService _orderService { get; set; }

        private readonly ILogger<RotoxHouseController> _logger;
        public RotoxHouseController(ILogger<RotoxHouseController> logger, IRotoxHouseService rotoxHouseService, IDelivDocService delivDocService, IStorageSpaceService storageSpaceService, IUserService userService, IOrderService orderService)
        {
            _logger = logger;
            _userService = userService;
            _rotoxHouseService = rotoxHouseService;
            _rotoxHouseService.IdPeople = _userService.GetIdPeople();
            _delivDocService = delivDocService;
            _storageSpaceService = storageSpaceService;
            _orderService = orderService;
        }

        [HttpPost("create")]
        public IActionResult Create([FromBody] RotoxHouse rotoxHouse)
        {
            try
            {
                rotoxhouse rh = rotoxHouse.Adapt<rotoxhouse>();
                rotoxhouse res = _rotoxHouseService.Create(rh);

                return Ok(res);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Не удалось привязать адрес изделия");
                return BadRequest(ex.Message + " " + ex.InnerException?.Message);
            }
        }

        [HttpGet("get")]
        public ActionResult<RotoxHouse> Get(int id)
        {
            try
            {
                rotoxhouse res = _rotoxHouseService.Get(id);

                return Ok(res.Adapt<RotoxHouse>());
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Не удалось создать Адрес изделия");
                return BadRequest(ex.Message + " " + ex.InnerException?.Message);
            }
        }

        [HttpGet("getbymanufactdoc")]
        public ActionResult<List<RotoxHouse>> GetByManufactDoc(int id)
        {
            try
            {
                List<RotoxHouse> res = _rotoxHouseService.GetByManufactDoc(id);

                return Ok(res);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Не удалось загрузить список изделий по ПЗ");
                return BadRequest(ex.Message + " " + ex.InnerException?.Message);
            }
        }

        [HttpGet("getbyorder")]
        public ActionResult<GetByOrderResponse> GetByOrder(int id)
        {
            try
            {
                List<RotoxHouse> items = _rotoxHouseService.GetByOrder(id);
                Order order = _orderService.Get(id).Adapt<Order>();

                GetByOrderResponse res = new GetByOrderResponse();
                res.Items = items;
                res.Order = order;

                return Ok(res);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Не удалось загрузить список изделий по заказу");
                return BadRequest(ex.Message + " " + ex.InnerException?.Message);
            }
        }

        [HttpGet("getbydelivdoc")]
        public ActionResult<GetByDelivDocResponse> GetByDelivDoc(int id)
        {
            try
            {
                List<RotoxHouse> res = _rotoxHouseService.GetByDelivDoc(id);
                DelivDoc doc = _delivDocService.Get(id).Adapt<DelivDoc>();
                return Ok(new GetByDelivDocResponse() { Items = res, DelivDoc = doc });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Не удалось получить изделия по рейсу");
                return BadRequest(ex.Message + " " + ex.InnerException?.Message);
            }
        }

        [HttpGet("getbystoragespace")]
        public ActionResult<GetByDelivDocResponse> GetByStorageSpace(string barcode, bool isGp = true)
        {
            try
            {                
                List<RotoxHouse> res = _rotoxHouseService.GetByStorageSpace(barcode, isGp);
                StorageSpace ss = _storageSpaceService.Get(barcode).Adapt<StorageSpace>();
                return Ok(new { Items = res, StorageSpace = ss });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Не удалось получить изделия по рейсу");
                return BadRequest(ex.Message + " " + ex.InnerException?.Message);
            }
        }

        [HttpPost("scan"), Authorize]
        public async Task<ActionResult<RotoxHouse>> Scan(string barcode, bool isGp = true)
        {
            RotoxHouse res = null;
            try
            {
                res = _rotoxHouseService.Scan(barcode, isGp);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Не удалось сканировать баркод");
                return BadRequest(ex.Message + " " + ex.InnerException?.Message);
            }

            return Ok(res);
        }

        [HttpPost("scan2"), Authorize]
        public async Task<ActionResult<RotoxHouse>> Scan2(string itemBarcode, string spaceBarcode)
        {
            RotoxHouse res = null;
            try
            {
                res = _rotoxHouseService.Scan(itemBarcode);
                rotoxhouse rotoxhouse = _rotoxHouseService.ScanCell(spaceBarcode, new List<rotoxhouse>() { res.Adapt<rotoxhouse>() }).FirstOrDefault();
                if (rotoxhouse != null)
                {
                    res.State = (int)rotoxhouse.state;
                    res.DtOut = rotoxhouse.dtout;
                    res.ZoneRow = rotoxhouse.idstoragespaceNavigation?.row;
                    res.ZoneCell = rotoxhouse.idstoragespaceNavigation?.cell;
                    res.ZoneStoreDepart = rotoxhouse.idstoragespaceNavigation?.idstoredepartNavigation?.name;
                    res.Row = rotoxhouse.idstoragespace2Navigation?.row;
                    res.Cell = rotoxhouse.idstoragespace2Navigation?.cell;
                    res.StoreDepart = rotoxhouse.idstoragespace2Navigation?.idstoredepartNavigation?.name;


                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Не удалось сканировать баркод");
                return BadRequest(ex.Message + " " + ex.InnerException?.Message);
            }

            return Ok(res);
        }

        [HttpPost("setparentnull"), Authorize]
        public async Task<ActionResult<StorageSpace>> SetParentNull(string storageSpaceBarcode )
        {
            StorageSpace res = null;
            try
            {
                res = _storageSpaceService.SetParentNull(storageSpaceBarcode).Adapt<StorageSpace>();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Не удалось сканировать баркод");
                return BadRequest(ex.Message + " " + ex.InnerException?.Message);
            }

            return Ok(res);
        }

        [HttpPost("shipitem"), Authorize]
        public async Task<ActionResult<RotoxHouse>> ShipItem(int idDelivDoc, string barcode)
        {
            RotoxHouse res = null;
            try
            {
                res = _rotoxHouseService.ShipItem(barcode, idDelivDoc);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Не удалось сканировать баркод");
                return BadRequest(ex.Message + " " + ex.InnerException?.Message);
            }

            return Ok(res);
        }

        [HttpPost("scanongp")]
        public async Task<ActionResult<StorageSpace>> ScanOnGp(string barcodefrom, string barcode)
        {
            StorageSpace res = null;
            try
            {
                res = _rotoxHouseService.ScanFromCellToCell(barcodefrom, barcode).Adapt<StorageSpace>();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Не удалось сканировать баркод");
                return BadRequest(ex.Message + " " + ex.InnerException?.Message);
            }

            return Ok(res);
        }


        [HttpPost("clearcell")]
        public async Task<ActionResult<StorageSpace>> ClearCell(string barcodefrom)
        {
            try
            {
                _rotoxHouseService.ClearCell(barcodefrom);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Не удалось сканировать баркод");
                return BadRequest(ex.Message + " " + ex.InnerException?.Message);
            }

            return Ok();
        }

        [HttpPost("scanongpremotestore")]
        public async Task<ActionResult<StorageSpace>> ScanOnGpRemoteStore(string barcodefrom, string barcode)
        {
            StorageSpace res = null;
            try
            {
                res = _rotoxHouseService.ScanFromCellToCellRemoteStore(barcodefrom, barcode).Adapt<StorageSpace>();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Не удалось сканировать баркод");
                return BadRequest(ex.Message + " " + ex.InnerException?.Message);
            }

            return Ok(res);
        }

        [HttpPost("scancell")]
        public async Task<ActionResult<List<RotoxHouse>>> ScanCell([FromBody] ScanCellViewModel model)
        {
            List<RotoxHouse> res = null;
            try
            {
                List<rotoxhouse> list = _rotoxHouseService.ScanCell(model.Barcode, model.Items.Adapt<List<rotoxhouse>>());
                res = list.Adapt<List<RotoxHouse>>();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Не удалось сканировать баркод");
                return BadRequest(ex.Message + " " + ex.InnerException?.Message);
            }

            return Ok(res);
        }

        [HttpPost("clearitems")]
        public async Task<ActionResult<List<RotoxHouse>>> ClearItems([FromBody] ClearItemsViewModel model)
        {
            try
            {   
                _rotoxHouseService.ClearItems(model.IdRotoxHouses);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Не удалось сканировать баркод");
                return BadRequest(ex.Message + " " + ex.InnerException?.Message);
            }

            return Ok();
        }

        [HttpPost("scancellremotestore")]
        public async Task<ActionResult<List<RotoxHouse>>> ScanCellRemoteStore([FromBody] ScanCellViewModel model)
        {
            List<RotoxHouse> res = null;
            try
            {
                List<rotoxhouse> list = _rotoxHouseService.ScanCellRemoteStore(model.Barcode, model.Items.Adapt<List<rotoxhouse>>());
                res = list.Adapt<List<RotoxHouse>>();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Не удалось сканировать баркод");
                return BadRequest(ex.Message + " " + ex.InnerException?.Message);
            }

            return Ok(res);
        }
    }
}
