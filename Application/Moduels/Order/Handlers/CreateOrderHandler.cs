using Application.Interface;
using AutoMapper;

using Domain.Interface;
using Domain.Interfaces.Generic;
using Application.Moduels.GenericHndlers;
using Application.Moduels.Order.Commands;


namespace Application.Moduels.Order.Handlers
{
    /*  public class CreatePersonHandler : IRequestHandler<CreateOrderCommand, int>
      {
          private readonly IMapper _mapper;
          private readonly IOrderRepository _orderRepository ;


          public CreatePersonHandler(IMapper mapper, IOrderRepository orderRepository)
          {
              _orderRepository = orderRepository;
              _mapper = mapper;
          }

          public  async Task <int> Handle(CreateOrderCommand request, CancellationToken cancellationToken)
          {
              var Order = _mapper.Map<Domain.entities.Order>(request);
              await _orderRepository.AddAsync(Order); 
              return Order.Id;

          }
      }*/

    public class CreateOrderHandler(CreateOrderCommand command, IMapper mapper, IOrderRepository repository) : CreatHandler(command, mapper, (IGenericRepository<IEntity>)repository)
    {


    }
}
