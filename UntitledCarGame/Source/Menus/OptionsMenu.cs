using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

using System;

using UntitledCarGame.UI;
using UntitledCarGame.GameManagement;

namespace UntitledCarGame.Menus
{
	class OptionsMenu : IScene
	{
		public void LoadSceneData()
		{
			UntitiledCarGame.instance.ChangeWindowDimensions(1280, 720);
		}

		public void UnloadSceneData()
		{
			
		}

		public void UpdateSceneData(GameTime _gameTime)
		{
			
		}

		public void DrawSceneData(SpriteBatch _spriteBatch)
		{

		}
	}
}
