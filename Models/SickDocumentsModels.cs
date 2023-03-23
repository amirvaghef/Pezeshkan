using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Pezeshkan.Models
{
    [Table("Special")]
    public class Special2
    {
        [Key, Column(Order=1)]
        [Display(Name = "Date")]
        public string Date { get; set; }

        [Key, Column(Order=2)]
        [Display(Name = "Document NO")]
        public long pcode { get; set; }

        [Key, Column(Order = 3)]
        public string userId { get; set; }

        [StringLength(500)]
        [Display(Name = "CC")]
        public string cc { get; set; }

        [Display(Name = "FMH")]
        public string fmh { get; set; }

        [Display(Name = "PMH")]
        public string pmh { get; set; }

        [Display(Name = "PSH")]
        public string psh { get; set; }

        //Present Glasses
        [Display(Name = "OD")]
        public string pdod { get; set; }

        //Present Glasses
        [Display(Name = "OS")]
        public string pdos { get; set; }

        //Visual Acuity
        [Display(Name = "APD")]
        public string apd_os { get; set; }

        //Contact Lens
        [Display(Name = "PD")]
        public string apd_od { get; set; }

        //External Exam
        [Display(Name = "OD")]
        public string pupils { get; set; }

        //External Exam
        [Display(Name = "OS")]
        public string pupilsOS { get; set; }

        //IOP
        [Display(Name = "OD")]
        public string iop_od { get; set; }

        //IOP
        [Display(Name = "OS")]
        public string iop_os { get; set; }

        //Still Lamp Exam Cornea
        [Display(Name = "OD")]
        public string Cornea_od { get; set; }

        //Still Lamp Exam AC
        [Display(Name = "OD")]
        public string ac_od { get; set; }

        //Still Lamp Exam Lens
        [Display(Name = "OD")]
        public string lens_od { get; set; }

        //ADD
        [Display(Name = "OD")]
        public string drops1_od { get; set; }

        //ADD
        [Display(Name = "OS")]
        public string drops1_os { get; set; }

        //CYCLO
        [Display(Name = "OD")]
        public string cyclo1_od { get; set; }

        //CYCLO
        [Display(Name = "OS")]
        public string cyclo1_os { get; set; }
        public string nearaddOd { get; set; }
        public string nearaddOs { get; set; }
        public string Near2 { get; set; }
        public string Ref2 { get; set; }

        //Assess
        [Display(Name = "Diag")]
        public string diag { get; set; }

        //Plan
        [Display(Name = "Plan")]
        public string plan { get; set; }

        [Display(Name = "Comment")]
        public string disc1 { get; set; }
        public string disc2 { get; set; }

        [Display(Name = "Medi1")]
        public string medi1 { get; set; }

        [Display(Name = "Medi2")]
        public string medi2 { get; set; }

        [Display(Name = "Medi3")]
        public string medi3 { get; set; }

        [Display(Name = "Medi4")]
        public string medi4 { get; set; }

        //Funduscopy / Cup
        [Display(Name = "OD")]
        public string disc { get; set; }

        //Funduscopy / Color
        [Display(Name = "OD")]
        public string color_od { get; set; }

        //Funduscopy / Margin
        [Display(Name = "OD")]
        public string margin_od { get; set; }

        //Funduscopy / Cup
        [Display(Name = "OS")]
        public string disc_os { get; set; }

        //Funduscopy / Color
        [Display(Name = "OS")]
        public string color_os { get; set; }

        //Funduscopy / Margin
        [Display(Name = "OS")]
        public string margin_os { get; set; }

        //Still Lamp Exam Cornea
        [Display(Name = "OS")]
        public string Cornea_os { get; set; }

        //Still Lamp Exam AC
        [Display(Name = "OS")]
        public string ac_os { get; set; }

        //Still Lamp Exam Lens
        [Display(Name = "OS")]
        public string lens_os { get; set; }
        public string disc_od { get; set; }

        //Visual Acuity / Without Glass
        [Display(Name = "OD")]
        public string visualod { get; set; }

        //Visual Acuity / Without Glass
        [Display(Name = "OS")]
        public string visualos { get; set; }

        //Plan
        [Display(Name = "Plan2")]
        public string plan2 { get; set; }

        //Plan
        [Display(Name = "Plan3")]
        public string plan3 { get; set; }

        //Assess
        [Display(Name = "Diag2")]
        public string diag2 { get; set; }

        //Assess
        [Display(Name = "Diag3")]
        public string diag3 { get; set; }

        [Display(Name = "Next Date")]
        public string date2 { get; set; }
        
        [Display(Name = "NPD")]
        public string npd { get; set; }

        [Display(Name = "Lid Margin")]
        public string Slit { get; set; }

        [Display(Name = "Conj")]
        public string Conj { get; set; }

        //Still Lamp Exam Angle
        [Display(Name = "OD")]
        public string angleod { get; set; }

        //Still Lamp Exam Angle
        [Display(Name = "OS")]
        public string angleos { get; set; }

        //Macula
        [Display(Name = "Macula1")]
        public string macula1 { get; set; }

        //Macula
        [Display(Name = "Macula2")]
        public string macula2 { get; set; }

        //Macula
        [Display(Name = "Macula3")]
        public string macula3 { get; set; }

        //Funduscopy / Vessels
        [Display(Name = "OS")]
        public string vesselsos { get; set; }

        //Funduscopy / Vessels
        [Display(Name = "OD")]
        public string vesselsod { get; set; }

        //Funduscopy / Periphery
        [Display(Name = "OD")]
        public string peripheryod { get; set; }

        //Funduscopy / Periphery
        [Display(Name = "OS")]
        public string peripheryos { get; set; }

        //Visual Acuity / With Glass
        [Display(Name = "OD")]
        public string visualglassod { get; set; }

        //Visual Acuity / Without Glass
        [Display(Name = "OS")]
        public string visualglassos { get; set; }

        //BCVA / {dropdown}
        [Display(Name = "OD")]
        public string BCVAOd1 { get; set; }
        public string BCVAOd2 { get; set; }

        //BCVA
        [Display(Name = "OD")]
        public string BCVAOd3 { get; set; }

        //BCVA / {dropdown}
        [Display(Name = "OS")]
        public string BCVAOs1 { get; set; }
        public string BCVAOs2 { get; set; }

        //BCVA
        [Display(Name = "OS")]
        public string BCVAOs3 { get; set; }
        public string Addod { get; set; }
        public string Addos { get; set; }

        //Present Near Glass
        [Display(Name = "OD")]
        public string PresentNGOd { get; set; }

        //Present Near Glass
        [Display(Name = "OS")]
        public string PresentNGOs { get; set; }
        public string nearaddod2 { get; set; }
        public string nearaddod3 { get; set; }
        public string nearaddos2 { get; set; }
        public string nearaddos3 { get; set; }

        //Contact Lens
        [Display(Name = "OS")]
        public string lenskindos { get; set; }

        //Contact Lens
        [Display(Name = "OD")]
        public string lenskindod { get; set; }

        //Assess
        [Display(Name = "Diag4")]
        public string diag4 { get; set; }
        public string diag5 { get; set; }
        public string diag6 { get; set; }

        //Plan
        [Display(Name = "Plan4")]
        public string plan4 { get; set; }
        public string plan5 { get; set; }
        public string plan6 { get; set; }
        public string BCVAOdcolor { get; set; }
        public string BCVAOscolor { get; set; }
        public string Tonopenos { get; set; }
        public string Tonopenod { get; set; }
        public string discopt { get; set; }
        public string pakod { get; set; }
        public string pakos { get; set; }

        //Deviation
        [Display(Name = "OD")]
        public string deviationod1 { get; set; }

        //Deviation
        [Display(Name = "OS")]
        public string deviationos1 { get; set; }

        [Display(Name = "Contact Lens")]
        public string lenskind { get; set; }
    }

    [Table("sick_info")]
    public class SickInfo
    {
        [Key, Column(Order = 1)]
        [Display(Name = "Document NO")]
        public int pcode { get; set; }

        [Key, Column(Order = 2)]
        public string userId { get; set; }

        [Required]
        [Display(Name = "Name")]
        public string fname { get; set; }

        [Required]
        [Display(Name = "Family")]
        public string lname { get; set; }

        [Display(Name = "Birth Year")]
        public string byear { get; set; }

        [Required]
        [Display(Name = "Father Name")]
        public string fathername { get; set; }

        [Display(Name = "Address")]
        public string address { get; set; }

        [Display(Name = "Telphone")]
        public string tel { get; set; }

        [Required]
        [Display(Name = "Married")]
        public string married { get; set; }

        [Required]
        [Display(Name = "Child/s")]
        public short? childs { get; set; }

        [Display(Name = "Job")]
        public string job { get; set; }

        [Display(Name = "Introducer")]
        public string moareffrom { get; set; }
    }

    [Table("desease")]
    public class Desease {

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int kind_of_desease { get; set; }

        public string desease_name { get; set; }

        public string desease_groop { get; set; }
    }

    [Table("complate")]
    public class Complate
    {
        [Key]
        public int kind_of_complate { get; set; }

        public string complate { get; set; }
    }
}