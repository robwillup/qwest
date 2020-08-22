namespace Quest.Files
{
    public interface IQuestFile
    {
        bool Create(string path);
        bool Delete(string path);
    }
}
