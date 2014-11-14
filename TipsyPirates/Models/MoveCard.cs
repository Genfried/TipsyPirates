using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TipsyPirates.Models
{
    public class MoveCard : Card
    {    
        public MoveCard()
        {
            _Commands = new List<Enums.CommandType>() { Enums.CommandType.Move };
        }
    }
}