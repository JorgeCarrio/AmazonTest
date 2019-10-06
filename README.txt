Herramientas para realizar la prueba:
 - La prueba se ha realizado sobre el navegador Chrome v77.0.3865.90 (Build oficial) (64 bits)
 - Microsoft Visual Studio Community 2019 v16.3.2 con los siguientes paquetes instalados en la solución:
	- DotNetSeleniumExtras.WaitHelpers v3.11.0
	- NUnit v3.12.0
	- NUnit3TestAdapter v3.15.1
	- Selenium.WebDriver v3.141.0
	- Selenium.WebDriver.ChromeDriver v77.0.3865.4000
 
La ejecución se ha realizado mediante el Visual Studio, abriendo la ventana de TestExplorer. También se podría ejecutar mediante NUnit-Console o NUnit Gui Runner.

El test se ha diseñado mediante NUnit y se encuentra dentro de la clase 'ChromeTests'. Se puede observar que se ha configurado para aceptar distintos artículos a comprar como parámetros de entrada.
En 'ChromeTests' se puede encontrar la estructura de SetUp, Test y TearDown. 
 - En el SetUp se configura el navegador para cada test, en este caso se ha configurado en modo oculto, y también se añade al driver una espera implícita para trabajar con los distintos elementos. Se ha visto que con 0.75 segundos era suficiente.
 - En Test se incluyen los pasos de prueba. Si ocurre algún error se capturará y la prueba dará un error.
 - En el TearDown cerramos la conexión con el driver.

Se ha considerado que utilizando la metodología Page Object Model podemos conseguir reducir el tiempo de mantenimiento para futuros cambios. Así si por ejemplo en algún momento cambian las propiedades de algún objeto, con cambiarlo en una línea concreta tendríamos todas las pruebas volviendo a funcionar correctamente.
Las clases POM se encuentran dentro del directorio PageObjects (HomePage y NavegationPage). En cada una de ellas se pueden observar los objetos declarados arriba y los métodos a continuación. Se ha considerado que dentro de la página de Amazon tenemos la parte de navegación de la cabecera inmutable. 
Así pues, se ha considerado mejor crear dicha clase para que las demás hereden los atributos de navegación, como buscar, ir a carrito... Son elementos que independientemente del paso del test en que nos encontremos permanecen en la parte superior.

Se ha intentado que el código sea legible y entendible siguiendo las buenas prácticas.
