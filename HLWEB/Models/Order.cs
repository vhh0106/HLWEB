namespace HLWEB.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
    using System.Web;

    [Table("Order")]
    public partial class Order
    {
        public long OrderID { get; set; }
        public DateTime? CreatedDate { get; set; }
        public long CustomerID { get; set; }
        [StringLength(250)]
        public string ShipName { get; set; }
        [StringLength(250)]
        public string ShipMobile { get; set; }
        [StringLength(250)]
        public string ShipAddress { get; set; }
        [StringLength(250)]
        public string ShipEmail { get; set; }
        public int Status { get; set; }
    }
}




