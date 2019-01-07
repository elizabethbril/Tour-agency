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
    public class TourLogic : ITourLogic
    {
        IUnitOfWork UoW;

        public TourLogic(IUnitOfWork UoW)
        {
            TourLogicMapper = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<TourDTO, Tour>();
                cfg.CreateMap<Tour, TourDTO>();
            }).CreateMapper();
            this.UoW = UoW;
        }

        IMapper TourLogicMapper;

        public TourLogic()
        {
            TourLogicMapper = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<TourDTO, Tour>();
                cfg.CreateMap<Tour, TourDTO>();
            }).CreateMapper();
            UoW = LogicDependencyResolver.ResolveUoW();
        }

        public void AddTour(TourDTO NewTour)
        {
            if (UserLogic.CurrentUser == null || UserLogic.CurrentUser.UserType != DTOs.UserType.Manager)
                throw new WrongUserException("Function availible only for managers");
            UoW.ToursTemplates.Add(TourLogicMapper.Map<TourDTO, Tour>(NewTour));
        }

        public void DeleteTour(int Id)
        {
            if (UserLogic.CurrentUser == null || UserLogic.CurrentUser.UserType != DTOs.UserType.Manager)
                throw new WrongUserException("Function availible only for managers");
            UoW.ToursTemplates.Delete(Id);
        }

        public void EditTour(int Id, TourDTO Tour)
        {
            if (UserLogic.CurrentUser == null || UserLogic.CurrentUser.UserType != DTOs.UserType.Manager)
                throw new WrongUserException("Function availible only for managers");
            Tour tour = UoW.ToursTemplates.Get(Id);
            tour = TourLogicMapper.Map<TourDTO, Tour>(Tour);
            UoW.ToursTemplates.Modify(Id, tour);
        }

        public IEnumerable<TourDTO> GetAllToursTemplates()
        {
            return TourLogicMapper.Map<IEnumerable<Tour>, List<TourDTO>>(UoW.ToursTemplates.GetAll());
        }

        public IEnumerable<TourDTO> FindTourTemplatesByPrice(int MinPrice, int MaxPrice)
        {
            return TourLogicMapper.Map<IEnumerable<Tour>, List<TourDTO>>(UoW.ToursTemplates.GetAll(t => t.Price >= MinPrice && t.Price <= MaxPrice));
        }

        public IEnumerable<TourDTO> FindTourTemplates(string SeachElem)
        {
            return TourLogicMapper.Map<IEnumerable<Tour>, List<TourDTO>>(UoW.ToursTemplates.GetAll(t => t.Type == SeachElem || t.City == SeachElem || t.Country == SeachElem || t.Name == SeachElem));
        }

        public IEnumerable<TourDTO> FindTourTemplatesByDuration(int MinDuration, int MaxDuration)
        {
            return TourLogicMapper.Map<IEnumerable<Tour>, List<TourDTO>>(UoW.ToursTemplates.GetAll(t => t.Duration >= MinDuration && t.Duration <= MaxDuration));
        }

        public IEnumerable<TourDTO> GetAllToursTemplatesOrderedByPrice()
        {
            return TourLogicMapper.Map<IEnumerable<Tour>, List<TourDTO>>(UoW.ToursTemplates.GetAll().OrderBy(t => t.Price));
        }

        public IEnumerable<TourDTO> GetAllToursTemplatesOrderedByDuration()
        {
            return TourLogicMapper.Map<IEnumerable<Tour>, List<TourDTO>>(UoW.ToursTemplates.GetAll().OrderBy(t => t.Duration));
        }

        public IEnumerable<TourDTO> GetAllToursTemplatesOrderedByCountry()
        {
            return TourLogicMapper.Map<IEnumerable<Tour>, List<TourDTO>>(UoW.ToursTemplates.GetAll().OrderBy(t => t.Country));
        }

        public TourDTO GetTour(int Id)
        {
            return TourLogicMapper.Map<Tour, TourDTO>(UoW.ToursTemplates.GetAll(t => t.Id == Id).FirstOrDefault());
        }

    }
}
