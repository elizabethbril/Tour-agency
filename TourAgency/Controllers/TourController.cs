using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using BLL.DTOs;
using TourAgency.Models;
using AutoMapper;
using TourAgency.Ninject;
using BLL.Interfaces;

namespace TourAgency.Controllers
{
    public class TourController : ApiController
    {
        public TourController()
        {
            this.TourLogic = UIDependencyResolver<ITourLogic>.ResolveDependency();
        }
        public TourController(ITourLogic TourLogic)
        {
            this.TourLogic = TourLogic;
        }

        ITourLogic TourLogic;

        IMapper TourControllerMapper = new MapperConfiguration(cfg =>
        {
            cfg.CreateMap<TourDTO, TourModel>();
            cfg.CreateMap<TourModel, TourDTO>();
        }).CreateMapper();

        // GET api/<controller>
        public IEnumerable<TourModel> Get()
        {
            return TourControllerMapper.Map<IEnumerable<TourDTO>, IEnumerable<TourModel>>(TourLogic.GetAllToursTemplates());
        }

        // GET api/<controller>/5
        public TourModel Get(int Id)
        {
            return TourControllerMapper.Map<TourDTO, TourModel>(TourLogic.GetTour(Id));
        }

        // POST api/<controller>
        public void Post([FromBody]TourModel Tour)
        {
            TourLogic.AddTour(TourControllerMapper.Map<TourModel, TourDTO>(Tour));
        }

        // PUT api/<controller>/5
        public void Put(int Id, [FromBody]TourModel Tour)
        {
            TourLogic.EditTour(Id, TourControllerMapper.Map<TourModel, TourDTO>(Tour));
        }

        // DELETE api/<controller>/5
        public void Delete(int Id)
        {
            TourLogic.DeleteTour(Id);
        }
    }
}