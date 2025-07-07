using Application.DTOs;
using Application.Interface;
using Application.Moduels.Customer.Commands;
using Application.Moduels.Item.Commands;
using AutoMapper;
using Domain.Interface;
using Domain.Interfaces.Generic;
using MediatR;

namespace Application.Moduels.Item.Handlers
{





    /*  public class CreateItemHandler : IRequestHandler<CreateItemCommand, int>
      {
          private readonly IMapper _mapper;
          private readonly IItemRepository _itemRepository;

          public CreateItemHandler(IMapper mapper, IItemRepository itemRepository)
          {
              _itemRepository = itemRepository;
              _mapper = mapper;

          }

          public async Task<int> Handle(CreateItemCommand request, CancellationToken cancellationToken)
          {



              var Item = _mapper.Map<Domain.entities.Item>(request);
              await _itemRepository.AddAsync(Item);
              return  Item.Id;

          }
      }*/

    public class CreateItemHandler(CreateItemCommand command, IMapper mapper, IItemRepository repository) : CreatHandler(command, mapper, (IGenericRepository<IEntity>)repository)
    {


    }
}
