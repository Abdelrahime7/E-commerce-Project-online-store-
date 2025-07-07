using Application.DTOs;
using MediatR;


namespace Application.Moduels.Inventory.Commands
{
  
        public record CreateInventoryCommand(InventoryDto inventoryDto) : IRequest<int>;


   
}
