using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace UntitledCarGame.UI
{
	class Textbox : UIElement
	{
		protected SpriteFont font;

		protected string text;

		protected UISprite sprite;

		public Textbox(ref UICanvas _canvas, SpriteFont _font, Vector2 _position, float _rotation = 0f, bool _enabled = true, bool _interactable = true) : base(ref _canvas, _position, Color.Black, _rotation, _enabled, _interactable)
		{
			font = _font;
			text = "";
			sprite = null;
		}

		public Textbox(ref UICanvas _canvas, SpriteFont _font, Vector2 _position, Color _color, float _rotation = 0f, bool _enabled = true, bool _interactable = true) : base(ref _canvas, _position, _color, _rotation, _enabled, _interactable)
		{
			font = _font;
			text = "";
			sprite = null;
		}

		public Textbox(ref UICanvas _canvas, SpriteFont _font, Texture2D _sprite, Vector2 _position, float _rotation = 0f, bool _enabled = true, bool _interactable = true) : base(ref _canvas, _position, Color.Black, _rotation, _enabled, _interactable)
		{
			font = _font;
			text = "";
			sprite = new UISprite(ref _canvas, _sprite, _position, _rotation, _enabled, _interactable);
		}

		public Textbox(ref UICanvas _canvas, SpriteFont _font, Texture2D _sprite, Vector2 _position, Color _color, float _rotation = 0f, bool _enabled = true, bool _interactable = true) : base(ref _canvas, _position, _color, _rotation, _enabled, _interactable)
		{
			font = _font;
			text = "";
			sprite = new UISprite(ref _canvas, _sprite, _position, _color, _rotation, _enabled, _interactable);
		}

		public void SetText(string _text)
		{
			text = _text;
		}

		public void SetColor(Color _color)
		{
			sprite.SetColor(_color);
		}

		public void SetTextColor(Color _color)
		{
			color = new Color(_color, color.A);
		}

		public void SetSprite(Texture2D _sprite)
		{
			sprite.SetSprite(_sprite);
		}

		public Vector2 GetCenter()
		{
			return sprite.GetCenter();
		}

		public new void SetInteractable(bool _interactable)
		{
			interactable = _interactable;

			if (sprite != null)
			{
				sprite.SetInteractable(_interactable);
			}
			
		}

		public new void ToggleInteractable()
		{
			SetInteractable(!interactable);
		}

		public override void OnDraw(SpriteBatch _spriteBatch)
		{
			if(IsEnabled())
			{
				if (sprite != null)
				{
					sprite.OnDraw(_spriteBatch);
				}

				_spriteBatch.DrawString(font, text, position, color, rotation, font.MeasureString(text) / 2, new Vector2(1f, 1f), SpriteEffects.None, 1f);
			}
		}



	}
}
