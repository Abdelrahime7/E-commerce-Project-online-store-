using Application.Interface;
using Application.Moduels.Inventory.Commands;
using AutoMapper;
using Domain.entities;
using Domain.Interface;
using Domain.Interfaces.Generic;
using MediatR;


namespace Application.Moduels.GenericHndlers
{

     
   public abstract class CreatHandler  : IRequestHandler<IRequest<int>, int> 
       
    {
       
        private readonly IRequest<int> _request;
        private readonly IMapper _mapper;
        private readonly IGenericRepository<IEntity> _repository;


        protected CreatHandler(IRequest<int> request, IMapper mapper, IGenericRepository<IEntity> repository)
        {
            _request = request;
            _mapper = mapper;
            _repository = repository;
        }

        public async Task<int> Handle(IRequest<int> request, CancellationToken cancellationToken)
        {
            request = _request;
            var Entity = _mapper.Map<IEntity>(request);
             await _repository.AddAsync(Entity);
            return Entity.Id;


        }
    }
}
