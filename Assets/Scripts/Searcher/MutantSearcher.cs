using UnityEngine;

public class MutantSearcher : Searcher
{
    private float _radius;
    private ITarget _mutant;

    public MutantSearcher(SearchConfig searchConfig, ITarget mutant)
    {
        _radius = searchConfig.Radius;
        _mutant = mutant;
    }

    public override float Radius => _radius;

    public override ITarget TryGetTarget()
    {
        var collider = Physics2D.OverlapCircle(_mutant.Transform.position, _radius);

        if(collider.TryGetComponent<ITarget>(out ITarget target))
            if(target is Character)
                return target;

        return null;
    }
}
