using AutoMapper;
using BLL.DTOs;
using BLL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using TourAgency.Models;
using TourAgency.Ninject;

namespace TourAgency.Controllers
{
    public class TransportController : ApiController
    {
        public TransportController()
        {
            TransportLogic = UIDependencyResolver<ITransportLogic>.ResolveDependency();
        }
        public TransportController(ITransportLogic TransportLogic)
        {
            this.TransportLogic = TransportLogic;
        }

        ITransportLogic TransportLogic;

        IMapper TransportControllerMapper = new MapperConfiguration(cfg =>
        {
            cfg.CreateMap<TransportDTO, TransportModel>();
            cfg.CreateMap<TransportPlaceDTO, TransportPlaceModel>();
            cfg.CreateMap<TransportModel, TransportDTO>();
            cfg.CreateMap<TransportPlaceModel, TransportPlaceDTO>();
        }).CreateMapper();

        // GET api/<controller>
        public IEnumerable<TransportModel> Get()
        {
            return TransportControllerMapper.Map<IEnumerable<TransportDTO>, IEnumerable<TransportModel>>(TransportLogic.GetAllTransport());
        }

        // GET api/<controller>/5
        public TransportModel Get(int Id)
        {
            return TransportControllerMapper.Map<TransportDTO, TransportModel>(TransportLogic.GetTransport(Id));
        }

        // POST api/<controller>
        public void Post([FromBody]TransportModel Transport, int AvailibleSeats, int PriceForTicket)
        {
            TransportLogic.AddTransport(TransportControllerMapper.Map<TransportModel, TransportDTO>(Transport), AvailibleSeats, PriceForTicket);
        }

        // PUT api/<controller>/5
        public void Put(int Id, [FromBody]string value)
        {
        }

        // DELETE api/<controller>/5
        public void Delete(int Id)
        {
            TransportLogic.DeleteTransport(Id);
        }
    }
}
