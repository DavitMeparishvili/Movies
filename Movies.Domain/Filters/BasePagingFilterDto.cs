using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Movies.Domain.Filters
{
    public abstract class BasePagingFilterDto
    {
        public int? Offset { get; set; }

        public int? Limit { get; set; }

        public int? Skip => Offset.HasValue && Limit.HasValue
            ? Offset * Limit
            : null;
    }
}
