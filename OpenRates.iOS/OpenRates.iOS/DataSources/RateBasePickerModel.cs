using System;
using System.Linq;
using OpenRates.iOS.Model;
using UIKit;

namespace OpenRates.iOS.DataSources
{
    public class RateBasePickerModel : UIPickerViewModel
    {
        public KnownCurrency SelectedRateBase { get; private set; }

        public event EventHandler ValueSelected;

        public RateBasePickerModel(KnownCurrency selectedRateBase)
        {
            SelectedRateBase = selectedRateBase;
        }
        
        public override nint GetComponentCount(UIPickerView pickerView)
        {
            return 1;
        }

        public override nint GetRowsInComponent(UIPickerView pickerView, nint component)
        {
            return Enum.GetNames(typeof(KnownCurrency)).Length;
        }

        public override string GetTitle(UIPickerView pickerView, nint row, nint component)
        {
            return GetRateBaseAt(row).GetFullName();
        }

        public override void Selected(UIPickerView pickerView, nint row, nint component)
        {
            SelectedRateBase = GetRateBaseAt(row);
            
            ValueSelected?.Invoke(this, EventArgs.Empty);
        }

        public static KnownCurrency GetRateBaseAt(nint row)
        {
            return Enum.GetValues(typeof(KnownCurrency)).Cast<KnownCurrency>().OrderBy(x => x.ToString()).ToArray()[row];
        }

        public static int GetIndexOf(KnownCurrency rateBase)
        {
            return Enum.GetValues(typeof(KnownCurrency)).Cast<KnownCurrency>().OrderBy(x => x.ToString()).ToList().IndexOf(rateBase);
        }
    }
}