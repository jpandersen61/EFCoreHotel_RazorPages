﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace EFCoreHotel_RazorPages.Models
{
    [Table("Hotel")]
    public partial class Hotel
    {
        public Hotel()
        {
            Rooms = new HashSet<Room>();
        }

        [Key]
        [Column("Hotel_No")]
        public int HotelNo { get; set; }
        [Required]
        [StringLength(30)]
        public string Name { get; set; }
        [Required]
        [StringLength(50)]
        public string Address { get; set; }

        [InverseProperty(nameof(Room.HotelNoNavigation))]
        public virtual ICollection<Room> Rooms { get; set; }
    }
}