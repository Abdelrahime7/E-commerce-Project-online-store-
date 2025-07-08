using AutoMapper;

using Domain.Interface;
using Domain.Interfaces.Generic;
using Application.Moduels.GenericHndlers;
using Application.Moduels.ItemGallery.Commands;
using Application.DTOs.ItemGallery;

namespace Application.Moduels.ItemGallery.Handlers
{
    public class UpdateItemGalleryHandler : UpdateHandler<UpdateItemGalleryCommand, ItemGalleryDto>
    {
        public UpdateItemGalleryHandler(IMapper mapper, IGenericRepository<IEntity> repository) : base(mapper, repository)
        {
        }

        protected override int GetId(UpdateItemGalleryCommand command) => command.Response.Id;
       
    }





}

