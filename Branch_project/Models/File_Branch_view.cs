using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Branch_project.Models
{
    public class File_Branch_view
    {

        [Key]
        public int branchid { get; set; }

        [Required]

        [DisplayName("اسم الفرع")]
        public string branchname { get; set; }


        [DisplayName("اسم الفرع انجليزي")]
        public string branchename { get; set; }

        [DisplayName("العملة")]
        public short? currid { get; set; }


        [DisplayName("المدير")]
        public string manager { get; set; }


        [DisplayName("المدير انجليزي")]
        public string emanager { get; set; }


        [DisplayName("العنوان")]
        public string address { get; set; }


        [DisplayName("العنوان انجليزي")]
        public string eaddress { get; set; }


        [DisplayName("الهاتف 1")]
        public string tel1 { get; set; }


        [DisplayName("الهاتف 2")]
        public string tel2 { get; set; }


        [DisplayName("الفاكس")]
        public string fax { get; set; }


        [DisplayName("البريد الالكتروني")]
        public string email { get; set; }
        [DisplayName("الشركة")]
        public string currname { get; set; }



    }
}
