# Two Minute Tutorial #

## Launching the application ##

You can launch a new application, recycle an existing application or just make sure that your application gets launched if it isn't already.

The `ApplicationLauncher` can take a timeout.

The third argument here is a delegate that you want to use if the launch fails. It will give you a message.

If you're not familiar with C# delegates, there's [a nice tutorial here](http://www.csharp-station.com/Tutorials/lesson14.aspx). You may also want to use a lambda - `(message) => DoThisWith(message)`, or even just `(message) => DoThisWith`.

```
Application application = new ApplicationLauncher(TimeSpan.Parse("00:00:20"))
  .LaunchOrRecycle(APP_NAME, APP_PATH, Assert.Fail); 
```


## Finding the window ##

```
var window = application.FindWindow(WINDOW_NAME) 
```

## Reading from and manipulating components ##

First [find the components](FindingComponents.md):

```
var totalLabel = window.Find<Label>("totalOutput");
```

Then use them:

```
string actualTotal = _universe.Window.Find<Label>("totalOutput").Text;
Assert.AreEqual(expectedTotal, actualTotal);
```

If you've got an object instead of a string, the string will be the `ToString()` of that object:

```
window.Find<ComboBox>("basketPetInput").Select("Pet[" + name + "]"); 
```

## Waiting for things to happen ##

When waiting for something, pass a delegate or lambda which will tell WiPFlash whether the waiting worked or not. The original WiPFlash element will be passed to the delegate so that you can use its properties or contents in the check, if you want to.

WiPFlash doesn't poll. Instead, it provides sensisble events to wait for - so for a combo box, it will wait for items to be selected, or for a new item to appear in its list. You can pass in [a different event](http://code.google.com/p/wipflash/source/browse/#hg/WiPFlash/Framework/Events) if you prefer.

The second argument is a handler for when things go wrong, and the waiting doesn't work.

```
comboBox.WaitFor(
                cb => new List<string>(cb.Items).Contains("Pet[" + name + "]"),
                e => Assert.Fail("Combo box should have contained a pet with name {0}",  
                     name));
```

## Scrolling ##

WiPFlash is based on Microsoft UI Automation. Sometimes, if you have items in a list or something else which is scrolled off the screen, you may need to scroll to use it.

WiPFlash will scroll until a check is true, just like waiting. The second argument is a handler again. The original WiPFlash `ScrollViewer` is passed to both delegates so that you can use it if you want to.

```
scrollViewer.ScrollUp(s => s.Contains(name), 
                     (s2) => Assert.Fail("Should have scrolled to {0}", name));
```

## More components ##

There are examples showing the behaviour of all of WiPFlash's components [here](http://code.google.com/p/wipflash/source/browse/#hg/Examples/Component).