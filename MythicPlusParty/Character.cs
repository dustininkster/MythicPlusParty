using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MythicPlusParty
{
    public class Character
    {
        public Character (string name)
        {
            Name = name;
        }
        public string Name { get; set; }
        public bool IsTank { get; set; }
        public bool IsHealer { get; set; }
        public bool IsDPS { get; set; }
        
    }
}
