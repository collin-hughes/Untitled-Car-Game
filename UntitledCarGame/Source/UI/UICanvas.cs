using System.Collections.Generic;

namespace UntitledCarGame.UI
{
	class UICanvas
	{
		List<UIElement> elements;

		public UICanvas()
		{
			elements = new List<UIElement>();
		}

		public void AddElement(UIElement _element)
		{
			elements.Add(_element);
		}

		public void SetActiveElement(UIElement _element)
		{
			foreach (UIElement element in elements)
			{
				if(element == _element)
				{
					element.SetActive(true);
				}

				else
				{
					element.SetActive(false);
				}
			}
		}

		public void DeactivateElement(UIElement _element)
		{
			foreach (UIElement element in elements)
			{
				if (element == _element)
				{
					element.SetActive(false);
				}
			}
		}
	}
}
