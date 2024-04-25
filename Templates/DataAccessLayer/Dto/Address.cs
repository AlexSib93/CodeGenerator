using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer.Dto
{
    /// <summary>
    /// Справочник адресов
    /// </summary>
    public partial class address
    {
        public address()
        {
            customeraddress = new HashSet<customeraddress>();
            customeridaddressNavigation = new HashSet<customer>();
            customeridaddresslegalNavigation = new HashSet<customer>();
            delivdoc = new HashSet<delivdoc>();
            installdoc = new HashSet<installdoc>();
            orders = new HashSet<orders>();
            servicedoc = new HashSet<servicedoc>();
            sizedoc = new HashSet<sizedoc>();
        }

        /// <summary>
        /// Первичный ключ
        /// </summary>
        [Key]
        public int idaddress { get; set; }
        /// <summary>
        /// Ссылка на регион
        /// </summary>
        public int? idaddregion { get; set; }
        /// <summary>
        /// Ссылка на край/область
        /// </summary>
        public int? idaddarea { get; set; }
        /// <summary>
        /// Ссылка на город
        /// </summary>
        public int? idaddcity { get; set; }
        /// <summary>
        /// Ссылка на район города
        /// </summary>
        public int? idaddcityregion { get; set; }
        /// <summary>
        /// Ссылка на улицу
        /// </summary>
        public int? idaddstreet { get; set; }
        public int? idaddbuild { get; set; }
        /// <summary>
        /// № дома
        /// </summary>
        public int? build { get; set; }
        /// <summary>
        /// Корпус, строение, индекс...
        /// </summary>
        [StringLength(64)]
        [Unicode(false)]
        public string? building { get; set; }
        /// <summary>
        /// Подъезд
        /// </summary>
        public int? doorway { get; set; }
        /// <summary>
        /// Квартира
        /// </summary>
        public int? apartment { get; set; }
        /// <summary>
        /// Этаж
        /// </summary>
        public int? floor { get; set; }
        /// <summary>
        /// Дополнительная информация
        /// </summary>
        [StringLength(512)]
        [Unicode(false)]
        public string? addinfo { get; set; }
        /// <summary>
        /// Наличие грузового лифта
        /// </summary>
        public bool? freightlift { get; set; }
        /// <summary>
        /// Наличие пассажирского лифта
        /// </summary>
        public bool? passengerlift { get; set; }
        /// <summary>
        /// Признак удалённости
        /// </summary>
        [Column(TypeName = "datetime")]
        public DateTime? deleted { get; set; }
        [StringLength(50)]
        [Unicode(false)]
        public string? speakerphone { get; set; }
        public Guid guid { get; set; }
        public int? postindex { get; set; }
        [StringLength(64)]
        [Unicode(false)]
        public string? build_str { get; set; }

        [InverseProperty("idaddressNavigation")]
        public virtual ICollection<customeraddress> customeraddress { get; set; }
        [InverseProperty("idaddressNavigation")]
        public virtual ICollection<customer> customeridaddressNavigation { get; set; }
        [InverseProperty("idaddresslegalNavigation")]
        public virtual ICollection<customer> customeridaddresslegalNavigation { get; set; }
        [InverseProperty("idaddressNavigation")]
        public virtual ICollection<delivdoc> delivdoc { get; set; }
        [InverseProperty("idaddressNavigation")]
        public virtual ICollection<installdoc> installdoc { get; set; }
        [InverseProperty("idaddressNavigation")]
        public virtual ICollection<orders> orders { get; set; }
        [InverseProperty("idaddressNavigation")]
        public virtual ICollection<servicedoc> servicedoc { get; set; }
        [InverseProperty("idaddressNavigation")]
        public virtual ICollection<sizedoc> sizedoc { get; set; }
    }
}
