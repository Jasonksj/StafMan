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
    
    public partial class Employee
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Employee()
        {
            this.Contrats = new HashSet<Contrat>();
            this.Departements = new HashSet<Departement>();
            this.Employees1 = new HashSet<Employee>();
            this.Missions = new HashSet<Mission>();
        }
    
        public int Id { get; set; }
        public string Nom { get; set; }
        public string Email { get; set; }
        public byte[] Picture { get; set; }
        public string Adresse { get; set; }
        public string Telephone { get; set; }
        public System.DateTime DateEmbauche { get; set; }
        public int IdDept { get; set; }
        public Nullable<int> IdManager { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Contrat> Contrats { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Departement> Departements { get; set; }
        public virtual Departement Departement { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Employee> Employees1 { get; set; }
        public virtual Employee Employee1 { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Mission> Missions { get; set; }
        public virtual Utilisateur Utilisateur { get; set; }
    }
}
