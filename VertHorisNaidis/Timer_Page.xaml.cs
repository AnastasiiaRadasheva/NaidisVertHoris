namespace VertHorisNaidis;

public partial class Timer_Page : ContentPage
{
    Label lbl;
    Button timerBtn;

    HorizontalStackLayout hsl;
    VerticalStackLayout vsl;

    List<string> nupud = new() { "Tagasi", "Avaleht", "Edasi" };

    bool on_off = false;

    public Timer_Page()
    {
        lbl = new Label
        {
            Text = "Vajuta nupule ja siia",
            FontSize = 22,
            FontFamily = "Impact",
            TextColor = Colors.Black,
            BackgroundColor = Colors.Beige,
            HorizontalOptions = LayoutOptions.Center,
            HorizontalTextAlignment = TextAlignment.Center
        };

        timerBtn = new Button
        {
            Text = "Näita info",
            FontSize = 18,
            FontFamily = "Impact",
            TextColor = Colors.White,
            BackgroundColor = Colors.DarkGreen,
            CornerRadius = 12,
            HeightRequest = 45,
            HorizontalOptions = LayoutOptions.Center
        };
        timerBtn.Clicked += timer_btn_Clicked;

        hsl = new HorizontalStackLayout { Spacing = 20, HorizontalOptions = LayoutOptions.Center };
        for (int index = 0; index < nupud.Count; index++)
        {
            Button nuup = new Button
            {
                Text = nupud[index],
                FontSize = 18,
                FontFamily = "Impact",
                TextColor = Colors.White,
                BackgroundColor = Colors.Beige,
                CornerRadius = 10,
                HeightRequest = 40,
                ZIndex = index
            };

            nuup.Clicked += Liik;
            hsl.Add(nuup);
        }

        vsl = new VerticalStackLayout
        {
            Padding = 20,
            Spacing = 15,
            HorizontalOptions = LayoutOptions.Center,
            Children = { lbl, timerBtn, hsl }
        };

        Content = vsl;
    }

    private async void ShowTime()
    {
        while (on_off)
        {
            timerBtn.Text = DateTime.Now.ToString("T");
            await Task.Delay(1000);
        }
    }

    private void timer_btn_Clicked(object? sender, EventArgs e)
    {
        if (on_off)
        {
            on_off = false;
            timerBtn.Text = "Näita info";
        }
        else
        {
            on_off = true;
            ShowTime();
        }
    }


    private void Liik(object? sender, EventArgs e)
    {
        Button nuup = sender as Button;
        if (nuup.ZIndex == 0)
        {
            Navigation.PushAsync(new FigurePage());
        }
        else if (nuup.ZIndex == 1)

        {
            Navigation.PopToRootAsync();

        }
        else if (nuup.ZIndex == 2)
        {

            Navigation.PushAsync(new FigurePage());
        }
    }
}
