﻿using System;

namespace LOGIC.Services.Models.Message
{
    public class Message_ResultSet
    {
        public Int64 message_id { get; set; }
        public String message_content { get; set; }
        public String message_status { get; set; }
        public String message_creation_date { get; set; }
        public String message_sent_date { get; set; }
        public String message_modified_date { get; set; }

    }
}