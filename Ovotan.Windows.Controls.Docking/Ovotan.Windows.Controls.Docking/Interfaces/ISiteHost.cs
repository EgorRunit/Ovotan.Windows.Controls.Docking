namespace Ovotan.Windows.Controls.Docking.Interfaces
{
    public interface ISiteHost : IDockGridChild
    {
        void AddDocument(ISiteHostDocument document);
        bool ContainsDocument(Guid id);
        bool TryActivate(Guid id);
    }
}
