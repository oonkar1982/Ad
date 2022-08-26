using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Diary.UI.Models
{
    public class CourtDTO
    {
        public string CourtName { get; set; }
        public string State { get; set; }
        public string Location { get; set; }
        public string City{ get; set; }
        
    }
    public class CourtInputModel
    {
        public int Id { get; set; }
        public string CourtName { get; set; }
        public int StateId { get; set; }
        public string Location { get; set; }
        public int CityId { get; set; }
        public string CourtTypeId { get; set; }
        public virtual List<SelectListItem> CourtType { get; set; }
        public virtual List<SelectListItem> StateList { get; set; }
        public virtual List<SelectListItem> CityList { get; set; }
    }

}
