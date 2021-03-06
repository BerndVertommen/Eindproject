﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EindProjectBusinessModels
{
    public class Werknemer
    {
        private DateTime geboortedatum;
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [ScaffoldColumn(false)] // word niet opgevraagd in auto generated creates.
        public int PersoneelsNr { get; set; }

        [Required(ErrorMessage = "Je moet een naam opgegeven")]
        [DataType(DataType.Text)]
        public string Naam { get; set; }

        [Required(ErrorMessage = "Je moet een voornaam opgegeven")]
        [DataType(DataType.Text)]
        public string Voornaam { get; set; }

        [Required(ErrorMessage = "Je moet een email adres opgegeven")]
        [EmailAddress]
        public string Email { get; set; }

        [Required(ErrorMessage = "Je moet een geboortedatum opgegeven")]
        [DataType(DataType.Date)]
        //[DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime Geboortedatum { get; set; }


        [Required(ErrorMessage = "Je moet een adres opgegeven")]
        [DataType(DataType.Text)]
        public string Adres { get; set; }

        [Required(ErrorMessage = "Je moet een postcode opgegeven")]
        [DataType(DataType.PostalCode)]
        public string Postcode { get; set; }

        [Required(ErrorMessage = "Je moet een gemeente opgegeven")]
        [DataType(DataType.Text)]
        public string Gemeente { get; set; }

        [ScaffoldColumn(false)] // word niet opgevraagd in auto generated creates.
        //public Dictionary<int, int> VerlofDagenPerJaar { get; set; }
        public List<JaarlijksVerlof> JaarlijksVerlof { get; set; }
        [Required]

        [ScaffoldColumn(false)] // word niet opgevraagd in auto generated creates.
        [DataType(DataType.Text)]
        public virtual Team Team { get; set; }

        [ScaffoldColumn(false)] // word niet opgevraagd in auto generated creates.
        public List<VerlofAanvraag> Verlofaanvragen { get; set; }

        [Required]
        //[Range(typeof (bool),"true","false",ErrorMessage = "Het teamleader veld moet ingevuld worden." )]
        public bool TeamLeader { get; set; }

         [Required(ErrorMessage = "Je moet een gebruikersnaam opgegeven")]
        [DataType(DataType.Text)]
        public string UserName { get; set; }

        // [ScaffoldColumn(false)] // word niet opgevraagd in auto generated creates.
        [DataType(DataType.Password)]
        public string Paswoord { get; set; }

        [ScaffoldColumn(false)] // word niet opgevraagd in auto generated creates.
        public bool IsHr
        {
            get
            {
                if (this.Team == null) return false;
                return this.Team.Naam.ToUpper() == "HR";
                
            }
        }

        public Werknemer()
        {
            Verlofaanvragen = new List<VerlofAanvraag>();
            // VerlofDagenPerJaar = new Dictionary<int, int>();
            JaarlijksVerlof = new List<JaarlijksVerlof>();
            //Geboortedatum = DateTime.Today;
        }

        [NotMapped]
        [ScaffoldColumn(false)]
        public string VolledigeNaam
        {
            get { return String.Format("{0} {1}", Naam.ToUpper(), Voornaam); }
        }
    }
}