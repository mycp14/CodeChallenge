
using AutoMapper;
using WebAPI.EFCore;
using WebAPI.Repository;

namespace WebAPI.Services
{
    public class PizzaService : IPizzaService
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IPizzaRepository _pizzaRepository;
        private readonly IPizzaTypeRepository _pizzaTypeRepository;

        public PizzaService(IMapper mapper, IUnitOfWork unitOfWork, IPizzaRepository pizzaRepository, IPizzaTypeRepository pizzaTypeRepository)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
            _pizzaRepository = pizzaRepository;
            _pizzaTypeRepository = pizzaTypeRepository;
        }

        public async Task<List<PizzaTypeVM>> GetAllPizzaTypes()
        {
            var pizzaTypes = await _pizzaTypeRepository.GetAll();
            var listofPizzaTypes = _mapper.Map<List<PizzaType>, List<PizzaTypeVM>>(pizzaTypes.ToList());
            if (listofPizzaTypes == null)
                throw new AppException($"No Pizza Type found.");

            return listofPizzaTypes;
        }
    }
}