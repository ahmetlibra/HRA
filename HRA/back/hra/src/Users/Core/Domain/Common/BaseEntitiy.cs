﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Common
{
    public abstract class BaseEntitiy : IEntity
    {
        public Guid Id { get; set; }

        public UserStatus UserStatus { get; set; } = UserStatus.Active; //default value will be waiting for approve

        public long CreatedDate { get; set; } = DateTime.Now.Ticks;

        public long? UpdatedDate { get; set; }

        public string? CreatedUserId { get; set; }

        public string? UpdatedUserId { get;set; }


    }
}
