using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Models;
using Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SmartLawnMower.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class LawnMowerController : ControllerBase
    {
        readonly IMowingService _mowingService;
        //private readonly ILogger<LawnMowerController> _logger;

        public LawnMowerController(IMowingService mowingService)
        {
            //this._logger = logger;
            this._mowingService = mowingService;
        }               

        [HttpPost("TurnClockwise")]        
        public IActionResult TurnClockwise([FromBody] SmartMower mowerObj)
        {
            if (!ModelState.IsValid || !Enum.IsDefined(typeof(Orientation), mowerObj.coordinate.orientation))
                return BadRequest("Invalid dimensions or coordinates");

            //if (mowerObj.lawnDimensions.length < 0 || mowerObj.lawnDimensions.width < 0)
            //    return BadRequest("Invalid dimensions");
            Coordinates coordinate;
            try
            {
                coordinate = _mowingService.turnClockwise(mowerObj);
                return Ok(coordinate);
            }
            catch (Exception ex)
            {
                return BadRequest();
            }
            
        }

        [HttpPost("TurnAntiClockwise")]
        public IActionResult TurnAntiClockwise([FromBody] SmartMower mowerObj)
        {
            
            if (!ModelState.IsValid || !Enum.IsDefined(typeof(Orientation), mowerObj.coordinate.orientation))
                return BadRequest("Invalid dimensions or coordinates");
            

            Coordinates coordinate;
            try
            {
                coordinate = _mowingService.turnAntiClockwise(mowerObj);
                return Ok(coordinate);
            }
            catch (Exception ex)
            {
                return BadRequest();
            }

        }
        [HttpPost("MoveMower")]
        public IActionResult MoveMower([FromBody] SmartMower mowerObj)
        {

            if (!ModelState.IsValid || !Enum.IsDefined(typeof(Orientation), mowerObj.coordinate.orientation))
                return BadRequest("Invalid dimensions or coordinates");

            if (!_mowingService.validateCoordinates(mowerObj))
                return BadRequest("Mower outside lawn");
            //if (mowerObj.lawnDimensions.length < 0 || mowerObj.lawnDimensions.width < 0)
            //    return BadRequest("Invalid dimensions");
            Coordinates coordinate;
            try
            {
                coordinate = _mowingService.moveMower(mowerObj);
                if (coordinate != null)
                    return Ok(coordinate);
                else
                    return BadRequest("Cannot move mower");
            }
            catch (Exception ex)
            {
                throw new Exception("Cannot move mower");
            }

        }
    }
}
