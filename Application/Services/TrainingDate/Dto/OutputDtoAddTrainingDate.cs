﻿using System;

namespace Application.Services.TrainingDate.Dto
{
    public class OutputDtoAddTrainingDate
    {
        public int Id { get; set; } // le retour renvoie aussi l'id
        public DateTime Date { get; set; }
    }
}