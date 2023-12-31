﻿using Movie_api.DartaLayer;
using LinqToDB;
using Movie_api.Model;

namespace Movie_api.Repository
{
    public class Service : IService
    {
        private readonly MovieDbContext _movieDb;
        private readonly IWebHostEnvironment _web;

        public Service(IWebHostEnvironment web, MovieDbContext kinoDb)
        {
            _movieDb = kinoDb;
            _web = web;

        }

        public async Task<Moveis> AddMoveisAsync(Moveis moveis)
        {
            if (moveis == null)
            {
                return new Moveis();
            }
            await _movieDb.AddAsync(moveis);
            await _movieDb.SaveChangesAsync();
            return moveis;

        }

        public async Task<IEnumerable<Moveis>> GetAllMoveisAsync()
        {
            var res = await _movieDb.Moveiss.ToListAsync();
            if (res == null)
            {
                return null;
            }
            return res;
        }

        public async Task<Moveis> GetByIdMoveisAsync(int moveisId)
        {
            var moveis = await _movieDb.Moveiss.FirstOrDefaultAsync(p => p.Id == moveisId);
            return moveis;
        }

        public async Task<Moveis> SetImageAsync(int moveisId, IFormFile file)
        {
            var movie = await _movieDb.Moveiss.FirstOrDefaultAsync(p => p.Id == moveisId);

            string fileName = Guid.NewGuid() + Path.GetExtension(file.FileName);
            string path = Path.Combine(_web.WebRootPath, $"Image/{fileName}");


            FileStream fileStream = File.Open(path, FileMode.Create);
            await file.OpenReadStream().CopyToAsync(fileStream);

            fileStream.Flush();
            fileStream.Close();
            movie.Image = fileName;
            return movie;





        }
    }
}