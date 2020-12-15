﻿using System;

namespace Domain.TrainingDate
{
    public class TrainingDateFactory : ITrainingDateFactory
    {
        public ITrainingDate Create(int id, DateTime dateTime)
        {
            return new TrainingDate
            {
                Id=id,
                Date=dateTime
            };
        }

        //créer un trainingdate depuis une date
        public ITrainingDate CreateFromDateTime(DateTime dateTime)
        {
            return Create(0, dateTime);
        }
    }
}