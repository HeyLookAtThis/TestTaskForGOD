public abstract class Searcher
{
    public abstract float Radius { get; }
    public abstract ITarget TryGetTarget();
}
