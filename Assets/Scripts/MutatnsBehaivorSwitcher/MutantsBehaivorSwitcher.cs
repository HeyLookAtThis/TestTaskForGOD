using UnityEngine;

public class MutantsBehaivorSwitcher
{
    private MutantSearcher _searcher;
    private Mutant _mutant;

    private Target _player;
    private Target _tagetForPlayer;
    private bool _isReachedAttackBehaivor;

    public MutantsBehaivorSwitcher(Mutant mutant, MutantSearcher searcher, Target targetForPlayer)
    {
        _mutant = mutant;
        _player = null;

        _searcher = searcher;
        _tagetForPlayer = targetForPlayer;

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

    public void TryReachAttackBehaivor()
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

    private void OnSetMoveToTargetBehaivor(Target target)
    {
        _player = target;
        _mutant.SetBehaivor(new MoveToPlayerBehaivor(_player, _tagetForPlayer, _mutant.Config.MoveToPlayerConfig));
    }

    private void SetAttackBehaivor()
    {
        _mutant.SetBehaivor(new AttackBehaivor(_player, _mutant.Config.AttackConfig));
    }

    private float GetDistanse() => Vector2.Distance(_player.Transform.position, _tagetForPlayer.Transform.position);
}
