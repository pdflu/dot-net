﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Entities
{
    public class Reply
    {
        public Int64 ReplyID { get; set; } //(PK)
        public String Reply_Content { get; set; }
        public String Reply_Status { get; set; }
    }
}
