﻿using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace dataModel.Repositories
{
    public class ParsedTextRespository : BaseRepository, IParsedTextRespository
    {
        public ParsedTextRespository(IDbContextFactory dbContextFactory) : base(dbContextFactory) { }

        public async Task<bool> AddManyAsync(IEnumerable<ParsedText> parsedText)
        {
            using (var db = base._dbContextFactory.Create())
            {
                await db.ParsedText.AddRangeAsync(parsedText);
                await db.SaveChangesAsync();
                return true;
            }

        }

        public async Task<bool> UpdateManyAsync(IEnumerable<ParsedText> parsedTextCollection)
        {
            using (var db = base._dbContextFactory.Create())
            {
                db.ParsedText.UpdateRange(parsedTextCollection);
                var rowsAffected = await db.SaveChangesAsync();

                return rowsAffected > 0 ? true : false;

            }
        }

        public async Task<ParsedText> GetParsedText(string id)
        {
            using(var db = base._dbContextFactory.Create())
            {
               return await db.ParsedText.FindAsync(id);
            }
        }

        public async Task<IEnumerable<ParsedText>> GetParsedTextByIds(IEnumerable<string> parsedTextIds)
        {   
            using(var db = base._dbContextFactory.Create())
            {
                return await (from p in db.ParsedText
                              where parsedTextIds.Contains(p.Id)
                              select p).ToListAsync<ParsedText>();
            }
        }

        public async Task<IEnumerable<ParsedText>> GetFavoriteParsedTextByMediaId(string mediaId)
        {
            using(var db = base._dbContextFactory.Create())
            {
                return await db.ParsedText.FromSql<ParsedText>("CALL usp_getUserFavoriteParsedTextByMediaId(@inputMediaId)", mediaId).ToListAsync<ParsedText>();
            }
        }
    }
}
