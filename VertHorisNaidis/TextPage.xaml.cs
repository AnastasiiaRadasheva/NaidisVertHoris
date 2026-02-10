


namespace VertHorisNaidis;

public partial class TextPage : ContentPage
{
	Label lbl;
	Editor editor;
	HorizontalStackLayout hsl;
	List<string> nupud = new List<string>() { "Tagasi", "Avaleht", "Edasi" };
    Button ttsBtn;

    VerticalStackLayout vsl;
	public TextPage(int i)
	{
		lbl = new Label
		{
			Text = "Pealkiri",
			FontSize = 30,
			FontFamily = "Impact",
			TextColor = Colors.Black,
			HorizontalOptions = LayoutOptions.Center,
			FontAttributes = FontAttributes.Bold,
			HorizontalTextAlignment = TextAlignment.Center
		};
		editor = new Editor
		{
			Placeholder = "Sisesta tekst",
			PlaceholderColor = Colors.Red,
			FontSize = 18,
            FontFamily = "Impact",
			FontAttributes = FontAttributes.Italic,
			HorizontalOptions = LayoutOptions.Center

        };
		editor.TextChanged += (sender, e) =>
		{
			lbl.Text = editor.Text;
		};

        ttsBtn = new Button
        {
            Text = " R‰‰gi",
            FontSize = 18,
            FontFamily = "Impact",
            TextColor = Colors.White,
            BackgroundColor = Colors.DarkGreen,
            CornerRadius = 12,
            HeightRequest = 45,
            HorizontalOptions = LayoutOptions.Center
        };

        ttsBtn.Clicked += Btn_Clicked;

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

            hsl.Add(nuup);
            nuup.Clicked += Liik;
        }
        vsl = new VerticalStackLayout
		{
			Padding = 20,
			Spacing = 15,
            Children = { lbl, editor, ttsBtn, hsl },
            HorizontalOptions = LayoutOptions.Center

		};
        Content = vsl;

    }
	private async void Btn_Clicked (object?sender, EventArgs e)
	{

        //await DisplayAlert("Debug", "Nupp tˆˆtab!", "OK");

        IEnumerable<Locale> locales = await TextToSpeech.Default.GetLocalesAsync();
		SpeechOptions option = new SpeechOptions()
		{
			Pitch = 1.5f,
			Volume = 0.75f,
			Locale = locales.FirstOrDefault()
		};
		var text = editor.Text;
		if (string.IsNullOrWhiteSpace(text))
		{
			await DisplayAlert("Viga", "Palun sisesta tekst", "OK");
			return;
		}
		try
		{
			await TextToSpeech.SpeakAsync(text, option);
		}
		catch(Exception ex)
		{
			await DisplayAlert("TTS viga", ex.Message, "OK");
		}

	}
    private void Liik(object? sender, EventArgs e)
    {
		Button nuup = sender as Button;
		if (nuup.ZIndex == 0)
		{
			Navigation.PopAsync();
		}
		else if (nuup.ZIndex == 1)

		{
            Navigation.PopToRootAsync();

        }
		else if (nuup.ZIndex == 2)
		{

			
		}
    }
}