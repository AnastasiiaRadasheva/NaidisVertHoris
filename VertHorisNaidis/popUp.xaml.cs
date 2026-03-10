namespace VertHorisNaidis;

public partial class popUp : ContentPage
{
    public popUp()
    {
        Button alertButton = new Button
        {
            Text = "Teade",
            VerticalOptions = LayoutOptions.Start,
            HorizontalOptions = LayoutOptions.Center
        };

        alertButton.Clicked += AlertButton_Clicked;
        Button alertYesNoButton = new Button
        {
            Text = "Jah või ei",
            VerticalOptions = LayoutOptions.Start,
            HorizontalOptions = LayoutOptions.Center
        };

        alertYesNoButton.Clicked += AlertYesNoButton_Clicked;

        // 3. Loome kolmanda nupu (Valikumenüü)
        Button alertListButton = new Button
        {
            Text = "Valik",
            VerticalOptions = LayoutOptions.Start,
            HorizontalOptions = LayoutOptions.Center
        };

        alertListButton.Clicked += AlertListButton_Clicked;

        // 4. Paigutame kõik nupud ekraanile üksteise alla
        Content = new VerticalStackLayout
        {
            Spacing = 20, // Jätab nuppude vahele 20 pikslit vaba ruumi
            Padding = new Thickness(0, 50, 0, 0), // Lükkab sisu veidi ülevalt alla
            Children =
            {
                alertButton,
                alertYesNoButton,
                alertListButton
            }
        };
    }

    // 1. Lihtne teade
    private async void AlertButton_Clicked(object sender, EventArgs e)
    {
        await DisplayAlertAsync("Teade", "See on lihtne teade!", "OK");
    }

    // 2. Nupp: Jah või ei valik
    private async void AlertYesNoButton_Clicked(object sender, EventArgs e)
    {
        // Küsime kasutajalt kinnitust (tagastab true või false)
        bool result = await DisplayAlertAsync("Kinnitus", "Kas oled kindel?", "Olen kindel", "Ei ole kindel");

        // Kuvame uue teate vastavalt sellele, mida kasutaja valis
        await DisplayAlertAsync("Teade", "Teie valik on: " + (result ? "Jah" : "Ei"), "OK");
    }

    // 3. Nupp: Valikute nimekiri
    private async void AlertListButton_Clicked(object sender, EventArgs e)
    {
        // Kuvab menüü ja salvestab kasutaja valitud teksti muutujasse 'action'
        string action = await DisplayActionSheetAsync(
            "Mida teha?",
            "Loobu",
            "Kustutada",
            "Tantsida",
            "Laulda",
            "Joonestada"
        );

        // Kontrollime, et kasutaja ei vajutanud lihtsalt kõrvale ega valinud "Loobu"
        if (action != null && action != "Loobu")
        {
            await DisplayAlertAsync("Valik", "Sa valisid tegevuse: " + action, "OK");
        }
    }
}