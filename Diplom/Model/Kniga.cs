//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Diplom.Model
{
    using System;
    using System.Collections.Generic;
    
    public partial class Kniga
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Kniga()
        {
            this.Zacaz = new HashSet<Zacaz>();
        }
    
        public int IdK { get; set; }
        public string NameK { get; set; }
        public string Avtor { get; set; }
        public string Polka { get; set; }
        public string Opisan { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Zacaz> Zacaz { get; set; }
    }
}
