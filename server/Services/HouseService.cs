namespace gregsListSharp.Services;


public class HouseService(HouseRepository repo){
    private readonly HouseRepository repo = repo;

    internal List<House> GetHouses(){
        List<House> house = repo.GetHouses();
        return house;
    }

    internal House PostHouse(House houseData){
        House house = repo.PostHouse(houseData);
        return house;
    }

    internal string DeleteHouse(string houseId){
        repo.DeleteHouse(houseId);
        return "House was deleted";
    }

    internal House GetHouseById(string houseId){
        House house = repo.GetHouseById(houseId);
        return house;
    }
}