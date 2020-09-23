using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace UntitledCarGame.UI
{
	class UISprite : UIElement
	{
		private Texture2D sprite;

		private Vector2 size;
		private Vector2 center;


		public UISprite(ref UICanvas _canvas, Texture2D _sprite, Vector2 _position, float _rotation = 0f, bool _enabled = true, bool _interactable = true) : base(ref _canvas, _position, Color.White, _rotation, _enabled, _interactable)
		{
			sprite = _sprite;

			RecalculateDimensions();
		}

		public UISprite(ref UICanvas _canvas, Texture2D _sprite, Vector2 _position, Color _color, float _rotation = 0f, bool _enabled = true, bool _interactable = true) : base(ref _canvas, _position, _color, _rotation, _enabled, _interactable)
		{
			sprite = _sprite;

			RecalculateDimensions();
		}

		private void RecalculateDimensions()
		{
			size = new Vector2(sprite.Width, sprite.Height);
			center = new Vector2(size.X / 2, size.Y / 2);
		}

		public void SetSprite(Texture2D _sprite)
		{
			sprite = _sprite;

			RecalculateDimensions();
		}

		public void SetColor(Color _color)
		{
			color = _color;
		}

		public Vector2 GetSize()
		{
			return size;
		}

		public Vector2 GetCenter()
		{
			return center;
		}

		public override void OnDraw(SpriteBatch _spriteBatch)
		{
			_spriteBatch.Draw(sprite, position, null, color, rotation, GetCenter(), new Vector2(1f, 1f), SpriteEffects.None, 1f);
		}

	}
}
