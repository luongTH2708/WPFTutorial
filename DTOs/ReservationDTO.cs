﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPFTutorial.DTOs
{
    public class ReservationDTO
    {
        [Key]
        public Guid ID { get; set; }
        public int RoomNumber { get; set; }
        public int FloorNumber { get; set; }
        public string Username { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
    }
}
