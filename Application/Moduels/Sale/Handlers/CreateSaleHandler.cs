using Application.Interface;
using AutoMapper;
using Application.Moduels.Person.Commands;
using Domain.Interfaces.Generic;
using Domain.Interface;
using Application.DTOs;
using Application.Moduels.Sale.Commands;
using Application.Moduels.GenericHndlers;


namespace Application.Moduels.Sale.Handlers
{
   

    public class CreateSaleHandler(CreateSaleCommand command  , IMapper mapper, ISaleRepository repository) : CreatHandler(command, mapper, (IGenericRepository<IEntity>)repository)
    {
       

    }




}
