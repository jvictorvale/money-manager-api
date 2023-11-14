namespace MoneyManager.Core.Settings;

public class JwtSettings
{
    public int ExpiracaoHoras { get; set; }
    public string Emissor { get; set; } = string.Empty;
    public string ComumValidoEm { get; set; } = string.Empty;
}