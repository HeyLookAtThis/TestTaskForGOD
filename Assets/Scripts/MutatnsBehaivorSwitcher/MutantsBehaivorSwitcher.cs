using UnityEngine;

public class MutantsBehaivorSwitcher
{
    private MutantSearcher _searcher;
    private Mutant _mutant;

    private ITarget _player;
    private bool _isReachedAttackBehaivor;

    public MutantsBehaivorSwitcher(Mutant mutant, MutantSearcher searcher)
    {
        _mutant = mutant;
        _player = null;

        _searcher = searcher;

        _mutant.SetBehaivor(new IdilingBehaivor());
        _isReachedAttackBehaivor = false;
    }

    public void AddActionsCallback()
    {
        _searcher.FoundTarget += OnSetMoveToTargetBehaivor;
        _searcher.LostTarget += OnSetIdilingBeghaivor;
    }

    public void RemoveActionsCallback()
    {
        _searcher.FoundTarget -= OnSetMoveToTargetBehaivor;
        _searcher.LostTarget -= OnSetIdilingBeghaivor;
    }

    public void Update()
    {
        if (_player == null)
            return;

        if (GetDistanse() <= _mutant.Config.MoveToPlayerConfig.Distance && _isReachedAttackBehaivor == false)
        {
            _isReachedAttackBehaivor = true;
            SetAttackBehaivor();
        }

        if(GetDistanse() >= _mutant.Config.MoveToPlayerConfig.Distance && _isReachedAttackBehaivor == true)
        {
            _isReachedAttackBehaivor = false;
        }
    }

    private void OnSetIdilingBeghaivor()
    {
        _mutant.SetBehaivor(new IdilingBehaivor());
        _player = null;
    }

    private void OnSetMoveToTargetBehaivor(ITarget target)
    {
        _player = target;
        _mutant.SetBehaivor(new MoveToPlayerBehaivor(_player, _mutant, _mutant.Config.MoveToPlayerConfig));
    }

    private void SetAttackBehaivor()
    {
        _mutant.SetBehaivor(new AttackBehaivor(_player, _mutant.Config.AttackConfig));
    }

    private float GetDistanse() => Vector2.Distance(_player.Transform.position, _mutant.Transform.position);
}
