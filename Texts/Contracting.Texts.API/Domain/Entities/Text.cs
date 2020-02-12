using System;
using System.Collections.Generic;

namespace Texts.API.Domain.Entities
{
    public partial class Text
    {
        public Guid TextId { get; set; }
        public string Language { get; set; }
        public string Branch { get; set; }
        public string Area { get; set; }
        public string Key { get; set; }
        public string Value { get; set; }
    }
}
