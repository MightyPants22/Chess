using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace mychess
{
    public enum GameState
    {
        WaitWhite,
        HighlightedWhite,
        WaitBlack,
        HighlightedBlack,
        LoseWhite,
        LoseBlack,
    }
}
