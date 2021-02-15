﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace IvorySaga.Api.DataTransferObjects
{
    public sealed class CreateSagaRequest
    {
        [Required]
        public string Author { get; set; }

        [Required]
        public string Title { get; set; }

        [Required]
        public string Content { get; set; }
    }
}
