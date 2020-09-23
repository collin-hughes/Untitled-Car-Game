using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace UntitledCarGame.GameManagement
{
	interface IScene
	{
		void LoadSceneData();

		void UnloadSceneData();

		void UpdateSceneData(GameTime _gameTime);

		void DrawSceneData(SpriteBatch _spriteBatch);
	}
}
