using MediatR;
using Notes.Application.Interfaces;
using Notes.Application.Common.Exceptions;
using System;
using Notes.Domain;

namespace Notes.Application.Notes.Commands.DeleteNote
{
    public class DeleteNoteCommandHandler : IRequestHandler<DeleteNoteCommand>
    {
        private readonly INotesDbContext _dbcontext;
        public DeleteNoteCommandHandler(INotesDbContext dbcontext)
        {
            _dbcontext = dbcontext;
        }
        public async Task Handle(DeleteNoteCommand request, CancellationToken cancellationToken)
        {
            var entity = await _dbcontext.Notes.FindAsync(new object[] { request.Id }, cancellationToken); 
            if (entity == null||entity.UserId!=request.UserId)
            {
                throw new NotFoundException(nameof(Note), request.Id);
            }
            _dbcontext.Notes.Remove(entity);
            await _dbcontext.SaveChangesAsync(cancellationToken);
        }
    }
}
