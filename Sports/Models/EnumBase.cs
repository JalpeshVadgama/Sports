using Sports.Extensions;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace Sports.Models
{
    public class EnumBase<TEnum> where TEnum : struct
    {
        protected EnumBase() { } //for EF

        protected EnumBase(TEnum @enum)
        {
            id = (int)(ValueType)@enum;
            name = @enum.ToString();
            descritpion = @enum.GetEnumDescription();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public virtual int id { get; set; }

        [Required]
        [MaxLength(100)]
        public virtual string name { get; set; }

        [MaxLength(100)]
        public virtual string descritpion { get; set; }

        public static string[] descriptionArry = GetDescriptionArray();

        private static string[] GetDescriptionArray()
        {
            List<string> retList = new List<string>();
            Enum.GetValues(typeof(TEnum)).Cast<object>().ToList().ForEach(v => retList.Add(v.GetEnumDescription()));
            return retList.ToArray();
        }
    }
}
