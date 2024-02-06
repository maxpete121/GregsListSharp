




namespace gregsListSharp.Repositories;


public class CarsRepository(IDbConnection db)
{
  private readonly IDbConnection db = db;

    internal Car CreateCar(Car carData)
    {
      string sql = @"
      INSERT INTO cars
      (make, model, year, price, imgUrl, color, description)
      VALUES
      (@make, @model, @year, @price, @imgUrl, @color, @description);
      
      SELECT
      *
      FROM cars
      WHERE id = LAST_INSERT_ID();
      ";
      Car car = db.Query<Car>(sql, carData).FirstOrDefault();
      return car;
    }

    internal List<Car> GetAllCars()
    {
      // what the heck happens here?
      string sql = @"
        SELECT 
        *
        FROM cars;
      ";
      // NOTE Query expects to get data back out, and will map it out to the model provided
      List<Car> cars = db.Query<Car>(sql).ToList(); // To List, changes the generic IEnumerable into a List type
      return cars;
    }

    internal Car GetCarById(int carId)
    {
      // NEVER string interpolate with sql strings
      // string sql = @$"
      // SELECT
      // *
      // FROM cars
      // WHERE id = {carId};
      // ";
      string sql = @"
      SELECT
      *
      FROM cars
      WHERE id = @carId;
      ";
      // note dapper can take in a key value pair, to replace our sql variables with their value
      //  ----------------------------⬇️ {carId: 3} which, modifies the last line of our code to read like:
      // WHERE id = 3;
      Car car = db.Query<Car>(sql, new{carId}).FirstOrDefault(); //FirstOrDefault, means it will only Return One Car, or null if no rows were selected.
      return car;
    }

    internal void RemoveCar(int carId)
    {
      string sql = @"
      DELETE FROM cars
      WHERE id = @carId;
      ";
    // NOTE Execute, just runs your sql, not expecting any return other than the rows that the sql affected.
      db.Execute(sql, new{carId});
    }

    internal Car UpdateCar(Car updateData)
    {
      // NOTE we did not add year here, cause we don't want users to be able to edit it.
        string sql = @"
        UPDATE cars SET
        make = @make,
        model = @model,
        price = @price,
        color = @color,
        description = @description,
        imgUrl = @imgUrl
        WHERE id = @id;

        SELECT 
        *
        FROM cars
        WHERE id = @id;
        ";
        Car car = db.Query<Car>(sql, updateData).FirstOrDefault();
        return car;
    }
}