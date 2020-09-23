using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace UntitledCarGame.GameManagement
{
	class GameStates
	{
		IScene currentScene;

		public GameStates()
		{
			currentScene = null;
		}

		public void LoadData(IScene _newScene)
		{
			_newScene.LoadSceneData();
			UnloadData();
			currentScene = _newScene;
		}

		public void UnloadData()
		{
			if(currentScene != null)
			{
				currentScene.UnloadSceneData();
			}
		}

		public void UpdateData(GameTime _gameTime)
		{
			currentScene.UpdateSceneData(_gameTime);
		}

		public void DrawData(SpriteBatch _spriteBatch)
		{
			currentScene.DrawSceneData(_spriteBatch);
		}
	}
}
