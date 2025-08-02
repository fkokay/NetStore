using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetStore.Domain.Common
{
    public interface IAuditable
    {
        /// <summary>
        /// Gets or sets the date and time of entity creation
        /// </summary>
        DateTime CreatedOnUtc { get; set; }

        /// <summary>
        /// Gets or sets the date and time of entity update
        /// </summary>
        DateTime UpdatedOnUtc { get; set; }
    }
}
