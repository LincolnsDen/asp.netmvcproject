using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace SampleMVCProject.Models
{
    public class Season
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public virtual ICollection<Fruit> Fruits { get; set; }
        public virtual ICollection<Vegetable> Vegetables { get; set; }
    }

    public class Fruit
    {
        [Required]
        public int ID { get; set; }
        public string Name { get; set; }
        public bool IsNew { get; set; }
        [Required]
        public DateTime PurchaseDate { get; set; }
        [Required]
        public string Image { get; set; }

        [ForeignKey("Season")]
        public int SeasonID { get; set; }

        public virtual Season Season { get; set; }

        public virtual FruitSupplier FruitSuppliers { get; set; }
    }

    public class Vegetable
    {
        [Required]
        public int ID { get; set; }
        [Display(Name="Vegetabe Name")]
        [StringLength(20,ErrorMessage ="enter within 20 charecter")]
        public string Name { get; set; }
        public bool IsAvailable { get; set; }
        
        [Required]
        public string Image { get; set; }

        [ForeignKey("Season")]
        public int SeasonID { get; set; }

        public virtual Season Season { get; set; }
    }

    public class FruitSupplier
    {
        [Required]
        public int ID { get; set; }
        public string Name { get; set; }
                
        [ForeignKey("Fruit")]
        public int FruitID { get; set; }

        public virtual List<Fruit> Fruit { get; set; }
    }
}