# Introduction #

Microsoft UI Automation can be really, really slow if you don't take steps to make it faster. Rather than spend ages making WiPFlash guess at how to do that for you in your particular context, here are some hints and tips for speeding up your scenarios.

# Find and cache the components #

In the enterprise project which drove WiPFlash, a lot of components appeared or disappeared dynamically. We therefore chose not to write caches into WiPFlash. However, there's nothing stopping you from creating a cache of your own, if you want to.

# Don't search for everything from top-level windows or panels #

If you have a large window with trees of components in it then WiPFlash will take a while to find your components (because Microsoft UI Automation does). Instead, look for sub-panels and navigate down the tree a bit before looking for the individual components. This will speed up your scenarios considerably! You can also cache any panels which aren't dynamically generated, even if the components within them are.

# You can wait for events on something different to the thing with which you're working #

This is mostly good for failing scenarios or components which don't provide suitable events when they change. If you have another component which changes at the same time, you can wait for that to change instead.