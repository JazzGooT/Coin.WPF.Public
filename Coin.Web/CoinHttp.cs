


using Newtonsoft.Json;

namespace Coin.Web
{
    public class CoinHttp
    {
        private readonly CancellationTokenSource _cancellationTokenSource;
        public CoinHttp()
        {
            _cancellationTokenSource = new CancellationTokenSource();
        }
        public async Task<T> SendAsync<T>(string url, TimeSpan interval, Action<T> callback, CancellationToken cancellationToken = default)
        {
            while (cancellationToken.IsCancellationRequested)
            {
                using (var client = new HttpClient())
                {
                    try
                    {
                        var responce = await client.GetAsync(url);
                        responce.EnsureSuccessStatusCode();
                        var content = await responce.Content.ReadAsStringAsync();
                        var result = JsonConvert.DeserializeObject<T>(content);
                    }
                    catch (Exception ex)
                    {
                        // handle exception//
                    }
                }
                await Task.Delay(interval, cancellationToken);
            }
            return default(T);
        }
        public void Stop()
        {
            _cancellationTokenSource.Cancel();
        }
    }
}