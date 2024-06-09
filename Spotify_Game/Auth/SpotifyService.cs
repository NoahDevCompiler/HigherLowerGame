using SpotifyAPI.Web;
using System.Threading.Tasks;

public class SpotifyService
{
    private readonly SpotifyClient _spotify;

    public SpotifyService(string clientId, string clientSecret) {
        var config = SpotifyClientConfig.CreateDefault();
        var request = new ClientCredentialsRequest(clientId, clientSecret);
        var response = new OAuthClient(config).RequestToken(request).Result;

        _spotify = new SpotifyClient(config.WithToken(response.AccessToken));
    }

    public async Task<FullTrack> GetTrackAsync(string trackId) {
        return await _spotify.Tracks.Get(trackId);
    }
}
