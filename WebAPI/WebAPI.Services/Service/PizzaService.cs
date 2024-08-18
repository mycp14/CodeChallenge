
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
            var listofPizzaTypes = _mapper.Map<IEnumerable<PizzaType>, List<PizzaTypeVM>>(pizzaTypes.ToList());
            if (listofPizzaTypes == null)
                throw new AppException($"No Pizza Type found.");

            return listofPizzaTypes;
        }

        public async Task<List<PizzaVM>> GetAllPizzas()
        {
            var pizzaTypes = await _pizzaRepository.GetPizzaIncludePizzaType();
            var listofPizzaTypes = _mapper.Map<IEnumerable<Pizza>, List<PizzaVM>>(pizzaTypes.ToList());
            if (listofPizzaTypes == null)
                throw new AppException($"No Pizzas found.");

            return listofPizzaTypes;
        }

        public async Task<PizzaTypeVM> GetPizzaTypeById(string id)
        {
            var pizzaTypes = await _pizzaTypeRepository.GetById(id);
            var pizzaTypeVM = _mapper.Map<PizzaType, PizzaTypeVM>(pizzaTypes);
            if (pizzaTypeVM == null)
                throw new AppException($"No Pizzas type found by this id {id}");

            return pizzaTypeVM;
        }

        public async Task<PizzaVM> GetPizzaById(string id)
        {
            var pizza = (await _pizzaRepository.GetPizzaIncludePizzaType()).Where(x => x.pizza_id == id).FirstOrDefault();
            var pizzaVM = _mapper.Map<Pizza, PizzaVM>(pizza);
            if (pizzaVM == null)
                throw new AppException($"No Pizzas found by this id {id}");

            return pizzaVM;
        }
    }
}