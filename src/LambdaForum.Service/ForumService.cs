using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using LambdaForum.Data;
using LambdaForum.Domain.Models;
using Microsoft.EntityFrameworkCore;

#pragma warning disable RCS1090 // Call 'ConfigureAwait(false)'.

namespace LambdaForum.Service
{
    public class ForumService : IForumService
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;

        public ForumService(ApplicationDbContext context, IMapper mapper)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
            _mapper  = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public async Task<IEnumerable<Forum>> ReadAll() =>
            await _context.Forums.ToListAsync();

        //public async Task<IEnumerable<T>> ReadAll<T>() =>
        //    (await _context.Forums.ToListAsync()).Select(f => _mapper.Map<T>(f)).ToList();
        public async Task<IEnumerable<T>> ReadAll<T>() =>
            await Task.Run(() => _mapper.ProjectTo<T>(_context.Forums));

        public async Task Create(Forum forum)
        {
            if (forum == null) throw new ArgumentNullException(nameof(forum));
            _context.Forums.Add(forum);
            await _context.SaveChangesAsync();
        }

        public async Task<Forum> Read(int id) =>
            await _context.Forums
                .Include(f => f.Posts)
                    .ThenInclude(p => p.User)
                .Include(f => f.Posts)
                    .ThenInclude(p => p.Replies)
                        .ThenInclude(r => r.User)
                .FirstAsync(f => f.Id == id);

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
