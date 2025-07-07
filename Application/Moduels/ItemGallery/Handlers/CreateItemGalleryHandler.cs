using Application.DTOs;
using Application.Interface;
using AutoMapper;
using MediatR;
using Application.Moduels.ItemGallery.Commands;
using Application.Moduels.Customer.Commands;
using Domain.Interface;
using Domain.Interfaces.Generic;
using Application.Moduels.GenericHndlers;


namespace Application.Moduels.ItemGallery.Handlers
{
    /*   public class CreateItemGalleryHandler : IRequestHandler<CreateItemGalleryCommand, int>
       {
           private readonly IMapper _mapper;
           private readonly IItemGalleryRepository _itemGalleryRepository ;


           public CreateItemGalleryHandler(IMapper mapper, IItemGalleryRepository itemGalleryRepository)
           {
               _itemGalleryRepository = itemGalleryRepository;
               _mapper = mapper;
           }

           public  async Task <int> Handle(CreateItemGalleryCommand request, CancellationToken cancellationToken)
           {
               //var Customer = new Domain.entities.Customer{Point= request.Point,PersonID= request.PersonID };
               var ItemGallery = _mapper.Map<Domain.entities.ItemGallery>(request);
               await _itemGalleryRepository.AddAsync(ItemGallery); 
               return ItemGallery.Id;

           }
       }*/
    public class CreateItemGalleryHandler(CreateItemGalleryCommand command, IMapper mapper, IItemGalleryRepository repository) : CreatHandler(command, mapper, (IGenericRepository<IEntity>)repository)
    {


    }
}
