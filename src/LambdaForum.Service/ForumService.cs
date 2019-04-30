using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using LambdaForum.Data;
using LambdaForum.Domain.Models;
using Microsoft.EntityFrameworkCore;

#pragma warning disable RCS1090 // Call 'ConfigureAwait(false)'.

namespace LambdaForum.Service
{
    public class ForumService : IForumService
    {
        private readonly ApplicationDbContext _context;

        public ForumService(ApplicationDbContext context) => _context = context;

        public async Task<IEnumerable<Forum>> ReadAll() =>
            await _context.Forums.ToListAsync();

        public async Task Create(Forum forum)
        {
            if (forum == null) throw new ArgumentNullException(nameof(forum));
            _context.Forums.Add(forum);
            await _context.SaveChangesAsync();
        }

        public async Task<Forum> Read(int id) =>
            await _context.Forums.Include(f => f.Posts).FirstAsync(f => f.Id == id);

        public async Task Update(Forum forum)
        {
            if (forum == null) throw new ArgumentNullException(nameof(forum));
            _context.Forums.Update(forum);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            var forum = await Read(id) ?? throw new ArgumentOutOfRangeException(nameof(id));
            _context.Forums.Remove(forum);
            await _context.SaveChangesAsync();
        }
    }
}

#pragma warning restore RCS1090 // Call 'ConfigureAwait(false)'.
