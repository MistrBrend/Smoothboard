![image](https://github.com/MistrBrend/Smoothboard/assets/104073696/f3b32325-9846-43f0-ad7b-8a20a86d27aa)



# Description --

Bij deze opdracht moet ik een smoothboard applicatie maken, dit word een website waarin de eigenaar van smoothboard alles kan bijhouden voor zijn bedrijf, dit zijn de volgende benodigheden die de eigenaar wilt bijhouden.

Instructies voor Sean:
 - Om klanten en opdrachten bij te houden moet je een account hebben. Rechts boven in de website kan je klikken op register om een account aan te maken of login als je al een account hebt. Als je ingelogd bent op je account heb je pas toegang tot de klanten en opdrachten pagina's.

**Klant gegevens**
> - Id - [Int]
> - Voornaam - [String]
> - Achternaam - [String]
> - Adres - [String]
> - Telefoonnummer - [String]
> - E-mailadres - [String]
> - EigenSurfboardDesign - [Boolean]

 

**Gegevens over de surfboard** 
> - Hoe lang is de surfboard?    ->    _260 cm  t/m 370 cm ( stappen van 10cm )_ 
> - Hoe breed is de surfboard?   ->    _ 65 cm t/m 85cm ( stappen van 5cm )_  
> - Wanneer brengt de klant het surfboard? 
> - Wanneer komt de klant het surfboard ophalen?	 
> - Akkoord van de klant over de surfboard ontwerp (boolean: yes/no)
> - Bij de ontwerp de datum en tijd bij te zetten. 

**Opdracht gegevens** 
> - KlantNaam - [Int]
> - DatumGebracht - [String]
> - DatumOpgehaald - [String]
> - AkkoordDesign - [Boolean]
> - SurfboardDesign - [String]
> - Status - [String]
> - Lengte - [Enumeration] (LengteNum)
> - Breedte - [Enumeration] (BreedteNum)

# User stories --

**Must have**
> - Als Sean wil ik klantgegevens kunnen invoeren. ( create )
> - Als sean wil ik klantgegevens kunnen bijhouden ( read )
> - Als Sean wil ik klantgegevens kunnen veranderen. ( update )
> - Als Sean wil ik klantgegevens kunnen verwijderen. ( delete )
> - Als sean wil ik de maten ( breedte en hoogte ) van de surfboard weten per klant
> - Als sean wil ik een een voorbeeld van de surfboard design sturen naar mijn klant ( concept design )
> - Als sean wil ik een akkoord voor de surfboard design voorbeeld
> - Als klant wil ik ook de mogelijkheid hebben om zelf een surfboard design te sturen
> - Als sean wil ik de tijd en datum willen weten dat de surfboard wordt gebracht en opgehaald
> - Als sean wil ik dat de klantengegevens veilig staan ( privacy )
  
**Should have**
> - Als sean wil ik alle opdrachten kunnen inzien

**Could have**
> - Als sean wil ik notificaties ontvangen wanneer een opdracht is afgerond en klaar is om opgehaald te worden.
> - Als sean wil ik de mogelijkheid hebben om opdrachten te markeren als "spoed"
> - Als klant wil ik de status van mijn opdracht kunnen controleren


