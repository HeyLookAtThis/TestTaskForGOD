public interface IBehaivorSwitcher
{
    void SwitchBehaivor<T>() where T : IBehaivor;
}
