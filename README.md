# SandKeyDisplay
# StellarMLS

This code is written in C# 6 using .NET Core, Javascript (JQuery) and HTML razor pages and is deployed on an AWS EC2 server. Sensitive data is masked using AWS Systems Manager.

This code runs a touch screen kiosk at a real estate office on Clearwater Beach. Users are able to search for homes for sale or lease on Clearwater Beach by touching a glass window with a touch sensitive display behind it, kinda like a big iPhone behind a window. As a stand alone display, it's not designed to be viewed on browsers not running 1080p, but can be viewed at

http://century21coasttocoast.net/Home/Locked 

=> so don't be diappointed if it looks "wonky".

Originally written in 2009, the code has been updated/refreshed to use .NET Core and the StellarMLS API to retrieve MLS listing information instead of downloading a csv file and updating a database. Almost all of the code in the wwwroot is original.

I will be updating this periodically.
