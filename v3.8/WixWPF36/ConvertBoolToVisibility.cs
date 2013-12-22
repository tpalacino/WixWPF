using System;
using System.Globalization;
using System.Windows;
using System.Windows.Data;

namespace WixWPF
{
    /// <summary>Converts values between <see cref="Visibility"/> and <see cref="Boolean"/>.</summary>
    public class ConvertBoolToVisibility : IValueConverter
    {
        #region Member Variables

        /// <summary>The default true value mapped visibility.</summary>
        private Visibility _trueValue = Visibility.Visible;

        /// <summary>The default false value mapped visibility.</summary>
        private Visibility _falseValue = Visibility.Collapsed;

        #endregion Member Variables

        #region Properties

        #region TrueValue
        /// <summary>The visibility that maps to the Boolean value "True".</summary>
        /// <value><seealso cref="Visibility.Visible"/></value>
        public Visibility TrueValue { get { return _trueValue; } set { _trueValue = value; } }
        #endregion TrueValue

        #region FalseValue
        /// <summary>The visibility that maps to the Boolean value "False".</summary>
        /// <value><seealso cref="Visibility.Collapsed"/></value>
        public Visibility FalseValue { get { return _falseValue; } set { _falseValue = value; } }
        #endregion FalseValue

        #endregion Properties

        #region Methods

        #region Convert
        /// <summary>Converts the specified <paramref name="value"/> to a <see cref="Visibility"/>.</summary>
        /// <param name="value">The value to convert.</param>
        /// <param name="targetType">The type that is expected by the caller.</param>
        /// <param name="parameter">The converter parameters.</param>
        /// <param name="culture">The culture information for this conversion.</param>
        /// <returns>The value of the <seealso cref="TrueValue"/> property if the specified <paramref name="value"/> is true, otherwise the value of the <seealso cref="FalseValue"/> property.</returns>
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            bool realVal = false;
            string valueStr = value == null ? string.Empty : value.ToString();

            bool.TryParse(valueStr, out realVal);

            return realVal ? TrueValue : FalseValue;
        }
        #endregion Convert

        #region ConvertBack
        /// <summary>Converts the specified <paramref name="value"/> to a <see cref="Boolean"/>.</summary>
        /// <param name="value">The value to convert.</param>
        /// <param name="targetType">The type that is expected by the caller.</param>
        /// <param name="parameter">The converter parameters.</param>
        /// <param name="culture">The culture information for this conversion.</param>
        /// <returns>True if the specified <paramref name="value"/> matches the value of the <seealso cref="TrueValue"/>, otherwise False.</returns>
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            Visibility realVal = FalseValue;
            string valueStr = value == null ? string.Empty : value.ToString();

            try { realVal = (Visibility)Enum.Parse(typeof(Visibility), valueStr); }
            catch { realVal = FalseValue; }

            return TrueValue.Equals(realVal);
        }
        #endregion ConvertBack

        #endregion Methods
    }
}
