using Application.DTOs;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Moduels.Item.Commands
{
    public record CreateItemCommand(ItemDto itemDto) : IRequest<int>;

}
