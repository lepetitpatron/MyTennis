﻿namespace MyTennis.Core.DTO
{
    public class LeagueDTO
    {
        public byte Id { get; set; }
        public string Name { get; set; }

        public override string ToString()
        {
            return Name;
        }
    }
}
