namespace MauiSamples.Views.Barcode;

public static class BarcodeFormats
{
    public static List<string> SupportedFormats { get; } = new()
    {
        "Aztec",
        "Codabar",
        "Code39",
        "Code93",
        "Code128",
        "DataMatrix",
        "Ean8",
        "Ean13",
        "Itf",
        "MaxiCode",
        "Pdf417",
        "QrCode",
        "Rss14",
        "RssExpanded",
        "UpcA",
        "UpcE",
        "UpcEanExtension",
        "Msi",
        "Plessey",
        "Imb",
        "PharmaCode"
    };
}