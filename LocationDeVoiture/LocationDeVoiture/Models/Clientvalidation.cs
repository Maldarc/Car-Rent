using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace LocationDeVoiture.Models
{

    [MetadataType(typeof(clientMetaData))]
    public partial class client
    {
        public class clientMetaData
        {
            [DisplayName("Nom")]
            public string nom { get; set; }

            [DisplayName("Prénom")]
            public string prenom { get; set; }

            [DisplayName("Téléphone")]
            public Nullable<int> telephone { get; set; }
        }
    }
}