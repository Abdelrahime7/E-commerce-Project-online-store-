using AutoMapper;

using Domain.Interface;
using Application.Moduels.GenericHndlers;
using Application.Moduels.ItemGallery.Commands;
using Application.DTOs.ItemGallery;
using Application.Interfaces.Generic;

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

