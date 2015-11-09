using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Newtonsoft.Json;

namespace Cofficient.Configuration
{
    /// <summary>
    /// Config节点
    /// </summary>
    public class Config
    {
        /// <summary>
        /// Coefficient集合
        /// </summary>
        [JsonProperty(PropertyName = "coefficient")]
        public Coefficient[] Coefficient { get; set; }
    }
}
