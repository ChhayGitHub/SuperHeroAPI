namespace SuperHeroAPI.Services.HeroTypeService
{
    public class HeroTypeService : IHeroTypeService
    {

        private readonly DataContext _context;

        public HeroTypeService(DataContext dataContext)
        {
            _context = dataContext;
        }
        public async Task<List<HeroTypes>> CreateHeroType(HeroTypes heroType)
        {
            _context.HeroTypes.Add(heroType);
            await _context.SaveChangesAsync();
            return await _context.HeroTypes.ToListAsync();

        }

        public async Task<List<HeroTypes>> DeleteHeroType(int id)
        {
           var hero = await _context.HeroTypes.FindAsync(id);
            if (hero == null)
            {
                return null;
            }
            _context.HeroTypes.Remove(hero);
             await _context.SaveChangesAsync();
            return await _context.HeroTypes.ToListAsync() ;
        }

        public async Task<List<HeroTypes>> GetAllHeroTypes()
        {
            var heroes = await _context.HeroTypes.ToListAsync();
            return heroes;
        }

        public async Task<HeroTypes> GetsingleHeroTypes(int id)
        {
            var hero = await _context.HeroTypes.FindAsync(id);
            if (hero == null)
            {
                return null;
            }
            return hero;
        }

        public async Task<List<HeroTypes>> UpdateHeroType(int id, HeroTypes request)
        {
            var hero = await _context.HeroTypes.FindAsync(id);
            if (hero is null)
            {
                return null;
            }
            hero.TypeName = request.TypeName;
            await _context.SaveChangesAsync();
            return await _context.HeroTypes.ToListAsync();
        }
    }
}
