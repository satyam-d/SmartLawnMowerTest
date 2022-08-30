using Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Services
{
    public interface IMowingService
    {
        Coordinates turnClockwise(SmartMower mowerObj);
        Coordinates turnAntiClockwise(SmartMower mowerObj);
        Coordinates moveMower(SmartMower mowerObj);
        bool validateCoordinates(SmartMower mowerObj);
    }
}
