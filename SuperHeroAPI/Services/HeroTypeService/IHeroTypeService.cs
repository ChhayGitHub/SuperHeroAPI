namespace SuperHeroAPI.Services.HeroTypeService
{
    public interface IHeroTypeService
    {
        Task<List<HeroTypes>> GetAllHeroTypes();
        Task<HeroTypes> GetSingleHeroTypes(int id);
        Task<List<HeroTypes>> CreateHeroType(HeroTypes heroType);
        Task<List<HeroTypes>> UpdateHeroType(int id, HeroTypes request);
        Task<List<HeroTypes>> DeleteHeroType(int id);
    }
}
