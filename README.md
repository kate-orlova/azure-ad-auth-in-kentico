# Azure AD authentication in Kentico
Azure AD authentication in Kentico project implements an Azure Active Directory identity provider for Kentico to verify user accounts existing in a business directory and issue security tokens upon successful authentication of those users.

Prior to start integrating make sure that a Kentico application planning to outsource an authentication to Azure AD is registered in Azure AD first. Azure AD registers and uniquely identifies an application in its directory. This solution supports the definition of registration parameters in Kentico Settings at a website / global level, the key configuration fields are
 * Client Id
 * Application Key
 * Tenant Id
 * Azure Groups to sync

# Contribution
Hope you found the above solution helpful, your contributions and suggestions will be very much appreciated. Please submit a pull request with your code enhancements.
