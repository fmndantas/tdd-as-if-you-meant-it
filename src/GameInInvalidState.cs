namespace src;

public class GameInInvalidState : Exception
{
    public GameInInvalidState(string reason) : base($"Game is invalid. Reason: {reason}")
    {
    }
}