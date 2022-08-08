using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LocationDeVoiture.Models
{
    public class LocationViewModel
    {
        public Nullable<int> idclient { get; set; }
        public Nullable<int> prix { get; set; }
        public Nullable<System.DateTime> date_debut { get; set; }
        public Nullable<System.DateTime> date_fin { get; set; }
        public int idlocation { get; set; }
        public string matricule { get; set; }
        public string disponible { get; set; }
    }
}