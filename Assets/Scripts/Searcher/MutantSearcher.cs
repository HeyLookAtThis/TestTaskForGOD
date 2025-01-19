using UnityEngine;
using UnityEngine.Events;

public class MutantSearcher : MonoBehaviour, ISearcher
{
    public event UnityAction<ITarget> FoundTarget;
    public event UnityAction LostTarget;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.TryGetComponent<ITarget>(out ITarget target))
            if(target is Character)
                FoundTarget?.Invoke(target);

        Debug.Log("Enter");
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.TryGetComponent<ITarget>(out ITarget target))
            if (target is Character)
                LostTarget?.Invoke();

        Debug.Log("Exit");
    }
}
