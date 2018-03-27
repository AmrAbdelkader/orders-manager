using System;
using System.Collections.Generic;

namespace OrdersManager.Core.Domain
{
    /// <summary>
    /// Domain event record data
    /// </summary>
    public class DomainEventRecord
    {
        /// <summary>
        /// Gets or sets the type.
        /// </summary>
        public string Type { get; set; }
        /// <summary>
        /// Gets or sets the Args.
        /// </summary>
        public List<KeyValuePair<string, string>> Args { get; set; }
        /// <summary>
        /// Gets or sets the Created date.
        /// </summary>
        public DateTime Created { get; set; }
    }
}
