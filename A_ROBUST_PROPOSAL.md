## A Robust Proposal

First things first. BYOND is not ideal. It's great in a lot of ways. It empowers amatures to learn object oriented programming and make multiplayer games. Its IDE contains a level editor and an image editor. But it was designed for MUDs. It supports Telnet. It has very poor cross-platform support. It uses an obscure, error-prone scripting language with many peculiarities. Its networking is bad. It's almost impossible to get threading to work.

There have been many, many attempts to remake Space Station 13 in other game engines. None of these attempts has been incredibly successful. This isn't because these developers are incompetent. It's because it's nearly impossible. SS13 is a very complex game with a huge codebase. It would be difficult for any group of developers to create a stand alone version.

It's especially difficult for professional developers to pick up, considering the size of the community and the already open nature of the code. There's very little potential for profit considering the game's niche appeal. One of the best parts of SS13is its potential for customization. Modding is not easy to get right, especially on the scale that a SS13 remake would require.

Sadly, the prospects aren't much better for hobbyists. The several groups working on clones independently hinders efforts more than it helps. It's discouraging for both developers and players when three clones exist and they all have very little to show. Neither will migrate from a community with active development to a remake with a fraction of the features.

Almost all attempts are over-ambitous and include plans to remake all the assets or even make the game 3D. Creating 3D assets, complete with textures and animations, is considerably more difficult than small 2D sprites. It also limits the ability of a newbie or a coder with poor art skills to create assets.

After watching many clones come and go (several of them my own), I decided that the best way to approach the problem would be the most backwards sounding. We needed to extract SS13 from BYOND, translate it into a modern language, and build a new engine around it. This is an ideal solution for the following reasons:

1. Code does not need to be remade.
2. Art assets do not need to be remade.
3. C# is a modern OO language that is used for real software, has actual library support, is less error-prone, can be threaded, is more efficient... I could go on...
4. Both the engine and client can be custom-built the way we want.
5. Development of BYOND versions can continue in parallel until everything works on our end.
6. We can find errors in the code more easily, and push changes back to the BYOND versions. (I have already done this once. I'm sitting on a small list of issues that I still need to PR...)
7. We will have much more potential for cool shit once we can edit the engine the game runs on.

Today I partially completed the first stage of that process. The translated codebase compiles. It's incredibly unlikely that anything will work very well, but that can be fixed over time. I hope I've managed to convince you that this is maybe not an entirely terrible idea. If you're interested in helping, please see below. If you think I'm an idiot, hit me up at bigboysauceboss@aol.com with your concerns, and I will try to answer them.

-- melichior 1/5/16

## FAQ

I'll try to address your concerns here.

##### How does this differ from OpenBYOND?
The two projects are similar, but OpenBYOND still relies on BYOND's scripting language, whereas this project aims to abandon the damn thing. For what it's worth, OpenBYOND seems to be abandoned.