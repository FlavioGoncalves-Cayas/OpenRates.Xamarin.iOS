using System;
using System.Collections.Generic;
using System.Linq;
using Foundation;
using OpenRates.Api;
using OpenRates.iOS.Shared.Model;
using OpenRates.iOS.Views;
using UIKit;

namespace OpenRates.iOS.DataSources
{
    public class RatesDataSource : UITableViewDataSource
    {
        double _amount;
        readonly KeyValuePair<string, double>[] _rates;

        public RatesDataSource(OpenRatesResponse rates, double amount)
        {
            _amount = amount;
            _rates = rates.Rates.Where(x => Enum.TryParse(x.Key, out KnownCurrency _)).OrderBy(r => r.Key).ToArray();
        }

        public override nint RowsInSection(UITableView tableView, nint section)
        {
            return _rates.Length;
        }

        public override UITableViewCell GetCell(UITableView tableView, NSIndexPath indexPath)
        {
            var cell = tableView.DequeueReusableCell(RateCell.CellKey) as RateCell ?? new RateCell();
            cell.RefreshRate(_rates[indexPath.Row].Key, _rates[indexPath.Row].Value, _amount);

            return cell;
        }

        public void RefreshAmount(double currentAmount)
        {
            _amount = currentAmount;
        }
    }
}