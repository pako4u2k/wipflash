# Introduction #

We've run into problems a few times with WiPFlash and Microsoft's security model, e.g. when using a Samba drive or a network share.

Apparently the restriction has been relaxed in .NET 3.5 SP 1. More info [here](http://blogs.msdn.com/b/brada/archive/2008/08/13/net-framework-3-5-sp1-allows-managed-code-to-be-launched-from-a-network-share.aspx).

# Details #

```
"C:\WINDOWS\Microsoft.NET\Framework\v2.0.50727\CasPol.exe" -addgroup 1.2 -url file:///L:/* (file:///L:/*) FullTrust
```

Replace L: with your appropriate drive.

(From [JohnnyNine](http://johnnynine.com/blog/RunningANetApplicationFromANetworkShare.aspx) with thanks)