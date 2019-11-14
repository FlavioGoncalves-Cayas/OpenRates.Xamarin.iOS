using UIKit;

namespace OpenRates.iOS.UIComponents
{
    public class PickerButton : UIButton
    {
        UIView _inputView;
        UIView _inputAccessoryView;

        public override UIView InputView => _inputView ?? base.InputView;

        public override UIView InputAccessoryView => _inputAccessoryView ?? base.InputAccessoryView;

        public override bool CanBecomeFirstResponder => true;

        public void SetInputAccessoryView(UIView view)
        {
            _inputAccessoryView = view;
        }

        public void SetInputView(UIView view)
        {
            _inputView = view;
        }
    }
}