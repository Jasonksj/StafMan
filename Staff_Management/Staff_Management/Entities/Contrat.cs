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
    using System.Security.Cryptography.X509Certificates;

    public partial class Contrat
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Contrat()
        {
            this.Missions = new HashSet<Mission>();
            this.Paiements = new HashSet<Paiement>();
        }

        public Contrat
            (
                int idEmployee,
                DateTime dateDebutContrat, 
                string titre, 
                string niveauHierachique,
                string type,
                float salaire,
                DateTime dateFin,
                int IdFonction
            )
        {
            this.Missions = new HashSet<Mission>();
            this.Paiements = new HashSet<Paiement>();
            IdEmployee = idEmployee;
            DateDebutContrat = dateDebutContrat;
            Titre = titre;
            NiveauHierachique = niveauHierachique;
            Type = type;
            Salaire = salaire;
            DateFin = dateFin;
            this.IdFonction = IdFonction;
        }

        public int IdEmployee { get; set; }
        public System.DateTime DateDebutContrat { get; set; }
        public string Titre { get; set; }
        public string NiveauHierachique { get; set; }
        public string Type { get; set; }
        public float Salaire { get; set; }
        public System.DateTime DateFin { get; set; }
        public int IdFonction { get; set; }
    
        public virtual Employee Employee { get; set; }
        public virtual Fonction Fonction { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Mission> Missions { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Paiement> Paiements { get; set; }
    }
}
