using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace AniDB.Domain.Infrastructure
{
    public interface IEntity
    {
        Guid Id { get; }
    }
}
