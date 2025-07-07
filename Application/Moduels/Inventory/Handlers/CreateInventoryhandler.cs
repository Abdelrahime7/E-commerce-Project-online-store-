using Application.DTOs;
using Application.Interface;
using AutoMapper;
using MediatR;
using  Application.Moduels.Inventory.Commands;
using Application.Moduels.Customer.Commands;
using Domain.Interface;
using Domain.Interfaces.Generic;
using Application.Moduels.GenericHndlers;

namespace Application.Moduels.Inventory.Handlers
{

    /*   public class CreateInventoryHandler : IRequestHandler<CreateInventoryCommand,int>
       {
           private readonly IMapper _mapper;
           private readonly IInventoryRepository _inventoryRepository;

           public CreateInventoryHandler(IMapper mapper, IInventoryRepository inventoryRepository)
           {
               _inventoryRepository = inventoryRepository;
               _mapper = mapper;

           }

           public async Task<int> Handle(CreateInventoryCommand request, CancellationToken cancellationToken)
           {


              var Inventory =_mapper.Map<Domain.entities.Inventory>(request);
               await _inventoryRepository.AddAsync(Inventory);
               return Inventory.Id;

           }


       }*/

    public class CreateInventoryHandler(CreateInventoryCommand command, IMapper mapper, IInventoryRepository repository) : CreatHandler(command, mapper, (IGenericRepository<IEntity>)repository)
    {


    }

}

