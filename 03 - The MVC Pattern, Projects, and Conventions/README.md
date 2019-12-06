## The MVC Pattern, Projects, and Conventions

### Entendiendo el patron MVC

#### Models
contienen o representan los datos
* El modelo en una aplicacion MVC deberia: 
  * Contener los datos del dominio.
  * Contener la lógica para crear, administrar y modificar los datos del dominio.
  * Proporcione una API limpia que exponga los datos del modelo y las operaciones en él.
* El modelo no deberia
  * Los detalles del mecanismo de almacenamiento de datos no deben exponerse a controladores y vistas
  * Contiene lógica que transforma el modelo en función de la interacción del usuario
  * Contener lógica para mostrar datos al usuario

Muchos desarrolladores nuevos en el patrón MVC se confunden con la idea de incluir la lógica en el modelo de datos, creyendo que el objetivo del patrón MVC es separar los datos de la lógica. Esta es una interpretación errónea: el objetivo del patrón MVC es dividir una aplicación en tres áreas funcionales, cada una de las cuales puede contener lógica y datos. El objetivo no es eliminar la lógica del modelo. Más bien, es para asegurarse de que el modelo solo contenga lógica para crear y administrar los datos del modelo.

#### Controllers
Los controladores son el tejido conectivo en el patrón MVC, actuando como conductos entre el modelo de datos y las vistas.
* Un controlador construido utilizando el patrón MVC debería
  * Contener las acciones necesarias para actualizar el modelo en función de la interacción del usuario.
* El controlador no deberia
  * Contiene lógica que gestiona la apariencia de los datos (ese es el trabajo de la vista)
  * Contiene lógica que gestiona la persistencia de datos (ese es el trabajo del modelo)
  
#### Views
Las vistas contienen la lógica requerida para mostrar datos al usuario o para capturar datos del usuario para que puedan ser procesados por una acción del controlador.
* Las vistas deberían
  * Contener la lógica y el marcado necesarios para presentar los datos al usuario.
* Las vistas no deberían
  * Contiene lógica compleja (esto se coloca mejor en un controlador)
  * Contiene lógica que crea, almacena o manipula el modelo de dominio.

