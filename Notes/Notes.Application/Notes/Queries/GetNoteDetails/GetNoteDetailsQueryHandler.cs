using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Notes.Application.Common.Exceptions;
using Notes.Application.Interfaces;
using Notes.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Notes.Application.Notes.Queries.GetNoteDetails
{
    public class GetNoteDetailsQueryHandler : IRequestHandler<GetNoteDetailsQuery, NoteDetailsVm>
    {
        private readonly  INotesDbContext _dbcontext;
        private readonly IMapper _mapper;
        public GetNoteDetailsQueryHandler(INotesDbContext dbcontext, IMapper mapper)
        {
            _dbcontext = dbcontext;
            _mapper = mapper;
        }
        public async Task<NoteDetailsVm> Handle(GetNoteDetailsQuery request,CancellationToken cancellationToken)
        {
            var entity = await _dbcontext.Notes
                .FirstOrDefaultAsync(note => note.Id == request.Id, cancellationToken);
            if (entity == null || entity.UserId != request.UserId) 
            {
                throw new NotFoundException(nameof(Note), request.Id);
            }
            return _mapper.Map<NoteDetailsVm>(entity);
        }
    }
}
