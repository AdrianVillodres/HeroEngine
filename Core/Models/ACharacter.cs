using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HeroEngine.Core.Models
{
    public abstract class ACharacter
    {
        public string Name { get; set; }
        public int MaxHP { get; set; }

        public ACharacter(string name)
        {
            Name = name;
            MaxHP = 100;
        }
    }
}
