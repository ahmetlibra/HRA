using Core.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entities.Abstract
{
    public class BaseEntitiy<T> : IEntity
    {
        public T Id { get; set; }

        public Guid TenantId { get; set; }

        public EntityStatus EntitiyStatus { get; set; } = EntityStatus.Pending; 

        public DateTimeOffset CreatedDate { get; set; } = DateTimeOffset.UtcNow; // Ticks yerine DateTimeOffset kullanmak daha standart ve zaman dilimi (timezone) sorunlarını çözer.
        public DateTimeOffset? UpdatedDate { get; set; }

        public T? CreatedUserId { get; set; }

        public T? UpdatedUserId { get; set; }
    }
}
