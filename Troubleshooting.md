# Introduction #

WiPFlash uses Microsoft UI Automation, which pretends to be a user. If a user can't do it, WiPFlash can't do it either.

# Details #

## Newly enabled control is clicked or used with no effect ##

Chances are that your newly enabled control wasn't enabled fast enough for WiPFlash, which pretends to be a very _fast_ user. Please use `<control>.WaitFor` to wait for the enabled control. `WaitFor` takes two arguments:

  1. An expression to check to see if it's true. WiPFlash may call this more than once if it's false.

  1. A failure handler in case it times out.

## WiPFlash doesn't raise a mouse click / key press / etc. ##

Microsoft UI Automation (on which WiPFlash is based) cares more about invoking controls than actually mimicking mouse and keyboard clicks. If you invoke the button or text box in some other way - for instance, tabbing onto it and hitting space, or cutting-and-pasting into the box - you may find that your application doesn't work either.

You'll probably find it's much harder to write examples at a class level, too.

We invite you to look at the MVVM implementations in the pet shop for alternatives. Responding to state changes, or using WPF's command pattern for buttons etc., is generally more robust than responding to mouse or key events.