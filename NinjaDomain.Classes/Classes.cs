﻿using NinjaDomain.Classes.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace NinjaDomain.Classes
{
        

    public class Ninja : IModificationHistory
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool ServedInOniwaban { get; set; }
        public Clan Clan { get; set; }

        public int ClanId { get; set; }

        public List<NinjaEquipment> EquipmentOwned { get; set; }

        public System.DateTime DateOfBirth { get; set; }

        public DateTime DateCreated { get; set; }

        public DateTime DateModified { get; set; }

        public bool isDirty { get; set; }

        public Ninja()
        {
            EquipmentOwned = new List<NinjaEquipment>();
        }
    }
    public class Clan  : IModificationHistory
    {
        public int Id { get; set; }
        public string ClanName { get; set; }
        public List<Ninja> Ninjas { get; set; }

        public DateTime DateCreated { get; set; }

        public DateTime DateModified { get; set; }

        public bool isDirty { get; set; }

        public Clan()
        {
            Ninjas = new List<Ninja>();
        }
    }

    public class NinjaEquipment : IModificationHistory
{
        public int Id { get; set; }
        public string Name { get; set; }
        public EquipmentType Type { get; set; }

        public DateTime DateCreated { get; set; }

        public DateTime DateModified { get; set; }

        public bool isDirty { get; set; }

        [Required]
        public Ninja Ninja { get; set; }
    }
}
