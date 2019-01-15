using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLL.DTOs;

namespace BLL.Interfaces
{
    public interface ITourLogic
    {
        void AddTour(TourDTO NewTour);
        Task AddTourAsync(TourDTO NewTour);
        void EditTour(int Id, TourDTO Tour);
        IEnumerable<TourDTO> GetAllToursTemplates();
        TourDTO GetTour(int Id);
        void DeleteTour(int Id);
        IEnumerable<TourDTO> FindTourTemplatesByPrice(int MinPrice, int MaxPrice);
        IEnumerable<TourDTO> FindTourTemplates(string SeachElem);
        IEnumerable<TourDTO> FindTourTemplatesByDuration(int MinDuration, int MaxDuration);
        IEnumerable<TourDTO> GetAllToursTemplatesOrderedByPrice();
        IEnumerable<TourDTO> GetAllToursTemplatesOrderedByDuration();
        IEnumerable<TourDTO> GetAllToursTemplatesOrderedByCountry();
    }
}
