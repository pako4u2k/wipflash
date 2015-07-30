### By `automationId` ###

This is WiPFlash's default method of finding components. The `automationId` usually comes from your `Name` property in WPF code.

### By `PropertyCondition` ###

Microsoft UI's properties return lots of information about your elements. Most properties are static and are found on the `AutomationElement` class. You may also be interested in `AndCondition` or `OrCondition`.

WiPFlash provides a number of these on its `FindBy` class, so that you don't have to go looking them up yourself.

```
var accessoriesTab = Window.Find<Tab>(FindBy.WpfTitle("Accessories"));
```

### Upgrading from 0.0.0.X ###

Previous versions of WiPFlash took a property and a value. Just use the same property inside a `PropertyCondition` instead.