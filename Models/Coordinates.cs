using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Models
{
    public class Coordinates
    {
        public Coordinates()
        {

        }
        public Coordinates(int x,int y, Orientation orientation)
        {
            this.x = x;
            this.y = y;
            this.orientation = orientation;
        }
        [Range(0,int.MaxValue,ErrorMessage ="y cannot be negative")]
        public int y { get; set; }
        [Range(0, int.MaxValue, ErrorMessage = "x cannot be negative")]
        public int x { get; set; }
        public Orientation orientation { get; set; }

    }
    public enum Orientation
    {
        North,
        East,
        South,        
        West
    }
}
