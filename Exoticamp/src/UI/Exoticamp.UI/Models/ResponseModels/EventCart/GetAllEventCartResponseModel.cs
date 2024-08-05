﻿using Exoticamp.UI.Models.EventCart;
using Newtonsoft.Json;
using System.ComponentModel;

namespace Exoticamp.UI.Models.ResponseModels.EventCart
{
    public class GetAllEventCartResponseModel
    {
        [JsonProperty("succeeded")]
        [DefaultValue(false)]
        public bool Succeeded { get; set; }

        [JsonProperty("message")]
        public string Message { get; set; }

        [JsonProperty("errors")]
        public List<string> Errors { get; set; }

        [JsonProperty("data")]
        public IEnumerable<EventCartVM> Data { get; set; }
    }
}