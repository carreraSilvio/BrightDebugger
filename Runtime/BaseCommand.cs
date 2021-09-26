namespace BrightDebugger
{
    public class BaseCommand
    {
        public string Id { get; private set; }
        public string Description { get; private set; }
        public string Format { get; private set; }

        public BaseCommand(string id, string description, string format)
        {
            Id = id;
            Description = description;
            Format = format;
        }

        public virtual void Execute()
        {

        }
    }
}