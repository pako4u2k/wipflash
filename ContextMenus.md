# Introduction #

ContextMenus are a pain to use and even worse to automate. Hints and tips here have been verified on Windows XP. If you're running into problems maybe one of these will help you.

# Details #

Wouldn't it be nice if we could just attach an ItemsSource, add items to it and have a context menu populate appropriately?

Unfortunately, the context menu does not like attaching commands to items when the command is found using a FindAncestor binding. The initial menu items will be fine, but by the time you come to add new items, the chances are that it will be found outside of the visual tree. FindAncestor then fails to find the correct data context for the command binding.

You could use PlacementTarget to find the command. Unfortunately, selections of items in the menu don't work with UI Automation if you do that, even though it works manually.

My work around is to attach the context menu to the items in the menu themselves. This seems to work in all circumstances.

If you can find any other ways to get the same capabilities in your application, I highly recommend avoiding context menus altogether.