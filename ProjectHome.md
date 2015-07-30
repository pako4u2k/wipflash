  * WPF UI Automation
  * Clean source code to help you understand UI Automation patterns
  * Examples showing how to use each aspect of WiPFlash
  * Lightweight, focused on common UI components and usage patterns
  * Complete access to underlying .NET automation elements
  * Pluggable, dependency-injected factories, finders etc. for easy extension
  * Speed!

This is WiPFlash's example UI. To get started, see [the Two Minute Tutorial!](TwoMinuteTutorial.md)

![http://wipflash.googlecode.com/files/wipflash-front.png](http://wipflash.googlecode.com/files/wipflash-front.png)
![http://wipflash.googlecode.com/files/wipflash-back.png](http://wipflash.googlecode.com/files/wipflash-back.png)

For more on how to use WiPFlash, please [look at the scenarios](http://code.google.com/p/wipflash/source/browse/Example.PetShop.Scenarios/PetRegistrationAndPurchase.cs) and the [associated steps](http://code.google.com/p/wipflash/source/browse/#hg/Example.PetShop.Scenarios/Steps) which do the work. There are also [more detailed examples for each component](http://code.google.com/p/wipflash/source/browse/#hg/Examples/Component). You may also benefit from a UI discovery tool like [Snoop UI](http://snoopwpf.codeplex.com/) to help you work out how to identify windows and elements inside them.

White, the most popular open-source .NET UI Automation tool, provides capabilities for Win32, WinForms and SWT, as well as WPF. If this project doesn't meet your needs, [look at White instead](http://code.google.com/p/white-project/).

Currently, WiPFlash can:
  * Launch or reuse an existing application or window
  * Enter text in TextBox, RichTextBox, and editable ComboBox
  * Retrieve text from RichTextBox (and its children), TextBox, TextBlock, Label, editable ComboBox
  * Select values in ListBox or ComboBox, and retrieve the selection
  * Click Buttons
  * Toggle CheckBox and RadioButton
  * Get values from a GridView, or look for a row of values within the GridView
  * Wait for common events like text or selection changing or items becoming available
  * Wait for any event you define
  * Scroll up and down until something is found (using a user-defined check)
  * Raise context menus

We hope you enjoy WiPFlash, and encourage you to give feedback on features, as well as the quality of examples and code!