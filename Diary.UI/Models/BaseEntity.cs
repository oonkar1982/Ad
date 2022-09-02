using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Diary.UI.Models
{
    public class BaseEntity
    {
        [Key]
        public int Id { get; set; }
    }
    public class Lawsuit : BaseEntity
    {

        public Lawsuit()
        {
            this.Hearings = new HashSet<Hearing>();
            this.Documents = new HashSet<Document>();
            this.Customers = new HashSet<Customer>();
            this.CreateOn = DateTime.Now;
        }

        public string FileNo { get; set; }
        public string Description { get; set; }
        public virtual Court Courts { get; set; }
        public Status Status { get; set; }
        public Casetype Casetype { get; set; }
        public virtual CaseCategory CaseCategory { get; set; }
        public virtual ApplicationUser ApplicationUser { get; set; }
        public DateTime CreateOn { get; set; }
        public virtual ICollection<Customer> Customers { get; set; }
        public virtual ICollection<Hearing> Hearings { get; set; }
        public virtual ICollection<Document> Documents { get; set; }
    }

    public  class CustomerLawsuit :BaseEntity
    {
        public Lawsuit Lawsuit { get; set; }
        public Customer customer { get; set; }
    }
    
    public class Document :BaseEntity
    {
        public string FileName { get; set; }
        public string ContentType { get; set; }
        public int LawsuitId { get; set; }
        public byte[] Data { get; set; }
      

    }
    public class CaseCategory : BaseEntity
    {
       public string Category { get; set; } 
       public int Category_Code { get; set; }
    }

    public enum ClientType
    {
        Client, Opponent
    }

    public class Hearing : BaseEntity
    {

        public Hearing()
        {
            this.CreateOn = DateTime.Now;
          
        }
        public string Description { get; set; }
        public virtual Lawsuit Lawsuits { get; set; }
        public DateTime CreateOn { get; set; }

    }

    public class ApplicationUser : BaseEntity
    {

        public string Name { get; set; }
        public string Email { get; set; }
        [DataType(DataType.Password)]
        public string Password { get; set; }
        public Role Role { get; set; }


    }

    public enum Role
    {
        admin,user
    }
    public class Customer : BaseEntity
    {
        public virtual Lawsuit Lawsuit { get; set; }       
        public ClientType ClientType { get; set; }
        public string ClientName { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public bool SendSMS { get; set; }
    }
    public class Court : BaseEntity
    {

        public string CourtName { get; set; }
        public virtual State State { get; set; }
        public string Location { get; set; }
        public virtual City City { get; set; }

        public string Courttypeid { get; set; }

        
    }

    public class State : BaseEntity
    {
        public string StateName { get; set; }
        public string State_code { get; set; }
        public virtual Country Country { get; set; }
    }
    public class Country : BaseEntity
    {
        public string Name { get; set; }
        public string Country_code { get; set; }

    }
    public class City : BaseEntity
    {
        public string Name { get; set; }
       
        public virtual State State { get; set; }
        public virtual Country Country { get; set; }
    }
    public enum Status
    {
        Open, Closed, Hold
    }

    public enum Casetype
    {
        RFA, EFA, RSA, CRM
    }

    public class Message : BaseEntity
    {
        public string Subject { get; set; }
        public int Createdby { get; set; }
        public string MessageBody { get; set; }

    }

    public class Messagerecipient : BaseEntity
    {
                
        public virtual Lawsuit Lawsuit { get; set; }
        public string PhoneNo { get; set; }
        public string Message  { get; set; }
        public bool IsSend { get; set; }
        public bool IsRead { get; set; }
    }

    public class StringMap :BaseEntity
    {
        public string FiledName { get; set; }
        public string DisplayName { get; set; }
        public string DisplayCode{ get; set; }
        public int EntityCode { get; set; }
        public string Dorder { get; set; }

    }

}