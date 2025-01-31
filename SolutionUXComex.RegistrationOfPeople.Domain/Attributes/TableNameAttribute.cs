namespace SolutionUXComex.RegistrationOfPeople.Domain.Attributes
{
    [AttributeUsage(AttributeTargets.Class)] // Aplica apenas a classes
    public class TableNameAttribute : Attribute
    {
        public string Name { get; }

        public TableNameAttribute(string name)
        {
            Name = name;
        }
    }
}
