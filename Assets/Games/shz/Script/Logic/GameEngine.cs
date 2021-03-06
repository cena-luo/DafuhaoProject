
using System;
using System.Collections.Generic;

using Shared;
using com.QH.QPGame.Services.Data;


namespace com.QH.QPGame.SHZ
{
	[GameDesc(GameIDPrefix = 1018, Version="1.0.2")]
    public class GameEngine : PokerGameAgent
	{
        public static GameEngine Instance
        {
            get
            {
                if (instance == null)
                {
                    return null;
                }
                else
                {
					return instance as GameEngine;
                }
            }
        }
	}
}
