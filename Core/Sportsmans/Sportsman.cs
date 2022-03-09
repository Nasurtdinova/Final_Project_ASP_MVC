﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Core
{
    public class Sportsman : Sportsmans
    {
        public Sportsman () {}

        public Sportsman(string[] args)
        {
            Name = args[0];
            Surname = args[1];
            Title = args[2];
            Image = args[3];
            Height = Convert.ToInt32(args[4]);
            Cost = Convert.ToInt32(args[5]);
            Command = args[6];
        }

        public Sportsman(string[] args, int id)
        {
            ID = id;
            Name = args[1];
            Surname = args[2];
            Title = args[3];
            Image = args[4];
            Height = Convert.ToInt32(args[5]);
            Cost = Convert.ToInt32(args[6]);
            Command = args[7];
        }
    }
}
