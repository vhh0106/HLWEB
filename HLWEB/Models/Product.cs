namespace Model.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
    using System.Web;

    [Table("Product")]
    public partial class Product
    {
        public long id { get; set; }

        [StringLength(250)]
        [DisplayName("Thẻ tiêu đề")]
        public string metaTitle { get; set; }

        [StringLength(250)]
        [DisplayName("Tên sản phẩm")]
        public string name { get; set; }

        [StringLength(255)]
        [DisplayName("CPU")]
        public string Cpu { get; set; }

        [StringLength(255)]
        [DisplayName("RAM")]
        public string ram { get; set; }

        [DisplayName("Ổ cứng")]
        [StringLength(255)]
        public string ocung { get; set; }

        [StringLength(255)]
        [DisplayName("Card đồ họa")]
        public string carđohoa { get; set; }

        [StringLength(255)]
        [DisplayName("Màn hình")]
        public string manhinh { get; set; }

        [DisplayName("Hệ điều hành")]
        [StringLength(255)]
        public string hedieuhanh { get; set; }

        [StringLength(255)]
        [DisplayName("Pin")]
        public string pin { get; set; }


        [StringLength(255)]
        [DisplayName("Trọng lượng")]
        public string trongluong { get; set; }

        [StringLength(255)]
        [DisplayName("Bảo hành")]
        public string baohanh { get; set; }

        [StringLength(5000)]
        [DisplayName("Mô tả")]
        public string mota { get; set; }

        [StringLength(250)]
        [DisplayName("Hình ảnh")]
        public string image { get; set; }
        [NotMapped]
        public HttpPostedFileBase imageFile { get; set; }

        [DisplayName("Giá")]
        public decimal? price { get; set; }

        [DisplayName("Giá đã giảm")]
        public decimal? promotionPrice { get; set; }

        [DisplayName("ID danh mục sản phẩm")]
        public long? categoryID { get; set; }

        [StringLength(250)]
        public string metaKeywords { get; set; }

        [StringLength(250)]
        public string metaDescription { get; set; }
        [DisplayName("Trạng thái")]
        public bool? status { get; set; }
        [DisplayName("Sản phẩm nổi bật, nhập vào(ngày/tháng/năm) sản phẩm được gỡ xuống")]
        public DateTime? topHot { get; set; }
    }
}
