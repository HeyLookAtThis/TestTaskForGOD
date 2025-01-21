public class MutantStateMachine : StateMachine
{
    public MutantStateMachine(Mutant mutant)
    {
        AddState(new MutatnIdilingState(mutant.Searcher, this));
        AddState(new MoveToPlayerState(mutant, this));
        AddState(new AttackState(mutant, this));

        SwitchState<MutatnIdilingState>();
    }
}
