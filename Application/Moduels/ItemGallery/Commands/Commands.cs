using Application.DTOs;
using Domain.entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Moduels.ItemGallery.Commands
{

        
    public record CreateItemGalleryCommand(ItemGalleryDto itemGalleryDto) : IRequest<int>;

}
