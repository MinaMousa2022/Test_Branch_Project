namespace Branch_project.Models
{
    
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("files_Branch")]
    public partial class files_Branch
    {
        [Key]
        public int branchid { get; set; }

        [Required]
     
        [DisplayName("ÇÓã ÇáİÑÚ")]
        public string branchname { get; set; }

      
        [DisplayName("ÇÓã ÇáİÑÚ ÇäÌáíÒí")]
        public string branchename { get; set; }

        [DisplayName("ÇáÚãáÉ")]
        public short? currid { get; set; }

    
        [DisplayName("ÇáãÏíÑ")]
        public string manager { get; set; }

       
        [DisplayName("ÇáãÏíÑ ÇäÌáíÒí")]
        public string emanager { get; set; }

      
        [DisplayName("ÇáÚäæÇä")]
        public string address { get; set; }

      
        [DisplayName("ÇáÚäæÇä ÇäÌáíÒí")]
        public string eaddress { get; set; }


        [DisplayName("ÇáåÇÊİ 1")]
        public string tel1 { get; set; }

     
        [DisplayName("ÇáåÇÊİ 2")]
        public string tel2 { get; set; }

      
        [DisplayName("ÇáİÇßÓ")]
        public string fax { get; set; }

       
        [DisplayName("ÇáÈÑíÏ ÇáÇáßÊÑæäí")]
        public string email { get; set; }
        [DisplayName("ÇáÔÑßÉ")]
        public short? companyid { get; set; }

       
    }
}
