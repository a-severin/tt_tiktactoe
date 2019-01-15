using System;

namespace TikTacToe.Model
{
    public static class GameStateExtension
    {
        public static GameState ToState(this GameMark mark)
        {
            switch (mark)
            {
                case GameMark.X:
                    return GameState.WinX;
                case GameMark.O:
                    return GameState.WinO;
                default:
                    throw new ArgumentOutOfRangeException($"Unexpect value {mark}");
            }
        }
    }
}