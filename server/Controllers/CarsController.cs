namespace gregsListSharp.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CarsController : ControllerBase
{
    private readonly CarsService carsService;

    public CarsController(CarsService carsService)
    {
        this.carsService = carsService;
    }

    [HttpGet]
    public ActionResult<List<Car>> GetAllCars(){
      try
      {
        List<Car> cars  = carsService.GetAllCars();
        return Ok(cars);
      }
      catch (Exception error)
      {
        return BadRequest(error.Message);
      }
    }

    [HttpGet("{carId}")]
    public ActionResult<Car> GetCarById(int carId){
      try
      {
        Car car = carsService.GetCarById(carId);
        return Ok(car);
      }
     catch (Exception error)
      {
        return BadRequest(error.Message);
      }
    }

    [HttpPost]
    public ActionResult<Car> CreateCar([FromBody] Car carData){
      try
      {
        Car car = carsService.CreateCar(carData);
        return Ok(car);
      }
     catch (Exception error)
      {
        return BadRequest(error.Message);
      }
    }

    [HttpDelete("{carId}")]
    public ActionResult<string> RemoveCar(int carId)
    {
      try
      {
        string message = carsService.RemoveCar(carId);
        return Ok(message);
      }
     catch (Exception error)
      {
        return BadRequest(error.Message);
      }
    }

    [HttpPut("{carId}")]
    public ActionResult<Car> UpdateCar([FromBody] Car updateData, int carId)
    {
      try
      {
        updateData.Id = carId;
        Car update = carsService.UpdateCar(updateData);
        return Ok(update);
      }
        catch (Exception error)
      {
        return BadRequest(error.Message);
      }
    }


}
