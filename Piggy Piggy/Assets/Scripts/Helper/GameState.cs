using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assets.Scripts.Helper
{
    public enum GameState
    {
        Intro,
        Playing,
        Dead,
        Victory
    }
    public static class GameStateManager
    {
        public static GameState GameState { get; set; }

        static GameStateManager()
        {
            GameState = GameState.Intro;
        }
    }
}
