using UnityEngine.Events;

public interface ISearcher
{
    event UnityAction<Target> FoundTarget;
    event UnityAction LostTarget;
}
