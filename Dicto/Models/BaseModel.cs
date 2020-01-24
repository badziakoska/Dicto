﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dicto.Models
{
    public abstract class BaseModel
    {
        public string Id { get; set; }
        
        public BaseModel()
        {
            this.Id = Guid.NewGuid().ToString();
           
        }
    }
}
