using Diary.UI.DataContext;
using Diary.UI.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Diary.UI.Rep
{
    public class CourtRep
    {

        private readonly ApplicationDbContext _context;

        public CourtRep()
        {
        }

        public CourtRep(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<CourtInputModel> Create( CourtInputModel item)
        {
            CourtInputModel model = new CourtInputModel();
            try
            {
                var _court = new Court()
                {
                    City = _context.Cities.Find(item.CityId),
                    State = _context.States.Find(item.StateId),
                    Courttypeid = item.CourtTypeId,
                    CourtName = item.CourtName
                };

                _context.Court.Add(_court);
                await _context.SaveChangesAsync();
                model = await GetCourtInputModel(_court.Id);
            }
            catch
            {
                 model = new CourtInputModel()
                {
                    CityId = item.CityId,
                    StateId = item.StateId,
                    CourtTypeId = item.CourtTypeId,
                    StateList = (List<SelectListItem>)_context.States.Select(e => new SelectListItem { Value = e.Id.ToString(), Text = e.StateName }).ToList(),
                    CityList = (List<SelectListItem>)_context.Cities.Select(e => new SelectListItem { Value = e.Id.ToString(), Text = e.Name }).ToList(),
                    CourtType = (List<SelectListItem>)_context.StringMap.Where(x => x.FiledName.Equals("CourtType")).Select(e => new SelectListItem { Value = e.DisplayCode.ToString(), Text = e.DisplayName }).ToList()
                };
            }
            return model;
        }

        public async Task<CourtInputModel> GetCourtInputModel( int ?id)
        {

            CourtInputModel model = new CourtInputModel();
            var record = await _context.Court.Include(co => co.State).Include(co=>co.City).Where(x=>x.Id ==id).FirstOrDefaultAsync();
            if (record == null)
            {
              

                 model = new CourtInputModel()
                {
                    StateList = (List<SelectListItem>)_context.States.Select(e => new SelectListItem { Value = e.Id.ToString(), Text = e.StateName }).ToList(),
                    CityList = (List<SelectListItem>)_context.Cities.Select(e => new SelectListItem { Value = e.Id.ToString(), Text = e.Name }).ToList(),
                    CourtType = (List<SelectListItem>)_context.StringMap.Where(x => x.FiledName.Equals("CourtType")).Select(e => new SelectListItem { Value = e.DisplayCode.ToString(), Text = e.DisplayName }).ToList()
                };
            }
            else
            {      
                    model = new CourtInputModel()
                    {
                        CourtName=record.CourtName,StateId=record.State.Id,CityId=record.City.Id,CourtTypeId=record.Courttypeid,
                        StateList = (List<SelectListItem>)_context.States.Select(e => new SelectListItem { Value = e.Id.ToString(), Text = e.StateName }).ToList(),
                        CityList = (List<SelectListItem>)_context.Cities.Select(e => new SelectListItem { Value = e.Id.ToString(), Text = e.Name }).ToList(),
                        CourtType = (List<SelectListItem>)_context.StringMap.Where(x => x.FiledName.Equals("CourtType")).Select(e => new SelectListItem { Value = e.DisplayCode.ToString(), Text = e.DisplayName }).ToList()
                    
                    
                    };
                
            }
            return model;
        }

        public async Task<string> Edit(int Id, CourtInputModel item)
        {
            

            var court = await _context.Court.FindAsync(Id);

            if (court != null)
            {
                try
                {
                    var _court = new Court()
                    {
                        Id = item.Id,
                        City = _context.Cities.Find(item.CityId),
                        State = _context.States.Find(item.StateId),
                        Courttypeid = item.CourtTypeId,
                        CourtName = item.CourtName
                    };
                    _context.Court.Update(_court);
                    await _context.SaveChangesAsync();
                    return "Sucess";

                }
                catch(Exception ex)
                {
                    return ex.Message;
                }
                
            }
            else
            {
                return "Not Found";
            }
        }
    }
}
