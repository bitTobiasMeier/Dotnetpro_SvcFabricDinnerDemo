# Dinner Demo
Beispielapplikation zum Artikel "Azure Service Fabric in der Tiefe" in der dotnetpro 2/18: https://www.dotnetpro.de/core/cloud/dinner-demo-1459712.html 

Die Anwendung und der Artikel wurde ursprünglich für Service Fabric SDK 2.7 geschrieben. 
Im Branch https://github.com/bitTobiasMeier/Dotnetpro_SvcFabricDinnerDemo/tree/Upgrade_to_SF_2.8 sind die Assemblies von SDK 2.8 referenziert.

Im Branch https://github.com/bitTobiasMeier/Dotnetpro_SvcFabricDinnerDemo/tree/SF3.0 sind die Assemblies von SDK 3.0 referenziert.


Falls im lokalen Entwicklungscluster mit Service Fabric SDK 3.0 der DNS Service nicht startet bitte folgende Anweisung in einer CMD mit Administrative Rights eingeben: 
sc stop sharedaccess 

