using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace LocationDeVoiture.Models
{

    [MetadataType(typeof(voitureMetaData))]
    public partial class voiture
    {
        

        public class voitureMetaData
        {
            [DisplayName("Matricule")]
            public string matricule { get; set; }

            [DisplayName("Marque")]
            public string marque { get; set; }

            [DisplayName("Modèle")]
            public string modele { get; set; }

            [DisplayName("Disponible")]
            public string disponible { get; set; }
        }
    }
}