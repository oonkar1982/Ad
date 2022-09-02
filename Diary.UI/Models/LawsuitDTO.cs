using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Diary.UI.Models
{


    public class LasuitsModel
    {
      public  IEnumerable<LawsuitViewModel> UpcomingHearings { get; set; }
       

    }
    public class LawsuitViewModel
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public string Customer { get; set; }
        public string Court { get; set; }
        public string Status { get; set; }
        public string Casetype { get; set; }
        public string CaseCategory { get; set; }
        public DateTime CreateOn { get; set; }

        public static Expression<Func<Lawsuit, LawsuitViewModel>> ViewModel
        {
            get
            {
                return x => new LawsuitViewModel()
                {
                    Id = x.Id,
                    Customer = x.Customers.Select(x => x.ClientName).FirstOrDefault(),
                    CaseCategory=x.CaseCategory.Category,
                    Court = x.Courts.CourtName,
                    Description = x.Description,
                    Casetype = x.Casetype.ToString(),
                    CreateOn=x.CreateOn,
                    Status = x.Status.ToString()                   
                };

            }
        }
    }
    public class LawsuitInputModel
    {
        public int Id { get; set; }
        public string FileNo { get; set; }
        public string Description { get; set; }

        public int CustomersId { get; set; }

        [Display(Name ="Courts")]
        public int CourtsId { get; set; }
        [Display(Name = "Status")]
        public Status Status { get; set; }

        [Display(Name = "Case type")]
        public Casetype Casetype { get; set; }
        [Display(Name = "Category")]
        public int CategoryId { get; set; }
        [Display(Name = "User")]
        public int ApplicationUserId { get; set; }
        public List<SelectListItem> CustomersList { get; set; }
        public List<SelectListItem> ApplicationUserList { get; set; }
        public List<SelectListItem> CourtList { get; set; }
        public List<SelectListItem> CategoryList { get; set; }


    }

    
    public class LawsuitEditModel
    {
        public int Id { get; set; }
        public string FileNo { get; set; }
        public string Description { get; set; }
        public int CustomersId { get; set; }
        public int CourtsId { get; set; }
        public Status Status { get; set; }
        public Casetype Casetype { get; set; }
        public int ApplicationUserId { get; set; }
        public List<Customer> CustomersList { get; set; }
        public List<SelectListItem> ApplicationUserList { get; set; }
        public List<SelectListItem> CourtList { get; set; }
        public ICollection<HearingViewModel> HearingsList { get; set; }
        public ICollection<DocumentViewModel> DoucmentList { get; set; }


    }
    public class HearingViewModel
    {
        public int Id { get; set; }

        [Required]
        public string Description { get; set; }
        public virtual Lawsuit Lawsuits { get; set; }
        public DateTime CreateOn    { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime? NextDate { get; set; }
    }

   public class SMSViewModel
    {
        public int Id { get; set; }
        public string  Recipient { get; set; }
        public string PhoneNo { get; set; }
        public string  Message { get; set; }
        public bool IsSend { get; set; }
        public bool IsRead { get; set; }


        public static Expression<Func<Messagerecipient, SMSViewModel>> ViewModel
        {
            get
            {
                return x => new SMSViewModel()
                {
                    Id = x.Id,
                        Message=x.Message,
                   PhoneNo=x.PhoneNo,  IsSend = x.IsSend,  IsRead=x.IsRead
                };

            }
        }

    }

    public class DocumentViewModel
    {
        public string FileName { get; set; }
        public string ContentType { get; set; }
        public int Id { get; set; }
    }
}
