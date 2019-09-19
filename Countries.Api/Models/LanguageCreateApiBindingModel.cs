﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Countries.Api.Models
{
    public class LanguageCreateApiBindingModel
    {
        public string Iso639_1 { get; set; }
        public string Iso639_2 { get; set; }
        public string Name { get; set; }
        public string NativeName { get; set; }
    }
}
