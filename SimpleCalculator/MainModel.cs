namespace SimpleCalculator;

public partial record MainModel
{
    public MainModel(IThemeService themeService)
    {
        Calculator = State.Value(this, () => new Calculator());
        IsDark = State.Value(this, () => themeService.IsDark);

        themeService.ThemeChanged += async (_, _) =>
        {
            var isDark = themeService.IsDark;
            await IsDark.Update(_ => isDark, CancellationToken.None);
        };
        
        IsDark.ForEachAsync(async (dark, _) =>
            await themeService.SetThemeAsync(dark ? AppTheme.Dark : AppTheme.Light));
    }

    public IState<bool> IsDark { get; }

    public IState<Calculator> Calculator { get; }

    public async ValueTask InputCommand(string key, CancellationToken ct) =>
        await Calculator.Update(c => c?.Input(key), ct);
};
