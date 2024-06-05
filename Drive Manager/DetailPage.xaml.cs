using Drive_Manager.Models;

namespace Drive_Manager;

public partial class DetailPage : ContentPage
{
	public DetailPage(DetailModel model)
	{
		InitializeComponent();
		BindingContext = model;
	}
}