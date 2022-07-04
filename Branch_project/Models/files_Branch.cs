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
     
        [DisplayName("��� �����")]
        public string branchname { get; set; }

      
        [DisplayName("��� ����� �������")]
        public string branchename { get; set; }

        [DisplayName("������")]
        public short? currid { get; set; }

    
        [DisplayName("������")]
        public string manager { get; set; }

       
        [DisplayName("������ �������")]
        public string emanager { get; set; }

      
        [DisplayName("�������")]
        public string address { get; set; }

      
        [DisplayName("������� �������")]
        public string eaddress { get; set; }


        [DisplayName("������ 1")]
        public string tel1 { get; set; }

     
        [DisplayName("������ 2")]
        public string tel2 { get; set; }

      
        [DisplayName("������")]
        public string fax { get; set; }

       
        [DisplayName("������ ����������")]
        public string email { get; set; }
        [DisplayName("������")]
        public short? companyid { get; set; }

       
    }
}
