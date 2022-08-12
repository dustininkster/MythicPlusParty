using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MythicPlusParty
{
    public class Player
    {
        public Player (string name, bool istank, bool ishealer, bool isdps)
        {
            Name = name;
            IsTank = istank;
            IsHealer = ishealer;
            IsDPS = isdps;
        }
        public string Name { get; set; }
        //tanklist
        List<Character> _tankList = new List<Character>();
        public List<Character> TankList { get { return _tankList; } set { _tankList = value; } }
        //healerlist
        List<Character> _healerList = new List<Character>();
        public List<Character> HealerList { get { return _healerList; } set { _healerList = value; } }
        //dpslist
        List<Character> _dpsList = new List<Character>();
        public List<Character> DPSList { get { return _dpsList; } set { _dpsList = value; } }

        public bool IsTank { get; set; }
        public bool IsHealer { get; set; }
        public bool IsDPS { get; set; }
    }
}
