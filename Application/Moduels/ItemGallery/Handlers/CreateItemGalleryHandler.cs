
using Application.Moduels.ItemGallery.Commands;
using Domain.Interface;
using Domain.Interfaces.Generic;
using Application.Moduels.GenericHndlers;
using AutoMapper;


namespace Application.Moduels.ItemGallery.Handlers
{

    public class CreateItemGalleryHandler : CreatHandler<CreateItemGalleryCommand>
    {
        public CreateItemGalleryHandler(IMapper mapper, IGenericRepository<IEntity> repository) : base(mapper, repository)
        {

        }

    }

}
