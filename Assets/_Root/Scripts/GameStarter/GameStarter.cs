using UnityEngine;

internal sealed class GameStarter : MonoBehaviour
{
    private Game _game;

    private void Start()
    {
        _game = new Game();
        _game.Start();
    }

    private void Update()
    {
        _game.Update(Time.deltaTime);
    }
}
