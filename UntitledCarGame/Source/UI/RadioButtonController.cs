using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;

namespace UntitledCarGame.UI
{
	class RadioButtonController
	{
		List<RadioButton> buttons;

		public RadioButtonController()
		{
			buttons = new List<RadioButton>();
		}

		public void AddButton(RadioButton _button)
		{
			buttons.Add(_button);
		}

		public void SelectedButton(RadioButton _button)
		{
			foreach(RadioButton button in buttons)
			{
				if (button != _button)
				{
					button.Deselect();
				}
			}
		}
	}
}
