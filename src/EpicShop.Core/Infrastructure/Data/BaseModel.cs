using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;

namespace EpicShop.Core.Infrastructure.Data
{
    public class BaseModel
    {
        [Key]
        public int Id { get; set; }


        //Bellow are a set of metadata values for all the models
        [Required]
        [ReadOnly(true)]
        [JsonIgnore]
        public bool IsDeleted { get; set; }

        [ReadOnly(true)]
        [JsonIgnore]
        public DateTime? DeletedDateTime { get; set; }

        [Required]
        [ReadOnly(true)]
        public DateTime CreatedDateTime { get; set; }

        [Required]
        [ReadOnly(true)]
        public DateTime UpdatedDateTime { get; set; }

        [Required]
        [ReadOnly(true)]
        public string CreatedBy { get; set; }

        [Required]
        [ReadOnly(true)]
        public string UpdatedBy { get; set; }
    }
    
}