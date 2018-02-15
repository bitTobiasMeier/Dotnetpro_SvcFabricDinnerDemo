# Dinner Demo
Beispielapplikation zum Artikel "Azure Service Fabric in der Tiefe" in der dotnetpro 2/18: https://www.dotnetpro.de/core/cloud/dinner-demo-1459712.html bzw. dotnetpro 3/18 https://www.dotnetpro.de/core/cloud/stateful-reliable-aktoren-1470112.html 

Die Anwendung und der Artikel wurde ursprünglich für Service Fabric SDK 2.7 geschrieben. 
Im Branch https://github.com/bitTobiasMeier/Dotnetpro_SvcFabricDinnerDemo/tree/Upgrade_to_SF_2.8 sind die Assemblies von SDK 2.8 referenziert.

Im Branch https://github.com/bitTobiasMeier/Dotnetpro_SvcFabricDinnerDemo/tree/SF3.0 sind die Assemblies von SDK 3.0 referenziert.

Falls im lokalen Entwicklungscluster mit Service Fabric SDK 3.0 der DNS Service nicht startet bitte folgende Anweisung in einer CMD mit Administrative Rights eingeben: 
sc stop sharedaccess 
Weitere Infos unter https://blog.bridging-it.de/blog/blogeintrag_5760.html

Beim Deployment der Anwendung in ein Azure Service Fabric - Cluster treten zur Zeit (Visual Studio 2017 15.5.6 und SF 3.0) Timeouts auf. Eine Anleitung zum Workaround ist im Blogartikel https://blog.bridging-it.de/blog/blogeintrag_5825.html aufgeführt.
