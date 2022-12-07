//------------------------------------------------------------------------------
// <auto-generated>
//     Ce code a été généré à partir d'un modèle.
//
//     Des modifications manuelles apportées à ce fichier peuvent conduire à un comportement inattendu de votre application.
//     Les modifications manuelles apportées à ce fichier sont remplacées si le code est régénéré.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Staff_Management.Entities
{
    using System;
    using System.Collections.Generic;
    
    public partial class Conge
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Conge()
        {
            this.Paiements = new HashSet<Paiement>();
        }

        public Conge(DateTime dateDebut, DateTime dateFin, string justification)
        {
            this.Paiements = new HashSet<Paiement>();
            DateDebut = dateDebut;
            DateFin = dateFin;
            Justification = justification;
        }

        public int IdConges { get; set; }
        public System.DateTime DateDebut { get; set; }
        public System.DateTime DateFin { get; set; }
        public string Justification { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Paiement> Paiements { get; set; }
    }
}
