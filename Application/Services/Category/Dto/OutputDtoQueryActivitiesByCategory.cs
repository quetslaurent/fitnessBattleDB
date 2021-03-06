﻿using System.Collections.Generic;
using Domain.Activity;

namespace Application.Services.Category.Dto
{
    public class OutputDtoQueryActivitiesByCategory
    {
        public int Id { get; set; } // le retour renvoie aussi l'id
        public string Name { get; set; }
        public IEnumerable<IActivity> Activities{ get;set;} // list d'activité ayant cette categorie
    }
}