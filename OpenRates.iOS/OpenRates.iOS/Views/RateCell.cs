using System;
using OpenRates.iOS.Shared.Model;
using UIKit;

namespace OpenRates.iOS.Views
{
    public class RateCell : UITableViewCell
    {
        public const string CellKey = "RateCell";

        public RateCell() : base(UITableViewCellStyle.Value1, CellKey)
        {
        }

        public void RefreshRate(string currency, double rate, double amount)
        {
            var isKnownCurrency = Enum.TryParse(currency, out KnownCurrency knownCurrency);
            
            TextLabel.Text = isKnownCurrency ? knownCurrency.GetFullName() : currency;
            DetailTextLabel.Text = $"{(rate * amount):F2}{(isKnownCurrency ? knownCurrency.GetSymbol() : string.Empty)}";
            DetailTextLabel.Font = UIFont.MonospacedDigitSystemFontOfSize(DetailTextLabel.Font.PointSize, UIFontWeight.Regular);
        }
    }
}