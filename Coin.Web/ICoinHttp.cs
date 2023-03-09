namespace Coin.Web
{
    public interface ICoinHttp
    {
        Task<T> SendAsync<T>(string url, TimeSpan interval, Action<T> callback, CancellationToken cancellationToken);
    }
}
