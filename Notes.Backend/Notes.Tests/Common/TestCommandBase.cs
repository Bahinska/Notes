using Notes.Persistence;
using System;


namespace Notes.Tests.Common
{
    public abstract class TestCommandBase : IDisposable
    {
        protected readonly NotesDbContext context;

        public TestCommandBase()
        {
            context = NotesContextFactory.Create();
        }

        public void Dispose()
        {
            NotesContextFactory.Destroy(context);
        }
    }
}
