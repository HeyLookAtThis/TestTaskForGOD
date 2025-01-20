using UnityEngine;
using UnityEngine.Events;

public class MutantSearcher : MonoBehaviour, ISearcher
{
    public event UnityAction<Target> FoundTarget;
    public event UnityAction LostTarget;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.TryGetComponent<Target>(out Target target))
            if(target is TargetForMutant)
                FoundTarget?.Invoke(target);

        Debug.Log("Enter");
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.TryGetComponent<Target>(out Target target))
            if (target is TargetForMutant)
                LostTarget?.Invoke();

        Debug.Log("Exit");
    }
}
