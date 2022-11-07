﻿using Core.Common.Data;
using System;
namespace Core.Business.Entites.DataModels
{
    [Alias(Name = "Hospital")]
    public class Hospital
    {
        public Hospital() { }
        [Key(AutoNumber = true)]
        public int Id { get; set; }
        public int CountryId { get; set; }
        public int CityId { get; set; }
        public string Title { get; set; }
        public string Details { get; set; }
        public int LanguageId { get; set; }
        public string Address { get; set; }
        public string BedCount { get; set; }

    }
}
