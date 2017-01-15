# SauceNao-Windows
Use SauceNao in Windows natively so you can find the source of every image in your local filesystem through [SauceNAO](http://saucenao.com).

Why
---
I needed something like [Image Search Options](https://addons.mozilla.org/it/firefox/addon/image-search-options/?src=userprofile) for the images I have already saved in my computer but I didn't find any decent client.

## Setup
The suggested way to install SauceNao-Windows is just by running the [setup](https://github.com/RoxasShadow/SauceNao-Windows/blob/master/Installer/setup.exe?raw=true).

If you want to bind this application to the right click (so that when you right click on an image file you can see the "SauceNao!" entry as in [here](https://twitter.com/RoxasShadowRS/status/622540459974524928)
just follow the instructions in the installer by filling the two fields that ask for the API keys, that you can get by reading the related sections in this README file.

If you want to execute a manual installation, please look at the bottom of this file.

## Adding API keys

### SauceNAO

You can get a `SAUCENAO_API_KEY` by [creating a new account on SauceNAO](https://saucenao.com/user.php) and [viewing your search API settings](https://saucenao.com/user.php?page=search-api).

## Imgur

You can get a `IMGUR_API_KEY` by [registering an application on api.imgur.com](http://api.imgur.com/oauth2/addclient).

## Manual installation
The executable is stored in `SauceNao-Windows/bin/Release`. You need the `exe` file and the `dll` file only, which must be stored in the same folder to work properly.

Usage
-----
`> SauceNao-Windows.exe <SAUCENAO_API_KEY> <IMGUR_API_KEY> <IMAGE_PATH> [PROXY IP:PORT]`

Bind to the right-click
-----------------------
In order to *SauceNAO* an image from your local filesystem, just set the correct variables inside `regedit.bat` and then run it as administrator. [Result](https://twitter.com/RoxasShadowRS/status/622540459974524928).