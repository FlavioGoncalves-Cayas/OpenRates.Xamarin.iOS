using System;
using System.Threading.Tasks;
using CoreGraphics;
using OpenRates.Api;
using OpenRates.iOS.DataSources;
using OpenRates.iOS.Model;
using OpenRates.iOS.UIComponents;
using OpenRates.iOS.Utils;
using UIKit;

namespace OpenRates.iOS.ViewControllers
{
    public class MainController : UIViewController
    {
        UILabel _baseCurrencyLabel;
        PickerButton _baseButton;
        UILabel _amountLabel;
        UIView _amountTextFieldBorder;
        UITextField _amountTextField;
        UITableView _ratesTable;

        UIView _loadingView;
        UIActivityIndicatorView _activityIndicator;

        KnownCurrency _currentBase;
        double _currentAmount;

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();

            Title = "OpenRates";

            EdgesForExtendedLayout = UIRectEdge.None;
            
            View.BackgroundColor = AppColors.Background;

            _currentAmount = 1;
            
            _baseCurrencyLabel = new UILabel
            {
                Text = "Currency:",
                Font = UIFont.BoldSystemFontOfSize(18)
            };
            
            _baseButton = new PickerButton
            {
                ContentEdgeInsets = new UIEdgeInsets(15, 10, 15, 10),
                Layer =
                {
                    BorderColor = AppColors.Blue.CGColor,
                    BorderWidth = 1,
                    CornerRadius = 8
                }
            };
            _baseButton.SetTitleColor(AppColors.Blue, UIControlState.Normal);
            
            _amountLabel = new UILabel
            {
                Text = "Amount:",
                Font = UIFont.BoldSystemFontOfSize(18)
            };
            
            _amountTextFieldBorder = new UIView
            {
                BackgroundColor = UIColor.Clear,
                Layer =
                {
                    BorderColor = AppColors.Blue.CGColor,
                    BorderWidth = 1,
                    CornerRadius = 8
                }
            };
            
            var inputAccessoryView = new UIToolbar
            {
                BarStyle = UIBarStyle.Default,
                TranslatesAutoresizingMaskIntoConstraints = false,
                Items = new[]
                {
                    new UIBarButtonItem(UIBarButtonSystemItem.FlexibleSpace), new UIBarButtonItem(UIBarButtonSystemItem.Done, AmountTextFieldDone)
                }
            };
            _amountTextField = new UITextField
            {
                Text = _currentAmount.ToString("F2"),
                TextColor = AppColors.Blue,
                TextAlignment = UITextAlignment.Right,
                Font = UIFont.PreferredBody,
                KeyboardType = UIKeyboardType.DecimalPad,
                InputAccessoryView = inputAccessoryView
            };
            
            _amountTextFieldBorder.AddSubview(_amountTextField);
            
            _ratesTable = new UITableView
            {
                AllowsSelection = false,
                TableFooterView = new UIView()
            };
            
            _loadingView = new UIView
            {
                BackgroundColor = UIColor.Clear
            };
            
            _activityIndicator = new UIActivityIndicatorView(UIActivityIndicatorViewStyle.Large)
            {
                HidesWhenStopped = true
            };
            
            _loadingView.AddSubview(_activityIndicator);
            
            View.AddSubviews(_baseCurrencyLabel, _baseButton, _amountLabel, _amountTextFieldBorder, _ratesTable, _loadingView);
        }

        public override async void ViewDidAppear(bool animated)
        {
            base.ViewDidAppear(animated);

            SetCurrentBase(KnownCurrency.EUR);
            
            await RefreshRates();

            _baseButton.TouchUpInside += BaseButtonOnTouchUpInside;
            _amountTextField.EditingChanged += AmountTextFieldOnValueChanged;
            _amountTextField.Ended += AmountTextFieldOnEnded;
        }

        async Task RefreshRates()
        {
            _ratesTable.DataSource = null;
            _ratesTable.ReloadData();
            
            _loadingView.Hidden = false;
            _activityIndicator.StartAnimating();
            
            var rates = await OpenRatesClient.Instance.GetLatestWithBaseAsync(_currentBase.ToString());

            _ratesTable.DataSource = new RatesDataSource(rates, _currentAmount);
            _ratesTable.ReloadData();

            _loadingView.Hidden = true;
            _activityIndicator.StopAnimating();
        }

        void RefreshConversion()
        {
            ((RatesDataSource) _ratesTable.DataSource).RefreshAmount(_currentAmount);
            _ratesTable.ReloadData();
        }

        public override void ViewDidLayoutSubviews()
        {
            base.ViewDidLayoutSubviews();

            LayoutSubviews();
        }

        void LayoutSubviews()
        {
            _baseCurrencyLabel.SizeToFit();
            _baseCurrencyLabel.Frame = new CGRect(30, 20, _baseCurrencyLabel.Frame.Width, _baseCurrencyLabel.Frame.Height);
            
            _baseButton.SizeToFit();
            _baseButton.Frame = new CGRect(40, _baseCurrencyLabel.Frame.GetMaxY() + 10, View.Bounds.Width - 80, _baseButton.Frame.Height);
            
            _amountLabel.SizeToFit();
            _amountLabel.Frame = new CGRect(30, _baseButton.Frame.GetMaxY() + 20, _amountLabel.Frame.Width, _amountLabel.Frame.Height);
            
            _amountTextField.SizeToFit();
            _amountTextFieldBorder.Frame = new CGRect(40, _amountLabel.Frame.GetMaxY() + 10, View.Bounds.Width - 80, _amountTextField.Frame.Height + 20);
            _amountTextField.Frame = new CGRect(15, 10, _amountTextFieldBorder.Frame.Width - 30, _amountTextField.Frame.Height);
            
            _ratesTable.Frame = new CGRect(10, _amountTextFieldBorder.Frame.GetMaxY() + 20, View.Bounds.Width - 20, View.Bounds.Height - _amountTextFieldBorder.Frame.GetMaxY() - View.SafeAreaInsets.Bottom - 10);
            
            _loadingView.Frame = new CGRect(0, _ratesTable.Frame.Y, View.Bounds.Width, View.Bounds.Height - _ratesTable.Frame.Y - View.SafeAreaInsets.Bottom);
            
            _activityIndicator.Frame = new CGRect(_loadingView.Frame.Width / 2 - 20, 40, 40, 40);
        }

        void BaseButtonOnTouchUpInside(object sender, EventArgs e)
        {
            var rateBasePickerModel = new RateBasePickerModel(_currentBase);
            rateBasePickerModel.ValueSelected += RateBasePickerModelOnValueSelected;
            
            var uiPickerView = new UIPickerView
            {
                ShowSelectionIndicator = true,
                Model = rateBasePickerModel
            };
            uiPickerView.Select(RateBasePickerModel.GetIndexOf(_currentBase), 0, true);
            
            _baseButton.SetInputView(uiPickerView);
            _baseButton.BecomeFirstResponder();
        }

        async void RateBasePickerModelOnValueSelected(object sender, EventArgs e)
        {
            _baseButton.ResignFirstResponder();
            
            var selectedRateBase = ((RateBasePickerModel) sender).SelectedRateBase;

            if (_currentBase == selectedRateBase)
                return;
            
            SetCurrentBase(selectedRateBase);

            await RefreshRates();
        }

        void AmountTextFieldDone(object sender, EventArgs e)
        {
            _amountTextField.ResignFirstResponder();
        }

        void AmountTextFieldOnValueChanged(object sender, EventArgs e)
        {
            if (!double.TryParse(_amountTextField.Text, out _))
            {
                _amountTextFieldBorder.Layer.BorderColor = AppColors.Red.CGColor;
                _amountTextField.TextColor = AppColors.Red;
            }
            else
            {
                _amountTextFieldBorder.Layer.BorderColor = AppColors.Blue.CGColor;
                _amountTextField.TextColor = AppColors.Blue;
            }
        }
        
        void AmountTextFieldOnEnded(object sender, EventArgs e)
        {
            _amountTextFieldBorder.Layer.BorderColor = AppColors.Blue.CGColor;
            _amountTextField.TextColor = AppColors.Blue;

            var previousAmount = _currentAmount;
            _currentAmount = double.TryParse(_amountTextField.Text, out var amount) ? amount : _currentAmount;

            _amountTextField.Text = _currentAmount.ToString("F2");

            if (previousAmount != _currentAmount)
                RefreshConversion();
        }

        void SetCurrentBase(KnownCurrency currentBase)
        {
            _currentBase = currentBase;
            
            _baseButton.SetTitle(_currentBase.GetFullName(), UIControlState.Normal);
            LayoutSubviews();
        }
    }
}