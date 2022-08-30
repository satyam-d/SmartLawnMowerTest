using System;
using System.ComponentModel.DataAnnotations;

namespace Models
{
    public class Lawn
    {
        public Lawn()
        {

        }
        public Lawn(int length,int width)
        {
            this.length = length;
            this.width = width;
        }
        [Range(0, int.MaxValue, ErrorMessage = "length cannot be negative")]
        public int length { get; set; }
        [Range(0, int.MaxValue, ErrorMessage = "Width cannot be negative")]
        public int width { get; set; }
    }
}
