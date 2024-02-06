namespace gregsListSharp.Repositories;


public class HouseRepository(IDbConnection db){
    private readonly IDbConnection db = db;

    internal List<House> GetHouses(){
        string sql = @"
        SELECT
        *
        FROM houses
        ";
        List<House> houses = db.Query<House>(sql).ToList();
        return houses;
    }

    internal House PostHouse(House houseData){
              string sql = @"
      INSERT INTO houses
      (Price, Bedrooms, Bathrooms, AgeYear, HouseDescription, ImgUrl)
      VALUES
      (@Price, @Bedrooms, @Bathrooms, @AgeYear, @HouseDescription, @ImgUrl);
      
      SELECT
      *
      FROM houses
      WHERE id = LAST_INSERT_ID();
      ";

      House house = db.Query<House>(sql, houseData).FirstOrDefault();
      return house;
    }

    internal void DeleteHouse(string houseId){
        string sql = @"
        DELETE FROM houses
        WHERE id = @houseId";
        db.Execute(sql, new{houseId});
    }

    internal House GetHouseById(string houseId){
        string sql = @"
        SELECT
        *
        FROM houses
        WHERE id=@houseId";
        House house = db.Query<House>(sql, new{houseId}).FirstOrDefault();
        return house;
    }
}