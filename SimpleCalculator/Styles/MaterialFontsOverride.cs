namespace SimpleCalculator.Styles;

public sealed class MaterialFontsOverride : ResourceDictionary
{
    public MaterialFontsOverride()
    {
        this
            .Build
            (
                r => r
                    .Add("LabelLargeFontSize", 32)
            )
            ;
        
    }
}
