﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Web.Domain.Models;

namespace Web.Domain.Services.Communications
{
    public class TrainingTutorResponse : BaseResponse<TrainingTutor>
    {
        public TrainingTutorResponse(TrainingTutor resource) : base(resource)
        {
        }

        public TrainingTutorResponse(string message) : base(message)
        {
        }
    }
}