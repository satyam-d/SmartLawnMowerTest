using System;
using System.Collections.Generic;
using System.Text;

namespace Models
{
    public class SmartMower
    {
        public SmartMower()
        {

        }
        public SmartMower(Coordinates coordinate,Lawn lawnDimensions)
        {
            this.coordinate = coordinate;
            this.lawnDimensions = lawnDimensions;
        }
        public Coordinates coordinate { get; set; }
        public Lawn lawnDimensions { get; set; }
    }
}
