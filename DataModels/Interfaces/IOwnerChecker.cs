namespace Fundify_API.DataModels.Interfaces;

public interface IOwnerChecker
{
    public bool CheckOwner(string? username);
}
