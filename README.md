
# Friends Sample App for Windows Phone

<a href="https://github.com/telerik/platform-friends-windowsphone" target="_blank"><img style="padding-left:20px" src="http://docs.telerik.com/platform/appbuilder/sample-apps/images/get-github.png" alt="Get from GitHub" title="Get from GitHub"></a>

* [Overview](#overview)
* [Screenshots](#screenshots)
* [Requirements](#requirements)
* [Configuration](#configuration)
* [Running the Sample](#running-the-sample)

## Overview

This repository contains the Telerik Friends app for Windows Phone. It is a sample mobile app demonstrating how to integrate a large gamut of Telerik Platform services into a native Windows Phone mobile application.

The Telerik Friends sample app showcases these features and SDKs:

- Cloud data access (Telerik Backend Services)
- Working with files (Telerik Backend Services)
- User registration and authentication (Telerik Backend Services)
- Authentication with social login providers (Facebook, Google, etc.) (Telerik Backend Services)
- Using custom user account fields (Telerik Backend Services)
- Basic app analytics (Telerik Analytics)
- Tracking feature usage (Telerik Analytics)

To implement all the features listed above, the sample app utilizes the following Telerik products and SDKs:

- Telerik Backend Services - this is where all data, files, and user accounts are stored in the cloud
- Telerik Backend Services .NET SDK - to connect the app to Telerik Backend Services
- Telerik Analytics - used to store analytics data in the cloud
- Telerik Analytics .NET SDK - to connect the app with Telerik Analytics

## Screenshots

Login Screen|Main Menu|Activity Details|Friends View
---|---|---|---
![Login Screen](https://raw.githubusercontent.com/telerik/platform-friends-windowsphone/master/screenshots/wp-login-screen.png)|![Activities stream view](https://raw.githubusercontent.com/telerik/platform-friends-windowsphone/master/screenshots/wp-menu.png)|![Activity details view](https://raw.githubusercontent.com/telerik/platform-friends-windowsphone/master/screenshots/wp-activitiy-details.png)|![Activity details view](https://raw.githubusercontent.com/telerik/platform-friends-windowsphone/master/screenshots/wp-friends.png)

## Requirements

Before you begin, you need to ensure that you have the following:

- **An active Telerik Platform account**
Ensure that you can log in to a Telerik Platform account. This can be a free trial account. Depending on your license you may not be able to use all app features. For more information on what is included in the different editions, check out the pricing page. All features included in the sample app work during the free trial period.

- **A compatible Microsoft Visual Studio version**
Visual Studio 2010 or later must be installed on your computer.

- **Windows Phone SDK 8.0**
The sample app comes as a Windows Phone 8 Application project. This means that you must have the Windows Phone SDK 8.0 installed to open the project in Microsoft Visual Studio.

## Configuration

The Friends sample app comes fully functional, but to see it in action you must link it to your own Telerik Platform account.

What you need to set:

### API Key for Telerik Backend Services

This is a unique string that links the sample mobile app to a project in Telerik Backend Services where all the data is read from/saved. When creating the project, you must base it on the Friends sample Backend Services project that has all the necessary data prepopulated.

You must use this project's API key. To set it in the app:

1. Open the `ConnectionSettings.cs` file.
2. Find the `public static string EverliveApiKey = "your-api-key-here";` line. 
3. Replace `your-api-key-here` with the API Key of your Friends Backend Services project.

> If you happen to break the structure of the automatically generated Friends sample project, you can delete it and a fresh instance will be created again for you automatically. Alternatively, you could create a new project and choose to start from a Friends template, instead of starting from a blank project.

### (Optional) Project Key for Telerik Analytics

This is a unique string that links the sample mobile app to a Telerik Analytics project in your account. If you do not set this the sample will still work, but no analytics data will be collected.
	
1. Open the `ConnectionSettings.cs` file.
2. Find the `public static string AnalyticsProjectKey = "your-analytics-project-key-here";` line.
3. Replace `your-analytics-project-key-here` with the Project Key of your Friends Analytics project.

### (Optional) Facebook App ID
To demonstrate social login, we've pre-initialized the sample to use a purpose-built Facebook app by Telerik. However, you still need to enable Facebook integration in the Telerik Platform portal:

1. Go to your app.
2. Click the Backend Services project that you are using.
3. Navigate to **Users > Authentication**.
4. Ensure that the Facebook box is checked.

> Note that if you intend to use the code for a production app you need to set up your own Facebook application and adjust the Facebook app ID as follows:
	
1. Open the `Views/LoginPage.xaml` file.
2. Find the `telerikCloud:FacebookLoginProvider` tag.
3. Replace the `ClientId` and `ClientSecret` attribute values with your Facebook app values.

### (Optional) Google Client ID

To demonstrate social login, we've pre-initialized the sample to use a Google Client ID owned by Telerik. However, you still need to enable Google integration in the Telerik Platform portal:

1. Go to your app.
2. Click the Backend Services project that you are using.
3. Navigate to **Users > Authentication**.
4. Ensure that the Google box is checked.

> Note that if you intend to use the code for a production app you need to set up your own Google Client ID and adjust the code as follows:

1. Open the `Views/LoginPage.xaml` file.
2. Find the `telerikCloud:GoogleLoginProvider` tag.
3. Replace the `ClientId` and `ClientSecret` attribute values with your Google app values.

### (Optional) Microsoft Account

To demonstrate social login, we've pre-initialized the sample to use a  Microsoft Account Client ID owned by Telerik. However, you still need to enable Microsoft Account integration in the Telerik Platform portal:

1. Go to your app.
2. Click the Backend Services project that you are using.
3. Navigate to **Users > Authentication**.
4. Ensure that the Windows Live box is checked.

> Note that if you intend to use the code for a production app you need to set up your own Microsoft Account Client ID and adjust the code as follows:

1. Open the `Views/LoginPage.xaml` file.
2. Find the `telerikCloud:LiveIDLoginProvider` tag.
3. Replace the `ClientId` and `ClientSecret` attribute values with your Microsoft Account app values.

## Running the Sample

Once the app is configured, click **Run** in Visual Studio to run it either on a real device or in an emulator.

> Ensure that the emulator or the device that you are using has Internet connectivity when running the sample.

