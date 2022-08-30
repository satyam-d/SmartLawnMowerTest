using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Models;

namespace Services
{
    public class MowingService: IMowingService
    {        
        public Coordinates turnClockwise(SmartMower mowerObj)
        {
            mowerObj.coordinate.orientation= mowerObj.coordinate.orientation.RotateClockwise();
            Thread.Sleep(2); //Sleep for 5 seconds
            return mowerObj.coordinate;
        }
        public Coordinates turnAntiClockwise(SmartMower mowerObj)
        {
            mowerObj.coordinate.orientation = mowerObj.coordinate.orientation.RotateAntiClockwise();
            Thread.Sleep(2); //Sleep for 5 seconds
            return mowerObj.coordinate;
        }
        public Coordinates moveMower(SmartMower mowerObj)
        {
            if(!((mowerObj.coordinate.x==0 && mowerObj.coordinate.orientation==Orientation.West) ||(mowerObj.coordinate.x >= mowerObj.lawnDimensions.length && mowerObj.coordinate.orientation == Orientation.East)
                || (mowerObj.coordinate.y == 0 && mowerObj.coordinate.orientation == Orientation.South) || (mowerObj.coordinate.y >= mowerObj.lawnDimensions.width && mowerObj.coordinate.orientation == Orientation.North)))
            {
                switch (mowerObj.coordinate.orientation)
                {
                    case Orientation.East:
                        mowerObj.coordinate.x = mowerObj.coordinate.x + 1;
                        break;
                    case Orientation.West:
                        mowerObj.coordinate.x = mowerObj.coordinate.x - 1;
                        break;
                    case Orientation.North:
                        mowerObj.coordinate.y = mowerObj.coordinate.y + 1;
                        break;
                    case Orientation.South:
                        mowerObj.coordinate.y = mowerObj.coordinate.y - 1;
                        break;
                }
                Thread.Sleep(5); //Sleep for 5 seconds
                return mowerObj.coordinate;
            }
            return null;
            
        }
        public bool validateCoordinates(SmartMower mowerObj)
        {
            if (mowerObj.coordinate.x >= mowerObj.lawnDimensions.length || mowerObj.coordinate.y >= mowerObj.lawnDimensions.width)
                return false;
            return true;
        }
        
    }
}
