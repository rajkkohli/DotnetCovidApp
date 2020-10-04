using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Dot_myCovid19app.Models
{
    public class URL
    {
        public int ID { get; set; }
        public string CountryName { get; set; }
        public string CovidURL { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Display(Name = "Created Date")]
        public DateTime Createddate { get; set; }

        public virtual ICollection<URL> URLs { get; set; }
    }
}