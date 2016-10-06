# SauceNao-Windows
Use SauceNao in Windows natively so you can find the source of every image in your local filesystem through [SauceNAO](http://saucenao.com).

Why
---
I needed something like [Image Search Options](https://addons.mozilla.org/it/firefox/addon/image-search-options/?src=userprofile) for the images I have already saved in my computer but I didn't find any decent client.

Usage
-----
`> SauceNao-Windows.exe <SAUCENAO_API_KEY> <IMGUR_API_KEY> <IMAGE_PATH> [PROXY IP:PORT]`

## Adding API keys

### SauceNAO

You can get a `SAUCENAO_API_KEY` by [creating a new account on SauceNAO](https://saucenao.com/user.php) and [viewing your search API settings](https://saucenao.com/user.php?page=search-api).

## Imgur

You can get a `IMGUR_API_KEY` by [registering an application on api.imgur.com](http://api.imgur.com/oauth2/addclient).

Bind to the right-click
-----------------------
In order to *SauceNAO* an image from your local filesystem, just set the correct variables inside `regedit.bat` and then run it as administrator. [Result](https://twitter.com/GiovanniCapuano/status/622540459974524928).