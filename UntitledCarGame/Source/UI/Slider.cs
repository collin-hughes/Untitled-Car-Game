using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;

namespace UntitledCarGame.UI
{
	class Slider : UIElement
	{
		private UISprite sprite;
		private UISprite handle;

		private float maxValue;
		private float currentValue;

		private bool isPressed;

		public Slider(ref UICanvas _canvas, Texture2D _sprite, Texture2D _handleSprite, Vector2 _position, float _maxValue, float _rotation = 0, bool _enabled = true, bool _interactable = true) : 
			base(ref _canvas, _position, Color.White, _rotation, _enabled, _interactable)
		{
			sprite = new UISprite(ref _canvas, _sprite, _position, _rotation, _enabled, _interactable);
			handle = new UISprite(ref _canvas, _handleSprite, new Vector2(_position.X + sprite.GetSize().X / 2, _position.Y), _rotation, _enabled, _interactable);

			maxValue = _maxValue;
			currentValue = _maxValue;
		}
		public Slider(ref UICanvas _canvas, Texture2D _sprite, Texture2D _handleSprite, Vector2 _position, float _maxValue, Color _color, float _rotation = 0, bool _enabled = true, bool _interactable = true) : 
			base(ref _canvas, _position, _color, _rotation, _enabled, _interactable)
		{
			sprite = new UISprite(ref _canvas, _sprite, _position, _rotation, _enabled, _interactable);
			handle = new UISprite(ref _canvas, _handleSprite, new Vector2(_position.X + sprite.GetSize().X / 2, _position.Y), _rotation, _enabled, _interactable);

			maxValue = _maxValue;
			currentValue = _maxValue;
		}

		public bool IsHovering(MouseState _mouseState)
		{
			if ((_mouseState.Position.X < handle.GetPosition().X + handle.GetCenter().X)
				&& (_mouseState.Position.X > handle.GetPosition().X - handle.GetCenter().X)
				&& (_mouseState.Position.Y < handle.GetPosition().Y + handle.GetCenter().Y)
				&& (_mouseState.Position.Y > handle.GetPosition().Y - handle.GetCenter().Y))
			{
				return true;
			}

			else
			{
				return false;
			}
		}

		public new void SetInteractable(bool _interactable)
		{
			interactable = _interactable;

			sprite.SetInteractable(_interactable);
			handle.SetInteractable(_interactable);

		}

		public new void ToggleInteractable()
		{
			SetInteractable(!interactable);
		}

		public void OnHover(MouseState _mouseState)
		{
			if (IsInteractable())
			{
				if (IsHovering(_mouseState))
				{
					color = Color.LightGray;
					handle.SetColor(color);
				}

				else
				{
					color = Color.White;
					handle.SetColor(color);
				}
			}

		}

		public void OnDrag(MouseState _mouseState)
		{
			if ((IsHovering(_mouseState) && IsInteractable() && _mouseState.LeftButton == ButtonState.Pressed) || isPressed)
			{
				int mouseX;

				isPressed = true;

				color = Color.Gray;
				handle.SetColor(color);

				mouseX = _mouseState.Position.X;

				if (mouseX > position.X + sprite.GetCenter().X)
				{
					mouseX = (int)position.X + (int)sprite.GetCenter().X;
				}

				else if (mouseX < position.X - sprite.GetCenter().X)
				{
					mouseX = (int)position.X - (int)sprite.GetCenter().X;
				}

				handle.SetPosition(mouseX, handle.GetPosition().Y);

				currentValue = (((handle.GetPosition().X - handle.GetSize().X) - sprite.GetSize().X) * maxValue) / sprite.GetSize().X;

				if(_mouseState.LeftButton == ButtonState.Released)
				{
					isPressed = false;
				}

			}
		}

		public override void OnDraw(SpriteBatch _spriteBatch)
		{
			sprite.OnDraw(_spriteBatch);
			handle.OnDraw(_spriteBatch);
			
		}
	}
}
