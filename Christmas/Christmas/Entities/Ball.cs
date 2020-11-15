using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;
using Christmas.Abstractions;

namespace Christmas.Entities
{
    public class Ball : Toy
    {
        public SolidBrush BallColor { get; set; }
        public Ball(Color color)
        {
            BallColor = new SolidBrush(color);
        }

        protected override void DrawImage(Graphics g) //PROTECTED => ball osztály bármelyik leszármazottja használhatja 
        {
            g.FillEllipse(BallColor, 0, 0, Width, Height);
        }
        
    }   
}
