Step 1 (kan skippes hvis system eksisterer på serviceplatform:

* Bestil funktions certifikat fra IT.
* Installer privat certifikat på test + prod miljø
* Udsted public certifikat som (.cer) eller hent det fra medarbejdersignatur.dk.
* Opret IT-system + serviceaftale på serviceplatformen.
* Godkend service aftale på serviceplatformen.


Step 2:

* Download teknisk specifikation fra:
* https://www.serviceplatformen.dk/administration/serviceOverview/show?uuid=e6be2436-bf35-4df2-83fe-925142825dc2
* (https://www.serviceplatformen.dk/administration/contract-doc/contracts/ServiceContract-e6be2436-bf35-4df2-83fe-925142825dc2.zip)


Step4:

* Importer \wsdl\context\PersonBaseDataExtendedService.wsdl i visual studio

![alt text](https://github.com/SkanderborgKommune/ServicePlatformIntegrationer-Person_stamdata_local/blob/master/importservice.JPG)


Step 5:

* Implementer koden fra dette github projekt.
* Endpoint.Config i enten Web.Config eller App.Config.


Step 6:
* Log på serviceplatformen som: Bruger (Kan registrere virksomhedens it-systemer, anmode om serviceaftaler og se forbrug.)
* Find UUID'er:

![alt text](https://github.com/SkanderborgKommune/ServicePlatformIntegrationer-Person_stamdata_local/blob/master/importservice.JPG)
