public interface IGenericLobbyManager
{
	int MaxPlayers { get; }
	void ReturnToLobby();
	void ReturnToStartScreen();
}