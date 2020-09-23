using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;

namespace UntitledCarGame.UI
{
	class CheckBox : UIElement
	{
		bool isSelected;
		bool isPressed;

		Texture2D selectedSprite;
		Texture2D unselectedSprite;

		UISprite sprite;

		public CheckBox(ref UICanvas _canvas, Texture2D _unselectedSprite, Texture2D _selectedSprite, bool _isSelected, Vector2 _position, float _rotation = 0f, bool _enabled = true, bool _interactable = true) :
			base(ref _canvas, _position, Color.White, _rotation, _enabled, _interactable)
		{
			isSelected = _isSelected;
			unselectedSprite = _unselectedSprite;
			selectedSprite = _selectedSprite;

			if (isSelected)
			{
				sprite = new UISprite(ref _canvas, _selectedSprite, _position, _rotation, _enabled, _interactable);
			}

			else
			{
				sprite = new UISprite(ref _canvas, _unselectedSprite, _position, _rotation, _enabled, _interactable);
			}
		}

		public CheckBox(ref UICanvas _canvas, Texture2D _unselectedSprite, Texture2D _selectedSprite, bool _isSelected, Vector2 _position, Color _color, float _rotation = 0f, bool _enabled = true, bool _interactable = true) :
			base(ref _canvas, _position, _color, _rotation, _enabled, _interactable)
		{
			isSelected = _isSelected;
			unselectedSprite = _unselectedSprite;
			selectedSprite = _selectedSprite;

			if (isSelected)
			{
				sprite = new UISprite(ref _canvas, _selectedSprite, _position, _rotation, _enabled, _interactable);
			}

			else
			{
				sprite = new UISprite(ref _canvas, _unselectedSprite, _position, _rotation, _enabled, _interactable);
			}
		}

		public bool IsHovering(MouseState _mouseState)
		{
			if ((_mouseState.Position.X < position.X + (sprite.GetCenter().X))
				&& (_mouseState.Position.X > position.X - (sprite.GetCenter().X))
				&& (_mouseState.Position.Y < position.Y + (sprite.GetCenter().Y))
				&& (_mouseState.Position.Y > position.Y - (sprite.GetCenter().Y)))
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

			if (!interactable)
			{
				color = new Color(color, .65f);
				sprite.SetColor(color);
			}

			else
			{
				color = new Color(color, 1f);
				sprite.SetColor(color);
			}
		}

		public new void ToggleInteractable()
		{
			SetInteractable(!interactable);
		}

		public void ToggleSelected()
		{
			isSelected = !isSelected;

			if (isSelected)
			{
				sprite.SetSprite(selectedSprite);
			}

			else
			{
				sprite.SetSprite(unselectedSprite);
			}
		}

		public void OnHover(MouseState _mouseState)
		{
			if (IsInteractable())
			{
				if (IsHovering(_mouseState))
				{
					color = Color.LightGray;
					sprite.SetColor(color);
				}

				else
				{
					color = Color.White;
					sprite.SetColor(color);
				}
			}
		}

		public void OnClick(MouseState _mouseState)
		{
			if ((IsHovering(_mouseState) && IsInteractable() && _mouseState.LeftButton == ButtonState.Pressed))
			{
				isPressed = true;

				color = Color.Gray;
				sprite.SetColor(color);
			}

			else if ((IsHovering(_mouseState) && IsInteractable() && isPressed && _mouseState.LeftButton == ButtonState.Released))
			{
				ToggleSelected();

				isPressed = false;
			}
		}

		public override void OnDraw(SpriteBatch _spriteBatch)
		{
			if (IsEnabled())
			{
				sprite.OnDraw(_spriteBatch);
			}
		}
	}
}