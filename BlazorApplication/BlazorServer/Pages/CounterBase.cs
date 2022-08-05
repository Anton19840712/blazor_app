using Microsoft.AspNetCore.Components;

namespace BlazorServer.Pages
{
	public class CounterBase : ComponentBase
	{
		protected int _currentCount = 0;
		protected string _fontFamily = "Verdana";

		protected void IncrementCount()
		{
			_currentCount++;
		}
	}
}
