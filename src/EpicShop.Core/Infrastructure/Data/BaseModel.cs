using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace EpicShop.Core.Infrastructure.Data
{
    public class BaseModel
    {
        [Key]
        [ReadOnly(true)]
        public int Id { get; set; }


        //Bellow are a set of metadata values for all the models
        [Required]
        [ReadOnly(true)]
        public bool IsDeleted { get; set; }

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