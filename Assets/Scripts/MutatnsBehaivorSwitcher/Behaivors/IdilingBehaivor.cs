public class IdilingBehaivor : IBehaivor
{
    private bool _isIdiling;

    public void StartBehaivor() => _isIdiling = true;
    public void StopBehaivor() => _isIdiling = false;

    public void Update()
    {
        if (_isIdiling == false)
            return;
    }
}
