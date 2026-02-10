using Microsoft.Maui.Controls;
using Microsoft.Maui.Controls.Shapes;

namespace VertHorisNaidis;

public partial class FigurePage : ContentPage
{
	BoxView boxView;
	Random rnd = new Random();
    Ellipse pall;
    VerticalStackLayout vsl;
    HorizontalStackLayout hsl;
    Polygon kolmnurk;
    List<string> nupud = new List<string>() { "Tagasi", "Avaleht", "Edasi" };

    public FigurePage()
	{
        int r = rnd.Next(256);
        int k = rnd.Next(256);
        int p = rnd.Next(256);
        boxView = new BoxView
        {
            Color = Color.FromRgb(r, k, p)
            ,
            WidthRequest = 200,
            HeightRequest = 200,
            HorizontalOptions = LayoutOptions.Center,
            BackgroundColor = Color.FromRgba(0,0,0,0),
            CornerRadius = 30,
        };
        TapGestureRecognizer tap = new TapGestureRecognizer();
        boxView.GestureRecognizers.Add(tap);
        tap.Tapped += (sender, e) =>
        {
            int r = rnd.Next(256);
            int k = rnd.Next(256);
            int p = rnd.Next(256);
            boxView.Color = Color.FromRgb(r, k, p);
            boxView.WidthRequest = boxView.Width + 20;

            boxView.HeightRequest = boxView.Height + 20;
            if (boxView.WidthRequest > (int)DeviceDisplay.MainDisplayInfo.Width/3)
            {
                boxView.WidthRequest = 200;

                boxView.HeightRequest = 200;
            }

        };
        pall = new Ellipse
        {
            WidthRequest = 200,
            HeightRequest = 200,
            Fill = new SolidColorBrush(Color.FromRgb(k, p, r)),
            Stroke = Colors.DarkKhaki,
            StrokeThickness = 5,
            HorizontalOptions = LayoutOptions.Center
        };

        TapGestureRecognizer tap1 = new TapGestureRecognizer();
        pall.GestureRecognizers.Add(tap1);
        tap1.Tapped += (sender, e) =>
        {
            int r = rnd.Next(256);
            int k = rnd.Next(256);
            int p = rnd.Next(256);
            pall.Fill = new SolidColorBrush(Color.FromRgb(k, p, r));
            pall.WidthRequest = pall.Width + 20;

            pall.HeightRequest = pall.Height + 20;
            if (pall.WidthRequest > (int)DeviceDisplay.MainDisplayInfo.Width / 3)
            {
                pall.WidthRequest = 200;

                pall.HeightRequest = 200;
            }

        };



        kolmnurk = new Polygon
        {
            Points = new PointCollection
            {
                new Point(0,200),
                 new Point(100,0),
                 new Point(200,200),
            },
            Fill = new SolidColorBrush(Color.FromRgb(k, r, p)),
            Stroke = Colors.DarkKhaki,
            StrokeThickness = 5,
            HorizontalOptions = LayoutOptions.Center,
            VerticalOptions = LayoutOptions.Center
        };

        TapGestureRecognizer kolmnurk1 = new TapGestureRecognizer();
        kolmnurk.GestureRecognizers.Add(kolmnurk1);
        kolmnurk1.Tapped += (sender, e) =>
        {
            int r = rnd.Next(256);
            int k = rnd.Next(256);
            int p = rnd.Next(256);
            kolmnurk.Fill = new SolidColorBrush(Color.FromRgb(k, p, r));
            kolmnurk.WidthRequest = kolmnurk.Width + 20;

            kolmnurk.HeightRequest = kolmnurk.Height + 20;
            if (kolmnurk.WidthRequest > (int)DeviceDisplay.MainDisplayInfo.Width / 3)
            {
                kolmnurk.WidthRequest = 200;

                kolmnurk.HeightRequest = 200;
            }

        };

        hsl = new HorizontalStackLayout { Spacing = 20, HorizontalOptions = LayoutOptions.Center };
        for (int index = 0; index < nupud.Count; index++)
        {
            Button nuup = new Button
            {
                Text = nupud[index],
                FontSize = 18,
                FontFamily = "Impact",
                TextColor = Colors.Chocolate,
                BackgroundColor = Colors.Beige,
                CornerRadius = 10,
                HeightRequest = 40,
                ZIndex = index
            };

            hsl.Add(nuup);
            nuup.Clicked += Liik;
        }
        vsl = new VerticalStackLayout
        {
            Padding = 20,
            Spacing = 15,
            Children = { boxView, hsl, pall, kolmnurk },
            HorizontalOptions = LayoutOptions.Center

        };
        Content = vsl;

        Content = new VerticalStackLayout
        {
            Padding = 20,
            Spacing = 30,
            Children =
            {
                new Label
                {
                    Text = "FigurePage",
                    FontSize = 28,
                    HorizontalOptions = LayoutOptions.Center
                },
                boxView,
                hsl, pall, kolmnurk
            }
        };

    }

    private void Liik(object? sender, EventArgs e)
    {
        Button nuup = sender as Button;
        if (nuup.ZIndex == 0)
        {
            Navigation.PushAsync(new TextPage());
        }
        else if (nuup.ZIndex == 1)

        {
            Navigation.PopToRootAsync();

        }
        else if (nuup.ZIndex == 2)
        {

            Navigation.PushAsync(new Timer_Page());
        }
    }
}