using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TipsyPirates.Models
{
    public abstract class Card
    {
        public List<Enums.CommandType> Commands { get { return _Commands; } }
        protected List<Enums.CommandType> _Commands { set; get; }

        public void Play(Ship ship) 
        {
            foreach(Enums.CommandType command in Commands)
            {
                if (command == Enums.CommandType.Move)
                {
                    ship.Sail();
                }
                else if(command == Enums.CommandType.TurnRight)
                {
                    ship.TurnStarboard();
                }
                else if(command == Enums.CommandType.TurnLeft)
                {
                    ship.TurnPort();
                }
                else
                {
                    ship.SailBackwards();
                }

                ship.EndPhase();
            }
        }
    }
}
