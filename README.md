
[![GitHub release](https://img.shields.io/github/release-date/kate-orlova/azure-ad-auth-in-kentico.svg?style=flat)](https://github.com/kate-orlova/azure-ad-auth-in-kentico/releases/tag/MVPRelease)
[![GitHub license](https://img.shields.io/github/license/kate-orlova/azure-ad-auth-in-kentico.svg)](https://github.com/kate-orlova/azure-ad-auth-in-kentico/blob/master/LICENSE)
![GitHub language count](https://img.shields.io/github/languages/count/kate-orlova/azure-ad-auth-in-kentico.svg?style=flat)
![GitHub top language](https://img.shields.io/github/languages/top/kate-orlova/azure-ad-auth-in-kentico.svg?style=flat)
![GitHub repo size](https://img.shields.io/github/repo-size/kate-orlova/azure-ad-auth-in-kentico.svg?style=flat)

# Azure AD authentication in Kentico
Azure Active Directory (AD) authentication in Kentico project implements an Azure AD identity provider for Kentico 10, 11 and 12 to verify user accounts existing in a business directory and issue security tokens upon successful authentication of those users.

The following diagram demonstrates the login process flow
![Sign in process flow](/assets/sign_in_flow.png)

Prior to start integrating make sure that a Kentico application planning to outsource an authentication to Azure AD is registered in Azure AD first. Azure AD registers and uniquely identifies an application in its directory. This solution supports the definition of registration parameters in Kentico Settings at a website / global level, the key configuration fields are
 * Client Id
 * Application Key
 * Tenant Id
 * Azure Groups to sync
 
The below screnshots will guide you where to find the required Azure AD settings:
![Azure application overview](/assets/azure_app.png)

![Azure application keys](/assets/azure_app_key.png)

It is also important to enable access for your application as follows:  
![Azure application permissions](/assets/azure_app_permissions.png)

The module comes with two user controls for Login and Logout functionality, and a proxy script (_/pages/AzureAuthRedirect.aspx_) implementing the integration routine. So, that you can adapt the user interface for your needs easily.

Another thing to check in Settings is that you have specified a login page for users in front-end, go to _"Settings -> Security & Membership -> Content"_ and set a _"Website logon page URL"_ field to your login page with the placed Login control on it.
![Login page URL](/assets/login_page.png)

How to secure a page on your Kentico website?
1. Select a page you wish to put behind the login
1. Go to _Page Properties -> Security_ tab
1. Select the required user roles to restrict access to the page in _"Users and Roles"_ field under _Permissions_ section
1. Specify access rights in _"Access rights"_ table
1. Set a _"Requires authentication"_ to "Yes" under _Access_ section

<img src="https://github.com/kate-orlova/azure-ad-auth-in-kentico/blob/master/assets/page_permissions.png" alt="Kentico page access permissions: Users and Roles" width="350">
<img src="https://github.com/kate-orlova/azure-ad-auth-in-kentico/blob/master/assets/page_access.png" alt="Kentico page access permissions" width="350">

# Installation steps
1. Import a relevant Kentico module package for your CMS version:
   1. Kentico 10: _Kentico10\AzureADAuthenticationModule_K10.zip_
   1. Kentico 11: _Kentico11\AzureADAuthenticationModule_K11.zip_
   1. Kentico 12: _Kentico12\AzureADAuthenticationModule_K12.zip_

# Configuration Guide
1. Make sure that your Kentico application is registered in Azure AD;
1. Include AzureADAuthInKentico project into your Kentico solution;
1. Restore Nuget packages for AzureADAuthInKentico project;
1. Check Kentico references in AzureADAuthInKentico project (the ones pointing to /lib/ folder) and make sure that you use your Kentico assemblies;
1. Define Azure AD registration parameters in Kentico Settings at a website / global level: _Client Id, Application Key, Tenant Id, Azure Groups to sync_ (see above about where to find them);
1. Build and run;
1. Now you are ready to secure your Kentico pages and use Azure AD accounts to access them:
   - Specify a login page for users in front-end, go to _"Settings -> Security & Membership -> Content"_ and set a _"Website logon page URL"_ field to your login page with the placed Login control on it;
   - Secure a page you want to be behind login (_see the "How to secure a page on your Kentico website?" section above_).
   
That is all, enjoy!

# Contribution
Hope you found the above solution helpful, your contributions and suggestions will be very much appreciated. Please submit a pull request with your code enhancements.

# License
The Azure AD authentication in Kentico module is released under the MIT license what means that you can modify and use it how you want even for commercial use. Please give it a star if you like it and your experience was positive.
