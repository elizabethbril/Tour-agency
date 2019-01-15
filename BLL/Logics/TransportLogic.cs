using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.UnitOfWork;
using DAL.Entities;
using BLL.DTOs;
using AutoMapper;
using BLL.DTOs.Exceptions;
using BLL.Interfaces;
using DAL.Interfaces;
using BLL.Ninject;

namespace BLL.Logics
{
    public class TransportLogic : ITransportLogic
    {
        IUnitOfWork UoW;

        public TransportLogic(IUnitOfWork UoW)
        {
            TransportLogicMapper = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<TransportDTO, Transport>();
                cfg.CreateMap<TransportPlaceDTO, TransportPlace>();
                cfg.CreateMap<Transport, TransportDTO>();
                cfg.CreateMap<TransportPlace, TransportPlaceDTO>();
            }).CreateMapper();
            this.UoW = UoW;
        }

        IMapper TransportLogicMapper;

        public TransportLogic()
        {
            TransportLogicMapper = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<TransportDTO, Transport>();
                cfg.CreateMap<TransportPlaceDTO, TransportPlace>();
                cfg.CreateMap<Transport, TransportDTO>();
                cfg.CreateMap<TransportPlace, TransportPlaceDTO>();
            }).CreateMapper();
            UoW = LogicDependencyResolver.ResolveUnitOfWork();
        }

        public void AddTransport(TransportDTO NewTransport, int AvailibleSeats, int PriceForTicket)
        {
            if (UserLogic.CurrentUser == null || UserLogic.CurrentUser.UserType != DTOs.UserType.Manager)
                throw new WrongUserException("Function availible only for managers");
            for (int i = 1; i <= AvailibleSeats; i++)
                NewTransport.TransportPlaces.Add(new TransportPlaceDTO(NewTransport, i, PriceForTicket));
            UoW.Transports.Add(TransportLogicMapper.Map<TransportDTO, Transport>(NewTransport));
        }

        public void DeleteTransport(int Id)
        {
            if (UserLogic.CurrentUser == null || UserLogic.CurrentUser.UserType != DTOs.UserType.Manager)
                throw new WrongUserException("Function availible only for managers");
            UoW.Transports.Delete(Id);
        }

        public IEnumerable<TransportDTO> GetAllTransport()
        {
            return TransportLogicMapper.Map<IEnumerable<Transport>, List<TransportDTO>>(UoW.Transports.GetAll(t => t.TransportPlaces));
        }

        public TransportDTO GetTransport(int Id)
        {
            return TransportLogicMapper.Map<Transport, TransportDTO>(UoW.Transports.GetAll(t => t.Id == Id, t => t.TransportPlaces).FirstOrDefault());
        }
    }
}
