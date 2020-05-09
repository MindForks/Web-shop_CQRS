using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace WS_Core.Domain.Dtos
{
    public class ManufacturerDto
    {
        [JsonProperty("title")]
        public string Title { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }
    }
}
