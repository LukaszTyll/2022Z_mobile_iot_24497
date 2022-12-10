namespace Alignment;

public partial class MainPage : ContentPage
{

	public MainPage()
	{
		InitializeComponent();
        
        var a = new BoxView { Color = Colors.Silver, HeightRequest = 40 };
        var b = new BoxView { Color = Colors.Blue, HeightRequest = 40 };
        var c = new BoxView { Color = Colors.Gray, HeightRequest = 40 };

        stack.Children.Add(a);
        stack.Children.Add(b);
        stack.Children.Add(c);
    }
    /* 
    void OnHorizontalStartClicked(object sender, EventArgs e) { target.HorizontalOptions = LayoutOptions.Start; }
    void OnHorizontalCenterClicked(object sender, EventArgs e) { target.HorizontalOptions = LayoutOptions.Center; }
    void OnHorizontalEndClicked(object sender, EventArgs e) { target.HorizontalOptions = LayoutOptions.End; }
    void OnHorizontalFillClicked(object sender, EventArgs e) { target.HorizontalOptions = LayoutOptions.Fill; }

    void OnVerticalStartClicked(object sender, EventArgs e) { target.VerticalOptions = LayoutOptions.Start; }
    void OnVerticalCenterClicked(object sender, EventArgs e) { target.VerticalOptions = LayoutOptions.Center; }
    void OnVerticalEndClicked(object sender, EventArgs e) { target.VerticalOptions = LayoutOptions.End; }
    void OnVerticalFillClicked(object sender, EventArgs e) { target.VerticalOptions = LayoutOptions.Fill; }
        */
}

