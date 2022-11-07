﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokemonAccedo.Dtos
{
    public class ResponseDto<T> where T : class
    { 
        public bool IsSuccess { get; set; }
        public string Message{ get; set; }
        public string Exception { get; set; }
        public T Data { get; set; }
    }
}
