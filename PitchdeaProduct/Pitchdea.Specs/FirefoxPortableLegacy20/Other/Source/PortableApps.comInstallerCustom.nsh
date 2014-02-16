!macro CustomCodePreInstall
	CreateDirectory "$INSTDIR\Data\settings"
	WriteINIStr "$INSTDIR\Data\settings\FirefoxPortableSettings.ini" "FirefoxPortableSettings" "AgreedToLicense" "2"
!macroend