namespace gregsListSharp.Controllers;

    // private readonly CarsService carsService;

    // public CarsController(CarsService carsService)
    // {
    //     this.carsService = carsService;
    // }

[ApiController]
[Route("api/houses")]


public class HouseController : ControllerBase{
    private readonly HouseService houseService;
    public HouseController(HouseService houseService)
    {
        this.houseService = houseService;
    }
    [HttpGet]
    public ActionResult<List<House>> GetHouses(){
        try
        {
            List<House> house = houseService.GetHouses();
            return Ok(house);
        }
        catch (Exception error)
        {
            
            return BadRequest(error.Message);
        }
    }

    [HttpPost]
    public ActionResult<House> PostHouse([FromBody] House houseData){
        try
        {
            House house = houseService.PostHouse(houseData);
            return Ok(house);
        }
        catch (Exception error)
        {
            
            return BadRequest(error.Message);
        }
    }

    [HttpDelete("{houseId}")]
    public ActionResult<string> DeleteHouse(string houseId){
        try
        {
            string message = houseService.DeleteHouse(houseId);
            return Ok(message);
        }
        catch (Exception error)
        {
            
            return BadRequest(error.Message);
        }
    }

    [HttpGet("{houseId}")]
    public ActionResult<House> GetHouseById(string houseId){
        try
        {
            House house = houseService.GetHouseById(houseId);
            return Ok(house);
        }
        catch (Exception error)
        {
            
            return BadRequest(error.Message);
        }
    }
}