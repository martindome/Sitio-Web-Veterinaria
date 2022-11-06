Para poder guardar el backuop en la carpeta, tenes que agregar el usuario "Todos" en la seguridad y darle control total

Para evitar que los validators no te dejen salir de una pagina o hacer otra cosa que no tiene que ver con eso, agregarle a los textbox, validators y buttons de validacion el tag ValidationGroup="Guardar"

git log --decorate --oneline --tags --no-walk --> para ver solo los commits tag
git log --decorate --oneline --tags --graph --> para ver el path de commits        

//https://www.c-sharpcorner.com/blogs/how-to-bind-gridview-using-json-and-webservices1
        //https://www.mikesdotnetting.com/article/97/cascading-dropdownlists-with-jquery-and-asp-net
        //https://www.mikesdotnetting.com/Article/96/Handling-JSON-Arrays-returned-from-ASP.NET-Web-Services-with-jQuery
	//https://stackoverflow.com/questions/71853391/message-shows-undefined-when-ajax-post-in-asp-net
        Setart en RouteConfing.cs //settings.AutoRedirectMode = RedirectMode.Permanent; (comentar la linea) para que pueda ir al codebehind a buscar el metodo
	https://www.technical-recipes.com/2017/creating-and-consuming-a-web-service-in-c-net/ Como agregar referencia para utilizar web service
	//https://www.javatpoint.com/web-services-in-c-sharp Como agregar referencia a WebService C# (Pero este si ando)
	https://www.aspsnippets.com/Articles/Call-Server-Side-function-from-JavaScript-without-PostBack-in-ASPNet.aspx#:~:text=and%20VB.Net.-,In%20order%20to%20call%20a%20Server%20Side%20function%20from%20JavaScript,without%20PostBack%20in%20ASP.Net. Como correr desde client un metodo (sin ajax)




# Universidad Abierta Interamericana

## Facultad de Tecnolog!a Inform tica

# Lenguajes de Programaci"n para la Administraci"n

![](RackMultipart20220914-1-yds0ay_html_3951fb68d46b346.png)

## Trabajo Pr ctico Integrador

Docente: Ing. S bato, Santiago

Alumnos:

Alfano, Magali

Bertinelli, Patricio

Costa, Juan Cruz

Dome, Martin

Rodriguez Arata, Damian

Alvarez, Gaston

## **Vndice**

**[Vndice](#_alqssrsm948s) 1**

**[Descripci"n del Negocio](#_7unuhad2i483) 2**

**[Casos de Uso](#_pmibjvi16u8) 3**

[2.1. LOGIN](#_yl8hfdjwfsy) 4

[2.1.1 Ciclo de vida](#_yyfx66mqpppp) 4

[Secuencia de navegaci"n:](#_tx5ik6wps67s) 5

[2.1.2 C"digo](#_inzkb4hfuyzj) 5

[2.2 BACKUP & RESTORE](#_y00nw8mcdzqp) 21

[2.2.1 Backup](#_vp1mabtusp49)

[Frecuencia de BackUp](#_vp1mabtusp49) 22

[2.2.1.1 Ciclo de Vida](#_409ndmqdkdqf) 22

[Secuencia de navegaci"n:](#_yxkvu5z97uq5) 23

[2.2.2 Restore](#_stop5emn0xvu) 28

[2.2.2.1 Ciclo de Vida](#_na99dqsutvt9) 28

[Secuencia de navegaci"n:](#_ax128152zwbc) 29

**[3- D!gito Verificador](#_tpb5gg7xqeva) 33**

[3.1 Ciclo de vida](#_quttzm5m2iey) 33

[Secuencia de navegaci"n:](#_ls5np1tf9xe8) 34

[3.2 C"digo](#_un3e1yko14vg) 35

**[5.1-Validaciones de control](#_act5r7kl0d) 47**

[6.1.2 - CONTROL DE INTEGRIDAD](#_b7lgqdtqxm5) 49

##


1.
## **Descripci"n del Negocio**

**Veterinaria "Cachorros SA",** es una empresa familiar ubicada en Burzaco, con sucursales en Quilmes y Wilde, fundada en 1996 por el doctor Carlos A. Gomez y Juan Pablo Vi$a, quienes actualmente siguen brindando su atenci"n especializada en perros y gatos. El uso de internet se realiza principalmente para expandir m s su mercado, dar a conocer sus servicios y captar nuevos clientes de zonas nuevas zonas geogr ficas.

![](RackMultipart20220914-1-yds0ay_html_10855b7dbdc5ed4b.png)

![](RackMultipart20220914-1-yds0ay_html_ccd693fe0d71881a.png)

![](RackMultipart20220914-1-yds0ay_html_c489b85280235386.png)

![](RackMultipart20220914-1-yds0ay_html_2e48b855211767b.png)

![](RackMultipart20220914-1-yds0ay_html_5c346c55dbe2ecda.png)

1.
## **Casos de Uso**

##


## ![Shape 2](RackMultipart20220914-1-yds0ay_html_adf89e4dcc9b022d.gif) ![Shape 2](RackMultipart20220914-1-yds0ay_html_63ebf2de5b3644bc.gif) ![Shape 2](RackMultipart20220914-1-yds0ay_html_2c3a187ab76ba00f.gif) ![Shape 2](RackMultipart20220914-1-yds0ay_html_6fc1ccf2e0556a8e.gif) ![Shape 2](RackMultipart20220914-1-yds0ay_html_6fc1ccf2e0556a8e.gif) ![Shape 2](RackMultipart20220914-1-yds0ay_html_a94356a9bec23459.gif) ![Shape 2](RackMultipart20220914-1-yds0ay_html_2b44be46c65cced1.gif) ![Shape 2](RackMultipart20220914-1-yds0ay_html_423d18d839da97fe.gif) ![Shape 2](RackMultipart20220914-1-yds0ay_html_b69a0c2f61a8c9bb.gif)

**15**

**1**

**4**

**2 7**

**6**

**6**

**8 12 13 16 17**

**3 5 9 14**

**4 10 11 15**

**2.1. LOGIN**

## **2.1.1 Ciclo de vida**
 ![](RackMultipart20220914-1-yds0ay_html_36e3aff53f67edb6.png)

### **Secuencia de navegaci"n:**

1. El usuario selecciona opci"n de login en la p gina de inicio. (UI)
2. Se hace una redirecci"n a la p gina de login, y el usuario ingresa los datos.(UI)
3. Se verifican los datos ingresados. (BLL)
4. Se procede a encriptar la password ingresada por el usuario. Se env!a la consulta y devuelve los datos del usuario, si los datos son correctos. (DAL) (BE)
5. Se env!a consulta para buscar las acciones del usuario. (BLL)
6. Se devuelven los datos de las acciones del usuario. (DAL) (BE)
7. Se guardan en las variables de sesi"n los datos del usuario. Login.aspx.cs (UI)
8. Se redirecciona a la p gina de Respuesta.aspx. (UI)
9. Se recuperan los datos del usuario de la variable de sesion.(UI)
10. Se env!an los datos a la bit cora de la acci"n realizada por el usuario. (BLL)
11. Se persisten los datos de la bit cora. (DAL) (BE)
12. Se muestra al usuario los datos de tipos de acceso en la pantalla de Respuesta.aspx y si es el administrador adem s se muestra el bot"n de "Bit cora" (UI).
13. El usuario administrador presiona el bot"n "Mostrar Bit cora". (UI)
14. Se env!a consulta para buscar la bit cora. (BLL)
15. Se recuperan los datos de la bit cora. (DAL) (BE)
16. Se carga el objeto Bit cora que alimentara la grilla. (UI)
17. Se muestra por pantalla una grilla, con la bit cora ordenada por fecha, con un filtro para Tipo de Usuario, y con paginado para ver muchos resultados.(UI)

### **2.1.2 C"digo**

**1. Default.aspx (Capa UI):** El usuario selecciona opci"n de login en la p gina de inicio.

![](RackMultipart20220914-1-yds0ay_html_b356a35b328970e2.png)

**Default.aspx**

![](RackMultipart20220914-1-yds0ay_html_657aa3df0fab8e50.png)

**2. Login.aspx (Capa UI):** Se hace una redirecci"n a p gina de login, y el usuario ingresa los datos.

![](RackMultipart20220914-1-yds0ay_html_311aa4ed0165f7ea.png)

**Login.aspx.cs**![](RackMultipart20220914-1-yds0ay_html_a2107d33cce602d5.png)

**3. Verificar\_Usuario (BLL):** Se verifican los datos ingresados. ![](RackMultipart20220914-1-yds0ay_html_dbddad879bd23a32.png)
 ![](RackMultipart20220914-1-yds0ay_html_761b2f7a255a98bd.png)**4. Usuario\_DAL.cs (Capa DAL):** Se procede a encriptar la password ingresada por el usuario. Se env!a la consulta y devuelve los datos del usuario, si los datos son correctos.

![](RackMultipart20220914-1-yds0ay_html_16169161c2ba1d52.png)

![](RackMultipart20220914-1-yds0ay_html_3ce4e940a884a22c.png)

**Acceso\_DAL.cs (Capa DAL):**![](RackMultipart20220914-1-yds0ay_html_a58dc1267809db00.png)

![](RackMultipart20220914-1-yds0ay_html_a58dc1267809db00.png)

**5. Usuario\_BLL (Capa BLL):** Se env!a consulta para buscar las acciones del usuario.

![](RackMultipart20220914-1-yds0ay_html_e5cc8a97396676e2.png)

**Accion.BE.cs (Capa BE):**

![](RackMultipart20220914-1-yds0ay_html_505fb3d3f3aa403f.png)

**6. Usuario\_DAL.cs (Capa DAL**): Se devuelven los datos de las acciones del usuario

![](RackMultipart20220914-1-yds0ay_html_f5bb1dfbcb5c5cf3.png)

**7. Loging.aspx.cs (Capa UI):** Se guardan en las variables de sesi"n los datos del usuario.

![](RackMultipart20220914-1-yds0ay_html_f2aa0490cba614f9.png)

**Usuario\_BE.cs (Capa BE):**

![](RackMultipart20220914-1-yds0ay_html_9111254c2c2c6ab2.png)

**TipoUsuario\_BE.cs (Capa BE):**

![](RackMultipart20220914-1-yds0ay_html_ec85163ecab41767.png)

**8. Respuesta.aspx.cs (Capa UI):** Se redirecciona a la p gina de Respuesta.

![](RackMultipart20220914-1-yds0ay_html_3b4574150194df9e.png)

**9. Respuesta.aspx.cs (Capa UI):** se recuperan los datos del usuario de la variable de sesi"n. ![](RackMultipart20220914-1-yds0ay_html_3b4574150194df9e.png) ![](RackMultipart20220914-1-yds0ay_html_733ce04fc7380174.png)

**10. Usuario\_BLL.cs (Capa BLL):** Se env!an los datos a la bit cora de la acci"n realizada por el usuario.

![](RackMultipart20220914-1-yds0ay_html_6fe51b5c1955939e.png)

**11. Usuario\_DAL.cs(Capa DAL):** Se persisten los datos de la bit cora.
 ![](RackMultipart20220914-1-yds0ay_html_e72deaf3de0adb3a.png)

**12. Respuesta.aspx (Capa UI):** Se muestra al usuario los datos de tipos de acceso en la pantalla y si es el administrador adem s se muestra el bot"n de "Mostrar Bit cora".

![](RackMultipart20220914-1-yds0ay_html_a9746eba6fd7fca5.png)

**Respuesta.aspx**

![](RackMultipart20220914-1-yds0ay_html_726d449259909ae.png)

13. **Respuesta.aspx (Capa UI):** El usuario administrador presiona el bot"n "Mostrar Bit cora".

![](RackMultipart20220914-1-yds0ay_html_3fe8c71c123bb0a9.png)

14. **Usuario\_BLL.cs (Capa BLL):** Se env!a consulta para buscar la bit cora.

![](RackMultipart20220914-1-yds0ay_html_609a6c18efa99911.png)

**15. Usuario\_DAL.cs (Capa DAL):** Se recuperan los datos de la bit cora.

![](RackMultipart20220914-1-yds0ay_html_e039404d860c05ce.png)

**DetalleBitacora\_BE.cs (Capa BE):**

![](RackMultipart20220914-1-yds0ay_html_3212e60544acfc52.png)

**16- Respuesta.ASPX.cs (Capa UI):** Se carga el objeto Bit cora que alimentara a la grilla.

![](RackMultipart20220914-1-yds0ay_html_3b6aef223f2a304a.png)

**17- Respuesta.ASPX (Capa UI):** Se muestra por pantalla una grilla, con la bit cora ordenada por fecha, con un filtro para Tipo de Usuario, calendario para fecha, y con paginado para ver muchos resultados.

![](RackMultipart20220914-1-yds0ay_html_48a410f107d2f16f.png)

**Con un filtro por fecha y cliente:**

![](RackMultipart20220914-1-yds0ay_html_438e9ff1bce2c364.png)

Se utiliz" un calendario para tomar las fechas como filtro, lleva por defecta la fecha actual. Cuando para la fecha seleccionada no hayan registros la grilla no se mostrar .

## **2.2 BACKUP & RESTORE**

## **2.2.1 Backup**

## **2.2.1.1 Ciclo de Vida**

## ![](RackMultipart20220914-1-yds0ay_html_8288426ae67326c9.png)

**Frecuencia del Backup:**

El backup lo realiza el usuario ADMIN, a demanda cada vez que lo considera necesario o lo necesite. Siendo el mismo un backup total de la base de datos.

### **Secuencia de navegaci"n:**

1. Como precondici"n se debe realizar el Login (2.1) con usuario webmaster (ADMIN).
2. Una vez realizado el Login e ingresado en la pantalla principal se presiona el bot"n de Backup & Restore, esto nos redireccionar  a la interfaz correspondiente: BackupRestore.aspx. ( Capa UI)
3. Se debe ingresar un nombre de archivo dentro del Textbox ( Capa UI)
4. Para finalizar la acci"n se pulsa sobre el bot"n "Realizar" (Capa UI)
5. Se env!an los datos a la acci"n correspondiente del usuario para la realizaci"n del Backup (Capa BLL)
6. Se procede a realizar el respaldo correspondiente de los datos (Capa DAL). Se retorna a la pantalla de BackupRestore.aspx

**2.2.1.2 C"digo**

**Respuesta.aspx [Dise$o]**

![](RackMultipart20220914-1-yds0ay_html_690dc2d6b501b912.png)

**BackupRestore.aspx [Dise$o]**

![](RackMultipart20220914-1-yds0ay_html_4cd806f9ebf34c14.png)

**Respuesta.aspx.cs (Capa BLL):**

![](RackMultipart20220914-1-yds0ay_html_632e277b34c1e6.png)

**BackupRestore.aspx.cs (Capa BLL):**

![](RackMultipart20220914-1-yds0ay_html_91ffb825044c59d6.png)

![](RackMultipart20220914-1-yds0ay_html_699bd2e65e54f6a8.png)

3.Se debe ingresar un nombre de archivo dentro del Textbox (UI), el cual ser  el nombre que se le asigne al Backup.

![](RackMultipart20220914-1-yds0ay_html_2ed154471fd17cd7.png)

4. Para finalizar la acci"n se pulsa sobre el bot"n "Realizar" (Capa UI)

5. Se env!an los datos a la acci"n correspondiente del usuario para la realizaci"n del Backup (Capa BLL).

Tambn tenemos un bot"n "Volver", que nos regresa al men# de "Respuesta.aspx" donde tenemos las acciones del administrador si est  logueado.

**Usuario\_BLL.cs**

![](RackMultipart20220914-1-yds0ay_html_80aa5ce1b6dcc0c6.png)

All! se genera el nombre de la ruta donde se dejar  el archivo .bak. Adem s de concatenar el nombre del mismo. La ruta por defecto es:\lppa-tp-main-V"_n#mero de versi"n del aplicativo final_"\Trabajo Practico LPPA\Backups\"_nombre ingresado_".

**Usuario\_DAL.cs**![](RackMultipart20220914-1-yds0ay_html_4ed2b4588a4a58f0.png)

6. Se procede a realizar el respaldo correspondiente de los datos (Capa DAL). Se retorna a la pantalla de BackupRestore.aspx (Capa UI)

![](RackMultipart20220914-1-yds0ay_html_b94e1a75803e3563.png)

### **2.2.2 Restore**

### **2.2.2.1 Ciclo de Vida**

### ![](RackMultipart20220914-1-yds0ay_html_8288426ae67326c9.png)

### **Secuencia de navegaci"n:**

1. Como precondici"n se debe realizar el Login (2.1) con usuario webmaster (ADMIN).
2. Una vez realizado el Login e ingresado en la pantalla principal se presiona el bot"n de Backup & Restore, esto nos redireccionar  a la interfaz correspondiente: BackupRestore.aspx. (UI)
3. Se debe seleccionar el archivo correspondiente al Restore que se desea realizar (UI)
4. Para finalizar la acci"n se pulsa sobre el bot"n "Realizar" (UI)
5. Se env!an los datos a la acci"n correspondiente del usuario para la realizaci"n del Restore (BLL)
6. Se procede a realizar el Restore correspondiente de los datos (DAL). Se retorna a la pantalla de BackupRestore.aspx

**2.2.2.2 C"digo:**

**Respuesta.aspx [Dise$o]**

![](RackMultipart20220914-1-yds0ay_html_690dc2d6b501b912.png)

2. Como precondici"n se debe realizar el Login (2.1) con usuario webmaster (ADMIN).

3. Una vez realizado el Login e ingresado en la pantalla principal se presiona el bot"n de Backup & Restore, esto nos redireccionar  a la interfaz correspondiente: BackupRestore.aspx. (Capa UI)

**BackupRestore.apsx**

![](RackMultipart20220914-1-yds0ay_html_f1c286e5830a4ed3.png)

4. Se debe seleccionar el archivo correspondiente al Restore que se desea realizar (Capa UI).

5. Para finalizar la acci"n se pulsa sobre el bot"n "Realizar" (UI) **BackupRestore.apsx**

En la siguiente imagen se ven los pasos I y II en el c"digo, as! desde la l!nea 52 hasta la 63 (paso I), se recuperan los archivos .bak para el Restore. Y luego desde la l!nea 69 a 78 se validan y ejecutan los pasos del restore (paso II). **BackupRestore.apsx.cs.**

Se pasa el flujo del programa a **Usuario\_BLL.cs** donde se invoca al todo "RestoreDB", que recibe la ruta que construimos antes, y de ah! se continua el flujo **Usuario\_DAL.cs,** quien finalmente, ejecuta el c"digo de la base que restituye el backup.

![](RackMultipart20220914-1-yds0ay_html_b61a8e08c8b6842.png)

**Usuario\_BLL.cs**

![](RackMultipart20220914-1-yds0ay_html_5530f91636d2a0ca.png)

**Usuario\_DAL.cs**

![](RackMultipart20220914-1-yds0ay_html_245cd29819d43a4.png)

6. Una vez realizado correctamente el Restore, se informa por pantalla y se devuelve el flujo a la pantalla de **BackupRestore.aspx** (UI).

![](RackMultipart20220914-1-yds0ay_html_72413069cc2d51cb.png)

## **3- D!gito Verificador**

### **3.1 Ciclo de vida**

![](RackMultipart20220914-1-yds0ay_html_77668decb778f008.png)

### **Secuencia de navegaci"n:**

1. Inicia en el todo Page\_Load comprobando la integridad digito verificador horizontal y luego hace el del vertical. Si hay tablas con errores se guarda registro de la misma tanto para horizontal como vertical, estos datos luego se mostrar n por pantalla. (UI)
2. Se obtienen las tablas con errores de verificaci"n DVH y las DVV. ( **Integridad\_BLL.cs** ).
3. Se recalculan los valores de los DVH (paso 6) de cada registro (paso 5) de tablas que tienen d!gitos verificadores (paso 4). En caso de encontrarse un registro corrompido, se agrega a una lista de registros para luego mostrar en pantalla. ( **Integridad\_DAL.cs** )
4. Se obtienen desde la base de datos todas las tablas que tienen d!gitos verificadores. Se guardan en objetos del tipo DigitoVerificador\_BE tanto el nombre de la tabla como el DVV (se usa en la verificaci"n del DVV, no del DVH). ( **Integridad\_DAL.cs** )
5. Se leen todos los registros de la tabla enviada como par metro y se guardan como una lista de objetos Registro\_BE. Cada Registro\_BE guarda el id del registro (para luego mostrar por pantalla si el registro est  comprometido), un string tiene concatenados todos los campos del registro con el DVH separado por el car cter ';', y el nombre de la tabla. ( **Integridad\_DAL.cs** )
6. Se calcula el valor del DVH del registro a partir de la codificaci"n ASCII de todos los campos del registro concatenados, multiplicando este valor por el peso que tienen en la cadena. Esta funci"n se utiliza tanto para guardar nuevos DVH como para el rec lculo en la verificaci"n de integridad. ( **Integridad\_DAL.cs** )
7. Se realiza la verificaci"n de integridad de la base de datos respecto al d!gito verificador vertical. (UI)
8. Se obtienen las tablas con errores de digito verificador vertical. ( **Integridad\_BLL.cs** )
9. Se recalculan los valores de los DVV (paso 11) de cada tabla que tiene d!gito verificador (paso 10). En caso de encontrarse una tabla corrompida, se agrega a una lista de registros (cuyo id es DVV) para luego mostrar en pantalla. ( **Integridad\_DAL.cs** )
10. Se obtienen desde la base de datos todas las tablas que tienen d!gitos verificadores. Se guardan en objetos del tipo DigitoVerificador\_BE tanto el nombre de la tabla como el DVV (se usa en la verificaci"n del DVV, no del DVH). ( **Integridad\_DAL.cs** )
11. Se calcula el DVV para la tabla como la suma total de todos los DVH de cada registro de la tabla. ( **Integridad\_DAL.cs** )
12. En caso de encontrarse errores con errores de DVH, DVV o ambos, se redirige a la p gina de error de integridad (UI).
13. Finalmente se imprime por pantalla una lista con las tablas comprometidas y los id de los registros que fallaron en la comprobaci"n de DVH. En caso de error de DVV, se imprime 'DVV' en lugar del ID del registro (UI)

### **3.2 C"digo**

**Default.aspx.cs**

1.Se realiza la verificacion de integridad de la base de datos respecto al digito verificador horizontal (l!nea 14)

7.Se realiza la verificacion de integridad de la base de datos respecto al d!gito verificador vertical (l!nea 16)

12.En caso de encontrarse errores con errores de DVH, DVV o ambos, se redirige a la p gina de error de integridad (l!nea 25)

![](RackMultipart20220914-1-yds0ay_html_51511051bb2e19c.png)

**Integridad\_BLL.cs**

2.Se obtienen las tablas con errores de digito verificador horizontal (linea 29)

8.Se obtienen las tablas con errores de digito verificador vertical (linea 37)

![](RackMultipart20220914-1-yds0ay_html_49b25709d11ccb5.png)

**Integridad\_DAL.cs**

3.Se recalculan los valores de los DVH (paso 6) de cada registro (paso 5) de tablas que tienen d!gitos verificadores (paso 4) (l!nea 73). En caso de encontrarse un registro corrompido, se agrega a una lista de registros para luego mostrar en pantalla.

4.Se obtienen desde la base de datos todas las tablas que tienen d!gitos verificadores (l!nea 166). Se guardan en objetos del tipo DigitoVerificador\_BE tanto el nombre de la tabla como el DVV (se usa en la verificaci"n del DVV, no del DVH)

5.Se leen todos los registros de la tabla enviada como par metro y se guardan como una lista de objetos Registro\_BE (l!nea 185). Cada Registro\_BE guarda el id del registro (para luego mostrar por pantalla si el registro est  comprometido), un string tiene concatenados todos los campos del registro con el DVH separado por el car cter ';', y el nombre de la tabla.

6.Se calcula el valor del DVH del registro a partir de la codificaci"n ASCII de todos los campos del registro concatenados, multiplicando este valor por el peso que tienen en la cadena (l!nea 14). Esta funci"n se utiliza tanto para guardar nuevos DVH como para el rec lculo en la verificaci"n de integridad.

9.Se recalculan los valores de los DVV (paso 11) de cada tabla que tiene d!gito verificador (paso 10) (l!nea 93). En caso de encontrarse una tabla corrompida, se agrega a una lista de registros (cuyo id es DVV) para luego mostrar en pantalla.

10.Se obtienen desde la base de datos todas las tablas que tienen d!gitos verificadores (l!nea 166). Se guardan en objetos del tipo DigitoVerificador\_BE tanto el nombre de la tabla como el DVV (se usa en la verificaci"n del DVV, no del DVH)

11.Se calcula el DVV para la tabla como la suma total de todos los DVH de cada registro de la tabla (l!nea 25)

![](RackMultipart20220914-1-yds0ay_html_e585f543989ba1c0.png)

![](RackMultipart20220914-1-yds0ay_html_6f9f31624d522776.png)

![](RackMultipart20220914-1-yds0ay_html_be6744be270d57a7.png)

![](RackMultipart20220914-1-yds0ay_html_6f181265906a8956.png)

![](RackMultipart20220914-1-yds0ay_html_795371dddc365173.png)

![](RackMultipart20220914-1-yds0ay_html_fad09808f48d82fc.png)

**Registro\_BE.cs**

![](RackMultipart20220914-1-yds0ay_html_15db46a547a2f846.png)

**DigitoVerificador\_BE.cs**

![](RackMultipart20220914-1-yds0ay_html_e05733fc68ed9657.png)

**FalloIntegridad.aspx.cs**

13.Finalmente se imprime por pantalla una lista con las tablas comprometidas y los id de los registros que fallaron en la comprobaci"n de DVH. En caso de error de DVV, se imprime 'DVV' en lugar del ID del registro.

![](RackMultipart20220914-1-yds0ay_html_4ec977778088695b.png)

**4**

## **.**
 **1 C"digo de Store Procedures**

**SP blanquear\_password**

CREATE procedure [dbo].[blanquear\_password]

@usu varchar(100)

as

begin

UPDATE dbo.Usuario SET bloqueado = 0 where usuario = @usu

end

select u.id as id, u.usuario as usuario, u.contrase$a as contrase$a, u.nombre as nombre, u.bloqueado as bloqueado, u.id\_tipo\_usuario as tipo\_usuario From Usuario u where usuario = @usu

GO

**SP bloquear\_usuario**

CREATE procedure [dbo].[bloquear\_usuario]

@usu varchar(100)

as

begin

UPDATE dbo.Usuario SET bloqueado = bloqueado + 1 where usuario = @usu

end

select u.id as id, u.usuario as usuario, u.contrase$a as contrase$a, u.nombre as nombre, u.bloqueado as bloqueado, u.id\_tipo\_usuario as tipo\_usuario From Usuario u where usuario = @usu

GO

**SP borrar\_digito\_verificador**

CREATE procedure [dbo].[borrar\_digito\_verificador]

@tabla varchar(100), @dvv varchar(500)

as

begin

declare @id int

set @id = isnull((Select max(ID\_Digito\_Verificador) from Digito\_Verificador),0 ) +1

DELETE [dbo].[Digito\_Verificador] WHERE Tabla = @tabla

end

GO

**SP desbloquear\_usuario**

CREATE procedure [dbo].[desbloquear\_usuario]

@usu varchar(100)

as

begin

UPDATE Usuario

SET bloqueado = 0

WHERE usuario = @usu;

end

select u.id as id, u.usuario as usuario, u.contrase$a as contrase$a, u.nombre as nombre, u.bloqueado as bloqueado, u.id\_tipo\_usuario as tipo\_usuario From Usuario u where usuario = @usu

GO

**SP listar\_acciones**

Create procedure [dbo].[listar\_acciones]

@id\_tipo\_usu varchar(50)

as

begin

select b.id, b.detalle

from TipoUsuario\_Accion a

inner join Accion b

on a.id\_accion= b.id

where a.id\_tipousuario = @id\_tipo\_usu

end

GO

**SP listar\_bitacora**

CREATE procedure [dbo].[listar\_bitacora]

as

begin

select a.\*, b.nombre, b.usuario

from Bitacora a

inner join Usuario b

on a.id\_usuario = b.id

ORDER BY a.fecha DESC

end

GO

**SP listar\_usuariosBloqueados**

Create procedure [dbo].[listar\_usuariosBloqueados]

as

begin

select \*

from Usuario

where bloqueado = 3

end

GO

**SP llenar\_bitacora**

CREATE procedure [dbo].[llenar\_bitacora]

@id\_usu varchar(100), @detalle varchar(500)

as

begin

declare @id int

declare @fecha datetime

set @id = isnull((Select max(id) from Bitacora),0 ) +1

INSERT INTO [dbo].[Bitacora]

([id]

,[detalle]

,[fecha]

,[id\_usuario])

VALUES

(@id,

@detalle,

FORMAT(SYSDATETIME(), 'dd/MM/yyyy hh:mm:ss', 'en-gb'),

@id\_usu)

end

select @id as id, @detalle as detalle, SYSDATETIME() as fecha, @id\_usu as id\_usu

GO

**SP llenar\_digito\_verificador**

CREATE procedure [dbo].[llenar\_digito\_verificador]

@tabla varchar(100), @dvv varchar(500)

as

begin

declare @id int

set @id = isnull((Select max(ID\_Digito\_Verificador) from Digito\_Verificador),0 ) +1

INSERT INTO [dbo].[Digito\_Verificador]

([ID\_Digito\_Verificador]

,[Tabla]

,[DVV])

VALUES

(@id,

@tabla,

@dvv)

end

GO

**SP modificar\_digito\_verificador**

CREATE procedure [dbo].[modificar\_digito\_verificador]

@tabla varchar(100), @dvv varchar(500)

as

begin

declare @id int

set @id = isnull((Select max(ID\_Digito\_Verificador) from Digito\_Verificador),0 ) +1

UPDATE [dbo].[Digito\_Verificador] SET DVV = @dvv WHERE Tabla = @tabla

end

GO

**SP update\_bitacora\_dvh**

CREATE procedure [dbo].[update\_bitacora\_dvh]

@id varchar(100), @dvh varchar(500)

as

begin

UPDATE [dbo].[Bitacora] SET dvh = @dvh WHERE id = @id

end

GO

**SP update\_usuario\_dvh**

CREATE procedure [dbo].[update\_usuario\_dvh]

@id varchar(100), @dvh varchar(500)

as

begin

UPDATE [dbo].[Usuario] SET dvh = @dvh WHERE id = @id

end

GO

**SP verificar\_usuario**

CREATE procedure [dbo].[verificar\_usuario]

@usu varchar(100), @pass varchar(100)

as

begin

select a.id, a.nombre, a.usuario, a.contrase$a, a.id\_tipo\_usuario, b.tipo\_usuario

from Usuario a

inner join Tipo\_Usuario b

on a.id\_tipo\_usuario = b.id

where a.usuario = @usu and a.contrase$a = @pass

end

GO

**SP verificar\_usuario\_sinpassword**

CREATE procedure [dbo].[verificar\_usuario\_sinpassword]

@usu varchar(100)

as

begin

select a.id, a.nombre, a.usuario, a.contrase$a, a.id\_tipo\_usuario,a.bloqueado, b.tipo\_usuario

from Usuario a

inner join Tipo\_Usuario b

on a.id\_tipo\_usuario = b.id

where a.usuario = @usu

end

GO

## **5.1-Validaciones de control**

Se realizan validaciones sobre los controles "Usuario" y "Contrase$a" donde se solicitan que ambos esn completos para poder acceder a los todos.\<RequiredFieldValidator\>. Como tambn, si se ingresan valores que no corresponden. Se le agrega una "regexp", [a-zA-Z]{6}\w\*\d{2}\W{1}, para validar 6 letras, 2 d!gitos y 1 car cter especial, al campo de contrase$a. Se muestra un mensaje gerico "Usuario o contrase$a Incorrectos" en caso de no cumplir.

![](RackMultipart20220914-1-yds0ay_html_f3731ed11643365b.png)

A continuaci"n se valida la pass ingresada, esto es mediante una funci"n de encriptaci"n, que utiliza el algoritmo Message-Digest Algorithm 5 (MD5). Para luego comparar su hash con el que se encuentra almacenado en la base. Utilizamos la librer!a System.Security.Cryptography.MD5

En el caso que el usuario ingrese incorrectamente la contrase$a 3 veces, la misma ser  bloqueada

![](RackMultipart20220914-1-yds0ay_html_68f135acb59319a7.png)

El desbloqueo le ser  solicitado al usuario ADMIN quien tendr  la funcionalidad para realizar la operaci"n:

**Respuesta.aspx**

![](RackMultipart20220914-1-yds0ay_html_dd216aad85e03b94.png)

En esta pantalla el usuario ADMIN #nicamente, podr  desbloquear a los usuarios que aparezcan en la lista de bloqueados. Deber  seleccionarlos y presionar el bot"n desbloquear. Cuando la lista es vac!a significa que no hay usuarios bloqueados.

![](RackMultipart20220914-1-yds0ay_html_4e40f2490d6cd689.png)

## **6.1.2 - CONTROL DE INTEGRIDAD**

Se realiza un control de integridad para validar que la base de datos no haya sido corrompida, y en caso de serlo se informa por pantalla al iniciar el aplicativo y no dejar  operar el sistema.

**5.1.3 ESTRATEGIAS DE PROGRAMACI`N**

El dise$o se realiz" en 4 capas:

- UI: Capa de interfaz de usuario
- BLL: Capa de entidad de l"gica de negocio
- DAL Capa de acceso a datos
- BE: Capa de entidades del negocio

La conexi"n realizada mediante la DAL a la base de datos es ADO.desconectado.

**5.1.4 CONTROL DE ACCESO POR URL**

Se realiza un control por el cual no se puede acceder de forma manual ingresando la direcciones de las url en el navegador. Esto es mediante validaci"n de permisos necesarios, es decir que quien no tenga permisos no podr  acceder a los recursos que no le corresponda, por ejemplo, un usuario no logueado o del tipo cliente no podr  acceder a la p gina del BackUp and Restore, "http://localhost:51036/BackupRestore.aspx".

![](RackMultipart20220914-1-yds0ay_html_60c328522b398a66.png)

Mediante el uso el de variables de Session, se verifica si el usuario est  logueado, adem s si tiene permisos para ver el recurso.

**5.1.5 AdRotators:**

Se incorpor" una adrotator en la secci"n de login, donde se agrega publicidad de productos que vendemos:

![](RackMultipart20220914-1-yds0ay_html_8b5797a1142ffddf.png)

Adem s de incorporar una galer!a de marcas que trabajan con nosotros.

![](RackMultipart20220914-1-yds0ay_html_2e48b855211767b.png)tnimtmmi
