
using CsvHelper.TypeConversion;
using CsvHelper;
using System.Globalization;
using AutoMapper;
using WebAPI.Repository;
using WebAPI.EFCore;

namespace WebAPI.Services
{
    public class ImportService : IImportService
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IPizzaTypeRepository _pizzaTypeRepository;
        private readonly IPizzaRepository _pizzaRepository;
        private readonly IOrderRepository _orderRepository;
        private readonly IOrderDetailRepository _orderDetailRepository;

        public ImportService(IMapper mapper, IUnitOfWork unitOfWork, IPizzaTypeRepository pizzaTypeRepository, IPizzaRepository pizzaRepository, IOrderRepository orderRepository, IOrderDetailRepository orderDetailRepository)
        {
            _unitOfWork = unitOfWork;
            _pizzaTypeRepository = pizzaTypeRepository;
            _pizzaRepository = pizzaRepository;
            _orderRepository = orderRepository;
            _orderDetailRepository = orderDetailRepository;
            _mapper = mapper;
        }

        public async Task ImportPizzaType(Stream fileStream)
        {
            var list = ReadPizzaTypeCsvFile(fileStream).ToList();
            var mapPizzaType = _mapper.Map<List<PizzaTypeVM>, IEnumerable<PizzaType>>(list.ToList());
            await _pizzaTypeRepository.BulkAdd(mapPizzaType);
            await _unitOfWork.CommitAsync();
        }

        private List<PizzaTypeVM> ReadPizzaTypeCsvFile(Stream fileStream)
        {
            try
            {
                using (var reader = new StreamReader(fileStream))
                using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
                {
                    var records = csv.GetRecords<PizzaTypeVM>();
                    return records.ToList();
                }
            }
            catch (HeaderValidationException ex)
            {
                // Specific exception for header issues
                throw new ApplicationException("CSV file header is invalid.", ex);
            }
            catch (TypeConverterException ex)
            {
                // Specific exception for type conversion issues
                throw new ApplicationException("CSV file contains invalid data format.", ex);
            }
            catch (Exception ex)
            {
                // General exception for other issues
                throw new ApplicationException("Error reading CSV file", ex);
            }
        }

        public async Task ImportPizzas(Stream fileStream)
        {
            var list = ReadPizzasCsvFile(fileStream).ToList();
            var mapPizza = _mapper.Map<List<PizzaDetailsVM>, IEnumerable<Pizza>>(list.ToList());
            await _pizzaRepository.BulkAdd(mapPizza);
            await _unitOfWork.CommitAsync();
        }

        private List<PizzaDetailsVM> ReadPizzasCsvFile(Stream fileStream)
        {
            try
            {
                using (var reader = new StreamReader(fileStream))
                using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
                {
                    var records = csv.GetRecords<PizzaDetailsVM>();
                    return records.ToList();
                }
            }
            catch (HeaderValidationException ex)
            {
                // Specific exception for header issues
                throw new ApplicationException("CSV file header is invalid.", ex);
            }
            catch (TypeConverterException ex)
            {
                // Specific exception for type conversion issues
                throw new ApplicationException("CSV file contains invalid data format.", ex);
            }
            catch (Exception ex)
            {
                // General exception for other issues
                throw new ApplicationException("Error reading CSV file", ex);
            }
        }

        public async Task ImportOrders(Stream fileStream)
        {
            var list = ReadOrdersCsvFile(fileStream).ToList();
            var mapOrder = _mapper.Map<List<OrderVM>, IEnumerable<Order>>(list.ToList());
            await _orderRepository.BulkAdd(mapOrder);
            await _unitOfWork.CommitAsync();
        }

        private IEnumerable<OrderVM> ReadOrdersCsvFile(Stream fileStream)
        {
            try
            {
                using (var reader = new StreamReader(fileStream))
                using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
                {
                    var records = csv.GetRecords<OrderVM>();
                    return records.ToList();
                }
            }
            catch (HeaderValidationException ex)
            {
                // Specific exception for header issues
                throw new ApplicationException("CSV file header is invalid.", ex);
            }
            catch (TypeConverterException ex)
            {
                // Specific exception for type conversion issues
                throw new ApplicationException("CSV file contains invalid data format.", ex);
            }
            catch (Exception ex)
            {
                // General exception for other issues
                throw new ApplicationException("Error reading CSV file", ex);
            }
        }

        public async Task ImportOrderDetails(Stream fileStream)
        {
            var list = ReadOrderDetailsCsvFile(fileStream).ToList();
            var mapOrderDetail = _mapper.Map<List<OrdersInfoVM>, IEnumerable<OrderDetail>>(list.ToList());
            await _orderDetailRepository.BulkAdd(mapOrderDetail);
            await _unitOfWork.CommitAsync();
        }

        private IEnumerable<OrdersInfoVM> ReadOrderDetailsCsvFile(Stream fileStream)
        {
            try
            {
                using (var reader = new StreamReader(fileStream))
                using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
                {
                    var records = csv.GetRecords<OrdersInfoVM>();
                    return records.ToList();
                }
            }
            catch (HeaderValidationException ex)
            {
                // Specific exception for header issues
                throw new ApplicationException("CSV file header is invalid.", ex);
            }
            catch (TypeConverterException ex)
            {
                // Specific exception for type conversion issues
                throw new ApplicationException("CSV file contains invalid data format.", ex);
            }
            catch (Exception ex)
            {
                // General exception for other issues
                throw new ApplicationException("Error reading CSV file", ex);
            }
        }
    }
}