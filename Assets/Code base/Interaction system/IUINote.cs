using LevGamekit.Infrastructure.ServiceLocator;

public interface IUINote : IService
{
    bool IsOpen { get; }
    void Hide();
    void ShowMessage(string message);
}