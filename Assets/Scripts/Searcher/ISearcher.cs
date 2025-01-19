using UnityEngine.Events;

public interface ISearcher
{
    event UnityAction<ITarget> FoundTarget;
    event UnityAction LostTarget;
}
