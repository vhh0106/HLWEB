namespace HLWEB.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
    using System.Web;

    [Table("OrderDetail")]
    public class OrderDetail
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public long ID { get; set; }
        public Order Order { get; set; }
        
        public long OrderID { get; set; }
        public long ProductID { get; set; }
        public decimal? Price { get; set; }
        public int Quantity { get; set; }
    }
}
