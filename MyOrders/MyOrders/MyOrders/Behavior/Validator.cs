public class Validator : Xamarin.Forms.Behavior<Entry>
{
    static readonly BindablePropertyKey IsValidPropertyKey =
        BindableProperty.CreateReadOnly(nameof(IsValid), typeof(bool), typeof(Validator), defaultValue: false);

    public static readonly BindableProperty IsValidProperty = IsValidPropertyKey.BindableProperty;

    public static readonly BindableProperty DecimalKodeProperty =
        Xamarin.Forms.BindableProperty.Create(nameof(DecimalKode), typeof(int), typeof(Validator), defaultValue: 0);

    Entry _entry { get; set; }


    public bool IsValid
    {
        get { return (bool)GetValue(IsValidProperty); }
        private set { SetValue(IsValidPropertyKey, value); }
    }

    public int DecimalKode
    {
        get { return (int)GetValue(DecimalKodeProperty); }
        set { SetValue(DecimalKodeProperty, value); }
    }

    protected override void OnPropertyChanged([CallerMemberName] string propertyName = null)
    {
        base.OnPropertyChanged(propertyName);
    }

    protected override void OnAttachedTo(Xamarin.Forms.Entry bindable)
    {
        base.OnAttachedTo(bindable);
        _entry = bindable;
        bindable.TextChanged += HandleTextChanged;
        bindable.BindingContextChanged += HandleBindingContextChanged;
    }
    protected override void OnDetachingFrom(Entry bindable)
    {
        base.OnDetachingFrom(bindable);
        bindable.TextChanged -= HandleTextChanged;

    }

    void HandleBindingContextChanged(object sender, EventArgs e)
    {
        BindingContext = _entry.BindingContext;
    }

    // Example Reg ^\d*\.\d{3}$
    // We use String concat to make it readable
    const string regex1 = @"^\d*(\.\d{0,";
    const string regex2 = @"})?$";
    void HandleTextChanged(object sender, TextChangedEventArgs e)
    {
        if (e.NewTextValue != null) // This happens when users click Cancel
        {
            string regex = regex1 + DecimalKode + regex2;
            IsValid = (Regex.IsMatch(e.NewTextValue, regex, RegexOptions.IgnoreCase, TimeSpan.FromMilliseconds(250)));
            ((Entry)sender).TextColor = IsValid ? Color.Default : Color.Red;
        }
    }
}